using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Model.ViewModels
{
    public class StateModel
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
