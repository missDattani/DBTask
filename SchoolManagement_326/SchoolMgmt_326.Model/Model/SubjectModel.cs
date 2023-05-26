using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Model.Model
{
    public class SubjectModel
    {
        [Key]
        public int SubId { get; set; }
        [Required]
        public string SubjectName { get; set; }
    }
}
