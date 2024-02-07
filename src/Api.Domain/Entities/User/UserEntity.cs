using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities.List;

namespace Api.Domain.Entities.User
{
    public class UserEntity : BaseEntity
    {

        [Required]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} carcacteres")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Username deve ter no máximo {1} carcacteres")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual List<ListEntity> Lists { get; set; }

    }
}