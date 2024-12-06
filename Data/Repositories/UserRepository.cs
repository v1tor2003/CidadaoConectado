using CidadaoConectado.API.Data.Context;
using CidadaoConectado.API.Data.Models;
using CidadaoConectado.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CidadaoConectado.API.Data.Repositories;

public class UserRepository : BaseRepository<string, User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {}

    public async Task<User?> GetByEmail(string email) =>
        await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));

    public override async Task<User?> GetByIdAsync(string id) => 
        await _context.Users.FirstOrDefaultAsync(user => user.Id.Equals(id));
    
}