#nullable disable warnings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Mediators
{
    public class MediatorBase<T>
    {
        public event Action<T> Created;
        public event Action<T> Updated;
        public event Action<T> Deleted;

        public void Create(T obj)
        {
            Created?.Invoke(obj);
        }

        public void Update(T obj)
        {
            Updated?.Invoke(obj);
        }

        public void Delete(T obj)
        {
            Deleted?.Invoke(obj);
        }
    }
}
