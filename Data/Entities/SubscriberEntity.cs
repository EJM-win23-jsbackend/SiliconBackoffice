using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class SubscriberEntity
    {
        [Key]
        public string Id { get; set; } = null!;   

        [Required]
        public string Email { get; set; } = null!;
    }
}
