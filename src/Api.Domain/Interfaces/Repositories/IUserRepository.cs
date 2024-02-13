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
        Task<UserEntity?> CreateNewUserAsync(UserEntity user);
        Task<UserEntity?> Login(string email, string password);
        Task<Tuple<UserEntity?, string>> UpdateUserAsync(UserEntity user);

        Task<bool> ExistsEmailOrUserName(string email, string username);

    }
}