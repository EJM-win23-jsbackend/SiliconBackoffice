using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {
        }

        public DbSet <CourseEntity> Courses { get; set; }

        public DbSet <CategoryEntity> Categories { get; set; }

    }
}
