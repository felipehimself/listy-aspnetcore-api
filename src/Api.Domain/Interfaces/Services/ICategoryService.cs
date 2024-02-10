using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Category;
using Api.Domain.Entities.Category;
using Api.Domain.Interfaces.Repositories;

namespace Api.Domain.Interfaces.Services
{
    public interface ICategoryService
    {

        Task<IEnumerable<CategoryEntity>> GetCategories();
        Task<CategoryCreateResultDto> AddCategory(CategoryCreateDto category);


    }
}