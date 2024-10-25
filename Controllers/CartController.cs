using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ArtsShop.Model.Product;
using ArtsShop.Model.Services;
namespace ArtsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cart cart)
        {
            var response = await _cartService.CreateCart(cart);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cart cart)
        {
            var response = await _cartService.UpdateCart(id, cart);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _cartService.GetCart(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Clean(int id)
        {
            var response = await _cartService.CleanCart(id);
            return Ok(response);
        }
    }
}
