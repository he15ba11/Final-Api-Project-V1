using Final_Api_Project.BL.Dtos.Categories;
using Final_Api_Project.BL.Dtos.Products;
using Final_Api_Project.BL.Managers.Categories;
using Final_Api_Project.BL.Managers.Products;
using Microsoft.AspNetCore.Mvc;

namespace Final_Api_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
{
        private readonly ICategoryManager _categoryManager;

        public CategoriesController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = _categoryManager.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public ActionResult<CategoryDetailsDto> GetCategoryDetails(int categoryId)
        {
            var categoryDetails = _categoryManager.GetCategoryDetails(categoryId);
            if (categoryDetails == null)
                return NotFound();

            return categoryDetails;
        }

        [HttpPost]
        public ActionResult AddCategory(AddCategoryDto addCategoryDto)
        {
            _categoryManager.AddCategory(addCategoryDto);
            var createdCategoryUrl = Url.Action(nameof(GetCategoryDetails), new { id = addCategoryDto.Id });
            return Created(createdCategoryUrl, addCategoryDto);
        }

        [HttpPut("{categoryId}")]
        public ActionResult EditProduct(int categoryId, EditCategoryDto editCategoryDto)
        {
            if (categoryId != editCategoryDto.Id)
            {
                return BadRequest("Category ID mismatch.");
            }

            _categoryManager.EditCategory(editCategoryDto);
            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        public ActionResult DeleteCategory(int categoryId)
        {
            var categoryDetails = _categoryManager.GetCategoryDetails(categoryId);
            if (categoryDetails == null)
            {
                return BadRequest("Category ID Desn't Found.");
            }
            _categoryManager.DeleteCategory(categoryId);
            return NoContent();
        }

    }
}
