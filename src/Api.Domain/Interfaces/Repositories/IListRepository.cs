using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities.List;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IListRepository : IGenericRepository<ListEntity>
    {
        Task<ListEntity?> AddList(ListEntity list);
        Task<IEnumerable<ListEntity>> GetLists();
    }
}