using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Models.Models
{
    public class SubjectModel
    {
        [Key]
        public int SubId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "SubjectName have max 20 characters")]
        public string SubjectName { get; set; }
    }
}
