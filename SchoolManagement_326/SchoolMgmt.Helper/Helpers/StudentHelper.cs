using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt.Helper.Helpers
{
    public class StudentHelper
    {
        public static Student ConvertStudent(StudentModel std)
        {
            try
            {
                Student student = new Student();
                student.SId = std.SId;
                student.FirstName = std.FirstName;
                student.LastName = std.LastName;
                student.Address = std.Address;
                student.Mobile = std.Mobile;
                student.Email = std.Email;
                student.Gender = std.Gender;
                student.TeacherId = std.TeacherId;
                student.CountryId = (int)std.CountryId;
                student.StateId = (int)std.StateId;
                student.CityId = (int)std.CityId;
                return student;
            }
            catch (Exception e) { throw e; }
        }

        public static StudentModel ConvertStudentM(Student std)
        {try
            {
                StudentModel student = new StudentModel();
                student.SId = std.SId;
                student.FirstName = std.FirstName;
                student.LastName = std.LastName;
                student.Address = std.Address;
                student.Mobile = std.Mobile;
                student.Email = std.Email;
                student.Gender = std.Gender;
                student.TeacherId = std.TeacherId;
                student.CountryId = (int)std.CountryId;
                student.StateId = (int)std.StateId;
                student.CityId = (int)std.CityId;
                return student;
            }
            catch (Exception e) { throw e; }
        }
    }
}
