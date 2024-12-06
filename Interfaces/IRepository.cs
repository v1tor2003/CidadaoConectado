namespace CidadaoConectado.API.Interfaces;

public interface IRepository<PK, T>
    where T : class
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    abstract Task<T?> GetByIdAsync(PK id);
    Task<IEnumerable<T>> GetAllAsync();
    Task SaveAsync();
}