namespace MySOASolution.Data.DAL.Interface
{
    public interface ICrud<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> ReadAsync(int id);
        Task<IEnumerable<T>> ReadAsync();
        Task<T> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
    }
}
