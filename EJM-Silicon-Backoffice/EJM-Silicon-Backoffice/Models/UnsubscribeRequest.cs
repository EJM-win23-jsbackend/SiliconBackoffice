using System.ComponentModel.DataAnnotations;

namespace EJMSiliconBackoffice.Models
{
    public class UnsubscribeRequest
    {
        public string Email { get; set; } = null!;
    }
}
