using Microsoft.EntityFrameworkCore;
using Api.Data.Context;
using Api.Domain.Entities.User;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Dtos.User;
using Api.Data.Security;


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

        public async Task<UserEntity?> CreateNewUserAsync(UserEntity user)
        {
            var exists = await _dbset.AnyAsync(x => (x.Email == user.Email) || x.Username == user.Username);

            if (exists) return null;

            if (user.Id == Guid.Empty)
            {
                user.Id = Guid.NewGuid();
            }

            user.CreatedAt = DateTime.UtcNow;
            user.Password = PasswordEncryptor.Encrypt(user.Password);

            _dbset.Add(user);
            await _context.SaveChangesAsync();

            return user;

        }


        public async Task<Guid?> Login(string email, string password)
        {

            var user = await _dbset.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null) return null;

            return PasswordEncryptor.VerifyPassword(user.Password, password) ? user.Id : null;


        }

    }
}