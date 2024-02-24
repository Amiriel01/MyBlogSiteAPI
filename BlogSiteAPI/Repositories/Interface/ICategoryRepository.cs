using BlogSite.API.Models.Domain;

namespace BlogSite.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        //create definition for the CreateCategory()
        Task<Category> CreateAsync(Category category);
    }
}
