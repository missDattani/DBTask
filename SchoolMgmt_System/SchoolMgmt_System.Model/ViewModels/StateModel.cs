using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Model.ViewModels
{
    public class StateModel
    {
        [Key]
        public int StId { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public int CoId { get; set; }

        public string CountryName { get; set; }
    }
}
