using BlogSite.API.Models.Domain;

namespace BlogSite.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        //create definition for the CreateCategory()
        Task<Category> CreateAsync(Category category);

        //create definition for the GetAllAsync()
        //after creating the task go to CategoryRepository.cs and add implement the interface
        Task<IEnumerable<Category>> GetAllAsync();

    }
}
