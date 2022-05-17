using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public  interface IHttpObject<T>
    {
        Task<bool> CreateAsync(T obj);
        Task<bool>  DeleteAsync(T obj);
        Task<IEnumerable<T>> GetAllAsync();
        IAsyncEnumerable<T> GetAllStream();
        Task<T> GetAsync(int id);
        Task<bool> UpdateAsync(T obj);
    }
}
