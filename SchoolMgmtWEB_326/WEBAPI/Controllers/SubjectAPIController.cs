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
    public class SubjectAPIController : ApiController
    {
        OrderManagementEntities entities = new OrderManagementEntities();
        [HttpGet]
        [Route("api/SubjectAPI/DisplaySubjects")]
        public async Task<IHttpActionResult> Read()
        {
            try
            {
                List<Subjects> subjects = await entities.Subjects.ToListAsync();
                if (subjects != null && subjects.Count() > 0)
                {
                    List<SubjectModel> subjectModelList = SubjectHelper.BindSubModelListToList(subjects);
                    return Ok(subjectModelList);
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
    }
}
