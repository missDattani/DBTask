using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Model.Model
{
    public class StateModel
    {
        [Key]
        public int StId { get; set; }
        [Required]
        [RegularExpression(@"^([A-Za-z]+)$")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "State name must have max 20 characters")]
        public string StateName { get; set; }
        [Required]
        public int CoId { get; set; }

        public string CountryName { get; set; }
    }
}
