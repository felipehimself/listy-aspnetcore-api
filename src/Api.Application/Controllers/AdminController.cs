using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {

        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }


        [Authorize("Bearer", Roles = "super_admin")]
        [HttpPatch]
        public async Task<IActionResult> Patch(Guid userid)
        {
            try
            {
                var result = await _service.ChangeUserRole(userid);

                return result ? Ok() : NotFound();
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}