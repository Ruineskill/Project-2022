#nullable disable warnings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;
using Presentation.Interfaces.Listing;

namespace Presentation.Validation.PersonRules
{
    public class NationalIDRule : ValidationRule, IDisposable
    {
        private readonly IPersonListingService _persons;

        private string? _initialId;

        public NationalIDRule()
        {
            _persons = App.GetService<IPersonListingService>();
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var result = value?.ToString();
                if(string.IsNullOrWhiteSpace(result))
                {
                    return new ValidationResult(false, "Required field");
                }
                
                if(_initialId == null) _initialId = result;

                if(!IsValidNationalRegistrationNumber(result)) return new ValidationResult(false, "Invalid number format");



                if(_initialId != result)
                {
                    if(_persons.ContainsNationalId(result)) return new ValidationResult(false, "Person with this ID already exists");

                }

               

            }
            catch(Exception)
            {
 
                return new ValidationResult(false, "Invalid number");
               
            }

    
            return ValidationResult.ValidResult;
        }

        public static bool IsValidNationalRegistrationNumber(string nrn)
        {
            //Last 2 digits of NationRegistration Number
            var nrnChecksum = Convert.ToInt64(nrn.Substring(9, 2));

            //First 9 digits to calculate
            var partToCalculate = nrn.Substring(0, 9);

            //Calculation
            var checksum = 97 - (Convert.ToInt64(partToCalculate) % 97);

            //Compare if equals return true
            if(nrnChecksum == checksum) return true;

            //// Checksum not yet ok. We check for a possible 1900/2000 situation;

            // we repeat the same test but now with the extra '2' added to the part
            partToCalculate = "2" + partToCalculate;

            // we calculate the expected checksum. again
            checksum = 97 - (Convert.ToInt64(partToCalculate) % 97);

            // we compare the excisting checksum with the calculated, again
            if(nrnChecksum == checksum)
            {
                // we have a good checksum. Person born between 2000 and now
                return true;
            }
            else
            {
                // invalid number, even after 2000 check
                return false;
            }
        }

        public void Dispose()
        {
            _initialId= null;
           
        }
    }
}
