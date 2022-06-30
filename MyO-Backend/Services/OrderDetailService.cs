using Microsoft.EntityFrameworkCore;
using MyO_Backend.Communication;
using MyO_Backend.Connection;
using MyO_Backend.Models;

namespace MyO_Backend.Services
{
    public interface IOrderDetailService
    {
        Task<InnerResponse> GetOrderDetailsByOrderId(int id);
    }
    public class OrderDetailService : BaseService, IOrderDetailService
    {
        public OrderDetailService(MyODbContext context) : base(context)
        {
        }

        public async Task<InnerResponse> GetOrderDetailsByOrderId(int id)
        {
            var orderDetails = await _context.OrderDetail
                .Where(x => x.OrderId == id)
                .Include(x => x.Product).ToListAsync();

            return new InnerResponse(true, PostMessage(MessageType.Info), orderDetails);
        }
    }
}
