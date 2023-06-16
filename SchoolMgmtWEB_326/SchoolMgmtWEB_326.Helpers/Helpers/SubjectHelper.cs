
using SchoolMgmtWEB_326.Models.Context;
using SchoolMgmtWEB_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Helpers.Helpers
{
    public class SubjectHelper
    {
        public static List<SubjectModel> BindSubModelListToList(List<Subjects> subjects)
        {
            try
            {
                List<SubjectModel> subModel = new List<SubjectModel>();
                foreach (var item in subjects)
                {
                    SubjectModel subM = new SubjectModel();
                    subM.SubId = item.SubId;
                    subM.SubjectName = item.SubjectName;
                    subModel.Add(subM);
                }
                return subModel;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static Subjects BindSubjectModelToSubject(SubjectModel model)
        {
            try
            {
                Subjects subjects = new Subjects();
                subjects.SubId = model.SubId;
                subjects.SubjectName = model.SubjectName;
                return subjects;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static SubjectModel BindSubjectToSubjectModel(Subjects subjects)
        {
            try
            {
                SubjectModel subModel = new SubjectModel();
                subModel.SubId = subjects.SubId;
                subModel.SubjectName = subjects.SubjectName;
                return subModel;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
