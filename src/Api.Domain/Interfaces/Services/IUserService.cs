
using Api.Domain.Dtos.User;
using Api.Domain.Entities.User;

namespace Api.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUser(Guid id);
        Task<UserCreateResultDto> AddUser(UserCreateDto user);
        Task<UserUpdateResultDto?> UpdateUser(UserUpdateDto user);
        Task<bool> DeleteUser(Guid id);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<bool> UpdatePassword(UserUpdatePasswordDto pwdDto);
    }
}