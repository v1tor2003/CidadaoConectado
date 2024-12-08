
using AutoMapper;
using CidadaoConectado.API.Data.Dtos.Post;
using CidadaoConectado.API.Data.Models;
using CidadaoConectado.API.Interfaces;

namespace CidadaoConectado.API.Services;
public class PostService : BaseCrudService<int, Post>, IPostService
{
    private readonly IImageUploadService _imageUploadService;
    public PostService(IPostRepository repository, IImageUploadService imageUploadService,IMapper mapper) : base(repository, mapper)
    => _imageUploadService = imageUploadService;

    public async Task CreateAsync(PostRequest postRequest)
    {
        var post = _mapper.Map<Post>(postRequest);
        post.PostImagePath = _imageUploadService.CreateImageFilePath(postRequest.Image);
        
        if(postRequest.Image is not null)
            await _imageUploadService.Save(postRequest.Image, post.PostImagePath);
   
        Console.WriteLine(post.PostImagePath);
        await _repository.CreateAsync(post);
    }
}