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
    public class StateAPIController : ApiController
    {
        OrderManagementEntities entities = new OrderManagementEntities();

        [HttpGet]
        [Route("api/StateAPI/DisplayStates")]

        public async Task<IHttpActionResult> Read()
        {
            try
            {
                List<States> states = await entities.States.ToListAsync();
                if (states != null && states.Count() > 0)
                {
                    List<StateModel> stateModelList = StateHelper.BindStModelListToList(states);
                    return Ok(stateModelList);
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
        public async Task<IHttpActionResult> GetDetails(int? StId)
        {
            try
            {
                States states = await entities.States.Where(m => m.StateId == StId).FirstOrDefaultAsync();
                StateModel stateModel = StateHelper.BindStateToStateModel(states);
                if (stateModel != null)
                {
                    return Ok(stateModel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e )
            {

                throw e;
            }
        }

        [HttpPost]
        public async Task<int> post(StateModel stateModel)
        {
            try
            {
                States states = StateHelper.BindStateModelToState(stateModel);
                if (stateModel.StateId == 0)
                {
                    var checkSt = await entities.States.AnyAsync(m => m.StateName == stateModel.StateName);
                    if (checkSt)
                    {
                        return 0;
                    }
                    else
                    {
                        entities.States.Add(states);
                        await entities.SaveChangesAsync();
                        return 1;
                    }
                }
                else
                {
                    entities.Entry(states).State = EntityState.Modified;
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
        public async Task<int> Delete(int StId)
        {
            try
            {
                var res = await entities.States.Where(m => m.StateId == StId).FirstOrDefaultAsync();
                if (res != null)
                {
                    entities.States.Remove(res);
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
