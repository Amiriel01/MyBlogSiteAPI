namespace BlogSite.API.Models.DTO
{
    public class CreateBlogPostRequestDTO
    {
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Content { get; set; }

        public string BlogImageUrl { get; set; }

        public string UrlHandle { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Author { get; set; }

        public bool IsVisible { get; set; }
    }
}
