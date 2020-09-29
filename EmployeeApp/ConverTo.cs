using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Helper
{
    class ConvertTo
    {
        private static Random rnd = new Random();
        private string firstName; 
        private string lastName;

        private static string[] domainName =
        {
            "hotmail", "gmail", "yahoo", "freemail", "company"
        }; 

        private static string[] extension =
        {
            "com", "net", "eu", "hu", "uk"
        };

        private string countryCode; 
        private string providerCode; 
        private string firstPart; 
        private string secondPart;

        private ConvertTo() { }

        private static string generateDomainNames()
        {
            return domainName[rnd.Next(domainName.Length)];
        }

        private static string generateExtensions()
        {
            return extension[rnd.Next(extension.Length)];
        }

        public static string email(string firstName, string lastName)
        {
            ConvertTo email = new ConvertTo(); 
            email.firstName = firstName; 
            email.lastName = lastName;

            return $"{email.firstName.ToLower()}.{email.lastName.ToLower()}@{generateDomainNames()}.{generateExtensions()}";
        }

        public static string phone(string phoneNumber)
        {
            ConvertTo pNumber = new ConvertTo(); 
            pNumber.countryCode = phoneNumber.Substring(0, 2); 
            pNumber.providerCode = phoneNumber.Substring(2, 2); 
            pNumber.firstPart = phoneNumber.Substring(4, 3); 
            pNumber.secondPart = phoneNumber.Substring(7, 3);

            return $"{pNumber.countryCode}/{pNumber.providerCode} {pNumber.firstPart}{pNumber.secondPart}";
        }
    }
}