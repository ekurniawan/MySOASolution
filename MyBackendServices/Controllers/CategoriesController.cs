using Microsoft.AspNetCore.Mvc;
using MyBackendServices.Models;

namespace MyBackendServices.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private static List<Category> categories = new List<Category>
            {
                new Category { CategoryID = 1, CategoryName = "Beverages" },
                new Category { CategoryID = 2, CategoryName = "Condiments" },
                new Category { CategoryID = 3, CategoryName = "Confections" },
                new Category { CategoryID = 4, CategoryName = "Dairy Products" },
                new Category { CategoryID = 5, CategoryName = "Grains/Cereals" },
                new Category { CategoryID = 6, CategoryName = "Meat/Poultry" },
            };

        public CategoriesController()
        {

        }

        [HttpGet]
        public List<Category> Get()
        {
            return categories;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = categories.SingleOrDefault(c => c.CategoryID == id);
            if (category == null)
            {
                return NotFound($"CategoryID {id} not found!");
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            categories.Add(category);
            return CreatedAtAction(nameof(GetById),
                new { id = category.CategoryID }, category);
        }
    }
}
