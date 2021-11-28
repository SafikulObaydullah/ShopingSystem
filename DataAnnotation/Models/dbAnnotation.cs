using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataAnnotation.Models
{
    public class dbAnnotation : DbContext
    {
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Grade> Grades { get; set; }

    }
}