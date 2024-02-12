using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.List;
using Api.Domain.Entities.List;
using Api.Domain.Exceptions;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using AutoMapper;

namespace Api.Service.Services.List
{
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;

        private readonly IMapper _mapper;


        public ListService(IListRepository listRepository, IMapper mapper)
        {
            _listRepository = listRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListDto>> GetLists()

        {
            var listEntities = await _listRepository.GetLists();

            var result = _mapper.Map<IEnumerable<ListDto>>(listEntities);


            return result;
        }


        public async Task<ListCreateResultDto> AddList(ListCreateDto list)
        {

            var entity = _mapper.Map<ListEntity>(list);

            var result = await _listRepository.AddList(entity) ?? throw new CustomException("Usuário inválido");

            return _mapper.Map<ListCreateResultDto>(result);


        }

        public async Task<bool> DeleteList(Guid id)
        {
            return await _listRepository.DeleteAsync(id);
        }

        public async Task<ListSingleDto> GetList(Guid id)
        {
            var entity = await _listRepository.GetList(id);

            return _mapper.Map<ListSingleDto>(entity);

            // return entity;
        }


        public async Task<ListUpdateResultDto> UpdateList(ListUpdateDto list)
        {
            var entity = _mapper.Map<ListEntity>(list);

            var result = await _listRepository.UpdateList(entity) ?? throw new CustomException("Id da lista inválido");

            return _mapper.Map<ListUpdateResultDto>(result);
        }
    }
}