using DataAnnotation.customAttr;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAnnotation.Models
{
    public class Designation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
       
        [MinLength(3)]
        [MaxLength(6)]
        [Required]
        [Display(Name = "Basic Salary")]
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
        [Required]
        public string Tax { get; set; }
        [DataType(DataType.Date)]
        [ValidCreationDate(ErrorMessage ="Please provide date Before Today")]
        public DateTime creationDate { get; set; }
    }
}