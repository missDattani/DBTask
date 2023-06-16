using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolMgmtWEB_326.SessionHelper
{
    public class GetAllData
    {
        public static int UserId
        {
            get
            {
                return HttpContext.Current.Session["UserId"] == null ? 0 : (int)HttpContext.Current.Session["UserId"];
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static string FirstName
        {
            get
            {
                return HttpContext.Current.Session["FirstName"] == null ? null : (string)HttpContext.Current.Session["FirstName"];
            }
            set
            {
                HttpContext.Current.Session["FirstName"]=value;
            }
        }

        public static string LastName
        {
            get
            {
                return HttpContext.Current.Session["LastName"] == null ? null : (string)HttpContext.Current.Session["LastName"];
            }
            set
            {
                HttpContext.Current.Session["LastName"] = value;
            }
        }

        public static string Email
        {
            get
            {
                return HttpContext.Current.Session["Email"] == null ? null : (string)HttpContext.Current.Session["Email"];
            }
            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }

        public static string Role
        {
            get
            {
                return HttpContext.Current.Session["Role"] == null ? null : (string)HttpContext.Current.Session["Role"];
            }
            set
            {
                HttpContext.Current.Session["Role"] = value;
            }
        }
    }
}