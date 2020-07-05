using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Infrastructure
{
    interface ICovidHelper
    {
        List<Countries> getCountries();
        List<CountryInfo> getCountryInfoList(String countryName);
    }
}
