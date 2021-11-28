using DataAnnotation.customAttr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageUpload.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        [MinLength(3)]
        [MaxLength(6)]
        [Required]
        [Display(Name = "Department's Short Name")]
        public string ShortName { get; set; }
        [DataType(DataType.Date)]
        [ValidCreationDate(ErrorMessage = "Please provide date Before today")]
        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime updateDate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}