using ArtsShop.Data;
using ArtsShop.Model.DTO;
using ArtsShop.Model.Product;
using Azure;
using Microsoft.EntityFrameworkCore;
using System;

namespace ArtsShop.Model.Services
{
    public class CartService
    {
        private readonly ArtShopDbContext _context;

        public CartService(ArtShopDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Cart>> CreateCart(Cart cart)
        {
            // Kiểm tra xem giỏ hàng có tồn tại không
            var existingCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == cart.UserId);
            if (existingCart != null)
            {
                return new Response<Cart> (true, "Giỏ hàng đã tồn tại.", existingCart);
            }

            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return new Response<Cart> (true,  "Tạo giỏ hàng thành công.", cart );
        }

        public async Task<Response<Cart>> UpdateCart(int id, Cart cart)
        {
            var existingCart = await _context.Carts.FindAsync(id);
            if (existingCart == null)
            {
                return new Response<Cart> ( false,  "Giỏ hàng không tồn tại.",null);
            }

            // Cập nhật thông tin
            existingCart.FullName = cart.FullName;
            existingCart.Mobile = cart.Mobile;
            existingCart.Address = cart.Address;
            existingCart.Note = cart.Note;
            existingCart.PaymentMethod = cart.PaymentMethod;

            await _context.SaveChangesAsync();

            return new Response<Cart> (true, "Cập nhật giỏ hàng thành công.", existingCart );
        }

        public async Task<Response<Cart>> GetCart(int id)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.Id == id);
            if (cart == null)
            {
                return new Response<Cart> (false  , "Giỏ hàng không tồn tại.", null);
            }

            return new Response<Cart> (true, "", cart);
        }

        public async Task<Response<Cart>> CleanCart(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return new Response<Cart> (false,  "Giỏ hàng không tồn tại.", null);
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return new Response<Cart> (true, "Đã xóa giỏ hàng.", null);
        }
    }
}