using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Model.Entities
{
    public class Users : IEntity
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(256)]
        public string Username { get; set; }
        [Required]
        [StringLength(256)]
        public string Password { get; set; }
        [Required]
        [StringLength(256)]
        public string Email { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
