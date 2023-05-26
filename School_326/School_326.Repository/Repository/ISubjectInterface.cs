using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Repository.Repository
{
    public interface ISubjectInterface
    {
        List<Subject> DisplaySubject();
        Subject DisplaySubjectById(int SubId);

        int InsertSubject(SubjectModel subject);

        int EditSubject(SubjectModel subject);
        SubjectModel EditSubject(int SubId);

        int RemoveSubject(int SubId);
        IEnumerable<Subject> SelectSubject();
    }
}
