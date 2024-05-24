using System.ComponentModel.DataAnnotations;

namespace EJMSiliconBackoffice.Models
{
    public class CourseCardModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        [Display(Name = "Image")]
        public string? ImageUri { get; set; }

        [Display(Name = "Price")]
        public string? Price { get; set; }

        [Display(Name = "Hours")]
        public string? Hours { get; set; }

        [Display(Name = "IsBestseller")]
        public bool IsBestseller { get; set; }

        [Display(Name = "LikesInNumbers")]
        public string? LikesInNumbers { get; set; }

        [Display(Name = "LikesInProcent")]
        public string? LikesInProcent { get; set; }

        [Display(Name = "Author")]
        [StringLength(50)]
        public string? Author { get; set; }
    }
}
