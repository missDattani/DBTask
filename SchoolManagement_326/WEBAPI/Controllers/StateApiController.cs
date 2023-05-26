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
    public class StateApiController : ApiController
    {
        private IStateInterface stInterface;

        public StateApiController(IStateInterface stInterface)
        {
            this.stInterface = stInterface;
        }

        [HttpGet]
        public IHttpActionResult GetStates()
        {
            try
            {
                return Ok(stInterface.DisplayStates());
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IHttpActionResult GetStateById(int StId)
        {
            try
            {
                return Ok(stInterface.DisplayStateById(StId));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public IHttpActionResult StateIns(StateModel StModel)
        {
            try
            {
                return Ok(stInterface.InsertState(StModel));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPut]
        public IHttpActionResult StateEdit(StateModel state)
        {
            try
            {
                return Ok(stInterface.EditState(state));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpDelete]
        public IHttpActionResult StateDelete(int StId)
        {
            try
            {
                if (stInterface.RemoveState(StId) == 1)
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
