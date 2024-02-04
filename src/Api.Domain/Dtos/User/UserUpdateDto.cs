using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.User
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "Id do usuário obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Username é obrigatório")]
        [StringLength(12)]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public required string Email { get; set; }


        [Required(ErrorMessage = "Senha obrigatória")]
        [MinLength(6, ErrorMessage = "Mínimo de 6 caracteres")]
        [MaxLength(12, ErrorMessage = "Máximo de 12 caracteres")]
        public required string Password { get; set; }


    }
}