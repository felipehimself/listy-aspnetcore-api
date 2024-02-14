using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.User
{
    public class UserUpdatePasswordDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Obrigatório informar senha atual")]
        public string CurrentPassword { get; set; }


        [Required(AllowEmptyStrings = false)]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Nova senha deve ter mínimo de {2} e máximo de {1} caracteres")]
        public string NewPassword { get; set; }
    }
}