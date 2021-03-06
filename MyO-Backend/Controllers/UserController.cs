using AutoMapper;
using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyO_Backend.Authentication;
using MyO_Backend.Communication;
using MyO_Backend.Models;
using MyO_Backend.Resources;
using MyO_Backend.Services;
using MyO_Backend.ViewModels;
using System.Net;
using BC = BCrypt.Net.BCrypt;

namespace MyO_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        public UserController(IMapper mapper, IUserService userService, IOrderService orderService) : base(mapper)
        {
            _userService = userService;
            _orderService = orderService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResponse<List<UserResource>>> GetAllUsers()
        {
            var response = await _userService.GetUsers();
            var usersResource = _mapper.Map<List<UserResource>>(response.Data);

            return new ApiResponse<List<UserResource>>(HttpStatusCode.OK, response.Message, usersResource);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ApiResponse<UserResource>> GetUserById(int id)
        {
            var response = await _userService.GetUserById(id);
            var userResource = _mapper.Map<UserResource>(response.Data);

            return new ApiResponse<UserResource>(HttpStatusCode.OK, response.Message, userResource);
        }

        [AllowAnonymous]
        [HttpGet("{id}/Order")]
        public async Task<ApiResponse<List<OrderResource>>> GetOrdersByUserId(int id)
        {
            var response = await _orderService.GetAllOrdersByUserId(id);
            var OrdersResource = _mapper.Map<List<OrderResource>>(response.Data);

            return new ApiResponse<List<OrderResource>>(HttpStatusCode.OK, response.Message, OrdersResource);
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<ApiResponse<AuthenticateResponse>> Authenticate([FromBody] AuthenticateRequest model)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());

            var response = await _userService.Authenticate(model);
            if (!response.Success)
            {
                throw new ApiException(response.Message);
            }

            var responseData = response.Data as AuthenticateResponse;
            var userResource = _mapper.Map<UserResource>(responseData.User);

            return new ApiResponse<AuthenticateResponse>(HttpStatusCode.OK, response.Message, new AuthenticateResponse(userResource, responseData.Token));
        }

        [AllowAnonymous]
        [HttpGet("IdentifyByToken")]
        public async Task<ApiResponse<UserResource>> IdentifyUserByToken()
        {
            string authHeader = Request.Headers["Authorization"];
            var response = await _userService.IdentifyUser(authHeader);
            if (!response.Success)
            {
                throw new ApiException(response.Message);
            }

            var userResource = _mapper.Map<UserResource>(response.Data);

            return new ApiResponse<UserResource>(HttpStatusCode.OK, response.Message, userResource);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<UserResource>> SaveUser(UserViewModel user)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());

            user.Password = BC.HashPassword(user.Password, 10);
            var newUser = _mapper.Map<UserViewModel, User>(user);
            var response = await _userService.SaveUser(newUser);

            if (!response.Success)
                throw new ApiException(response.Message);

            var userResource = _mapper.Map<UserResource>(response.Data);

            return new ApiResponse<UserResource>(HttpStatusCode.OK, response.Message, userResource);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ApiResponse<UserResource>> UpdateUser(int id, UserViewModel user)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());

            user.Password = BC.HashPassword(user.Password, 10);
            var editUser = _mapper.Map<UserViewModel, User>(user);
            var response = await _userService.UpdateUser(id, editUser);

            if (!response.Success)
                throw new ApiException(response.Message);

            var userResource = _mapper.Map<UserResource>(response.Data);

            return new ApiResponse<UserResource>(HttpStatusCode.OK, response.Message, userResource);
        }
    }
}
