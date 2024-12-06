
using AutoMapper;
using CidadaoConectado.API.Data.Dtos.Like;
using CidadaoConectado.API.Data.Models;
using CidadaoConectado.API.Interfaces;

namespace CidadaoConectado.API.Services;

public class LikeService : BaseCrudService<int, Like>, ILikeService
{
    public LikeService(ILikeRepository repository, IMapper mapper) : base(repository, mapper)
    { }

}