using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class TeacherEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;     
        [MaxLength(500)]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public string? YoutubeSubscribers { get; set; }

        public string? FaceBookFollowers { get; set; }

        public string? ExtraInfo { get; set; }  
    }
}
