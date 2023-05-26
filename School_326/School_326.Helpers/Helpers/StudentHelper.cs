using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Helpers.Helpers
{
    public class StudentHelper
    {
        public static Student ConvertStudent(StudentModel studentM)
        {
            Student stud = new Student();
            stud.SId = studentM.SId;
            stud.FirstName = studentM.FirstName;
            stud.LastName = studentM.LastName;
            stud.Address = studentM.Address;
            stud.Mobile = studentM.Mobile;
            stud.Email = studentM.Email;
            stud.Gender = studentM.Gender;
            stud.TeacherId = studentM.TeacherId;
            stud.CoId = studentM.CoId;
            stud.StId = studentM.StId;
            stud.CiId = studentM.CiId;
            return stud;
        }

        public static StudentModel ConvertStudentM(Student student)
        {
            StudentModel studentM = new StudentModel();
            studentM.SId = student.SId;
            studentM.FirstName = student.FirstName;
            studentM.LastName = student.LastName;
            studentM.Address = student.Address;
            studentM.Mobile = student.Mobile;
            studentM.Email = student.Email;
            studentM.Gender = student.Gender;
            studentM.TeacherId = student.TeacherId;
            studentM.CoId = (int)student.CoId;
            studentM.StId = (int)student.StId;
            studentM.CiId = (int)student.CiId;
            return studentM;
        }
    }
}
