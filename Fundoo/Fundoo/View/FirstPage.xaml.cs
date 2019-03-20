// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FirstPage.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------


namespace Fundoo.View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FirstPage"/> class.
        /// </summary>
        public FirstPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Clicked event of the Login control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Login_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }

        /// <summary>
        /// Handles the Clicked event of the Register control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegisterPage());
        }
    }
}