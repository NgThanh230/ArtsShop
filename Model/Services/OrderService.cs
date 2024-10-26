using ArtsShop.Data;
using ArtsShop.Model.DTO;
using ArtsShop.Model.Product;
using Azure;
using Microsoft.EntityFrameworkCore;
using System;

namespace ArtsShop.Model.Services
{
    public class OrderService
    {
        private readonly ArtShopDbContext _context;

        public OrderService(ArtShopDbContext context)
        {
            _context = context;
        }

        public async Task<Response> CreateOrder(OrderCreateDto orderDto)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.Id == orderDto.CartId);
            if (cart == null || !cart.CartItems.Any())
            {
                return Response.Failure("The cart is empty");
            }

            decimal subtotal = cart.CartItems.Sum(item => item.Price * item.Quantity);
            decimal discount = cart.CartItems.Sum(item => (item.Price * item.Discount / 100) * item.Quantity);
            decimal tax = (subtotal - discount) * 0.1M;
            decimal total = subtotal - discount + tax;

            var order = new Order
            {
                UserId = orderDto.UserId,
                FullName = orderDto.FullName,
                Address = orderDto.Address,
                Phone = orderDto.Phone,
                Email = orderDto.Email,
                Status = (int)OrderStatus.New,
                PaymentMethod = orderDto.PaymentMethod,
                Subtotal = subtotal,
                Total = total,
                Discount = discount,
                Tax = tax,
                Note = orderDto.Note
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderItems = cart.CartItems.Select(item => new OrderItem
            {
                OrderId = order.Id,
                ProductId = item.ProductId,
                Price = item.Price,
                Discount = item.Discount,
                Quantity = item.Quantity,
                Image = item.Image
            }).ToList();

            _context.OrderItems.AddRange(orderItems);
            _context.CartItems.RemoveRange(cart.CartItems);
            await _context.SaveChangesAsync();

            return Response.success("Order created successfully", order);
        }

        public async Task<Response> UpdateOrderStatus(int orderId, int status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return Response.Failure("Order not found");
            }

            order.Status = status;
            await _context.SaveChangesAsync();

            return Response.success("Order status updated successfully");
        }

        public async Task<Response> GetOrdersByUser(int userId)
        {
            var orders = await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
            return Response.success("User's orders retrieved successfully", orders);
        }

        public async Task<Response> GetOrderDetails(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return Response.Failure("Order not found");
            }

            var orderDetail = new OrderDetailDto
            {
                Id = order.Id,
                UserId = order.UserId,
                FullName = order.FullName,
                Address = order.Address,
                Phone = order.Phone,
                Email = order.Email,
                Status = order.Status,
                PaymentMethod = order.PaymentMethod,
                Subtotal = order.Subtotal,
                Total = order.Total,
                Discount = order.Discount,
                Tax = order.Tax,
                Note = order.Note,
                Items = order.OrderItems.Select(item => new OrderItemDto
                {
                    ProductId = item.ProductId,
                    Price = item.Price,
                    Discount = item.Discount,
                    Quantity = item.Quantity,
                    Image = item.Image
                }).ToList()
            };

            return Response.success("Order details retrieved successfully", orderDetail);
        }
    }
}
