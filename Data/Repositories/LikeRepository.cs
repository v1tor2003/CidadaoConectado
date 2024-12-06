using CidadaoConectado.API.Data.Context;
using CidadaoConectado.API.Data.Models;
using CidadaoConectado.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CidadaoConectado.API.Data.Repositories;

public class LikeRepository : BaseRepository<int, Like>, ILikeRepository
{
    public LikeRepository(AppDbContext context) : base(context)
    {}

    public override async Task<Like?> GetByIdAsync(int id) =>
        await _context.Likes.FirstOrDefaultAsync(user => user.Id == id);
}