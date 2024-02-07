using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.List;
using Api.Domain.Entities.List;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using AutoMapper;

namespace Api.Service.Services.List
{
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;
        private readonly IListItemRepository _listItemRepository;

        private readonly IMapper _mapper;



        public ListService(IListRepository listRepository, IListItemRepository listItemRepository, IMapper mapper)
        {
            _listRepository = listRepository;
            _listItemRepository = listItemRepository;
            _mapper = mapper;
        }


        public async Task<ListCreateResultDto> AddList(ListCreateDto list)
        {

            var entity = _mapper.Map<ListEntity>(list);

            var result = await _listRepository.AddList(entity);

            return _mapper.Map<ListCreateResultDto>(result);


        }

        public async Task<bool> DeleteList(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ListEntity> GetList(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ListEntity>> GetLists()
        {
            return await _listRepository.GetLists();
        }

        public async Task<ListEntity> UpdateList(ListEntity list)
        {
            throw new NotImplementedException();
        }
    }
}