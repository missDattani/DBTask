using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationAllOverTopics.Model.ViewModel
{
    public class CountryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
    }
}
