using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICategory _categoryBLL;
        public CategoryController(ICategory categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }
        [HttpGet]
        public IActionResult GetCategory([FromBody] UsersDTO user)
        {
            List<CategoriesDTO> categories = _categoryBLL.GetCategory(user);
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoriesDTO category)
        {
            try
            {
                _categoryBLL.AddCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] CategoriesDTO category)
        {
            try
            {
                _categoryBLL.UpdateCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteCategory([FromBody] CategoriesDTO category)
        {
            try
            {
                _categoryBLL.DeleteCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //public List<CategoriesDTO> GetCategory(UsersDTO user);
        //public void AddCategory(CategoriesDTO category);
        //public void UpdateCategory(CategoriesDTO category);
        //public void DeleteCategory(CategoriesDTO category);

    }
}
