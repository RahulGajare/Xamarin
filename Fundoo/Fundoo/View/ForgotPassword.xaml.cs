// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForgotPassword.xaml.cs" company="Bridgelabz">
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
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary> 
    /// ForgotPassword partial class
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForgotPassword"/> class.
        /// </summary>
        public ForgotPassword()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Clicked event of the TxtResetPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void TxtResetPassword_Clicked(object sender, EventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Resetpassword(txtEmailAddress.Text);
            await this.DisplayAlert("Alert", "password sent to your mail", "OK");
        }
    }
}