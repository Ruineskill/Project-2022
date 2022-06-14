#nullable disable warnings
using Presentation.DTO;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class AddressViewModel : ViewModelBase
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }



        public static implicit operator AddressDto(AddressViewModel cwd)
        {
            return new AddressDto
            {
                Street = cwd.Street,
                Number = cwd.Number,
                City = cwd.City,
                ZipCode = cwd.ZipCode,
            };
        }
        public static implicit operator AddressViewModel(AddressDto cdt)
        {
            return new AddressViewModel
            {
                Street = cdt.Street,
                Number = cdt.Number,
                City = cdt.City,
                ZipCode = cdt.ZipCode,
            };
        }

    }
}
