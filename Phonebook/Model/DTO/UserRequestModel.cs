using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class UserRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
