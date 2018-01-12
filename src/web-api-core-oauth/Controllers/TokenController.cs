using System;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Models.OAuth;

namespace webApi.Controllers
{
    [Route("api/token")]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;

        public TokenController(ITokenProvider tokenProvider) // We'll create this later, don't worry.
        {
            _tokenProvider = tokenProvider;
        }

        public JsonWebToken Post(LoginModel loginModel)
        {
            // Authenticate depending on the grant type.
            User user = loginModel.grant_type == "refresh_token" ? GetUserByToken(loginModel.refresh_token) : GetUserByCredentials(loginModel.client_id, loginModel.client_secret);

            if (user == null)
                throw new UnauthorizedAccessException("No!");

            int ageInMinutes = 20;  // However long you want...

            DateTime expiry = DateTime.UtcNow.AddMinutes(ageInMinutes);

            var token = new JsonWebToken
            {
                access_token = _tokenProvider.CreateToken(user, expiry),
                expires_in = ageInMinutes * 60
            };

            if (loginModel.grant_type != "refresh_token")
                token.refresh_token = GenerateRefreshToken(user);

            return token;
        }

        private User GetUserByToken(string refreshToken)
        {
            // TODO: Check token against your database.
            if (refreshToken == "test")
                return new User { Username = "test" };

            return null;
        }

        private User GetUserByCredentials(string username, string password)
        {
            // TODO: Check username/password against your database.
            if (username == password)
                return new User { Username = username };

            return null;
        }

        private string GenerateRefreshToken(User user)
        {
            // TODO: Create and persist a refresh token.
            return "test";
        }
    }
}
