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
    public class SubjectRepository : ISubjectInterface
    {
        private readonly OrderManagementEntities entities = new OrderManagementEntities();
        public List<SubjectModel> DisplaySubjects()
        {
            try
            {
                List<Subjects> subjects = entities.Subjects.ToList();
                if (subjects != null && subjects.Count() > 0)
                {
                    List<SubjectModel> subModel = SubjectHelper.BindSubModelListToList(subjects);
                    return subModel;
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
        public SubjectModel DisplaySubjectById(int? SubId)
        {
            try
            {
                Subjects sub = entities.Subjects.Where(m => m.SubId == SubId).FirstOrDefault();
                SubjectModel subjectModel = SubjectHelper.BindSubjectToSubjectModel(sub);
                if (subjectModel != null)
                {
                    return subjectModel;
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


        public int InsSubject(SubjectModel subModel, int? SubId)
        {
            try
            {
                Subjects subjects = SubjectHelper.BindSubjectModelToSubject(subModel);
                if (SubId == 0)
                {
                    var checkSub = entities.Subjects.Any(m => m.SubjectName == subModel.SubjectName);
                    if (checkSub)
                    {
                        return 0;
                    }
                    else
                    {
                        entities.Subjects.Add(subjects);
                        entities.SaveChanges();
                        return 1;
                    }
                }
                else
                {
                    entities.Entry(subjects).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int RemoveSubject(int SubId)
        {
            try
            {
                var res = entities.Subjects.Where(m => m.SubId == SubId).FirstOrDefault();
                if (res != null)
                {
                    entities.Subjects.Remove(res);
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

        public IEnumerable<Subjects> SelectSubjects()
        {
            try
            {
                return entities.Subjects.ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
