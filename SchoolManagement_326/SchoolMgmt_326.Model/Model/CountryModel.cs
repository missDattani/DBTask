using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Model.Model
{
    public class CountryModel
    {
        [Key]
        public int CoId { get; set; }
        [Required]
        [RegularExpression(@"^([A-Za-z]+)$")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Country name must have max 20 characters")]
        public string CountryName { get; set; }
    }
}
