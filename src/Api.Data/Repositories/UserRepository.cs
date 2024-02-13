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

        public async Task<bool> ExistsEmailOrUserName(string email, string username)
        {
            return await _dbset.AnyAsync(x => (x.Email == email) || x.Username == username);
        }

        public async Task<Tuple<UserEntity?, string>> CreateNewUserAsync(UserEntity user)
        {
            // var exists = await _dbset.AnyAsync(x => (x.Email == user.Email) || x.Username == user.Username);
            var exists = await ExistsEmailOrUserName(user.Email, user.Username);

            if (exists) return new Tuple<UserEntity?, string>(null, "Email já em uso");



            // TODO:
            // Nao precisa verificar, guid sempre será novo, é um novo cara...
            // if (user.Id == Guid.Empty)
            // {
            //     user.Id = Guid.NewGuid();
            // }
            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;
            user.Password = PasswordEncryptor.Encrypt(user.Password);

            _dbset.Add(user);
            await _context.SaveChangesAsync();

            // return user;
            return new Tuple<UserEntity?, string>(user, "");

        }


        public async Task<UserEntity?> Login(string email, string password)
        {

            var user = await _dbset.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null) return null;

            return PasswordEncryptor.VerifyPassword(user.Password, password) ? new UserEntity { Id = user.Id, Role = user.Role } : null;


        }

        public async Task<Tuple<UserEntity?, string>> UpdateUserAsync(UserEntity user)
        {

            var emailInUse = await _dbset.FirstOrDefaultAsync(x => x.Email == user.Email);

            if (emailInUse != null && emailInUse.Id != user.Id) return new Tuple<UserEntity?, string>(null, "E-mail já em uso");


            var userNameInUse = await _dbset.FirstOrDefaultAsync(x => x.Username == user.Username);

            if (userNameInUse != null && userNameInUse.Id != user.Id) return new Tuple<UserEntity?, string>(null, "Username já em uso");


            var userFromDb = await GetByIdAsync(user.Id);

            if (userFromDb != null)
            {

                user.Id = userFromDb.Id;
                user.CreatedAt = userFromDb.CreatedAt;
                user.Password = userFromDb.Password;
                user.Role = userFromDb.Role;
                user.UpdatedAt = DateTime.UtcNow;

                _context.Entry(userFromDb).CurrentValues.SetValues(user);

                await _context.SaveChangesAsync();

                return new Tuple<UserEntity?, string>(user, "");

            }

            return new Tuple<UserEntity?, string>(null, "Algo deu errado");


        }
    }
}