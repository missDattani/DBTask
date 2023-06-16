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
    public class CityAPIController : ApiController
    {
        OrderManagementEntities entities = new OrderManagementEntities();
        [HttpGet]
        [Route("api/CityAPI/DisplayCities")]

        public async Task<IHttpActionResult> Read()
        {
            try
            {
                List<City> cities = await entities.City.ToListAsync();
                if (cities != null && cities.Count() > 0)
                {
                    List<CityModel> cityModelList = CityHelper.BindCtModelListToList(cities);
                    return Ok(cityModelList);
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

        public async Task<IHttpActionResult> GetDetails(int? CtId)
        {
            try
            {
                City city = await entities.City.Where(m => m.CityId == CtId).FirstOrDefaultAsync();
                CityModel cityModel = CityHelper.BindCityModelToCity(city);
                if (cityModel != null)
                {
                    return Ok(cityModel);
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
        public async Task<int> post(CityModel cityModel)
        {
            try
            {
                City city = CityHelper.BindCityModelToCity(cityModel);
                if (cityModel.CityId == 0)
                {
                    var checkCt = await entities.City.AnyAsync(m => m.CityName == cityModel.CityName);
                    if (checkCt)
                    {
                        return 0;
                    }
                    else
                    {
                        entities.City.Add(city);
                        await entities.SaveChangesAsync();
                        return 1;
                    }
                }
                else
                {
                    entities.Entry(city).State = EntityState.Modified;
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
        public async Task<int> Delete(int CtId)
        {
            try
            {
                var res = await entities.City.Where(m => m.CityId == CtId).FirstOrDefaultAsync();
                if (res != null)
                {
                    entities.City.Remove(res);
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
