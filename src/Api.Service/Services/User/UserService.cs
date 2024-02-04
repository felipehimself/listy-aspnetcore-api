using Api.Domain.Dtos.User;
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

        public async Task<bool> DeleteUser(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var dto = new UserDto
            {
                Id = entity.Id,
                Username = entity.Username,
                Name = entity.Name,
                Email = entity.Email,
                CreatedAt = entity.CreatedAt
            };

            return dto;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var list = new List<UserDto>();

            var entities = await _repository.GetAllAsync();

            foreach (var user in entities)
            {

                var userDto = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Username = user.Username,
                    CreatedAt = user.CreatedAt,
                };

                list.Add(userDto);


            }

            return list;
        }

        public async Task<UserCreateResultDto> AddUser(UserCreateDto user)
        {
            // TODO
            // Automapper
            // Encrypt password
            var userEntity = new UserEntity
            {

                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Username = user.Username
            };


            var userCreated = await _repository.AddAsync(userEntity);

            var teste = new UserCreateResultDto
            {
                Email = userCreated.Email,
                Name = userCreated.Name,
                Username = userCreated.Username,
                CreatedAt = DateTime.UtcNow // ver se automapper vai resolver
            };

            return teste;

        }

        public async Task<UserUpdateResultDto?> UpdateUser(UserUpdateDto user)
        {

            var entity = new UserEntity
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password
            };


            var result = await _repository.UpdateAsync(entity);

            if (result == null) return null;



            return new UserUpdateResultDto
            {
                Id = result!.Id,
                Email = result.Email,
                Name = result.Name,
                Username = result.Username,
                UpdatedAt = result.UpdatedAt ?? DateTime.UtcNow

            };

        }
    }
}
