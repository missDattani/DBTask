using School_326.Models.Context;
using School_326.Models.Models;
using School_326.Repository.Repository;
using School_326.Repository.Services;
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
       
        public ICountryInterface coInterface;

        public CountryApiController(ICountryInterface coInterface)
        {
            this.coInterface = coInterface;
        }

        [HttpGet]
        public IHttpActionResult GetCountries()
        {
            try { 
            return Ok(coInterface.DiplayCountries());
            }
            catch(Exception e)
            {
                throw e;
            }
        }

  
        public IHttpActionResult GetByID(int CoId)
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
                return Ok(coInterface.RemoveCountry(CoId));
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
