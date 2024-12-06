
using AutoMapper;
using CidadaoConectado.API.Data.Dtos.Post;
using CidadaoConectado.API.Data.Models;
using CidadaoConectado.API.Interfaces;

namespace CidadaoConectado.API.Services;
public class PostService : BaseCrudService<int, Post>, IPostService
{
    public PostService(IPostRepository repository, IMapper mapper) : base(repository, mapper)
    { }

    public async Task CreateAsync(PostRequest postRequest)
    {
        await _repository.CreateAsync(_mapper.Map<Post>(postRequest));
    }
}