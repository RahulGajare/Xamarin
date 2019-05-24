// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------
////[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Fundoo
{
    using System;
    using Fundoo.DependencyServices;
    using Fundoo.View;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Microsoft.AppCenter;
    using Microsoft.AppCenter.Push;
    using Plugin.Connectivity;
    using Plugin.LocalNotifications;

    /// <summary>
    /// partial App Class
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Application" />
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            
            this.InitializeComponent();

            if (!CrossConnectivity.Current.IsConnected)
            {
                Message.ShowToastMessage("No Internet Connection");
                return;
            }

            FireBaseThroughAuthentication fireBaseThoroughAuthentication = new FireBaseThroughAuthentication();

           

            //// If user is already Logged in , then navigating to fundooNotes page(Master Page).
            var isLoggedin = fireBaseThoroughAuthentication.CheckStatus();
            if (isLoggedin)
            {
                this.MainPage = new NavigationPage(new FundooNotes());
            }
            else
            {
                this.MainPage = new NavigationPage(new Greeting());              
            }        
        }

     

        /// <summary>
        /// Application developers override this method to perform actions when the application starts.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnStart()
        {
            // Handle when your app starts

            //// For Sending Push Notification using AppCenter.
            AppCenter.Start("4451c333-7a45-472f-8c06-7336aeae7a74", typeof(Push));
          
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application enters the sleeping state.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application resumes from a sleeping state.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
