using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Login;
using Api.Domain.Exceptions;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;

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

        public async Task<string?> Login(LoginDto user)
        {

            var userId = await _repository.Login(user.Email, user.Password) ?? throw new CustomException("Usurário ou e-mail inválido");

            var token = _authenticationService.GenerateJwtToken(userId);

            return token;

        }
    }
}