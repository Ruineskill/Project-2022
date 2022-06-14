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
        public event Action<T> OnCreated;
        public event Action<T> OnUpdated;
        public event Action<T> OnDeleted;

        public void Create(T obj)
        {
            OnCreated?.Invoke(obj);
        }

        public void Update(T obj)
        {
            OnUpdated?.Invoke(obj);
        }

        public void Delete(T obj)
        {
            OnDeleted?.Invoke(obj);
        }
    }
}
