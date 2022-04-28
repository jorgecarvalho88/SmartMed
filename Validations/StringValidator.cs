using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validations
{
    public static class StringValidator
    {
        public static string? ValidateIsNullOrWhiteSpace(string? value, string? property)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return property + ": Required Field";
            }

            return null;
        }
    }
}
