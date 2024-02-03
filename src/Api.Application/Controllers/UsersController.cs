using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Service.Services;
using Api.Service.Services.User;
using Api.Domain.Entities.User;
using Api.Domain.Interfaces.Services;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Post(UserEntity user)
        {

            return Ok(await _service.Post(user));

        }



    }
}