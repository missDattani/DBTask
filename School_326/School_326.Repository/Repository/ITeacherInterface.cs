using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Repository.Repository
{
    public interface ITeacherInterface
    {
        List<Teacher> DisplayTeachers();
        Teacher DisplayTeacherById(int TecId);
        int InsertTeacher(TeacherModel tecM);

        int EditTeacher(TeacherModel teacher);
        TeacherModel EditTeacher(int TecId);
        int RemoveTeacher(int TecId);
        IEnumerable<Teacher> SelectTeachers();
    }
}
