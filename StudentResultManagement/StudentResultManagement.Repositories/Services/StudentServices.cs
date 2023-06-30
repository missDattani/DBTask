using StudentResultManagement.Helpers.Helpers;
using StudentResultManagement.Models.Context;
using StudentResultManagement.Models.Model;
using StudentResultManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResultManagement.Repositories.Services
{
    public class StudentServices : IStudentInterface
    {
        Pooja326MVCEntities1 entities = new Pooja326MVCEntities1();

        public int AddStudentMaster(StudentModel studentModel)
        {
            try
            {
                StudentMaster studentMaster = StudentHelper.BindStdMasterToStdModel(studentModel);
                if (studentMaster != null)
                {
                    entities.StudentMaster.Add(studentMaster);
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
