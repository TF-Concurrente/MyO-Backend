using AutoMapper;
using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyO_Backend.Communication;
using MyO_Backend.Models;
using MyO_Backend.Resources;
using MyO_Backend.Services;
using MyO_Backend.ViewModels;
using System.Net;

namespace MyO_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IOrderService OrderService;
        private readonly IOrderDetailService OrderDetailService;

        public OrderController(IMapper mapper, IOrderService orderService, IOrderDetailService orderDetailService) : base(mapper)
        {
            OrderService = orderService;
            OrderDetailService = orderDetailService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ApiResponse<List<OrderResource>>> GetAllOrders()
        {
            var response = await OrderService.GetAllOrders();
            var orderResources = _mapper.Map<List<OrderResource>>(response.Data);

            return new ApiResponse<List<OrderResource>>(HttpStatusCode.OK, response.Message, orderResources);
        }

        [Authorize]
        [HttpGet("{id}/OrderDetail")]
        public async Task<ApiResponse<List<OrderDetailResource>>> GetAllOrdersDetailByOrder(int id)
        {
            var response = await OrderDetailService.GetOrderDetailsByOrderId(id);
            var orderDetailResources = _mapper.Map<List<OrderDetailResource>>(response.Data);

            return new ApiResponse<List<OrderDetailResource>>(HttpStatusCode.OK, response.Message , orderDetailResources);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ApiResponse<OrderResource>> GetOrderById(int id)
        {
            var response = await OrderService.GetOrderById(id);
            var orderResources = _mapper.Map<OrderResource>(response.Data);

            return new ApiResponse<OrderResource>(HttpStatusCode.OK, response.Message, orderResources);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ApiResponse<OrderResource>> DeleteOrder(int id)
        {
            var response = await OrderService.DeleteOrder(id);
            var orderResources = _mapper.Map<OrderResource>(response.Data);

            return new ApiResponse<OrderResource>(HttpStatusCode.OK, response.Message, orderResources);
        }


        [Authorize]
        [HttpPost]
        public async Task<ApiResponse<OrderResource>> SaveOrder(OrderViewModel order)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());

            var newOrder = _mapper.Map<OrderViewModel, Order>(order);
            var response = await OrderService.SaveOrder(newOrder);

            if (!response.Success)
                throw new ApiException(response.Message);

            var orderResource = _mapper.Map<Order, OrderResource>((Order)response.Data);

            return new ApiResponse<OrderResource>(HttpStatusCode.OK, response.Message , orderResource);
        }
    }
}
