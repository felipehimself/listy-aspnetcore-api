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

        [Authorize("Bearer", Roles = "admin")]
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


        [Authorize("Bearer", Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await _service.DeleteCategory(id);

                return deleted ? NoContent() : NotFound();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        [Authorize("Bearer", Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto category)
        {

            try
            {
                var result = await _service.UpdateCategory(category);
                
                return result ? NoContent() : NotFound();
            }
            catch (System.Exception)
            {

                throw;
            }


        }


    }
}