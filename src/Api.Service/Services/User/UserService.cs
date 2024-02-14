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

            Tuple<UserEntity?, string> result = await _repository.CreateNewUserAsync(entity);

            if (result.Item1 == null) throw new CustomException(result.Item2, HttpStatusCode.NotAcceptable);

            return _mapper.Map<UserCreateResultDto>(result.Item1);

        }

        public async Task<UserUpdateResultDto?> UpdateUser(UserUpdateDto user)
        {

            var entity = _mapper.Map<UserEntity>(user);

            Tuple<UserEntity?, string> result = await _repository.UpdateUserAsync(entity);

            if (result.Item1 == null) throw new CustomException(result.Item2, HttpStatusCode.NotAcceptable);

            return _mapper.Map<UserUpdateResultDto>(result.Item1);


        }

        public async Task<bool> UpdatePassword(UserUpdatePasswordDto pwdDto)
        {
            var result = await _repository.UpdatePasswordAsync(pwdDto.UserId, pwdDto.CurrentPassword, pwdDto.NewPassword);

            if (!result) throw new CustomException("Informações inválidas", HttpStatusCode.Unauthorized);

            return result;
        }
    }
}
