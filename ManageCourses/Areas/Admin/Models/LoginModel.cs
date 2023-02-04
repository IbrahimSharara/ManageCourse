using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManageCourses.Areas.Admin.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [DisplayName("Email Address")]
        [Required]
        public string email { get; set; }
        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string? message { get; set; }
    }
}
