using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Category { get; set; }

    }
}