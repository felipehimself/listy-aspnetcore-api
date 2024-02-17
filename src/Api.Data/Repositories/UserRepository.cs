using Microsoft.EntityFrameworkCore;
using Api.Data.Context;
using Api.Domain.Entities.User;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Dtos.User;


namespace Api.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public readonly DbSet<UserEntity> _dbset;
        public MyContext _context;

        public UserRepository(MyContext context) : base(context)
        {
            _dbset = context.Set<UserEntity>();
            _context = context;
        }


        public async Task<bool> EmailExists(string email)
        {
            return await _dbset.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> UserNameExists(string email)
        {
            return await _dbset.AnyAsync(x => x.Username == email);
        }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _dbset.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<UserEntity?> GetByUsernameAsync(string username)
        {
            return await _dbset.FirstOrDefaultAsync(x => x.Username == username);

        }
    }
}