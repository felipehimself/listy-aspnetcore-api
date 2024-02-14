using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            var now = DateTime.UtcNow;

            var updatedItems = entity.ListItems.Select(item =>
            {

                item.CreatedAt = now;

                return item;
            });

            entity.ListItems = updatedItems.ToList();

            // foreach (var item in entity.ListItems)
            // {
            //     // item.Id = Guid.NewGuid();
            //     item.CreatedAt = now;
            // }

            var result = await _listRepository.AddAsync(entity);

            return _mapper.Map<ListCreateResultDto>(result);

            // var entity = _mapper.Map<ListEntity>(list);

            // var result = await _listRepository.AddList(entity) ?? throw new CustomException("Usuário inválido", HttpStatusCode.NotAcceptable);

            // return _mapper.Map<ListCreateResultDto>(result);


        }

        public async Task<bool> DeleteList(Guid id, Guid userId)
        {
            var list = await _listRepository.GetList(id);

            if (list == null) return false;

            if (list.User.Id != userId) throw new UnauthorizedAccessException();

            return await _listRepository.DeleteAsync(id);
        }

        public async Task<ListSingleDto?> GetList(Guid id)
        {
            var entity = await _listRepository.GetList(id) ?? throw new CustomException("Id da lista inválido", HttpStatusCode.NotFound);

            return _mapper.Map<ListSingleDto>(entity);

        }


        public async Task<ListUpdateResultDto?> UpdateList(ListUpdateDto list)
        {


            var listWithItems = await _listRepository.GetListWithItems(list.Id) ?? throw new CustomException("Id da lista inválido", HttpStatusCode.NotFound);

            if (listWithItems.UserId != list.UserId) throw new UnauthorizedAccessException();


            var entity = _mapper.Map<ListEntity>(list);

            var now = DateTime.UtcNow;

            var updateListItems = listWithItems!.ListItems.Select(itemFromdb =>
                {
                    var findItem = list.ListItems.First(itemInDto => itemInDto.Id == itemFromdb.Id);

                    if (findItem != null)
                    {

                        itemFromdb.Content = findItem.Content;
                        itemFromdb.UpdatedAt = now;
                    }

                    return itemFromdb;

                }).ToList();


            entity.ListItems = updateListItems;

            var result = await _listRepository.UpdateAsync(entity);

            // var originalList = await _listRepository.GetByIdAsync(list.Id) ?? throw new CustomException("Id da lista inválido", HttpStatusCode.NotFound);


            // if(originalList.UserId != list.UserId) throw new UnauthorizedAccessException();


            // var entity = _mapper.Map<ListEntity>(list);

            // var result = await _listRepository.UpdateList(entity) ?? throw new CustomException("Id da lista inválido", HttpStatusCode.NotFound);

            return _mapper.Map<ListUpdateResultDto>(result);
        }
    }
}