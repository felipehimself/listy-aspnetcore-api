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
using System.Net;
using Api.Domain.Exceptions;
using System.Diagnostics;
using Api.CrossCutting.Helpers;
using Microsoft.AspNetCore.Authorization;

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


        [Authorize("Bearer", Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _service.GetUsers());

        }

        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {

            return Ok(await _service.GetUser(id));


        }

        [HttpPost]
        public async Task<IActionResult> Post(UserCreateDto user)
        {

            return Ok(await _service.AddUser(user));

        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put(UserUpdateDto user)
        {
            var userId = new GetUserFromRequest(HttpContext).GetUserId();

            user.Id = userId;

            var result = await _service.UpdateUser(user);

            return (result == null) ? NotFound() : NoContent();

        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userIdOnRequest = new GetUserFromRequest(HttpContext).GetUserId();

            if (userIdOnRequest != id) return Unauthorized();


            var deleted = await _service.DeleteUser(id);

            return deleted ? NoContent() : NotFound();


        }

        [Authorize("Bearer")]
        [HttpPatch("update-password")]
        public async Task<IActionResult> Patch(UserUpdatePasswordDto pwdDto)
        {
            var userId = new GetUserFromRequest(HttpContext).GetUserId();

            pwdDto.UserId = userId;

            await _service.UpdatePassword(pwdDto);
            return NoContent();


        }

    }
}