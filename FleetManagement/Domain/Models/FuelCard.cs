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
    }
}
