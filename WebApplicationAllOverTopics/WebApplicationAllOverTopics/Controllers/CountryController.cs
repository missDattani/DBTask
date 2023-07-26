using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAllOverTopics.Common.Helpers;
using WebApplicationAllOverTopics.Model.ViewModel;
using WebApplicationAllOverTopics.Services.Country;

namespace WebApplicationAllOverTopics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region Fields
        public readonly ICountryServices countryServices;
        #endregion

        #region Constructor
        public CountryController(ICountryServices countryServices)
        {
            this.countryServices = countryServices;
        }
        #endregion

        #region Methods
        [Authorize(Roles = "Admin,User")]
        [HttpGet("CountryList")]
        
        public async Task<ApiResponse<CountryModel>> GetCountryList()
        {
            try
            {
                ApiResponse<CountryModel> response = new ApiResponse<CountryModel>() { Result = new List<CountryModel>() };
                var data = await countryServices.GetCountries();
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
