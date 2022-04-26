using Microsoft.AspNetCore.Http;
using Services.Shared.Dictionaries;
using Services.Shared.Models;

namespace Services.Shared.Authentication.Helper
{
    public class HttpContextHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser CurrentUser
        {
            get
            {
                var user = new CurrentUser();
                if (_httpContextAccessor.HttpContext != null)
                {
                    var claims = _httpContextAccessor.HttpContext.User;

                    user.Id = Convert.ToInt32(claims.FindFirst(AuthDictionary.UserId)?.Value);
                    user.Email = claims.FindFirst(AuthDictionary.Email)?.Value;
                    user.AccessToken = claims.FindFirst(AuthDictionary.AccessToken)?.Value;
                    user.RefreshToken = claims.FindFirst(AuthDictionary.RefreshToken)?.Value;
                    user.RefreshTokenExpires = Convert.ToDateTime(claims.FindFirst(AuthDictionary.RefreshTokenExpires)?.Value);
                    user.AccessTokenExpires = Convert.ToDateTime(claims.FindFirst(AuthDictionary.AccessTokenExpires)?.Value);
                }

                return user;
            }
        }
    }
}
