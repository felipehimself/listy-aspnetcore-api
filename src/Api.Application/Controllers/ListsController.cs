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

            try
            {
                return Ok(await _service.GetLists());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }

        }

        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetList(Guid id)
        {

            try
            {
                var result = await _service.GetList(id);
                if (result == null) return NotFound();

                return Ok(await _service.GetList(id));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

                throw;
            }

        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> CreateList(ListCreateDto list)
        {
            var userId = new GetUserFromRequest(HttpContext).GetUserId();

            if (userId == null) return Unauthorized();


            list.UserId = userId!.Value;

            try
            {
                return Ok(await _service.AddList(list));

            }
            // catch (ListCreateException e)
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

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(Guid id)
        {


            var userId = new GetUserFromRequest(HttpContext).GetUserId();

            if (userId == null) return Unauthorized();


            try
            {
                var result = await _service.DeleteList(id, userId!.Value);

                if (!result) return NotFound();

                return Ok(true);

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

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<IActionResult> UpdateList(ListUpdateDto list)
        {


            var userId = new GetUserFromRequest(HttpContext).GetUserId();

            if (userId == null) return Unauthorized();

            list.UserId = userId!.Value;

            try
            {
                await _service.UpdateList(list);

                return NoContent();

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