using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.List;
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

            return Ok(await _service.GetLists());


        }

        [HttpPost]
        public async Task<IActionResult> CreateList(ListCreateDto list)
        {

            return Ok(await _service.AddList(list));

        }

    }
}