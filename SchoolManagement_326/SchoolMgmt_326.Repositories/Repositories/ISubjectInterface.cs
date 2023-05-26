using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Repositories.Repositories
{
    public interface ISubjectInterface
    {
        List<Subject> DisplaySubjects();
        Subject DisplaySubjectById(int SubId);

        int InsertSubject(SubjectModel sub);

        SubjectModel EditSubject(int SubId);
        int EditSubject(SubjectModel sub);

        int RemoveSubject(int SubId);
        IEnumerable<Subject> SelectSubject();
    }
}
