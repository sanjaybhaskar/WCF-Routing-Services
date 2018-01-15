using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Windows;
using GeoLib.Contracts;
using GeoLib.Proxies;

namespace GeoLib.Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            if (txtZipCode.Text != "")
            {
                GeoClient proxy = new GeoClient("GeoLibRouter");

                ZipCodeData data = proxy.GetZipInfo(txtZipCode.Text);
                if (data != null)
                {
                    lblCity.Content = data.City;
                    lblState.Content = data.State;
                }

                proxy.Close();
            }
        }

        private void btnGetZipCodes_Click(object sender, RoutedEventArgs e)
        {
            if (txtState.Text != null)
            {
                GeoClient proxy = new GeoClient("GeoLibRouter");

                IEnumerable<ZipCodeData> data = proxy.GetZips(txtState.Text);
                if (data != null)
                    lstZips.ItemsSource = data;

                proxy.Close();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GeoClient proxy = new GeoClient("GeoLibRouterBroadcast");

            proxy.PerformBroadcast();
        }
    }
}
