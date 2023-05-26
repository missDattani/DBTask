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
    public class TeacherRepository : ITeacherInterface
    {
        DBTempEntitiesNew entities = new DBTempEntitiesNew();

        public List<Teacher> DisplayTeachers()
        {
            entities.Configuration.ProxyCreationEnabled = false;
            return entities.Teachers.ToList();
        }

        public Teacher DisplayTeacherById(int TecId)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            var tec = entities.Teachers.Where(m => m.TecId == TecId).FirstOrDefault();
            return tec;
        }

        public int InsertTeacher(TeacherModel tecM)
        {
            var CheckTec = entities.Teachers.Any(m => m.FirstName == tecM.FirstName && m.LastName == tecM.LastName);
            if (CheckTec)
            {
                return 0;
            }
            else
            {
                Teacher tec = TeacherHelper.ConvertTeacher(tecM);
                entities.Teachers.Add(tec);
                entities.SaveChanges();
                return 1;
            }
        }

        public int EditTeacher(TeacherModel tecM)
        {
            Teacher tec = TeacherHelper.ConvertTeacher(tecM);
            entities.Entry(tec).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return 1;
        }

        public TeacherModel EditTeacher(int TecId)
        {
            Teacher tec = entities.Teachers.Find(TecId);
            TeacherModel tecM = TeacherHelper.ConvertTeacherM(tec);
            entities.SaveChanges();
            return tecM;
        }

        public int RemoveTeacher(int TecId)
        {
            var res = entities.Teachers.Where(m => m.TecId == TecId).FirstOrDefault();
            entities.Teachers.Remove(res);
            entities.SaveChanges();
            return 1;
        }

        public IEnumerable<Teacher> SelectTeachers()
        {
            return entities.Teachers.ToList();
        }
    }
}
