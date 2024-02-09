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


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetUsers());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _service.GetUser(id));
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserCreateDto user)
        {

            try
            {
                return Ok(await _service.AddUser(user));
            }

            catch (UserCreateException e)
            {
                Debug.WriteLine(e.Message);
                return StatusCode((int)HttpStatusCode.NotAcceptable, e.Message);
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put(UserUpdateDto user)
        {
            try
            {
                return Ok(await _service.UpdateUser(user));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {

            try
            {
                var isDeleted = await _service.DeleteUser(id);

                if (!isDeleted) return NotFound();


                return Ok(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }


        }

    }
}