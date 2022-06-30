using MyO_Backend.Authentication;
using MyO_Backend.Communication;
using MyO_Backend.Connection;
using MyO_Backend.Models;

namespace MyO_Backend.Services
{
    public interface IUserService
    {
        Task<InnerResponse<User>> Authenticate(AuthenticateRequest model);
        Task<InnerResponse<User>> IdentifyUser(string authHeader);
        Task<InnerResponse<User>> GetUsers();
        Task<InnerResponse<User>> GetUserById(int id);
        Task<InnerResponse<User>> SaveUser(User user);
        Task<InnerResponse<User>> UpdateUser(User user);
    }
    public class UserService : BaseService, IUserService
    {
        public UserService(MyODbContext context) : base(context)
        {
        }

        public Task<InnerResponse<User>> Authenticate(AuthenticateRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<InnerResponse<User>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InnerResponse<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<InnerResponse<User>> IdentifyUser(string authHeader)
        {
            throw new NotImplementedException();
        }

        public Task<InnerResponse<User>> SaveUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<InnerResponse<User>> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
