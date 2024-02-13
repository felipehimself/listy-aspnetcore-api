using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Category
{
    public class CategoryCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Categoria deve ter mínimo de {2} máximo de {1} caracteres.")]
        public string Category { get; set; }
    }
}