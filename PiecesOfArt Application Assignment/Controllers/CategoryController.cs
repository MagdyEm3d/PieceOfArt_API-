using Microsoft.AspNetCore.Mvc;
using PiecesOfArt_Application_Assignment.DTOS;
using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Reposatories;

namespace PiecesOfArt_Application_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryReposatory _categoryRepository;

        public CategoryController(ICategoryReposatory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("Add-Category")]
        public IActionResult AddCategory(Categorydto categorydto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = new Category
            {
                CategoryName = categorydto.CategoryName,
                CategoryDescription = categorydto.CategoryDescription
            };

            _categoryRepository.AddCategory(category);
            _categoryRepository.SaveChanges();

            return Ok("Category Added Successfully");
        }

        [HttpDelete("Delete-Secound-Recourd")]
        public IActionResult DeleteCategory()
        {
            var category = _categoryRepository.GetSecondCategory();
            if (category == null)
                return BadRequest("Category Not Found");

            _categoryRepository.DeleteCategory(category);
            _categoryRepository.SaveChanges();

            return Ok("Category Deleted Successfully");
        }
    }
}
