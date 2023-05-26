using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Helpers.Helpers
{
    public class TeacherHelper
    {
        public static Teacher ConvertTeacher(TeacherModel teacherM)
        {
            Teacher teacher = new Teacher();
            teacher.TecId = teacherM.TecId;
            teacher.FirstName = teacherM.FirstName;
            teacher.LastName = teacherM.LastName;
            teacher.Address = teacherM.Address;
            teacher.Mobile = teacherM.Mobile;
            teacher.Email = teacherM.Email;
            teacher.Gender = teacherM.Gender;
            teacher.SubjectId = teacherM.SubjectId;
            teacher.CoId = teacherM.CoId;
            teacher.StId = teacherM.StId;
            teacher.CiId = teacherM.CiId;
            return teacher;
        }

        public static TeacherModel ConvertTeacherM(Teacher teacher)
        {
            TeacherModel teacherM = new TeacherModel();
            teacherM.TecId = teacher.TecId;
            teacherM.FirstName = teacher.FirstName;
            teacherM.LastName = teacher.LastName;
            teacherM.Address = teacher.Address;
            teacherM.Mobile = teacher.Mobile;
            teacherM.Email = teacher.Email;
            teacherM.Gender = teacher.Gender;
            teacherM.SubjectId = teacher.SubjectId;
            teacherM.CoId = (int)teacher.CoId;
            teacherM.StId = (int)teacher.StId;
            teacherM.CiId = (int)teacher.CiId;
            return teacherM;
        }
    }
}
