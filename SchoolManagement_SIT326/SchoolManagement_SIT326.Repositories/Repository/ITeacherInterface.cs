using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Repositories.Repository
{
    public interface ITeacherInterface
    {
        List<TeacherModel> DisplayTeachers();
        Teachers DisplayTeacherById(int? TecId);
        int InsTeacher(TeacherModel tecM, int? TecId);
        int RemoveTeacher(int TecId);
    }
}
