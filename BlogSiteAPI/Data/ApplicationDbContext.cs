using BlogSite.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.API.Data
{
    //The database context class is a bridge between the controllers and the database
    //DbContext comes from Microsoft.EntityFrameworkCore
    public class ApplicationDbContext : DbContext
    {
        //constructor for the ApplicationDbContext class
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //create the class properties
        //BlogPost and Category comes from the Models.Domain folder
        //DbSet class represents the collection of all entities that can be queried from the database
        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BlogImage> BlogImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between BlogPost and Category
            modelBuilder.Entity<BlogPost>()
                .HasMany(bp => bp.Categories)
                .WithMany(c => c.BlogPosts)
                .UsingEntity(j => j.ToTable("BlogPostCategory"));

            modelBuilder.Entity<Category>()
                .Property(c => c.Name).HasMaxLength(200);
        }
    }
}
