namespace CidadaoConectado.API.Interfaces;

public interface ICrudService<PK, T>
    where T : class
{
    Task CreateAsync(T entity);
    Task CreateAsync<TRequest>(TRequest entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T?> GetByIdAsync(PK id);
    Task<TResponse?> GetByIdAsync<TResponse>(PK id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<TReponse>> GetAllAsync<TReponse>();
}