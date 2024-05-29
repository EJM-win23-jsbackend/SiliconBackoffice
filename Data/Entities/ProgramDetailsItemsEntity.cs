using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class ProgramDetailsItemsEntity
    {
        [Key]
        public int Id { get; set; }

        public int ProgramDetailsId { get; set; }

        public ProgramDetailsEntity ProgramDetailsEntity { get; set; } = new ProgramDetailsEntity();

        public string? DetailTitle { get; set; } = null!;

        public string? Detail { get; set; } = null!;
    }
}
