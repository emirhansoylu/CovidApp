using CovidApp.Infrastructure;
using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace CovidApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void updateAllWidgets(String selectedCountrySlug)
        {
            List<CountryInfo> countryInfoList = new List<CountryInfo>();
            CovidHelper covidHelper = new CovidHelper();
            countryInfoList = covidHelper.getCountryInfoList(selectedCountrySlug);
            TopBar_Panel.updateCountryInfo(countryInfoList.Last());
            updateCharts(countryInfoList);

        }

        private void updateCharts(List<CountryInfo> countryInfoList)
        {
            Dictionary<String, int> dicCases = new Dictionary<String, int>();
            Dictionary<String, int> dicDeaths = new Dictionary<String, int>();
            Dictionary<String, int> dicActive = new Dictionary<String, int>();
            Dictionary<String, int> dicRecovered = new Dictionary<String, int>();
            for(int i = 0; i < countryInfoList.Count; i++)
            {
                if (i % 7 != 0)
                    continue;
                dicCases.Add(countryInfoList[i].date.ToString("d MMM"), Convert.ToInt32(countryInfoList[i].confirmed));
                dicDeaths.Add(countryInfoList[i].date.ToString("d MMM"), Convert.ToInt32(countryInfoList[i].deaths));
                dicActive.Add(countryInfoList[i].date.ToString("d MMM"), Convert.ToInt32(countryInfoList[i].active));
                dicRecovered.Add(countryInfoList[i].date.ToString("d MMM"), Convert.ToInt32(countryInfoList[i].recovered));
            }
            Chart_Cases.updateCountryInfo("CASES", dicCases);
            Chart_Deaths.updateCountryInfo("DEATHS", dicDeaths);
            Chart_Active.updateCountryInfo("ACTIVE", dicActive);
            Chart_Recovered.updateCountryInfo("RECOVERED", dicRecovered);
        }
    }
}
