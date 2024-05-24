using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace EJMSiliconBackoffice.Models
{
    public class CourseModel
    {
        [Required]
        [Display(Name = "Title")]
        [StringLength(60)]
        public string Title { get; set; } = null!;

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Alt")]
        public string? ImageALtText { get; set; }

        [Display(Name = "Price")]
        public string? Price { get; set; }

        [Display(Name = "DiscountPrice")]
        public string? DiscountPrice { get; set; }

        [Display(Name = "Ingress")]
        public string? Ingress { get; set; }

        [Display(Name = "Hours")]
        public string? Hours { get; set; }

        [Display(Name = "IsBestseller")]
        public bool IsBestseller { get; set; }

        [Display(Name = "IsDigital")]
        public bool IsDigital { get; set; }

        [Display(Name = "LikesInNumbers")]
        public string? LikesInNumbers { get; set; }

        [Display(Name = "LikesInProcent")]
        public string? LikesInProcent { get; set; }

        [Display(Name = "Author")]
        [StringLength(50)]
        public string? Author { get; set; }

        [StringLength(1000)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "WhatYouLearn")]
        public string? WhatYouLearn { get; set; }

        public string? NumberOfArticles { get; set; }

        public string? Resourses { get; set; }

        public string? ExtraInfoOne { get; set; }

        public string? ExtraInfoTwo { get; set; }

        public string? ExtraInfoThree { get; set; }

        [Range(0, 5)]
        public int? NumberOfStars { get; set; }

        public int CategoryId { get; set; }
        
        public int TeacherId { get; set; }

        public int? WhatYouLearnId { get; set; }
        
        public int? ProgramDetailsId { get; set; }

    }
}
