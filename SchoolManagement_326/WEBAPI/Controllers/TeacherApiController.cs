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
    public class TeacherApiController : ApiController
    {
        private ITeacherInterface tecInterface;

        public TeacherApiController(ITeacherInterface tecInterface)
        {
            this.tecInterface = tecInterface;
        }

        [HttpGet]
        public IHttpActionResult GetTeachers()
        {
            try
            {
                return Ok(tecInterface.DisplayTeachers());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IHttpActionResult GetTeacherById(int TecId)
        {
            try
            {
                return Ok(tecInterface.DisplayTeacherById(TecId));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public IHttpActionResult TeacherIns(TeacherModel tecModel)
        {
            try
            {
                return Ok(tecInterface.InsertTeacher(tecModel));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPut]
        public IHttpActionResult TeacherEdit(TeacherModel teacher)
        {
            try
            {
                return Ok(tecInterface.EditTeacher(teacher));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpDelete]
        public IHttpActionResult TeacherDelete(int TecId)
        {
            try
            {
                return Ok(tecInterface.RemoveTeacher(TecId));
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
