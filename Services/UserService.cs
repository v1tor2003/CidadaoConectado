using AutoMapper;
using CidadaoConectado.API.Data.Dtos.User;
using CidadaoConectado.API.Data.Models;
using CidadaoConectado.API.Interfaces;

namespace CidadaoConectado.API.Services;

public class UserService : BaseCrudService<string, User>, IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository repository, IMapper mapper) 
    : base(repository, mapper)
    {
        _userRepository = repository;
    }

    public async Task Register(UserRequest userRequest)
    {
        var user = await _userRepository.GetByEmail(userRequest.Email);
        if(user is not null) return;
        await CreateAsync(_mapper.Map<User>(userRequest));
    }
}