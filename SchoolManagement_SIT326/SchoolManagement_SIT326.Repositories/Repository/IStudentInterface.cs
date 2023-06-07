using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Repositories.Repository
{
    public interface IStudentInterface
    {
        List<StudentModel> DisplayStudent();
        Student DisplayStudentById(int? StuId);
        int InsStudent(StudentModel stuM, int? StuId);
        int RemoveStudent(int StuId);
    }
}
