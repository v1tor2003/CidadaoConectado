using AutoMapper;
using CidadaoConectado.API.Data.Dtos.User;
using CidadaoConectado.API.Data.Models;
using CidadaoConectado.API.Interfaces;

namespace CidadaoConectado.API.Services;

public class UserService : BaseCrudService<string, User>, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IImageUploadService _imageUploadService;
    public UserService(IUserRepository repository, IImageUploadService imageUploadService, IMapper mapper) 
    : base(repository, mapper)
    {
        _userRepository = repository;
        _imageUploadService = imageUploadService;
    }

    public async Task Register(UserRequest userRequest)
    {
        var user = await _userRepository.GetByEmail(userRequest.Email);
        if(user is not null) return;

        user = _mapper.Map<User>(userRequest);
        
        user.AvatarPath = _imageUploadService.CreateImageFilePath(userRequest.Avatar);
        if(userRequest.Avatar is not null)
            await _imageUploadService.Save(userRequest.Avatar, user.AvatarPath);
        
        Console.WriteLine(user.AvatarPath);
        await CreateAsync(user);
    }
}