using CatalogAPI.Infrastructure;
using CatalogAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Repositories
{
    public class Repository<T>: IRepository<T> where T : EntityBase
    {
        private readonly CatalogContext db;
        private readonly DbSet<T> entities;

        public Repository(CatalogContext gc)
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
        public IEnumerable<T> GetAll()
        {
            return this.entities.ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.entities.FindAsync(id);
        }

        
    }
}
