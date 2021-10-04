using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace IBANvalidator.Services
{
    public class IbanValidationService
    {
        private static string _bankAccountNumber { get; set; }
        private static Dictionary<string, dynamic> _bankData { get; set; }
        private static string _bankCode { get; set; }
        private bool _isCheckingBankCode { get; set; }
        private static bool _isValid { get; set; }

        public string BankAccountNumber
        {
            get => _bankAccountNumber;
            set => _bankAccountNumber = value;
        }

        private static Dictionary<string, dynamic> BankData
        {
            get => _bankData;
            set => _bankData = value;
        }
        
        public bool IsCheckingBankCode
        {
            get => _isCheckingBankCode;
            set => _isCheckingBankCode = value;
        }

        public IbanValidationService()
        {
            _bankData           = new Dictionary<string, dynamic>();
            _bankCode           = null;
            _isCheckingBankCode = false;
            _isValid            = false;
        }

        public static void Validate()
        {
            _isValid = false;
            
            //TODO: validation here
            BankData.Add("name", "Test bank");
        }

        public static Dictionary<string, dynamic> GenerateResult()
        {
            //TODO: load real message after process is done

            var result = new Dictionary<string, dynamic>
            {
                {"status", "Ok"}, 
                {"message", "Validator in progress"}, 
                {"iban", _bankAccountNumber}, 
                {"valid", _isValid}, 
                {"bic", _bankCode},
                {"bankData", _bankData}
            };


            return result;
        }
    }
}
