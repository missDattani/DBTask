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
    public class StudentRepository : IStudentInterface
    {
        private readonly OrderManagementEntities entities = new OrderManagementEntities();
        public List<StudentModel> DisplayStudent()
        {
            try
            {
                List<Student> stuList = entities.Student.ToList();
                if (stuList != null && stuList.Count() > 0)
                {
                    List<StudentModel> sModel = StudentHelper.BindStuModelListToList(stuList);
                    return sModel;
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

        public Student DisplayStudentById(int? StuId)
        {
            try
            {
                Student std = entities.Student.Where(m => m.StuId == StuId).FirstOrDefault();
                if (std != null)
                {
                    return std;
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

        public int InsStudent(StudentModel stuM, int? StuId)
        {
            try
            {
                Student student = StudentHelper.BindStudentModelToStudent(stuM);
                if (StuId == 0)
                {
                    var checkStu = entities.Student.Any(m => m.FirstName == stuM.FirstName && m.LastName == stuM.LastName);
                    if (checkStu)
                    {
                        return 0;
                    }
                    else
                    {
                        entities.Student.Add(student);
                        entities.SaveChanges();
                        return 1;
                    }
                }
                else
                {
                    entities.Entry(student).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int RemoveStudent(int StuId)
        {
            try
            {
                var res = entities.Student.Where(m => m.StuId == StuId).FirstOrDefault();
                if (res != null)
                {
                    entities.Student.Remove(res);
                    entities.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
