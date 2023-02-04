using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManageCourses.Areas.Admin.Models
{
    public class TrainerVM
    {
        [Key]
        [HiddenInput]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("User Name")]
        [Remote(action: "checkName", controller: "Trainer", ErrorMessage = "This Name has been used before")]
        public string name { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Email")]
        [Remote(action: "checkEmail", controller: "Trainer", ErrorMessage = "This Email has been used before")]
        public string email { get; set; }
        [Required]
        [DisplayName("Description")]
        [MinLength(10, ErrorMessage = "Please enter valid description")]
        public string description { get; set; }
        [Required]
        [StringLength(250)]
        [Url(ErrorMessage = "Please enter valid URL")]
        [DisplayName("Website")]
        public string website { get; set; }
        [DisplayName("Creation Time")]
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime creationDate { get; set; }
    }
}
