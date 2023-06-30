using StudentResultManagement.Models.Context;
using StudentResultManagement.Models.Model;
using StudentResultManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentResultManagement.Controllers
{
    public class StudentController : Controller
    {
        IStudentInterface studentInterface;

        public StudentController(IStudentInterface studentInterface)
        {
            this.studentInterface = studentInterface;
        }
        Pooja326MVCEntities1 entities = new Pooja326MVCEntities1();
        // GET: Student
        public ActionResult Index()
        {
            StudentModel studentModel = new StudentModel();
            studentModel.ListOfExams = entities.Exams.ToList();
            studentModel.ListOfSubjects = entities.Subjects.ToList();

            return View(studentModel);
        }

        [HttpPost]
        public ActionResult Index(StudentModel studentModel)
        {
            StudentMaster studentMaster = new StudentMaster();
            studentMaster.StudentId = studentModel.StudentId;
            studentMaster.Name = studentModel.Name;
            studentMaster.ExamId = studentModel.ExamId;
            studentMaster.ClassName = studentModel.ClassName;
            studentMaster.RollNumber = studentModel.RollNumber;
            entities.StudentMaster.Add(studentMaster);
            entities.SaveChanges();
            foreach (var item in studentModel.StudentDetailsList)
            {
                StudentDetails studentDetails = new StudentDetails();
                studentDetails.MarksObtained = item.MarksObtained;
                studentDetails.Percentage = item.Percentage;
                studentDetails.StudentId = studentMaster.StudentId;
                studentDetails.SubjectId = item.SubjectId;
                studentDetails.TotalMarks = item.TotalMarks;
                entities.StudentDetails.Add(studentDetails);
                entities.SaveChanges();
            }
            return Json(new { message = "Data Added Successfully",status=true}, JsonRequestBehavior.AllowGet);
        }
    }
}