using SchoolMgmtWEB_326.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Repository.Repositories
{
    public interface ICountryInterface
    {
        IEnumerable<Country> SelectCountry();
        IEnumerable<States> SelectStates(int ?CoId);
        List<States> GetAllStates();
    }
}
