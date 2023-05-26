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
    public class SubjectRepository:ISubjectInterface
    {
        DBTempEntitiesNew entities = new DBTempEntitiesNew();
        public List<Subject> DisplaySubject()
        {
            entities.Configuration.ProxyCreationEnabled = false;
            return entities.Subjects.ToList();
        }

        public Subject DisplaySubjectById(int SubId)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            var sub = entities.Subjects.Where(m => m.SubId == SubId).FirstOrDefault();
            return sub;
        }

        public int InsertSubject(SubjectModel subjectM)
        {
            var CheckSub = entities.Subjects.Any(m => m.SubjectName == subjectM.SubjectName);
            if (CheckSub)
            {
                return 0;
            }
            else
            {
                Subject subject = SubjectHelper.ConvertSubject(subjectM);
                entities.Subjects.Add(subject);
                entities.SaveChanges();
                return 1;
            }
            
        }

        public int EditSubject(SubjectModel subModel)
        {
            Subject sub = SubjectHelper.ConvertSubject(subModel);
            entities.Entry(sub).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return 1;
        }

        public SubjectModel EditSubject(int SubId)
        {
            Subject sub = entities.Subjects.Find(SubId);
            SubjectModel subModel = SubjectHelper.ConvertSubjectM(sub);
            entities.SaveChanges();
            return subModel;
        }

        public int RemoveSubject(int SubId)
        {
            var res = entities.Subjects.Where(m => m.SubId == SubId).FirstOrDefault();
            entities.Subjects.Remove(res);
            entities.SaveChanges();
            return 1;
        }

        public IEnumerable<Subject> SelectSubject()
        {
            return entities.Subjects.ToList();
        }

        
    }
}
