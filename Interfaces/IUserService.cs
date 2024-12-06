using CidadaoConectado.API.Data.Dtos.User;
using CidadaoConectado.API.Data.Models;

namespace CidadaoConectado.API.Interfaces;

public interface IUserService : ICrudService<string, User> 
{ 
    Task Register(UserRequest user);
}