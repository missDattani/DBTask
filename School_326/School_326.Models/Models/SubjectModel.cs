using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Models.Models
{
    public class SubjectModel
    {
        [Key]
        public int SubId { get; set; }
        [Required]
        public string SubjectName { get; set; }
    }
}
