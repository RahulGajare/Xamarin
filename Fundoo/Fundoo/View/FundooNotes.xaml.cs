// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FundooNotes.xaml.cs" company="Bridgelabz">
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
    using Fundoo.DependencyServices;
    using Fundoo.Interfaces;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// FundooNotes Class
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FundooNotes : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FundooNotes"/> class.
        /// </summary>
        public FundooNotes()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Clicked event of the LogoutIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LogoutIcon_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IFirebaseAuthenticator>().Signout();
            Message.ShowToastMessage("LoggedOut Successfully");

            Navigation.PopToRootAsync();
            Navigation.PushAsync(new Greeting());
        }    
    }
}