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
    public class SubjectApiController : ApiController
    {
       
            private ISubjectInterface subInterface;

            public SubjectApiController(ISubjectInterface subInterface)
            {
                this.subInterface = subInterface;
            }

            [HttpGet]
            public IHttpActionResult GetSubjects()
            {
                try
                {
                    return Ok(subInterface.DisplaySubjects());
                }
                catch (Exception e)
                {
                    throw e;
                }
            }


            public IHttpActionResult GetSubjectById(int SubId)
            {
                try
                {
                    return Ok(subInterface.DisplaySubjectById(SubId));
                }
                catch (Exception e)
                {

                    throw e;
                }
            }

            [HttpPost]
            public IHttpActionResult SubjectIns(SubjectModel SubModel)
            {
                try
                {
                    return Ok(subInterface.InsertSubject(SubModel));
                }
                catch (Exception e)
                {

                    throw e;
                }
            }

            [HttpPut]
            public IHttpActionResult SubjectEdit(SubjectModel subModel)
            {
                try
                {
                    return Ok(subInterface.EditSubject(subModel));
                }
                catch (Exception e)
                {

                    throw e;
                }
            }

            [HttpDelete]
            public IHttpActionResult SubjectDelete(int SubId)
            {
                try
                {
                    return Ok(subInterface.RemoveSubject(SubId));
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }
}
