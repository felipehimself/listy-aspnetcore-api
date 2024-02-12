using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Comment
{
    public class CommentCreateDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public Guid ListId { get; set; }
        public string Comment { get; set; }
    }
}