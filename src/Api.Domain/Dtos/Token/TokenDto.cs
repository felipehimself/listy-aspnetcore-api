using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Token
{
    public class TokenDto
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }
    }
}