using AutoMapper;
using CidadaoConectado.API.Data.Dtos.Like;
using CidadaoConectado.API.Data.Dtos.Post;
using CidadaoConectado.API.Data.Dtos.User;
using CidadaoConectado.API.Data.Models;

namespace CidadaoConectado.API.Data.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRequest, User>()
            .ForMember(dest => dest.AvatarPath, opt => opt.Ignore());

        CreateMap<User, UserResponse>();

        CreateMap<PostRequest, Post>()
            .ForMember(dest => dest.PostImagePath, opt => opt.Ignore());

        CreateMap<Post, PostResponse>()
            .ForMember(dest => dest.Likes, 
                opt => opt.MapFrom(src => src.Likes.Select(l => new LikeResponse { LikeId = l.Id, UserId = l.UserId }))
            );

        CreateMap<LikeRequest, Like>();
    }
}