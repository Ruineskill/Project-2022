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
        public string Name { get; set; }
        public ICollection<Fuel> Fuels { get; set; }

        #endregion
    }
}
