using Microsoft.Extensions.Options;
using RestSharp;
using Services.Authentication.Client.Base;
using Services.Shared.Authentication.Helper;
using Services.Shared.Client;
using Services.Shared.Models;

namespace Services.Authentication.Client
{
    public class AuthenticationClient : ClientBase
    {
        public AuthenticationClient(HttpContextHelper contextHelper, IOptions<AuthenticationClientOptions> options)
            : base(contextHelper.CurrentUser.AccessToken, options.Value)
        {

        }

        public ServiceResult<TokenResponseModel> Login(LoginModel model)
        {
            var request = CreateRequestAnonymous<ServiceResult<TokenResponseModel>>(AuthenticationApiConstants.AuthenticationLogin, model, Method.Post);
            return HandleResponse(request);
        }

        public ServiceResult Register(RegisterUserModel model)
        {
            var request = CreateRequestAnonymous<ServiceResult>(AuthenticationApiConstants.AuthenticationRegister, model, Method.Post);
            return HandleResponse(request);
        }

    }
}
