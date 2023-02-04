using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ManageCourses.Areas.Admin.Models
{
    public class CategoryVM
    {
        [Key]
        [HiddenInput]
        public int id { get; set; }
        [StringLength(100)]
        [Remote(action:"checkName" , controller: "Category" , ErrorMessage ="This name has been used before")]
        public string name { get; set; }
        [AllowNull]
        public int? parentId { get; set; }
    }
}
