using System.ComponentModel.DataAnnotations;

namespace EJMSiliconBackoffice.Models
{
    public class CategoryModel
    {
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = null!;
    }
}
