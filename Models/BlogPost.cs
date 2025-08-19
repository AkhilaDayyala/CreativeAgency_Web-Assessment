namespace Web.CreativeAgency.Models
{
    public class BlogPost
    {
        public string Slug { get; set; } = "";
        public string Title { get; set; } = "";
        public string Category { get; set; } = "";
        public DateTime PublishedOn { get; set; }
        public string Excerpt { get; set; } = "";
        public string Content { get; set; } = "";
    }
}
