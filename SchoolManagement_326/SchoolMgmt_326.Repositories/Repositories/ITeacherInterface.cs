using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Repositories.Repositories
{
    public interface ITeacherInterface
    {
        IEnumerable<SP_GetTeacherDetails1_Result> DisplayTeachers();

        Teacher DisplayTeacherById(int TecId);

        int InsertTeacher(TeacherModel std);

        TeacherModel EditTeacher(int TecId);
        int EditTeacher(TeacherModel tec);

        int RemoveTeacher(int TecId);
        IEnumerable<Teacher> SelectTeacher();
    }
}
