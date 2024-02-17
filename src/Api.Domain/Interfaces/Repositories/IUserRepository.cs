using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities.User;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        Task<bool> EmailExists(string email);
        Task<bool> UserNameExists(string email);

        Task<UserEntity?> GetByEmailAsync(string email);
        Task<UserEntity?> GetByUsernameAsync(string username);



    }
}