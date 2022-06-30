using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyO_Backend.Communication;
using MyO_Backend.Resources;
using MyO_Backend.Services;
using System.Net;

namespace MyO_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService ProductService;
        public ProductController(IMapper mapper, IProductService productService) : base(mapper)
        {
            ProductService = productService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ApiResponse<List<ProductResource>>> GetAllOrders()
        {
            var response = await ProductService.GetAllProducts();
            var ProductResources = _mapper.Map<List<ProductResource>>(response.Data);

            return new ApiResponse<List<ProductResource>>(HttpStatusCode.OK, response.Message, ProductResources);
        }
    }
}
