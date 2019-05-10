// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesSlideUpMenu.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

using Fundoo.DataHandler;
using Fundoo.Model;
using Fundoo.View.Collabrators;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fundoo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesSlideUpMenu : PopupPage
    {
        private string noteKey;
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesSlideUpMenu"/> class.
        /// </summary>
        public NotesSlideUpMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesSlideUpMenu"/> class.
        /// </summary>
        public NotesSlideUpMenu(string noteKey)
        {
            InitializeComponent();
            this.noteKey = noteKey;
        }

        /// <summary>
        /// Handles the Clicked event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
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
            //editnew.changeColor();
            base.OnDisappearing();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.RemovePageAsync(this);
            EditNote editNote = new EditNote();

        }



        private async void Share_Clicked(object sender, EventArgs e)
        {
            NotesHandler notesHandler = new NotesHandler();
            Note note = await notesHandler.GetNote(this.noteKey);

            await Xamarin.Essentials.Share.RequestAsync(new ShareTextRequest
            {
                Text = note.Info,
                Title = "Share!"
            });
        }

      

        private async void collabratorIcon_Clicked(object sender, EventArgs e)
        {

            
          await  Navigation.PushAsync(new EmailList(this.noteKey));
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}