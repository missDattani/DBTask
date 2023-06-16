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
    public class StudentAPIController : ApiController
    {
        OrderManagementEntities entities = new OrderManagementEntities();

        [HttpGet]
        [Route("api/StudentAPI/DisplayStudents")]

        public async Task<IHttpActionResult> Read()
        {
            try
            {
                List<Student> students = await entities.Student.ToListAsync();
                if (students != null && students.Count() > 0)
                {
                    List<StudentModel> studentModelList = StudentHelper.BindStuModelListToList(students);
                    return Ok(studentModelList);
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
