using SchoolMgmtWEB_326.Models.Context;
using SchoolMgmtWEB_326.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Repository.Services
{
    public class CountryService : ICountryInterface
    {
        OrderManagementEntities entities = new OrderManagementEntities();
        public IEnumerable<Country> SelectCountry()
        {
            try
            {
                return entities.Country.ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<States> SelectStates(int? CoId)
        {
            try
            {
                return entities.States.Where(m => m.CountryId == CoId).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<States> GetAllStates()
        {
            try
            {
                return entities.States.ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
