using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T value);
        void Remove(T value);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(int id);
        Task<T> UpdateAsync(T value);
    }
}
