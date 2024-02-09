using Api.Domain.Dtos.User;
using Api.Domain.Entities.User;
using AutoMapper;

namespace Api.CrossCutting.Mapper.User
{
    public class UserEntityToDtoProfile : Profile
    {
        public UserEntityToDtoProfile()
        {

            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserEntity, UserCreateDto>().ReverseMap();
            CreateMap<UserEntity, UserCreateResultDto>().ReverseMap();
            CreateMap<UserEntity, UserUpdateDto>().ReverseMap();
            CreateMap<UserEntity, UserUpdateResultDto>().ReverseMap();
            CreateMap<UserEntity, UserInListDto>().ReverseMap();
        }
    }
}