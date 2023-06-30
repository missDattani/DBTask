using StudentResultManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResultManagement.Repositories.Repositories
{
    public interface IStudentInterface
    {
        int AddStudentMaster(StudentModel studentModel);
    }
}
