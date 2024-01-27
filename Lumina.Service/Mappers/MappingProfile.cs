using AutoMapper;
using Lumina.Domain.Entities;
using Lumina.Service.DTOs.Users;

namespace Lumina.Service.Mappers;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
        // User DTOs
        CreateMap<UserPostModel, User>().ReverseMap();
        CreateMap<UserPutModel, User>().ReverseMap();
        CreateMap<UserViewModel, User>().ReverseMap();

    }
}
