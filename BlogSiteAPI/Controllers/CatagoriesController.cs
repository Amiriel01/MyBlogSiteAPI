using BlogSite.API.Data;
using BlogSite.API.Models.Domain;
using BlogSite.API.Models.DTO;
using BlogSite.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//create this api controller by right clicking the controllers file, clicking add, selecting controller from the menu, click API on the left, then click API Controller Empty, name the controller file (it must have the word Controller right before the .cs so the application can search for all the class files with the Controller key word, then click add.
namespace BlogSite.API.Controllers
{
    //the contoller has two attributes, the route which has the route api/[controller] the [controller] is the controller name, in this case Catagories and ApiController
    //the endpoint to reach this controller is https://localhost:(portnumber)/api/categories
    [Route("api/[controller]")]
    [ApiController]
    //CatagoriesController inherits from the ControllerBase class
    public class CatagoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICategoryRepository categoryRepository;

        //use injected DbContext class in the controller so that it can be used by entity framework core to save it
        //use ctor to create a constructor in the file
        //find the controller property ApplicationDbContext in the Data file, name it dbContext
        public CatagoriesController(ICategoryRepository categoryRepository)
        {
            //can click ctrl + . while hovering dbContext to create and assign this field and be able to use it in side the controller
            this.categoryRepository = categoryRepository;
        }

        //route to post method
        //create a post http attribute
        [HttpPost]
        //define method, pass the Direct Transfer Object (DTO) to the CreateCatagory() method
        //request is the name because it is what the user is sending the api
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO request)
        {
            // Map DTO to Domain Model (DM)
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await categoryRepository.CreateAsync(category);

            //Map back from a domain model (DM) to a domain transfer object (DTO)
            //create the new CategoryDTO response variable, give it the props needed for the category
            //return status success 200 and the return result
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

            return Ok(response);

            //run the api using the http run button at the top of visual studio, it will open swagger and the application run can be checked
        }
    }
}
