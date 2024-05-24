using Data.Entities;
using EJMSiliconBackoffice.Models;


namespace EJMSiliconBackoffice.ViewModels
{
    public class CourseViewModel
    {
        public List<CourseEntity>? Courses { get; set; }

        public List<CategoryEntity>? Categories { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; } 
    }
}
