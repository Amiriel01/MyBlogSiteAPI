namespace BlogSite.API.Models.DTO
{
    public class UpdateCategoryRequestDTO
    {
        //put the properties that the user will send when updating the category, the Guid Id was left off because the user will not update that.
        public string Name { get; set; }

        public string UrlHandle { get; set; }
    }
}
