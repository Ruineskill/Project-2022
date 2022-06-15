using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Validation
{
    public class ValidatorBase
    {
        public string? Message { get; set; }
        public Queue<string> ReValidation { get; set; } = new Queue<string>();

        public bool Result(bool result, string? msg = null)
        {
            Message = msg;
            return result;
        }

        public static bool IsEmptyOrNull(string text)
        {
            return string.IsNullOrEmpty(text);
        }

        public static bool IsNumericOnly(string text)
        {
            if(IsEmptyOrNull(text)) return false;
            return text.All(char.IsNumber);
        }

        public static bool IsLetterOnly(string text)
        {
            if(IsEmptyOrNull(text)) return false;
            return text.All(c=>char.IsWhiteSpace(c) || char.IsLetter(c));
        }

        public static bool IsLetterOrDigit(string text)
        {
            if(IsEmptyOrNull(text)) return false;
            return text.All(c => char.IsWhiteSpace(c) || char.IsLetter(c) || char.IsDigit(c));
        }

        public void ReValidateProperty(string propertyName)
        {
            ReValidation.Enqueue(propertyName);
         
        }
    }
}
