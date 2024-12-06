using AutoMapper;
using CidadaoConectado.API.Interfaces;

namespace CidadaoConectado.API.Services;

public abstract class BaseCrudService<PK, T> : ICrudService<PK, T>
    where T : class
{
    protected readonly IRepository<PK, T> _repository;
    protected readonly IMapper _mapper;

    public BaseCrudService(IRepository<PK, T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateAsync(T entity)
    {
        await _repository.CreateAsync(entity);
        await _repository.SaveAsync();
    }

    public async Task CreateAsync<TRequest>(TRequest entity)
    {
        await CreateAsync(_mapper.Map<T>(entity));
    }

    public async Task DeleteAsync(T entity)
    {
        await _repository.DeleteAsync(entity);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<TReponse>> GetAllAsync<TReponse>()
    {
        var data = await GetAllAsync();

        return data.Select(_mapper.Map<TReponse>);
    }

    public async Task<T?> GetByIdAsync(PK id)
    {
       return await _repository.GetByIdAsync(id);
    }

    public async Task<TResponse?> GetByIdAsync<TResponse>(PK id)
    {
        return _mapper.Map<TResponse>(await GetByIdAsync(id));
    }

    public async Task UpdateAsync(T entity)
    {
        await _repository.UpdateAsync(entity);
        await _repository.SaveAsync();
    }
}