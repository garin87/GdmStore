using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.Services
{
    public interface IBaseServices<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetItem(long id);
        Task<T> DeleteItem(long id);
        Task<T> AddItem(T t);
    }
}
