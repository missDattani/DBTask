using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Model.ViewModels
{
	public class CountryModel
	{
		[Key]
		public int CoId { get; set; }
		[Required]
		public string CountryName { get; set; }

		public int FilterTotalCount { get; set; }
	}

	public class CountryDataModel 
	{
		public int CoId { get; set; }
		public string CountryName { get; set; }
	}

}
