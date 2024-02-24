namespace BlogSite.API.Models.DTO
    //create a DTO folder in the Models folder, add the class for the DTO being created, this will hold the properties needed by the API to create the category
{
    public class CreateCategoryRequestDTO
    {
        //put the properties that the user will send when creating the new category, the Guid Id was left off because the user will not create that.
        public string Name { get; set; }

        public string UrlHandle { get; set; }
    }
}
