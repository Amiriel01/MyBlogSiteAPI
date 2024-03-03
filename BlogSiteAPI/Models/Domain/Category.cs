namespace BlogSite.API.Models.Domain
{
    public class Category
    {
        //create properties for Category
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UrlHandle { get; set; }

        //one category can have multiple blog posts
        //this represents the relation between the blog posts and the category
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
