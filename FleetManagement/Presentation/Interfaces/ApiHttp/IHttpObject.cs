using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces.ApiHttp
{
    public interface IHttpObject<T>
    {
        Task<T> CreateAsync(T obj);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IAsyncEnumerable<T> GetAllStream();
        Task<T> GetAsync(int id);
        Task UpdateAsync(T obj);
    }
}
