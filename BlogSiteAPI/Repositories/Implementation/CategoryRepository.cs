using BlogSite.API.Data;
using BlogSite.API.Models.Domain;
using BlogSite.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        //inject constructor
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            //pass the category created to the AddAsync method
            await dbContext.Categories.AddAsync(category);
            //tell dbContext class to save the changes, entity framework core will save the changes to the database
            await dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            //method that returns all of the categories in the list
            return await dbContext.Categories.ToListAsync();
        }
    }
}
