namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T value);

        Task RemoveAsync(T value);

        Task<IEnumerable<T>> GetAllAsync();

        IAsyncEnumerable<T> GetAllStream();

        Task<T> FindAsync(int id);

        Task UpdateAsync(T value);

    }
}
