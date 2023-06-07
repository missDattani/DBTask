using SchoolManagement_SIT326.Helpers.GlobalEnum;
using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Helpers.Helpers
{
    public class TeacherHelper
    {
        public static List<TeacherModel> BindTecModelListToList(List<Teachers> teachers)
        {
            try
            {
                List<TeacherModel> models = new List<TeacherModel>();
                foreach (var item in teachers)
                {
                    TeacherModel tecModel = new TeacherModel();
                    tecModel.TecId = item.TecId;
                    tecModel.FirstName = item.FirstName;
                    tecModel.LastName = item.LastName;
                    tecModel.Gender = (int)item.Gender;
                    tecModel.Address = item.Address;
                    tecModel.MobileNo = item.MobileNo;
                    tecModel.Email = item.Email;
                    tecModel.SubjectId = item.SubjectId;
                    tecModel.CountryId = item.CountryId;
                    tecModel.StateId = item.StateId;
                    tecModel.CityId = item.CityId;
                    tecModel.GenderName = GetGenderString(item.Gender);
                    tecModel.CountryName = item.Country.CountryName;
                    tecModel.StateName = item.States.StateName;
                    tecModel.CityName = item.City.CityName;
             
                    models.Add(tecModel);
                }
                return models;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static Teachers BindTeacherModelToTeacher(TeacherModel tecModel)
        {
            try
            {
                Teachers teachers = new Teachers();
                teachers.TecId = tecModel.TecId;
                teachers.FirstName = tecModel.FirstName;
                teachers.LastName = tecModel.LastName;
                teachers.Gender = tecModel.Gender;
                teachers.Address = tecModel.Address;
                teachers.MobileNo = tecModel.MobileNo;
                teachers.Email = tecModel.Email;
                teachers.SubjectId = tecModel.SubjectId;
                teachers.CountryId = tecModel.CountryId;
                teachers.StateId = tecModel.StateId;
                teachers.CityId = tecModel.CityId;
                return teachers;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public static TeacherModel BindTeacherToTecaherModel(Teachers teachers)
        {
            try
            {
                TeacherModel teacherM = new TeacherModel();
                teacherM.TecId = teachers.TecId;
                teacherM.FirstName = teachers.FirstName;
                teacherM.LastName = teachers.LastName;
                teacherM.Gender = (int)teachers.Gender;
                teacherM.MobileNo = teachers.MobileNo;
                teacherM.Address = teachers.Address;
                teacherM.Email = teachers.Email;
                teacherM.SubjectId = teachers.SubjectId;
                teacherM.CountryId = teachers.CountryId;
                teacherM.StateId = teachers.StateId;
                teacherM.CityId = teachers.CityId;
                teacherM.GenderName = GetGenderString(teachers.Gender);
                teacherM.CountryName = teachers.Country.CountryName;
                teacherM.StateName = teachers.States.StateName;
                teacherM.CityName = teachers.City.CityName;
           
                return teacherM;
            }
            catch (Exception e )
            {

                throw e;
            }
        }

        public static string GetGenderString(int? Gender)
        {
            try
            {
                return Enum.GetName(typeof(GenderEnum), Gender);
            }
            catch (Exception e)
            {

                throw e;
            } 
        }
    }
}
