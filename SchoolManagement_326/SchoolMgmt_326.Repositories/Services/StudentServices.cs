using SchoolMgmt.Helper.Helpers;
using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using SchoolMgmt_326.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Repositories.Services
{
    public class StudentServices : IStudentInterface
    {

     Pooja_SchoolMgmt_326Entities2 entities = new Pooja_SchoolMgmt_326Entities2();


        public IEnumerable<SP_GetStudentDetails1_Result> DisplayStudents()
        {try
            {
                return entities.SP_GetStudentDetails1();
            }
            catch (Exception e) { throw e; }
        }

        public Student DisplayStudentById(int SId)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            var std = entities.Students.Where(m => m.SId == SId).FirstOrDefault();
            return std;
        }

        public int InsertStudent(StudentModel student)
        {
            var checkSt = entities.Students.Any(m => m.FirstName == student.FirstName && m.LastName == student.LastName);
            if (checkSt)
            {
                return 0;
            }
            else
            {
                Student st = StudentHelper.ConvertStudent(student);
                entities.Students.Add(st);
                entities.SaveChanges();
                return 1;
            }
        }

        public StudentModel EditStudent(int SId)
        {
            try
            {
                Student std = entities.Students.Find(SId);
                StudentModel stdm = StudentHelper.ConvertStudentM(std);
                return stdm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int EditStudent(StudentModel student)
        {
            try
            {
           
                Student std = StudentHelper.ConvertStudent(student);
                entities.Entry(std).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int RemoveStudent(int SId)
        {
            try
            {
                var res = entities.Students.Where(x => x.SId == SId).FirstOrDefault();
                entities.Students.Remove(res);
                entities.SaveChanges();
                return 1;
            }
            catch (Exception e) { throw e; }
        }
    }
}
