using Microsoft.EntityFrameworkCore;
using MyO_Backend.Communication;
using MyO_Backend.Connection;

namespace MyO_Backend.Services
{
    public interface IProductService
    {
        Task<InnerResponse> GetAllProducts();
    }
    public class ProductService : BaseService, IProductService
    {
        public ProductService(MyODbContext context) : base(context)
        {
        }

        public async Task<InnerResponse> GetAllProducts()
        {
            var products = await _context.Product.ToListAsync();

            return new InnerResponse(true, PostMessage(MessageType.Info), products);
        }
    }
}
