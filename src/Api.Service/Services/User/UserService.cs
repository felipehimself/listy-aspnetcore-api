using Api.Domain.Entities.User;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services.User
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repository;


        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)

        {

            throw new NotImplementedException();
        }

        public async Task<UserEntity> Get(Guid id)
        {
            throw new NotImplementedException();
        }


        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _repository.AddAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}