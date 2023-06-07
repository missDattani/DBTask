using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Models.Models
{
    public class StateModel
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "StateName have max 20 characters")]
        public string StateName { get; set; }
        [Required]
        public Nullable<int> CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
