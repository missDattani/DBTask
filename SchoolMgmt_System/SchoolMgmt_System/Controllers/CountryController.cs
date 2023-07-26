using Microsoft.AspNetCore.Mvc;
using SchoolMgmt_System.Filter;
using SchoolMgmt_System.Model.ViewModels;
using SchoolMgmt_System.Services.Country;

namespace SchoolMgmt_System.Controllers
{
    [TypeFilter(typeof(JwtTokenFilter))]
    public class CountryController : Controller
	{
		#region Fields
		private ICountryServices countryService;
		#endregion

		#region Constructor
		public CountryController(ICountryServices countryService)
		{
			this.countryService = countryService;
		}
		#endregion

		#region Methods
		public async Task<IActionResult> CountryList()
		{
			try
			{
				List<CountryModel> countrylist = await countryService.GetAllCountries();
				return View(countrylist);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IActionResult> GetCountryById(int Id)
		{
			try
			{
				CountryModel countryModel = await countryService.GetCountryById(Id);
				return View(countryModel);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IActionResult> AddEditCountry(int Id)
		{
			try
			{
				if (Id == 0)
				{
					return View();
				}
				else
				{
					var country = await countryService.GetCountryById(Id);
					return View(country);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddEditCountry(CountryModel countryModel)
		{
			try
			{
				await countryService.AddEditCountry(countryModel);
				return RedirectToAction("CountryList");
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IActionResult> DeleteCountry(int Id)
		{
			try
			{
				var Index = await countryService.DeleteCountry(Id);
				if (Index == -1)
				{
					ViewBag.Error = "Country Is In Use";
					return RedirectToAction("CountryList");
                }
				else
				{
					return RedirectToAction("CountryList");
				}

			}
			catch (Exception)
			{

				throw;
			}
		}


		[HttpPost]
		public async Task<IActionResult> GetCountries()
		{
			HttpContext context = HttpContext;
			context.Response.ContentType = "text/plain";

			List<string> columns = new List<string>();
			columns.Add("CountryName");
			//columns.Add("Id");

			Int32 ajaxDraw = Convert.ToInt32(context.Request.Form["draw"]);

			Int32 offSetVal = Convert.ToInt32(context.Request.Form["start"]);

			Int32 pageSize = Convert.ToInt32(context.Request.Form["length"]);

			string? searchBy = context.Request.Form["search[Value]"];

			string? sortColumn = context.Request.Form["order[0][column]"];


            sortColumn = columns[Convert.ToInt32(sortColumn)];

			string? sortDirection = context.Request.Form["order[0][dir]"];

			List<CountryModel> coList = await countryService.GetCountryDataTable(sortColumn, sortDirection,offSetVal,pageSize,searchBy);
			Int32 recordTotal = 0;

			List<CountryDataModel> countries = new List<CountryDataModel>();
			if (!string.IsNullOrEmpty(coList.FirstOrDefault().CountryName))
			{
				for(int i = 0; i < coList.Count; i++)
				{
					CountryDataModel country = new CountryDataModel();
					country.CoId = coList[i].CoId;
					country.CountryName = coList[i].CountryName;
					countries.Add(country);
				}
				recordTotal = countries.Count > 0 ? Convert.ToInt32(coList.FirstOrDefault().FilterTotalCount) : 0;
			}
			Int32 FilteredRecord = recordTotal;

			DatatableResponseModel responseModel = new DatatableResponseModel()
			{
				draw = ajaxDraw,
				recordsFiltered = FilteredRecord,
				recordsTotal = recordTotal,
				data = countries,
			};
			return Json(responseModel);

		}
		#endregion
	}
}
