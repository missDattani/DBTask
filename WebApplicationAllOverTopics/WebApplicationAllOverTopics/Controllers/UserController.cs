using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;
using WebApplicationAllOverTopics.Common.Helpers;
using WebApplicationAllOverTopics.Model.ViewModel;
using WebApplicationAllOverTopics.Services.JwtAuthentication;
using WebApplicationAllOverTopics.Services.User;

namespace WebApplicationAllOverTopics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Fileds
        public readonly IUserServices userServices;
        public readonly IJwtAuthServices jwtAuthServices;
        private readonly AuthenticationModel authenticationModel;
        #endregion

        #region Constructor
        public UserController(IUserServices userServices,IJwtAuthServices jwtAuthServices ,IOptions<AuthenticationModel> authenticationModel)
        {
            this.userServices = userServices;
            this.authenticationModel = authenticationModel.Value;
            this.jwtAuthServices = jwtAuthServices;
        }
        #endregion

        #region Methods
        [HttpPost("UserLogin")]
        public async Task<ApiPostResponse<UserModel>> Login([FromBody] LoginModel model)
        {
            try
            {
                ApiPostResponse<UserModel> response = new ApiPostResponse<UserModel>();
                var result = await userServices.UserLogin(model);
                if (result != null)
                {
                    string JwtToken = jwtAuthServices.GenerateToken(result.Email, result.RoleName, authenticationModel.SecretKey, authenticationModel.ValidateMin);
                    if(!string.IsNullOrEmpty(JwtToken))
                    {
                       // HttpContext.Session.SetString("userToken",JwtToken);
                        response.Success = true;
                        response.Messages = ApiMessages.SuccessLogin;
                        response.Token = JwtToken;
                    }
                  
                }
                else
                {
                    response.Success = false;
                    response.Messages = ApiMessages.FailedLogin;
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("RegisterUser")]
        public async Task<BaseApiResponse> SignUp(UserModel userModel)
        {
            BaseApiResponse response = new BaseApiResponse();
            var result = await userServices.AddEditUser(userModel);
            if (result != 0)
            {
                response.Success = true;
                response.Messages = ApiMessages.SuccessRegister;
            }
            else
            {
                response.Success = false;
                response.Messages = ApiMessages.FailedRegister;
            }
            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("UserList")]
        public async Task<ApiResponse<UserModel>> GetUserList()
        {
            try
            {
                ApiResponse<UserModel> response = new ApiResponse<UserModel>() { Result = new List<UserModel>() };
                var data = await userServices.GetUsers();
                if (data != null)
                {
                    response.Result = data;
                }
                response.Success = true;
                return response;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
