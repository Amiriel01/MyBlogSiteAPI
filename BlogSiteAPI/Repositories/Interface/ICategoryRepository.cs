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

        //if a category is found return it, if it is not found will return null
        Task<Category?> GetById(Guid id);

       Task<Category?> UpdateAsync(Category category);

        Task<Category?> DeleteAsync(Guid id);

    }
}
