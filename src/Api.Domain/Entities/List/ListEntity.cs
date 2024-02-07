using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities.User;

namespace Api.Domain.Entities.List
{
    public class ListEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Category { get; set; }

        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual IEnumerable<ListItemEntity> ListItems { get; set; }


    }
}