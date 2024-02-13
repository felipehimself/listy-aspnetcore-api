using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Comment
{
    public class CommentCreateDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [Required]
        public Guid ListId { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Comentário deve ter mínimo de {2} caracteres.")]
        public string Comment { get; set; }
    }
}