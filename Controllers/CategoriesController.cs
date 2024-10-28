using ArtsShop.Data;
using ArtsShop.Model;
using ArtsShop.Model.Product;
using ArtsShop.Model.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ArtsShop.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest(new Response<Category>(false, "Invalid category data", null));
            }

            var response = await _categoryService.Create(category);

            if (!response.isSuccess)
            {
                return BadRequest(response);
            }

            return CreatedAtAction(nameof(GetAll), new { id = category.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest(new Response<Category>(false, "Invalid category data", null));
            }

            var response = await _categoryService.Update(id, category);

            if (!response.isSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAll();

            if (!response.isSuccess)
            {
                return BadRequest(response); // Trả về Bad Request nếu không thành công
            }

            return Ok(response); // Trả về 200 OK với dữ liệu
        }
        [HttpGet("byType/{type}")]
        public async Task<IActionResult> GetByType(string type)
        {
            var response = await _categoryService.GetByType(type);

            if (!response.isSuccess)
            {
                return BadRequest(response); // Trả về Bad Request nếu không thành công
            }

            return Ok(response); // Trả về 200 OK với dữ liệu
        }
    }
}
