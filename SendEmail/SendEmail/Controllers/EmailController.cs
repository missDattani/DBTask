using SendEmail.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SendEmail.Controllers
{
    public class EmailController : Controller
    {
        Pooja326MVCEntities entities = new Pooja326MVCEntities(); 
        // GET: Email
         public JsonResult LoadData()
        {
            try
            {
                return Json(entities.Tbl_Email.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public JsonResult InsertEmail(string toEmail,string subject, string body)
         {
            string result = string.Empty;
            try
            {
                Tbl_Email tbl_Email = new Tbl_Email();
                tbl_Email.ToEmail = toEmail;
                tbl_Email.Subject = subject;
                tbl_Email.Body = body;
                entities.Tbl_Email.Add(tbl_Email);
                entities.SaveChanges();
                result = "Data Inserted Successfully";
            }
            catch (Exception e)
            {

                result = e.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteEmail(int Id)
        {
            string result = string.Empty;
            var res = entities.Tbl_Email.Where(m => m.Id == Id).FirstOrDefault();
            if(res != null)
            {
                entities.Tbl_Email.Remove(res);
                entities.SaveChanges();
                result = "Successfully Deleted";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmailById(int Id)
        {
            var getId = entities.Tbl_Email.Where(m => m.Id == Id).FirstOrDefault();
            return Json(getId, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateEmail(string toEmail, string subject, string body, int Id)
        {
            string result = string.Empty;
            try
            {
                Tbl_Email tbl_Email = entities.Tbl_Email.Where(m => m.Id == Id).FirstOrDefault();
                tbl_Email.ToEmail = toEmail;
                tbl_Email.Subject = subject;
                tbl_Email.Body = body;
                entities.Entry(tbl_Email).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                result = "Data Updated Successfully";
            }
            catch (Exception e)
            {

                result = e.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}