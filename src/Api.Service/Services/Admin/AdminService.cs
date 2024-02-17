using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services.Admin
{
    public class AdminService : IAdminService
    {

        private readonly IUserRepository _repository;

        public AdminService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ChangeUserRole(Guid userId)
        {

            var user = await _repository.GetByIdAsync(userId);

            if (user == null) return false;

            user.Role = user.Role == "user" ? "admin" : "user";

            await _repository.UpdateAsync(user);

            return true;
        }
    }
}