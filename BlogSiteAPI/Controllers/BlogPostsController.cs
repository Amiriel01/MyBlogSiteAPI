using Azure.Core;
using BlogSite.API.Models.Domain;
using BlogSite.API.Models.DTO;
using BlogSite.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ICategoryRepository categoryRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository, 
            ICategoryRepository categoryRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.categoryRepository = categoryRepository;
        }

        //POST: {apibaseurl}/api/blogposts
        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody]CreateBlogPostRequestDTO request)
        {
            //convert DTO to DM
            var blogPost = new BlogPost
            {
                Author = request.Author,
                Title = request.Title,
                Content = request.Content,
                BlogImageUrl = request.BlogImageUrl,
                IsVisible = request.IsVisible,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,
                Categories = new List<Category>()
            };

            //loop through categories
            foreach (var categoryGuid in request.Categories)
            {
                var existingCategory = await categoryRepository.GetById(categoryGuid);
                if (existingCategory != null)
                {
                    blogPost.Categories.Add(existingCategory);
                }
            }

            blogPost = await blogPostRepository.CreateAsync(blogPost);

            //convert DM to DTO
            var response = new BlogPostDTO
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Title = blogPost.Title,
                Content = blogPost.Content,
                BlogImageUrl = blogPost.BlogImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                UrlHandle = blogPost.UrlHandle,
                Categories = blogPost.Categories.Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle,
                }).ToList()
            };

            return Ok(response);
        }

        //GET: {apibaseurl}api/blogposts
        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await blogPostRepository.GetAllAsync();
            //Convert to DTO
            var response = new List<BlogPostDTO>();
            foreach (var blogPost in blogPosts)
            {
                response.Add(new BlogPostDTO
                {
                    Id = blogPost.Id,
                    Author = blogPost.Author,
                    Title = blogPost.Title,
                    Content = blogPost.Content,
                    BlogImageUrl = blogPost.BlogImageUrl,
                    PublishedDate = blogPost.PublishedDate,
                    ShortDescription = blogPost.ShortDescription,
                    UrlHandle = blogPost.UrlHandle,
                    IsVisible=blogPost.IsVisible,
                    Categories = blogPost.Categories.Select(x => new CategoryDTO
                    {
                        Id = x.Id,
                        Name = x.Name,
                        UrlHandle = x.UrlHandle,
                    }).ToList()
                });
            }

            return Ok(response);
        }

        //GET: {apiBaseUrl}/api/blogposts/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBlogPostById([FromRoute] Guid id)
        {
            //Get the blog post from the repository
            var blogPost = await blogPostRepository.GetByIdAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            //convert DM to DTO
            var response = new BlogPostDTO
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Title = blogPost.Title,
                Content = blogPost.Content,
                BlogImageUrl = blogPost.BlogImageUrl,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                UrlHandle = blogPost.UrlHandle,
                IsVisible = blogPost.IsVisible,
                Categories = blogPost.Categories.Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle,
                }).ToList()
            };

            return Ok(response);
        }

        //GET: {apibaseurl}/api/blogPosts/{urlhandle}
        [HttpGet]
        [Route("{urlHandle}")]
        public async Task<IActionResult> GetBlogPostByUrlHandle([FromRoute] string urlHandle)
        {
            //get blogpost details from repository
           var blogPost = await blogPostRepository.GetByUrlHandleAsync(urlHandle);

            if (blogPost == null)
            {
                return NotFound();
            }

            //convert DM to DTO
            var response = new BlogPostDTO
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Title = blogPost.Title,
                Content = blogPost.Content,
                BlogImageUrl = blogPost.BlogImageUrl,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                UrlHandle = blogPost.UrlHandle,
                IsVisible = blogPost.IsVisible,
                Categories = blogPost.Categories.Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle,
                }).ToList()
            };

            return Ok(response);
        }

        //PUT: {apiBaseUrl}/api/blogposts/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBlogPostById([FromRoute] Guid id, UpdateBlogPostRequestDTO request)
        {
            //Convert DTO to DM
            var blogPost = new BlogPost
            {
                Id = id,
                Author = request.Author,
                Title = request.Title,
                Content = request.Content,
                BlogImageUrl = request.BlogImageUrl,
                IsVisible = request.IsVisible,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,
                Categories = new List<Category>()
            };

            //loop through categories from request
            foreach (var categoryGuid in request.Categories)
            {
                var existingCategory = await categoryRepository.GetById(categoryGuid);
                if (existingCategory != null)
                {
                    blogPost.Categories.Add(existingCategory);
                }
            }

            //Call repository to update blog post domain model
            var updatedBlogPost = await blogPostRepository.UpdateAsync(blogPost);

            if (updatedBlogPost == null) 
            {
                return NotFound();
            }

            //convert DM back to DTO
            var response = new BlogPostDTO
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Title = blogPost.Title,
                Content = blogPost.Content,
                BlogImageUrl = blogPost.BlogImageUrl,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                UrlHandle = blogPost.UrlHandle,
                IsVisible = blogPost.IsVisible,
                Categories = blogPost.Categories.Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle,
                }).ToList()
            };

            return Ok(response);
        }
        //DELETE {apiBaseUrl}/api/blogposts/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] Guid id)
        {
            var deletedBlogPost = await blogPostRepository.DeleteAsync(id);

            if (deletedBlogPost == null) 
            { 
                return NotFound(); 
            }

            //convert DM to DTO
            var response = new BlogPostDTO
            {
                Id = deletedBlogPost.Id,
                Author = deletedBlogPost.Author,
                Title = deletedBlogPost.Title,
                Content = deletedBlogPost.Content,
                BlogImageUrl = deletedBlogPost.BlogImageUrl,
                PublishedDate = deletedBlogPost.PublishedDate,
                ShortDescription = deletedBlogPost.ShortDescription,
                UrlHandle = deletedBlogPost.UrlHandle,
                IsVisible = deletedBlogPost.IsVisible,
            };

            return Ok(response);
        }
    }
}
