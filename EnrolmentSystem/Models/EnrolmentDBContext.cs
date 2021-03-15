using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrolmentSystem.Models
{
    public class EnrolmentDBContext : DbContext
    {
        public EnrolmentDBContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<Student> Students { get; set; }
    }
}
