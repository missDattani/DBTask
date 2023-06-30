using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResultManagement.Models.Model
{
    public class StudentDetailsModel
    {
      
        public int StdDetailId { get; set; }
   
        public Nullable<int> StudentId { get; set; }
 
        public Nullable<int> SubjectId { get; set; }
   
        public Nullable<int> TotalMarks { get; set; }
    
        public Nullable<int> MarksObtained { get; set; }
   
        public Nullable<decimal> Percentage { get; set; }
    }
}
