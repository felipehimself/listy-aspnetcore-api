using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.User
{
    public class UserUpdateResultDto
    {

        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}