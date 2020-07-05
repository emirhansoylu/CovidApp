using CovidApp.Infrastructure;
using System;
using System.Collections.Generic;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;


namespace CovidApp
{
    public sealed partial class Chart : UserControl
    {
        CovidHelper covidHelper;
        
        public Chart()
        {
            this.InitializeComponent();
            covidHelper = new CovidHelper();
        }

        public void updateCountryInfo(String title, Dictionary<String, int> dictionary)
        {
            (ColumnChart.Series[0] as ColumnSeries).ItemsSource = dictionary;
            ColumnChart.Title = title;
        }
    }
}
