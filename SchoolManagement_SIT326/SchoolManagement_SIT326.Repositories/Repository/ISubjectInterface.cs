using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Repositories.Repository
{
    public interface ISubjectInterface
    {
        List<SubjectModel> DisplaySubjects();
        Subjects DisplaySubjectById(int? SubId);
        int InsSubject(SubjectModel subModel, int? SubId);
        int RemoveSubject(int SubId);
        IEnumerable<Subjects> SelectSubjects();
    }
}
