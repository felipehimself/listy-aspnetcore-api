using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities.User
{
    public class UserEntity : BaseEntity
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(12)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(6, ErrorMessage = "Mínimo de 6 caracteres")]
        [MaxLength(12, ErrorMessage = "Máximo de 12 caracteres")]
        public string Password { get; set; }
    }
}