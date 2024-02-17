using System.Net;
using Api.Domain.Dtos.User;
using Api.Domain.Entities.User;
using Api.Domain.Exceptions;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Service.Services.Security;
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

            var emailExists = await _repository.EmailExists(user.Email);
            var usernameExists = await _repository.UserNameExists(user.Username);

            if (emailExists && usernameExists) throw new CustomException("E-mail e nome do usuário já em uso", HttpStatusCode.NotAcceptable);

            if (emailExists) throw new CustomException("E-mail já em uso", HttpStatusCode.NotAcceptable);

            if (usernameExists) throw new CustomException("Nome de usuário já em uso", HttpStatusCode.NotAcceptable);


            user.Password = PasswordEncryptorService.Encrypt(user.Password);

            var entity = _mapper.Map<UserEntity>(user);

            var result = await _repository.AddAsync(entity);

            return _mapper.Map<UserCreateResultDto>(result);

        }

        public async Task<UserUpdateResultDto?> UpdateUser(UserUpdateDto user)
        {
            var userFromDb = await _repository.GetByIdAsync(user.Id) ?? throw new CustomException("Informações inválidas", HttpStatusCode.NotAcceptable);

            var emailInUse = await _repository.GetByEmailAsync(user.Email);
            var usernameInUse = await _repository.GetByUsernameAsync(user.Username);

            if (emailInUse != null && emailInUse.Id != user.Id && usernameInUse != null && usernameInUse.Id != user.Id) throw new CustomException("E-mail e nome de usuário já em uso", HttpStatusCode.NotAcceptable);

            if (emailInUse != null && emailInUse.Id != user.Id) throw new CustomException("E-mail já em uso", HttpStatusCode.NotAcceptable);

            if (usernameInUse != null && usernameInUse.Id != user.Id) throw new CustomException("Nome de usuário já em uso", HttpStatusCode.NotAcceptable);

          
            userFromDb.Name = user.Name;
            userFromDb.Username = user.Username;
            userFromDb.Email = user.Email;



            var result = await _repository.UpdateAsync(userFromDb);

            return _mapper.Map<UserUpdateResultDto>(result);

        }

        public async Task UpdatePassword(UserUpdatePasswordDto pwdDto)
        {
            var user = await _repository.GetByIdAsync(pwdDto.UserId) ?? throw new CustomException("Usuário inválido", HttpStatusCode.Unauthorized);

            var pwdMatch = PasswordEncryptorService.VerifyPassword(user.Password, pwdDto.CurrentPassword);

            if (!pwdMatch) throw new CustomException("Senha atual incorreta", HttpStatusCode.Unauthorized);

            user.Password = PasswordEncryptorService.Encrypt(pwdDto.NewPassword);

            await _repository.UpdateAsync(user);

        }
    }
}
