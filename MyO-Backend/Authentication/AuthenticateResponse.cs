using MyO_Backend.Models;
using MyO_Backend.Resources;

namespace MyO_Backend.Authentication
{
    public class AuthenticateResponse
    {
        public User User { get; set; }
        public UserResource UserResource { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            User = user;
            Token = token;
        }

        public AuthenticateResponse(UserResource user, string token)
        {
            UserResource = user;
            Token = token;
        }
    }
}
