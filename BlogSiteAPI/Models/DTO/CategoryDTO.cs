namespace BlogSite.API.Models.DTO
{
    //this is used to take the domain model returned and deliver it to the user as a domain transfer object
    public class CategoryDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UrlHandle { get; set; }

    }
}
