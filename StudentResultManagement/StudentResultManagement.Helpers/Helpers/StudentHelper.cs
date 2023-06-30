using StudentResultManagement.Models.Context;
using StudentResultManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResultManagement.Helpers.Helpers
{
    public class StudentHelper
    {
        public static StudentMaster BindStdMasterToStdModel(StudentModel studentModel)
        {
            try
            {
                StudentMaster studentMaster = new StudentMaster();
                studentMaster.StudentId = studentModel.StudentId;
                studentMaster.Name = studentModel.Name;
                studentMaster.ExamId = studentModel.ExamId;
                studentMaster.ClassName = studentModel.ClassName;
                studentMaster.RollNumber = studentModel.RollNumber;

                return studentMaster;

            }
            catch (Exception e)
            {

                throw e;
            }
    }
}
}
