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

        public async Task<ApiResponse<Cart>> CreateCart(Cart cart)
        {
            // Kiểm tra xem giỏ hàng có tồn tại không
            var existingCart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == cart.UserId);
            if (existingCart != null)
            {
                return new ApiResponse<Cart> (true, null, "Giỏ hàng đã tồn tại.", existingCart);
            }

            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return new ApiResponse<Cart> (true, null,  "Tạo giỏ hàng thành công.", cart );
        }

        public async Task<ApiResponse<Cart>> UpdateCart(int id, Cart cart)
        {
            var existingCart = await _context.Cart.FindAsync(id);
            if (existingCart == null)
            {
                return new ApiResponse<Cart> ( false,null, "Giỏ hàng không tồn tại.",null);
            }

            // Cập nhật thông tin
            existingCart.FullName = cart.FullName;
            existingCart.Mobile = cart.Mobile;
            existingCart.Address = cart.Address;
            existingCart.Note = cart.Note;
            existingCart.PaymentMethod = cart.PaymentMethod;

            await _context.SaveChangesAsync();

            return new ApiResponse<Cart> (true,null, "Cập nhật giỏ hàng thành công.", existingCart );
        }

        public async Task<ApiResponse<Cart>> GetCart(int id)
        {
            var cart = await _context.Cart.Include(c => c.Items).FirstOrDefaultAsync(c => c.Id == id);
            if (cart == null)
            {
                return new ApiResponse<Cart> (false, null, "Giỏ hàng không tồn tại.", null);
            }

            return new ApiResponse<Cart> (true, null, "", cart);
        }

        public async Task<ApiResponse<Cart>> CleanCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return new ApiResponse<Cart> (false, null, "Giỏ hàng không tồn tại.", null);
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return new ApiResponse<Cart> (true, null, "Đã xóa giỏ hàng.", null);
        }
    }
}