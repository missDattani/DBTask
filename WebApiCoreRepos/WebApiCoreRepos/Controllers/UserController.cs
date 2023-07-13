using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApiCoreRepos.Common.Helpers;
using WebApiCoreRepos.Filter;
using WebApiCoreRepos.Model.ViewModel;
using WebApiCoreRepos.Services.JwtAuthentication;
using WebApiCoreRepos.Services.User;

namespace WebApiCoreRepos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Fields
        private IUserServices userServices;
        private IJWTAuthServices jwtAuthServices;
        private readonly JWTAuthenticationModel authModel;
        #endregion

        #region Constructor
        public UserController(IUserServices userServices, IJWTAuthServices jwtAuthServices,IOptions<JWTAuthenticationModel> authModel)
        {
            this.userServices = userServices;
            this.authModel = authModel.Value;
            this.jwtAuthServices = jwtAuthServices;
        }
        #endregion

        #region Methods
        [HttpPost("UserLogin")]
        public async Task<ApiPostResponse<UserModel>> Login(LoginModel loginModel)
        {
            ApiPostResponse<UserModel> response = new ApiPostResponse<UserModel>();
            var result = await userServices.LoginUser(loginModel);
            if (result != null)
            {
             
                string JWTtoken = jwtAuthServices.GenerateJwtToken(result.EMAIL, result.USERID.ToString(), authModel.SecretKey, authModel.ValidateMin);
                if (!string.IsNullOrEmpty(JWTtoken))
                {
                    HttpContext.Session.SetString("userToken", JWTtoken);
                    response.Success = true;
                    response.Message = ApiMessages.LoginSuccess;
                    response.token = JWTtoken;
                }
              
            }
            else
            {
                response.Success =false;
                response.Message = ApiMessages.LoginFailed;
            }
            return response;
        }

        [HttpPost("RegisterUser")]
        public async Task<BaseApiResponse> SignUp([FromBody]UserModel user)
        {
            BaseApiResponse response = new BaseApiResponse();
            var result = await userServices.RegisterUser(user);
            if (result != 0)
            {
                response.Success = true;
                response.Message = ApiMessages.RegisterSuccess;
            }
            else
            {
                response.Success = false;
                response.Message = ApiMessages.RegisterFailed;
            }
            return response;
        }

        [Authorize]
        //[TypeFilter(typeof(JwtTokenFilter))]
        [HttpGet("UserList")]
        public async Task<ApiResponse<UserModel>> GetUserList()
        {
          
            ApiResponse<UserModel> response = new ApiResponse<UserModel>() { Result = new List<UserModel>() };
            var result = await userServices.GetUsers();
            if(result != null)
            {
                response.Result = result;
            }
            response.Success = true;
            return response;
        }
        #endregion
    }
}
