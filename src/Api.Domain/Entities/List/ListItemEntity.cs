using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities.List
{
    public class ListItemEntity : BaseEntity
    {
        
        public string Content { get; set; }

        public Guid ListId { get; set; }

        public virtual ListEntity List { get; set; }


    }
}