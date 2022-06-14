using Domain.Models.Enums;
using System;
using System.Collections.Generic;

namespace Presentation.DTO
{
    public class FuelCardDto
    {
        public int Id { get; set; }
        public long CardNumber { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int PinCode { get; set; }
        public ICollection<FuelType> UsableFuelTypes { get; set; } = new List<FuelType>();

        public PersonDto? Person { get; set; }

        public bool Blocked { get; set; }
    }
}
