using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services
{
    public interface IAdminService
    {
        Task<bool> ChangeUserRole(Guid userId);
    }
}