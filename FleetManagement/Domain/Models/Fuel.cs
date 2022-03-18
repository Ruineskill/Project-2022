using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Fuel
    {
        #region Properties
        public int Id { get;  set; }
        public string Type { get;  set; }
        public ICollection<FuelCardFuel> FuelCards { get;  set; }
        #endregion

        #region Constructor
        public Fuel(int id, string type, ICollection<FuelCardFuel> fuelCards)
        {
            Id = id;
            Type = type;
            FuelCards = fuelCards;
        }
        public Fuel(int id, string type)
        {
            Id = id;
            Type = type;
        }

        #endregion
    }
}
