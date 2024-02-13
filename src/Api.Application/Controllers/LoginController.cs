using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Login;
using Api.Domain.Exceptions;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {


        private readonly ILoginService _service;


        public LoginController(ILoginService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Post(LoginDto credentials)
        {

            try
            {
                var token = await _service.Login(credentials);
                return Ok(new { token });
            }

            catch (CustomException e)
            {

                Debug.WriteLine(e.Message);
                return StatusCode((int)e.StatusCode, e.Message);


            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

                throw;
            }


        }

    }


}