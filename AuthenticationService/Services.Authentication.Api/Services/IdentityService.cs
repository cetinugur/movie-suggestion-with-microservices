using System.Net;
using Microsoft.AspNetCore.Identity;
using Services.Authentication.Model.Entities;
using Services.Shared.Authentication;
using Services.Shared.Dictionaries;
using Services.Shared.Models;

namespace Services.Authentication.Api.Services
{
    public class IdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AuthenticationServerHelper _authenticationServerHelper;
        private readonly SignInManager<AppUser> _signInManager;

        public IdentityService(UserManager<AppUser> userManager, AuthenticationServerHelper authenticationServerHelper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _authenticationServerHelper = authenticationServerHelper;
            _signInManager = signInManager;
        }

        public async Task<ApiResult> Login(LoginModel model)
        {

            var user = _userManager.Users.FirstOrDefault(x => x.UserName == model.UserName && x.EmailConfirmed);
            if (user == null)
                return new ApiResult(HttpStatusCode.NotFound, AuthDictionary.UserNotFound);

            var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!checkPassword.Succeeded)
            {
                await _userManager.AccessFailedAsync(user);
                return new ApiResult(HttpStatusCode.Unauthorized, AuthDictionary.IncorrectPassword);
            }

            var token = _authenticationServerHelper.GenerateToken(user.UserName, user.Id);

            return new ApiResult(HttpStatusCode.OK, token);

        }

        public async Task<ApiResult> Register(RegisterUserModel model)
        {

            var user = _userManager.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user != null)
                return new ApiResult(HttpStatusCode.Conflict, AuthDictionary.EmailAddressExist);

            var appUser = new AppUser()
            {
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                EmailConfirmed = true,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (!result.Succeeded)
                return new ApiResult(HttpStatusCode.BadRequest, result.Errors.ToString() ?? AuthDictionary.UserCannotCreated);

            return new ApiResult(HttpStatusCode.OK);

        }

        public Task<ApiResult> ForgotPassword()
        {
            // TODO : implement for avoid of an antipattern
            throw new NotImplementedException();
        }

        public Task<ApiResult> ResetPassword()
        {
            // TODO : implement for avoid of an antipattern
            throw new NotImplementedException();
        }

        public Task<ApiResult> ValidateEmail()
        {
            // TODO : implement for avoid of an antipattern
            throw new NotImplementedException();
        }
    }
}
