
using Api.Domain.Entities.User;

namespace Api.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);

        Task<UserEntity> Post(UserEntity user);
        Task<UserEntity> Put(UserEntity user);
        Task<bool> Delete(Guid id);
    }
}