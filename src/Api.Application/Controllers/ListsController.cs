using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.List;
using Api.Domain.Exceptions;
using Api.Domain.Interfaces.Services;
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


        [HttpPost]
        public async Task<IActionResult> CreateList(ListCreateDto list)
        {

            try
            {
                return Ok(await _service.AddList(list));

            }
            catch (ListCreateException e)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(Guid id)
        {

            try
            {
                var result = await _service.DeleteList(id);

                if (!result) return NotFound();

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