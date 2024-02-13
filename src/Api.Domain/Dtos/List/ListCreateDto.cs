using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.List
{
    public class ListCreateDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Necessário informar o título da Lista")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Mínimo de {2} de máximo de {1} caracteres")]
        public string Title { get; set; }


        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Mínimo de {2} de máximo de {1} caracteres")]
        public string Category { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Necessário {1} itens")]
        public IEnumerable<string> ListItems { get; set; }
    }
}
