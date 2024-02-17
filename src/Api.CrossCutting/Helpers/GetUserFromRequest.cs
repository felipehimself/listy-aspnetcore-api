using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Api.CrossCutting.Helpers
{
    public class GetUserFromRequest
    {
        private readonly HttpContext _context;

        public GetUserFromRequest(HttpContext context)
        {
            _context = context;
        }

        public Guid GetUserId()
        {

            var userId = _context.Items["UserId"]!;

            return Guid.Parse(userId.ToString()!);



        }


    }
}