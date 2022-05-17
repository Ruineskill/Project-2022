namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<bool> AddAsync(T value);

        bool Remove(T value);

        Task<IEnumerable<T>> GetAllAsync();

        IAsyncEnumerable<T> GetAllStream();

        Task<T> FindAsync(int id);

        Task<bool> UpdateAsync(T value);

    }
}
