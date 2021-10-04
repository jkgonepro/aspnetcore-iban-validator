using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IBANvalidator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IBANvalidator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidatorController : ControllerBase
    {
        private readonly ILogger<ValidatorController> _logger;
        
        public class Input
        {
            public string Iban { get; set; }
            public string IsCheckingBic { get; set; }
        }

        public ValidatorController(ILogger<ValidatorController> logger)
        {
            _logger  = logger;
        }
        
        [HttpGet]
        public Dictionary<string, dynamic> Get()
        {
            var baseUrl = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host;
            var endpointData = new Dictionary<string, dynamic>
            {
                {"status", "error"},
                {"message", HttpStatusCode.MethodNotAllowed + ". Please read: " + baseUrl + "/documentation"}
            };

            return endpointData;
        }

        [HttpPost]
        public Dictionary<string, dynamic> Run(string iban, bool isBicValidated) //[FromBody] Input data
        {
            IbanValidationService service = new IbanValidationService();
            
            service.BankAccountNumber  = iban;
            service.IsCheckingBankCode = isBicValidated;

            IbanValidationService.Validate();
            return IbanValidationService.GenerateResult();
            
            //string contentType = "application/json";
            //var httpClient = new HttpClient();
            //HttpContent httpContent = new StringContent("Test", Encoding.UTF32, contentType);
            //var response = httpClient.PostAsync(ingestPath, httpContent);
        }
    }
}
