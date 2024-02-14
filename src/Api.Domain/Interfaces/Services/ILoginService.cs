using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Login;

namespace Api.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Task<string> Login(LoginDto user);
    }
}