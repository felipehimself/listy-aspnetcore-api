using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Category;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                return Ok(await _service.GetCategories());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(CategoryCreateDto category)
        {

            try
            {
                return Ok(await _service.AddCategory(category));

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }



        }

    }
}