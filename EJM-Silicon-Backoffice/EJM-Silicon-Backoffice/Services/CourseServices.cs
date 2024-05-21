using Data.Contexts;
using Data.Entities;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;

namespace EJMSiliconBackoffice.Services
{
    public class CourseServices
    {
        private readonly CourseContext _context;

        public CourseServices(CourseContext context)
        {
            _context = context;
        }


        //Denna del ska tas bort - ska just nu bara hämta kursen för styling!!
        public async Task<List<CourseEntity>> GetAllCoursesAsync()
        {
            try
            {
                var result = _context.Courses.ToList();

                if (result.Any())
                {
                    {
                        return result;
                    }
                }
                return null!;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetAllCoursesAsync::" + ex.Message);
                return null!;
            }
        }

        //Denna del ska tas bort - ska just nu bara hämta kursen för styling!!
        public async Task<List<CategoryEntity>> GetAllCategoriesAsync()
        {
            try
            {
                var result = _context.Categories.ToList();

                if (result.Any())
                {
                    {
                        return result;
                    }
                }
                return null!;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetAllCoursesAsync::" + ex.Message);
                return null!;
            }
        }

        public CourseEntity GetACourseAsync(int id)
        {
            try
            {
                var result = _context.Courses.FirstOrDefault(x => x.Id == id);
    
            if (result != null)
            {
                {
                    return result;
                }
            }
                return null!;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetACourseAsync::" + ex.Message);
                return null!;
            }
        }
    }


}
