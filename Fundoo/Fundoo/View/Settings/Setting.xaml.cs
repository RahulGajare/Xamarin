// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Setting.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

using Fundoo.View.Others;
using Fundoo.View.Settings;
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

      
        private void PhoneDialer_clicked(object sender, EventArgs e)
        {
            Phonedialer phonedialer = new Phonedialer();
            phonedialer.PlacePhoneCall("7757878978");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            List<string> recepients = new List<string>();
            recepients.Add("rahulgajare0@gmail.com");
            recepients.Add("rahulg52586@gmail.com");
            EmailPage emailPage = new EmailPage();
            await emailPage.SendEmail("Meeting", "at 4,30", recepients);
        }


        private void Version_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Versiontracking());
        }

     

        private void Clipboard_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ClipboardPage());
        }
    }
}