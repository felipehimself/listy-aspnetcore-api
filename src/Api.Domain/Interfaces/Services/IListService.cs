using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.List;
using Api.Domain.Entities.List;

namespace Api.Domain.Interfaces.Services
{
    public interface IListService
    {
        Task<ListCreateResultDto> AddList(ListCreateDto list);
        Task<IEnumerable<ListEntity>> GetLists();
        Task<ListEntity> GetList(Guid id);
        Task<ListEntity> UpdateList(ListEntity list);
        Task<bool> DeleteList(Guid id);
    }
}