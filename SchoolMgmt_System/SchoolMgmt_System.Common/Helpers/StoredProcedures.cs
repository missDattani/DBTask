using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Common.Helpers
{
    public class StoredProcedures
    {
        #region Login
        public const string UserLogin = "Sp_UserLogin";
        public const string UserInfo = "Sp_UserData";
        public const string CheckUser = "Sp_CheckUser";
        public const string GetUserDetailsByEmail = "Sp_UserDetailsByEmail";
		#endregion

		#region Countries
		public const string CountryList = "Sp_GetAllCountries";
		public const string InsertCountry = "Sp_AddEdit_Country";
		public const string GetCountryById = "Sp_GetCountryById";
		public const string DeleteCountry = "Sp_Delete_Country";
        public const string CountryDataTable = "Sp_GetCountryDataTable";
        #endregion

        #region State
        public const string StateList = "Sp_GetAllStates";
        public const string InsertState = "Sp_AddEdit_State";
        public const string GetStateById = "Sp_GetStateById";
        public const string DeleteState = "Sp_Delete_State";
     
        #endregion

        #region City
        public const string CityList = "Sp_GetAllCity";
        public const string InsertCity = "Sp_AddEdit_City";
        public const string GetCityById = "Sp_GetCityById";
        public const string GetStateByCountryId = "Sp_GetStateByCountryID";
        // public const string DeleteCity = "Sp_Delete_City";
        #endregion
    }
}
