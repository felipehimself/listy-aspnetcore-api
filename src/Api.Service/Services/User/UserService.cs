using System.Net;
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

            return _mapper.Map<UserDto>(entity);

        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {

            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDto>>(entities);


        }

        public async Task<UserCreateResultDto> AddUser(UserCreateDto user)
        {
            var entity = _mapper.Map<UserEntity>(user);

            var userCreated = await _repository.CreateNewUserAsync(entity) ?? throw new UserCreateException("Username ou email inválido");

            return _mapper.Map<UserCreateResultDto>(userCreated);

        }

        public async Task<UserUpdateResultDto?> UpdateUser(UserUpdateDto user)
        {

            var entity = _mapper.Map<UserEntity>(user);

            // Todo
            // Mensagem virá do result
            var result = await _repository.UpdateUserAsync(entity) ?? throw new CustomException("Username ou email já em uso", HttpStatusCode.NotAcceptable);

            return _mapper.Map<UserUpdateResultDto>(result);


        }
    }
}
