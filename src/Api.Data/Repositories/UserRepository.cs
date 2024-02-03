
using Microsoft.EntityFrameworkCore;

using Api.Data.Context;
using Api.Domain.Entities.User;
using Api.Domain.Interfaces.Repositories;


namespace Api.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public readonly DbSet<UserEntity> _dbset;

        public UserRepository(MyContext context) : base(context)
        {
            _dbset = context.Set<UserEntity>();
        }


    }
}