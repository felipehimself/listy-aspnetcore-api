using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Helpers;

namespace Api.Domain.Dtos.User
{
    public class UserUpdateDto
    {
        // [GuidValidation(ErrorMessage = " Forneça in Id váááálido")]
        [Required(ErrorMessage = "Id do usuário obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome tem que ter pelo menos {2} e máximo de {1} caracteres")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Username é obrigatório")]
        [StringLength(12, MinimumLength = 1, ErrorMessage = "Username tem que ter pelo menos {2} e máximo de {1} caracteres")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public required string Email { get; set; }


        [Required(ErrorMessage = "Senha obrigatória")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Mínimo de {2} e máximo de {1} caracteres")]
        public required string Password { get; set; }


    }
}