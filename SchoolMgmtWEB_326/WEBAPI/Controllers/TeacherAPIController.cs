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
    public class TeacherAPIController : ApiController
    {
        OrderManagementEntities entities = new OrderManagementEntities();

        [HttpGet]
        [Route("api/TeacherAPI/DisplayTeachers")]
        public async Task<IHttpActionResult> Read()
        {
            try
            {
                List<Teachers> teachers = await entities.Teachers.ToListAsync();
                if (teachers != null && teachers.Count() > 0)
                {
                    List<TeacherModel> teacherModelList = TeacherHelper.BindTecModelListToList(teachers);
                    return Ok(teacherModelList);
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
