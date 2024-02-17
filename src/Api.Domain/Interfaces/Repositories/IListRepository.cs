using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.List;
using Api.Domain.Entities.List;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IListRepository : IGenericRepository<ListEntity>
    {
      
        Task<IEnumerable<ListEntity>> GetLists();
        Task<ListEntity?> GetList(Guid id);
        Task<ListEntity?> GetListWithItems(Guid id);
    }
}