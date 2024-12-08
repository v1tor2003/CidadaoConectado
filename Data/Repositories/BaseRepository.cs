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
         // Check if the entity is already tracked
        var trackedEntity = _context.Entry(entity);
        if (trackedEntity.State == EntityState.Detached)
        {
            // Attach the entity if it is not already tracked
            var primaryKey = _context.Model.FindEntityType(typeof(T))?
                .FindPrimaryKey()?
                .Properties
                .Select(p => p.PropertyInfo?.GetValue(entity))
                .ToArray();

            if (primaryKey is not null)
            {
                var existingEntity = _context.Set<T>().Find(primaryKey);
                if (existingEntity is not null)
                {
                    // Update the existing entity with new values
                    _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                }
            }
            else
            {
                // Attach and mark entity as modified if primary key is unknown
                _context.Attach(entity).State = EntityState.Modified;
            }
        }
        else
        {
            // Entity is already tracked, mark it as modified
            trackedEntity.State = EntityState.Modified;
        }

        return Task.CompletedTask;
    }
}