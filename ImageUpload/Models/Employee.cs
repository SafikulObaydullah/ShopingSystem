using DataAnnotation.customAttr;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ImageUpload.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [ValidCreationDate(ErrorMessage = "Please provide date Before today")]
        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime DOB { get; set; }
        [ForeignKey("Department")]
        public int DeptID { get; set; }
        [DisplayName("Picture")]
        public string PicturePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase Pic { get; set; }
        public virtual Department Department { get; set; }
    }
}