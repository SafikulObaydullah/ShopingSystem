using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAnnotation.Models
{
    public class Grade
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        [MinLength(3)]
        [MaxLength(6)]
        [Required]
        [Display(Name="Basic Salary")]
        public string Salary { get; set; }
        [MinLength(3)]
        [MaxLength(6)]
        [Required]
        [Display(Name = "House Rent Rate")]
        public string HRRate { get; set; }
        [MinLength(3)]
        [MaxLength(6)]
        [Required]
        [Display(Name = "Medical Allownce Rate")]
        public string MARate { get; set; }
        [MinLength(3)]
        [MaxLength(6)]
        [Required]
        [Display(Name = "Month Bonous")]
        public string Bonous { get; set; }
        [MinLength(3)]
        [MaxLength(6)]
        [Required]
        [Display(Name = "Profitant Fund")]
        public string PF { get; set; }
        public string Tax { get; set; }

    }
}