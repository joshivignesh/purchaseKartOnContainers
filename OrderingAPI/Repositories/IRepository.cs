using System.Threading.Tasks;

namespace OrderAPI.Repositories
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T item);

        Task<T> UpdateAsync(int id, T item);

        Task<T> DeleteAsync(int id);
    }
}
