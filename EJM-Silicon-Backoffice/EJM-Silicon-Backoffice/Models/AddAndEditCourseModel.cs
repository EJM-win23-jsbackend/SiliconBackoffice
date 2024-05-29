namespace EJMSiliconBackoffice.Models
{
    public class AddAndEditCourseModel
    {
        public AddAndEditCourseModel()
        {
            Categories = new string[0];
            Authors = new List<Author>();
            Prices = new Prices();
            Content = new Content();
        }

        public string? ImageUri { get; set; }
        public string? ImageHeaderUri { get; set; }
        public bool IsBestSeller { get; set; }
        public bool IsDigital { get; set; }
        public string[]? Categories { get; set; }
        public string? Title { get; set; }
        public string? Ingress { get; set; }
        public string? StarRating { get; set; }
        public string? Reviews { get; set; }
        public string? LikesInProcent { get; set; }
        public string? Likes { get; set; }
        public string? Hours { get; set; }
        public virtual List<Author>? Authors { get; set; }
        public virtual Prices? Prices { get; set; }
        public virtual Content? Content { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? AuthorImage { get; set; }
    }

    public class Prices
    {
        public string? Currency { get; set; }
        public string? Price { get; set; } // decimal null???
        public string? Discount { get; set; }
    }

    public class Content
    {
        public Content()
        {
            Learning = new string[0];
            Includes = new string[0];
            ProgramDetails = new List<ProgramDetailItem>();
        }
        public string? Description { get; set; }
        public string[]? Learning { get; set; }
        public string[]? Includes { get; set; }
        public virtual List<ProgramDetailItem>? ProgramDetails { get; set; }
    }
    public class ProgramDetailItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
