using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Helpers
{
    public class ValidationHelpers
    {
        public static void ValidateString(string stringToCheck,string valueString) 
        {
            if (stringToCheck.Length < 5 || stringToCheck.Length > 30 || string.IsNullOrWhiteSpace(stringToCheck))
            {
                throw new ArgumentException($"{valueString} must be between 5 and 30 characters long.");
            }
        }
    }
}
