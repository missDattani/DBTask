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
    public class StudentApiController : ApiController
    {
        private IStudentInterface stdInterface;

        public StudentApiController(IStudentInterface stdInterface)
        {
            this.stdInterface = stdInterface;
        }

        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            try
            {
                return Ok(stdInterface.DisplayStudents());
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public IHttpActionResult GetStudentById(int SId)
        {
            try
            {
                return Ok(stdInterface.DisplayStudentById(SId));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public IHttpActionResult StudentIns(StudentModel stdModel)
        {
            try
            {
                return Ok(stdInterface.InsertStudent(stdModel));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPut]
        public IHttpActionResult StudentEdit(StudentModel stdModel)
        {
            try
            {
                return Ok(stdInterface.EditStudent(stdModel));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpDelete]
        public IHttpActionResult StudentDelete(int SId)
        {
            try
            {
                return Ok(stdInterface.RemoveStudent(SId));
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
