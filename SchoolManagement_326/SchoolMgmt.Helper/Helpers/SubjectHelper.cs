using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt.Helper.Helpers
{
    public class SubjectHelper
    {
        public static SubjectModel ConvertSubject(Subject sub)
        {try
            {
                SubjectModel subject = new SubjectModel();
                subject.SubId = sub.SubId;
                subject.SubjectName = sub.SubjectName;
                return subject;
            }
            catch (Exception e) { throw e; }
        }
    }
}
