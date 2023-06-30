using StudentResultManagement.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentResultManagement.Models.Model
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [Display(Name ="Student Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Exams")]
        public Nullable<int> ExamId { get; set; }
        [Required]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }
        [Required]
        public string RollNumber { get; set; }
        [Display(Name ="Subjects")]
        public int SubjectId { get; set; }

        public IEnumerable<Exams> ListOfExams { get; set; }

        public IEnumerable<Subjects> ListOfSubjects { get; set; }
        [Display(Name = "Total Marks")]
        public int TotalMarks { get; set; }
        [Display(Name = "Marks Obtained")]
        public int MarksObtained { get; set; }
        [Display(Name = "Percentage")]
        public Decimal Percentage { get; set; }

        public List<StudentDetailsModel> StudentDetailsList { get; set; }
        [Display(Name = "Exam Name")]
        public string ExamName { get; set; }

    }
}
