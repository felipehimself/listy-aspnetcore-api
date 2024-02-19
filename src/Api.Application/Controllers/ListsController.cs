using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.CrossCutting.Helpers;
using Api.Domain.Dtos.List;
using Api.Domain.Exceptions;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListsController : ControllerBase
    {
        private readonly IListService _service;

        public ListsController(IListService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {


            return Ok(await _service.GetLists());


        }

        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _service.GetList(id));



        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(ListCreateDto list)
        {
            var userId = new GetUserFromRequest(HttpContext).GetUserId();

            list.UserId = userId;

            return Ok(await _service.AddList(list));


        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var userId = new GetUserFromRequest(HttpContext).GetUserId();

            var deleted = await _service.DeleteList(id, userId);

            return deleted ? NoContent() : NotFound();


        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put(ListUpdateDto list)
        {


            var userId = new GetUserFromRequest(HttpContext).GetUserId();

            list.UserId = userId;

            await _service.UpdateList(list);

            return NoContent();

        }

    }
}