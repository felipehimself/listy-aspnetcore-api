using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Service.Services;
using Api.Service.Services.User;
using Api.Domain.Entities.User;
using Api.Domain.Interfaces.Services;
using Api.Domain.Dtos.User;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        // TODO
        // Fazer validações de retorno no bad request, not content etc...

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.GetUser(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserCreateDto user)
        {
            return Ok(await _service.AddUser(user));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserUpdateDto user)
        {


            return Ok(await _service.UpdateUser(user));
        }




    }
}