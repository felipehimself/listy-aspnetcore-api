using Api.Domain.Dtos.User;
using Api.Domain.Entities.User;
using Api.Domain.Exceptions;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using AutoMapper;

namespace Api.Service.Services.User
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;


        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            var dto = _mapper.Map<UserDto>(entity);

            return dto;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {

            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDto>>(entities);


        }

        public async Task<UserCreateResultDto> AddUser(UserCreateDto user)
        {
            var myEntity = _mapper.Map<UserEntity>(user);

            var userCreated = await _repository.CreateNewUserAsync(myEntity) ?? throw new UserCreateException("Username or password already taken");

            return _mapper.Map<UserCreateResultDto>(userCreated);

        }

        public async Task<UserUpdateResultDto?> UpdateUser(UserUpdateDto user)
        {

            var entity = _mapper.Map<UserEntity>(user);

            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<UserUpdateResultDto>(result);


        }
    }
}
