using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Repositories
{
    public interface IRepository<T>
    {
            IEnumerable<T> GetAll();
            Task<T> GetByIdAsync(int id);

            Task<T> AddAsync(T item);
    }
}
