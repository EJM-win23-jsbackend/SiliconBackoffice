using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class ProgramDetailsEntity
    {
        [Key]
        public int Id { get; set; }
        public List<ProgramDetailsItemsEntity> ProgramDetails { get; set; } = new List<ProgramDetailsItemsEntity>();
    }
}
