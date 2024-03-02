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

        public async Task<Category?> DeleteAsync(Guid id)
        {
           var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCategory is null)
            {
                return null;
            }

            dbContext.Categories.Remove(existingCategory);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            //method that returns all of the categories in the list
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(Guid id)
        {
            //use dbContext.Categories.FirstOrDefaultAsync x is what is returned x.id is the id of what is returned, if it equals the expeced id item found or null
           return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (existingCategory != null)
            {
                //use this line to update the existing category to the new values given
                dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return category;
            }

            return null;
        }
    }
}
