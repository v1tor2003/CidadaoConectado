using CidadaoConectado.API.Data.Context;
using CidadaoConectado.API.Data.Models;
using CidadaoConectado.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CidadaoConectado.API.Data.Repositories;

public class PostRepository : BaseRepository<int, Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {}

    public override async Task<Post?> GetByIdAsync(int id) =>
        await _context.Posts.FirstOrDefaultAsync(user => user.Id == id);
}