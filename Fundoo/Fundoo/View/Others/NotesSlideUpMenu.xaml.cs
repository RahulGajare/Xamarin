// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesSlideUpMenu.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class NotesSlideUpMenu : PopupPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesSlideUpMenu"/> class.
        /// </summary>
        public NotesSlideUpMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Clicked event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
        }

        /// <summary>
        /// When overridden, allows the application developer to customize behavior as the <see cref="T:Xamarin.Forms.Page" /> disappears.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnDisappearing()
        {
            EditNote editnew = new EditNote();
            editnew.changeColor();
            base.OnDisappearing();
        }

        private void Delete1_Clicked(object sender, EventArgs e)
        {

        }

        private void Delete2_Clicked(object sender, EventArgs e)
        {

        }
    }
}