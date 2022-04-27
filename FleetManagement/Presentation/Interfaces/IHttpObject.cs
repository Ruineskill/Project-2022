using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public  interface IHttpObject<T>
    {
        Task<T> CreateAsync(T obj);
        void DeleteAsync(T obj);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> UpdateAsync(T obj);
    }
}
