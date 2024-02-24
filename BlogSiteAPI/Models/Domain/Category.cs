namespace BlogSite.API.Models.Domain
{
    public class Category
    {
        //create properties for Category
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UrlHandle { get; set; }
    }
}
