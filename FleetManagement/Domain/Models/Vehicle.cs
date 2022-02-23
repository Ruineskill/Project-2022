using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Vehicle
    {
        #region Properties
        public int Id { get; set; }
        public string Branch { get; set; }
        public string Model { get; set; }
        public string Chassisnummer { get; set; }
        public string Nummerplaat { get; set; }

        #endregion
    }
}
