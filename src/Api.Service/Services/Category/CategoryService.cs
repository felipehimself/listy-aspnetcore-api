using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Category;
using Api.Domain.Entities.Category;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using AutoMapper;

namespace Api.Service.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryCreateResultDto> AddCategory(CategoryCreateDto category)
        {
            var entity = _mapper.Map<CategoryEntity>(category);

            var result = await _repository.AddAsync(entity);

            return _mapper.Map<CategoryCreateResultDto>(result);
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(entities);


        }
    }
}