using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Repository.Repository
{
    public interface IStudentInterface
    {
        List<Student> DisplayStudents();
        Student DisplayStudentById(int SId);
        int InsertStudent(StudentModel stdM);

        int EditStudent(StudentModel student);
        StudentModel EditStudent(int SId);
        int RemoveStudent(int SId);
    }
}
