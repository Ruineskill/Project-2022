using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.DTO
{
    public class AddressDto
    {
        public string Street { get; set; } = string.Empty;

        public int Number { get; set; }

        public string City { get; set; } = string.Empty;

        public int ZipCode { get; set; }

    }
}
