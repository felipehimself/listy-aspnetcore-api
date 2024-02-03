using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class BaseEntity
    {

        [Key]
        public Guid Id { get; set; }

        private DateTime _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value ?? DateTime.UtcNow; }
        }

        private DateTime? _updatedAt;

        public DateTime? UpdatedAt { get; set; }


    }
}