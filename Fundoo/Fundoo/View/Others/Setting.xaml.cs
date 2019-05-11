// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Setting.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

using Fundoo.View.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fundoo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Setting : ContentPage
    {
        public Setting()
        {
            this.InitializeComponent();
        }

       

        private void Internet_Clicked(object sender, EventArgs e)
        {
            if(Xamarin.Essentials.Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
            {
                DisplayAlert("alert", "Check your internet connection", "ok");
            }
            else
            {
                DisplayAlert("alert", " Internet connection", "ok");
            }
        }

        private void Browser_Clicked(object sender, EventArgs e)
        {
            Xamarin.Essentials.Browser.OpenAsync("https://firebase.google.com/", Xamarin.Essentials.BrowserLaunchMode.SystemPreferred);
        }

        private void AppInformation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AppInformation());
        }

       

        private void DeviceInformation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeviceInformation());
        }
    }
}