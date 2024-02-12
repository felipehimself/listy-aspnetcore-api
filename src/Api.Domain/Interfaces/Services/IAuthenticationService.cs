using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Enums;

namespace Api.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        string GenerateJwtToken(Guid userId, string role);
    }
}