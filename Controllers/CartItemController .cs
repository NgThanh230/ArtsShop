using ArtsShop.Model.DTO;
using ArtsShop.Model.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtsShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly CartItemService _service;

        public CartItemController(CartItemService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CartItemDto cartItemDto)
        {
            var cartItem = await _service.Create(cartItemDto);
            return CreatedAtAction(nameof(GetById), new { id = cartItem.Id }, cartItem);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cartItem = await _service.GetById(id);
                return Ok(cartItem);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CartItemDto cartItemDto)
        {
            try
            {
                var updatedCartItem = await _service.Update(id, cartItemDto);
                return Ok(updatedCartItem);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return NoContent(); // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
