using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Repositories.Repositories
{
    public interface IStudentInterface
    {
        IEnumerable<SP_GetStudentDetails1_Result> DisplayStudents();

        Student DisplayStudentById(int SId);
        int InsertStudent(StudentModel std);

         StudentModel EditStudent(int SId);
        int EditStudent(StudentModel std);
        int RemoveStudent(int SId);
    }
}
