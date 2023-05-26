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
    public class TeacherServices : ITeacherInterface
    {
        private Pooja_SchoolMgmt_326Entities2 entities = new Pooja_SchoolMgmt_326Entities2();

       

        public IEnumerable<SP_GetTeacherDetails1_Result> DisplayTeachers()
        {
            try
            {
                
                return entities.SP_GetTeacherDetails1();
                
            }
            catch (Exception e) { throw e; }
        }

        public Teacher DisplayTeacherById(int TecId)
        {
            try
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var tec = entities.Teachers.Where(m => m.TecId == TecId).FirstOrDefault();
                return tec;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<Teacher> SelectTeacher()
        {
            try
            {
                return entities.Teachers.ToList();
            }
            catch (Exception e) { throw e; }
        }

        public int InsertTeacher(TeacherModel teacher)
        {
            var checkTe = entities.Teachers.Any(m => m.FirstName == teacher.FirstName && m.LastName == teacher.LastName);
            if (checkTe)
            {
                return 0;
            }
            else
            {
                Teacher t1 =  TeacherHelper.ConvertTeacher(teacher);
                entities.Teachers.Add(t1);
                entities.SaveChanges();
                return 1;
            }
        }



        public TeacherModel EditTeacher(int TecId)
        {
            try { 
            Teacher tec = entities.Teachers.Find(TecId);
            TeacherModel tecm = TeacherHelper.ConvertTeacherM(tec);
            return tecm;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int EditTeacher(TeacherModel teacher)
        {
            try {
                //TeacherHelper tHelper = new TeacherHelper();
            Teacher tec = TeacherHelper.ConvertTeacher(teacher);
            entities.Entry(tec).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return 1;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int RemoveTeacher(int TecId)
        {
            try
            {
                var res = entities.Teachers.Where(x => x.TecId == TecId).FirstOrDefault();
                entities.Teachers.Remove(res);
                entities.SaveChanges();
                return 1;
            }
            catch (Exception e) { throw e; }
        }

        
    }
}
