using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.User
{
    public class UserCreateResultDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }


        public required string Username { get; set; }

        public required string Email { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}