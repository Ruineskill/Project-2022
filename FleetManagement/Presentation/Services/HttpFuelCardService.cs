using Domain.Models;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class HttpFuelCardService : IHttpFuelCardService
    {
        public Task<FuelCard> CreateAsync(FuelCard obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(FuelCard obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FuelCard>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FuelCard> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FuelCard> UpdateAsync(FuelCard obj)
        {
            throw new NotImplementedException();
        }
    }
}
