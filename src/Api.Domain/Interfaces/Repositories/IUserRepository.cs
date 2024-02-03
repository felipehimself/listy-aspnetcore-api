using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities.User;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {

    }
}