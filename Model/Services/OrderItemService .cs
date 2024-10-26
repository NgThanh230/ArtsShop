using ArtsShop.Data;
using ArtsShop.Model.DTO;
using ArtsShop.Model.Product;
using Microsoft.EntityFrameworkCore;

namespace ArtsShop.Model.Services
{
    public class OrderItemService
    {
        private readonly ArtShopDbContext _context;

        public OrderItemService(ArtShopDbContext context)
        {
            _context = context;
        }

        public async Task<Response> GetOrderItemsByOrderId(int orderId)
        {
            var orderItems = await _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();

            return Response.success("Order items retrieved successfully.", orderItems);
        }

        public async Task<Response> CreateOrderItem(OrderItemCreateDto dto)
        {
            var orderItem = new OrderItem
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Price = dto.Price,
                Discount = dto.Discount,
                Quantity = dto.Quantity,
                Image = dto.Image
            };

            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return Response.success("Order item created successfully.", orderItem);
        }
    }
}
