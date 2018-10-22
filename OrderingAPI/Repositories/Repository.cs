using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;
using System;
using System.Threading.Tasks;

namespace OrderAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly OrdersContext db;
        private readonly DbSet<T> entities;
        public Repository(OrdersContext gc)
        {
            this.db = gc;
            this.entities = gc.Set<T>();
        }
        public async Task<T> AddAsync(T item)
        {
            this.entities.Add(item);
            await db.SaveChangesAsync();
            return item;
        }

        public Task<T> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(int id, T item)
        {
            throw new NotImplementedException();
        }
    }
}
