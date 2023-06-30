using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResultManagement.Models.Model
{
    public class ExamModel
    {
        [Key]
        public int ExamId { get; set; }
        [Required]
        public string ExamName { get; set; }
    }
}
