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
    public class CountryApiController : ApiController
    {
        private ICountryInterface coInterface;

        public CountryApiController(ICountryInterface coInterface)
        {
            this.coInterface = coInterface;
        }


      public IHttpActionResult GetCountries()
        {
            try
            {
                return Ok(coInterface.DisplayCountries());
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public IHttpActionResult GetCountryById(int CoId)
        {
            try
            {
                return Ok(coInterface.DisplayCountryById(CoId));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public IHttpActionResult CountryIns(CountryModel CoModel)
        {
            try
            {
                return Ok(coInterface.InsertCountry(CoModel));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPut]
        public IHttpActionResult CountryEdit(CountryModel CoModel)
        {
            try
            {
                return Ok(coInterface.EditCountry(CoModel));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpDelete]
        public IHttpActionResult CountryDelete(int CoId)
        {
            try
            {
                if (coInterface.DeleteCountry(CoId) == 1)
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
