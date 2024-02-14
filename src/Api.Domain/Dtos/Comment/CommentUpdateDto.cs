using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Comment
{
    public class CommentUpdateDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Comentário deve ter mínimo de {2} caracteres.")]
        public String Comment { get; set; }

    }
}