using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt.Helper.Helpers
{
    public class TeacherHelper
    {
        public static TeacherModel ConvertTeacherM(Teacher tec)
        {
            try
            {
                TeacherModel teacher = new TeacherModel();
                teacher.TecId = tec.TecId;
                teacher.FirstName = tec.FirstName;
                teacher.LastName = tec.LastName;
                teacher.Address = tec.Address;
                teacher.Mobile = tec.Mobile;
                teacher.Email = tec.Email;
                teacher.Gender = tec.Gender;
                teacher.SubjectId = tec.SubjectId;
                teacher.CountryId = (int)tec.CountryId;
                teacher.StateId = (int)tec.StateId;
                teacher.CityId = (int)tec.CityId;
                return teacher;
            }
            catch (Exception e) { throw e; }
        }
        public static Teacher ConvertTeacher(TeacherModel tec)
        {
            try
            {
                Teacher teacher = new Teacher();
                teacher.TecId = tec.TecId;
                teacher.FirstName = tec.FirstName;
                teacher.LastName = tec.LastName;
                teacher.Address = tec.Address;
                teacher.Mobile = tec.Mobile;
                teacher.Email = tec.Email;
                teacher.Gender = tec.Gender;
                teacher.SubjectId = tec.SubjectId;
                teacher.CountryId = (int)tec.CountryId;
                teacher.StateId = (int)tec.StateId;
                teacher.CityId = (int)tec.CityId;
                return teacher;
            }
            catch (Exception e) { throw e; }
        }
    }
}
