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
    public class SubjectService : ISubjectInterface
    {
        private Pooja_SchoolMgmt_326Entities2 entities;

        public SubjectService(Pooja_SchoolMgmt_326Entities2 entities)
        {
            this.entities = entities;
        }

        public List<Subject> DisplaySubjects()
        {
            
            try
            {
                return entities.Subjects.ToList();
            }
            catch (Exception e) { throw e; }
        }

        public Subject DisplaySubjectById(int SubId)
        {
            try
            {
                var sub = entities.Subjects.Where(m => m.SubId == SubId).FirstOrDefault();
                return sub;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<Subject> SelectSubject()
        {
            try
            {
                return entities.Subjects.ToList();
            }
            catch (Exception e) { throw e; }
        }

        public int InsertSubject(SubjectModel sub)
        {
            var checkSub = entities.Subjects.Any(m => m.SubjectName == sub.SubjectName);
            if (checkSub)
            {
                return 0;
            }
            else
            {
                entities.sp_AddEditSubject(null, sub.SubjectName);
                entities.SaveChanges();
                return 1;
            }

        }

        public SubjectModel EditSubject(int SubId)
        {
            try { 
            Subject sub = entities.Subjects.Find(SubId);
            SubjectModel subm = SubjectHelper.ConvertSubject(sub);
            return subm;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int EditSubject(SubjectModel subject)
        {
            try { 
            entities.sp_AddEditSubject(subject.SubId, subject.SubjectName);
            entities.SaveChanges();
            return 1;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int RemoveSubject(int SubId)
        {
            try
            {
                var res = entities.Subjects.Where(x => x.SubId == SubId).FirstOrDefault();
                entities.Subjects.Remove(res);
                entities.SaveChanges();
                return 1;
            }
            catch (Exception e) { throw e; }
        }
    }
}
