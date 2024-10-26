using ArtsShop.Data;
using ArtsShop.Model.DTO;
using ArtsShop.Model.Product;

namespace ArtsShop.Model.Services
{
    public class CartItemService
    {
        private readonly ArtShopDbContext _context;

        public CartItemService(ArtShopDbContext context)
        {
            _context = context;
        }

        public async Task<CartItem> Create(CartItemDto cartItemDto)
        {
            var cartItem = new CartItem
            {
                ProductId = cartItemDto.ProductId,
                CartId = cartItemDto.CartId,
                Quantity = cartItemDto.Quantity,
                Price = (decimal)cartItemDto.Price,
                Discount = cartItemDto.Discount,
                Image = cartItemDto.Image
            };

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task<CartItem> Update(int id, CartItemDto cartItemDto)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                throw new KeyNotFoundException("Cart item not found");
            }

            cartItem.ProductId = cartItemDto.ProductId;
            cartItem.CartId = cartItemDto.CartId;
            cartItem.Quantity = cartItemDto.Quantity;
            cartItem.Price = (decimal)cartItemDto.Price;
            cartItem.Discount = cartItemDto.Discount;
            cartItem.Image = cartItemDto.Image;

            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task<bool> Delete(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                throw new KeyNotFoundException("Cart item not found");
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<CartItem> GetById(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                throw new KeyNotFoundException("Cart item not found");
            }

            return cartItem;
        }
    }
}
