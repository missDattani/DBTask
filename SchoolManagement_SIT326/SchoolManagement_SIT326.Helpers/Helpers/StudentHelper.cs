using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Helpers.Helpers
{
    public class StudentHelper
    {
        public static List<StudentModel> BindStuModelListToList(List<Student> students)
        {
            try
            {
                List<StudentModel> models = new List<StudentModel>();
                foreach (var item in students)
                {
                    StudentModel stuModel = new StudentModel();
                    stuModel.StuId = item.StuId;
                    stuModel.FirstName = item.FirstName;
                    stuModel.LastName = item.LastName;
                    stuModel.Gender = item.Gender;
                    stuModel.Address = item.Address;
                    stuModel.MobileNo = item.MobileNo;
                    stuModel.Email = item.Email;
                    stuModel.SubjectId = item.SubjectId;
                    stuModel.CountryId = item.CountryId;
                    stuModel.StateId = item.StateId;
                    stuModel.CityId = item.CityId;
                    stuModel.CountryName = item.Country.CountryName;
                    stuModel.StateName = item.States.StateName;
                    stuModel.CityName = item.City.CityName;

                    models.Add(stuModel);
                }
                return models;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static Student BindStudentModelToStudent(StudentModel stuModel)
        {
            try
            {
                Student student = new Student();
                student.StuId = stuModel.StuId;
                student.FirstName = stuModel.FirstName;
                student.LastName = stuModel.LastName;
                student.Gender = stuModel.Gender;
                student.Address = stuModel.Address;
                student.MobileNo = stuModel.MobileNo;
                student.Email = stuModel.Email;
                student.SubjectId = stuModel.SubjectId;
                student.CountryId = stuModel.CountryId;
                student.StateId = stuModel.StateId;
                student.CityId = stuModel.CityId;
                return student;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public static StudentModel BindStudentToStudentModel(Student student)
        {
            try
            {
                StudentModel studentM = new StudentModel();
                studentM.StuId = student.StuId;
                studentM.FirstName = student.FirstName;
                studentM.LastName = student.LastName;
                studentM.Gender = student.Gender;
                studentM.MobileNo = student.MobileNo;
                studentM.Address = student.Address;
                studentM.Email = student.Email;
                studentM.SubjectId = student.SubjectId;
                studentM.CountryId = student.CountryId;
                studentM.StateId = student.StateId;
                studentM.CityId = student.CityId;
                studentM.CountryName = student.Country.CountryName;
                studentM.StateName = student.States.StateName;
                studentM.CityName = student.City.CityName;

                return studentM;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
