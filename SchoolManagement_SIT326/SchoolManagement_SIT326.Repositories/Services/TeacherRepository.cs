using SchoolManagement_SIT326.Helpers.Helpers;
using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using SchoolManagement_SIT326.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Repositories.Services
{
    public class TeacherRepository : ITeacherInterface
    {
        private readonly OrderManagementEntities entities = new OrderManagementEntities();


        public List<TeacherModel> DisplayTeachers()
        {
            try
            {
                List<Teachers> tecList = entities.Teachers.ToList();
                if (tecList != null && tecList.Count() > 0)
                {
                    List<TeacherModel> tecModel = TeacherHelper.BindTecModelListToList(tecList);
                    return tecModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public Teachers DisplayTeacherById(int? TecId)
        {
            try
            {
                Teachers teachers = entities.Teachers.Where(m => m.TecId == TecId).FirstOrDefault();
                if (teachers != null)
                {
                    return teachers;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public int InsTeacher(TeacherModel tecM, int? TecId)
        {
            try
            {
                Teachers teachers = TeacherHelper.BindTeacherModelToTeacher(tecM);
                if (TecId == 0)
                {
                    var checkTec = entities.Teachers.Any(m => m.FirstName == tecM.FirstName && m.LastName == tecM.LastName);
                    if (checkTec)
                    {
                        return 0;
                    }
                    else
                    {
                        entities.Teachers.Add(teachers);
                        entities.SaveChanges();
                        return 1;
                    }
                }
                else
                {
                    entities.Entry(teachers).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int RemoveTeacher(int TecId)
        {
            var res = entities.Teachers.Where(m => m.TecId == TecId).FirstOrDefault();
            if(res != null)
            {
                entities.Teachers.Remove(res);
                entities.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
