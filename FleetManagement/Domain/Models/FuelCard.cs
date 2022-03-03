using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FuelCard
    {
        #region Properties
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public int PinCode { get; set; }
        public User User { get; set; }
        public ICollection<FuelCardFuel> Fuels { get; set; }

        #endregion

        #region Constructor
        public FuelCard(int id, string cardNumber, int pinCode, User user, ICollection<FuelCardFuel> fuels)
        {
            Id = id;
            CardNumber = cardNumber;
            PinCode = pinCode;
            User = user;
            Fuels = fuels;
        }

        public FuelCard(int id, string cardNumber, int pinCode)
        {
            Id = id;
            CardNumber = cardNumber;
            PinCode = pinCode;
        }
        #endregion
    }
}
