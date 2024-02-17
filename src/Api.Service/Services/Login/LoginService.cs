using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Login;
using Api.Domain.Exceptions;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Service.Services.Security;

namespace Api.Service.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;
        private readonly IAuthenticationService _authenticationService;


        public LoginService(IUserRepository repository, IAuthenticationService authenticationService)
        {
            _repository = repository;
            _authenticationService = authenticationService;
        }

        public async Task<string> Login(LoginDto user)
        {

            var userFromDb = await _repository.GetByEmailAsync(user.Email) ?? throw new CustomException("E-mail ou senha inválidos", HttpStatusCode.Unauthorized);

            var pwdMatch = PasswordEncryptorService.VerifyPassword(userFromDb.Password, user.Password);

            if (!pwdMatch) throw new CustomException("E-mail ou senha inválidos", HttpStatusCode.Unauthorized);

            return _authenticationService.GenerateJwtToken(userFromDb.Id, userFromDb.Role);

        }
    }
}