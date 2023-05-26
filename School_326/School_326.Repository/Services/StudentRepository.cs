using School_326.Helpers.Helpers;
using School_326.Models.Context;
using School_326.Models.Models;
using School_326.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Repository.Services
{
    public class StudentRepository : IStudentInterface
    {
        DBTempEntitiesNew entities = new DBTempEntitiesNew();
        public List<Student> DisplayStudents()
        {
            entities.Configuration.ProxyCreationEnabled = false;
            return entities.Students.ToList();
        }

        public Student DisplayStudentById(int SId)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            var std = entities.Students.Where(m => m.SId == SId).FirstOrDefault();
            return std;
        }

        public int EditStudent(StudentModel student)
        {
            Student std = StudentHelper.ConvertStudent(student);
            entities.Entry(std).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return 1;
        }

        public StudentModel EditStudent(int SId)
        {
            Student std = entities.Students.Find(SId);
            StudentModel stdM = StudentHelper.ConvertStudentM(std);
            entities.SaveChanges();
            return stdM;
        }

        public int InsertStudent(StudentModel stdM)
        {
            var CheckStd = entities.Students.Any(m => m.FirstName == stdM.FirstName && m.LastName == stdM.LastName);
            if (CheckStd)
            {
                return 0;
            }
            else
            {
                Student std = StudentHelper.ConvertStudent(stdM);
                entities.Students.Add(std);
                entities.SaveChanges();
                return 1;
            }
        }

        public int RemoveStudent(int SId)
        {
            var res = entities.Students.Where(m => m.SId == SId).FirstOrDefault();
            entities.Students.Remove(res);
            entities.SaveChanges();
            return 1;
        }
    }
}
