using Microsoft.EntityFrameworkCore;
using MyO_Backend.Communication;
using MyO_Backend.Connection;
using MyO_Backend.Models;

namespace MyO_Backend.Services
{
    public interface IOrderService
    {
        Task<InnerResponse> GetAllOrders();
        Task<InnerResponse> GetAllOrdersByUserId(int id);
        Task<InnerResponse> GetOrderById(int id);
        Task<InnerResponse> SaveOrder(Order order);
        Task<InnerResponse> DeleteOrder(int id);
    }
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(MyODbContext context) : base(context)
        {
        }

        public async Task<InnerResponse> DeleteOrder(int id)
        {
            var existingOrder = await GetOrderById(id);

            if (existingOrder.Data == null)
                return new InnerResponse(true, PostMessage(MessageType.Error), null);

            var order = (Order)existingOrder.Data;
            order.IsDeleted = true;

            try
            {
                _context.Update(order);
                await SaveAsync();

                return new InnerResponse(true, null, order);

            }
            catch (Exception ex)
            {
                return new InnerResponse(false, PostMessage(ex), null);
            }
        }

        public async Task<InnerResponse> GetAllOrders()
        {
            var orders = await _context.Order
                .Include(x => x.OrderDetail)
                .ThenInclude(x => x.Product)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

            return new InnerResponse(true, PostMessage(MessageType.Info), orders);
        }

        public async Task<InnerResponse> GetAllOrdersByUserId(int id)
        {
            var orders = await _context.Order
                .Include(x => x.OrderDetail)
                .ThenInclude(x => x.Product)
                .OrderByDescending(x => x.CreatedAt)
                .Where(x => x.UserId == id)
                .ToListAsync();

            return new InnerResponse(true, PostMessage(MessageType.Info), orders);
        }

        public async Task<InnerResponse> GetOrderById(int id)
        {
            var order = await _context.Order
                .Include(x => x.OrderDetail)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.OrderId == id);                

            return new InnerResponse(true, PostMessage(MessageType.Info), order);
        }

        public async Task<InnerResponse> SaveOrder(Order order)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                float orderTotalAmount = 0;                
                for (int i = 0; i < order.OrderDetail.Count; i++)
                {                    
                    order.OrderDetail.ElementAt(i).TotalAmount = order.OrderDetail.ElementAt(i).Quantity
                        * order.OrderDetail.ElementAt(i).Amount;
                    orderTotalAmount += order.OrderDetail.ElementAt(i).TotalAmount;
                }

                order.TotalAmount = orderTotalAmount;
                await _context.Order.AddAsync(order);

                await SaveAsync();

                transaction.Commit();

                return new InnerResponse(true, null, order);
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                return new InnerResponse(false, PostMessage(ex), null);
            }
        }
    }
}
