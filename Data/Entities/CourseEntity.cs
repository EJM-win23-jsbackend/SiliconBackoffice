using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class CourseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? ImageALtText { get; set; }
        public string? Price { get; set; }
        public string? DiscountPrice { get; set; }
        public string? Hours { get; set; }
        public bool IsBestseller { get; set; }
        public bool IsDigital { get; set; }
        public string? LikesInNumbers { get; set; }
        public string? LikesInProcent { get; set; }
        public string? NumberOfArticles { get; set; }

        public string? Resourses { get; set; }

        public string? ExtraInfoOne { get; set;}

        public string? ExtraInfoTwo { get; set; }

        public string? ExtraInfoThree { get; set; }

        [Range(0, 5)]
        public int? NumberOfStars { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Ingress { get; set; }
        public string? WhatYouLearn { get; set;}
        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }

        public int TeacherId { get; set; }
        public TeacherEntity? Teacher { get; set; }

        public int? WhatYouLearnId { get; set; }
        public WhatYouLearnEntity? WhatYouLearnEntity { get; set; }

        public int? ProgramDetailsId { get; set; }
        public ProgramDetailsEntity? ProgramDetailsEntity { get; set; }
    }
}
