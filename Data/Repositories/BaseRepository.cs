using CidadaoConectado.API.Data.Context;
using CidadaoConectado.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CidadaoConectado.API.Data.Repositories;

public abstract class BaseRepository<PK, T> : IRepository<PK, T>
    where T : class
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context) =>
        _context = context;

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity!);
    }

    public Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public abstract Task<T?> GetByIdAsync(PK id);
    
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(T entity)
    {
        var entityEntry = _context.Set<T>().Find(entity);
        
        if(entityEntry is not null)
        {
            _context.Set<T>().Entry(entityEntry).CurrentValues.SetValues(entity);
        }

        return Task.CompletedTask;
    }
}