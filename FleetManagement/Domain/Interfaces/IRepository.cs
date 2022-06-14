namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T value);

        void Remove(T value);

        Task<IEnumerable<T>> GetAllAsync();

        IAsyncEnumerable<T> GetAllStream();

        Task<T> FindAsync(int id);

        Task UpdateAsync(T value);

    }
}
