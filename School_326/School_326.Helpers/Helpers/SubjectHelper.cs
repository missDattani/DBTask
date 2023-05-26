using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Helpers.Helpers
{
    public class SubjectHelper
    {
        public static Subject ConvertSubject(SubjectModel subjectM)
        {
            Subject sub = new Subject();
            sub.SubId = subjectM.SubId;
            sub.SubjectName = subjectM.SubjectName;
            return sub;
        }

        public static SubjectModel ConvertSubjectM(Subject subject)
        {
            SubjectModel subM = new SubjectModel();
            subM.SubId = subject.SubId;
            subM.SubjectName = subject.SubjectName;
            return subM;
        }
    }
}
