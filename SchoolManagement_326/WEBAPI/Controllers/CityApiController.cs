using SchoolMgmt_326.Model.Model;
using SchoolMgmt_326.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEBAPI.Controllers
{
    public class CityApiController : ApiController
    {
        private ICityInterface ctInterface;

        public CityApiController(ICityInterface ctInterface)
        {
            this.ctInterface = ctInterface;
        }

        [HttpGet]
        public IHttpActionResult GetCity()
        {
            try
            {
                return Ok(ctInterface.DisplayCities());
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IHttpActionResult GetCityById(int CiId)
        {
            try
            {
                return Ok(ctInterface.DisplayCityById(CiId));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public IHttpActionResult CityIns(CityModel ctModel)
        {
            try
            {
                return Ok(ctInterface.InsertCities(ctModel));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPut]
        public IHttpActionResult CityEdit(CityModel city)
        {
            try
            {
                return Ok(ctInterface.EditCity(city));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpDelete]
        public IHttpActionResult CityDelete(int CiId)
        {
            try
            {
               if(ctInterface.RemoveCity(CiId) == 1) 
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
               
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
