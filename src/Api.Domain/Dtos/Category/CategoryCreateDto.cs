using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Category
{
    public class CategoryCreateDto
    {
        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Categoria deve ter mínimo de {2} máximo de {1} caracteres.")]
        [RegularExpression(@"^\S.{0,9}\S$", ErrorMessage = "Campos em branco não são permitidos")]
        public string Category { get; set; }
    }
}