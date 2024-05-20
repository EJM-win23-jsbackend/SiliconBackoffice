using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class WhatYouLearnItemsEntity
    {
        [Key]
        public int Id { get; set; }
        public int WhatYouLearnId { get; set; }
        public WhatYouLearnEntity WhatYouLearnEntity { get; set; } = new WhatYouLearnEntity();
        public string WhatyoulearnFact { get; set; } = null!;
    }
}
