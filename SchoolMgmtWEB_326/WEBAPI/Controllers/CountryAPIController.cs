using SchoolMgmtWEB_326.Helpers.Helpers;
using SchoolMgmtWEB_326.Models.Context;
using SchoolMgmtWEB_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WEBAPI.Controllers
{
    public class CountryAPIController : ApiController
    {
        OrderManagementEntities entities = new OrderManagementEntities();

        [HttpGet]
        [Route("api/CountryAPI/DisplayCountry")]

        public async Task<IHttpActionResult> Read()
        {
            try
            {
                List<Country> countries = await entities.Country.ToListAsync();
                if (countries != null && countries.Count() > 0)
                {
                    List<CountryModel> countryModelList = CountryHelper.BindCoModelListToList(countries);
                    return Ok(countryModelList);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetDetails(int? CoId)
        {
            try
            {
                Country country = await entities.Country.Where(m => m.CountryId == CoId).FirstOrDefaultAsync();
                CountryModel countryModel = CountryHelper.BindCountryToCountryModel(country);
                if (countryModel != null)
                {
                    return Ok(countryModel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public async Task<int> post(CountryModel countryModel)
        {
            try
            {
                Country country = CountryHelper.BindCountryModelToCountry(countryModel);
                if (countryModel.CountryId == 0)
                {
                    var checkCo = await entities.Country.AnyAsync(m => m.CountryName == countryModel.CountryName);
                    if (checkCo)
                    {
                        return 0;
                    }
                    else
                    {
                        entities.Country.Add(country);
                        await entities.SaveChangesAsync();
                        return 1;
                    }
                }
                else
                {
                    entities.Entry(country).State = EntityState.Modified;
                    await entities.SaveChangesAsync();
                    return 1;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
          
        }

        [HttpDelete]
        public async Task<int> Delete(int CoId)
        {
            try
            {
                var result = await entities.Country.Where(m => m.CountryId == CoId).FirstOrDefaultAsync();
                if (result != null)
                {
                    entities.Country.Remove(result);
                    await entities.SaveChangesAsync();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
       
    }
}
