using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Helpers
{
    public class ValidationHelpers
    {
        public static void ValidateString(string stringToCheck, string valueString)
        {
            if (string.IsNullOrWhiteSpace(stringToCheck) || stringToCheck.Length < 5 || stringToCheck.Length > 30)
            {
                throw new ArgumentException($"{valueString} must be non-empty string, with length between 5 and 30.");
            }
        }
    }
}
