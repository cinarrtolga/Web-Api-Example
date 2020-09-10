using System;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class PhoneModel
    {
        public int PhoneId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public string Title { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Notes { get; set; }
        public string HomeAddress { get; set; }
        public string NickName { get; set; }
        public string WebSite { get; set; }
        public DateTime? BirthDay { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
