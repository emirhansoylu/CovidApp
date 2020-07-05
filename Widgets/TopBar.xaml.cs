using CovidApp.Infrastructure;
using CovidApp.Model;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CovidApp
{
    public sealed partial class TopBar : UserControl
    {
        CountryInfo countryInfo;
        CovidHelper covidHelper;
        List<Countries> countryList;
        public TopBar()
        {
            this.InitializeComponent();
            
            this.countryInfo = new CountryInfo();
            this.covidHelper = new CovidHelper();
            this.DataContext = this.countryInfo;
            countryList = this.covidHelper.getCountries();
            List<Countries> orderedCountryList = countryList.OrderBy(o => o.country).ToList();
            foreach (Countries country in orderedCountryList)
            {
                ComboBox_Country.Items.Add(country.country);
            }
        }

        public void updateCountryInfo(CountryInfo countryInfo) 
        {
            this.countryInfo = countryInfo;
            this.Bindings.Update();
        }

        private void ComboBox_Country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCountry = (sender as ComboBox).SelectedValue.ToString();
            string selectedCountrySlug = "";
            foreach (Countries country in countryList)
            {
                if (country.country == selectedCountry)
                {
                    selectedCountrySlug = country.slug;
                    break;
                }
            }

            var frame = (Frame)Window.Current.Content;
            var page = (MainPage)frame.Content;
            page.updateAllWidgets(selectedCountrySlug);
        }
    }
}
