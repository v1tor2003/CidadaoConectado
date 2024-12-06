using CidadaoConectado.API.Data.Models;

namespace CidadaoConectado.API.Interfaces;

public interface IUserRepository : IRepository<string, User> 
{
    Task <User?> GetByEmail(string email);
}