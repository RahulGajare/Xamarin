using Fundoo.DataHandler;
using Fundoo.DependencyServices;
using Fundoo.Interfaces;
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
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {

            this.InitializeComponent();
            this.GetNotes();
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

        /// <summary>
        /// Handles the Clicked event of the TakeaNote control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TakeaNote_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WriteNotesPage());
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        public async void GetNotes()
        {
            DataLogic dataLogic = new DataLogic();
            var allNotes = await dataLogic.GetAllNotes();
            NotesList.ItemsSource = allNotes;
        }


        protected override void OnAppearing()
        {
            GetNotes();
            ////DataLogic dataLogic = new DataLogic();
            ////var allNotes = await dataLogic.GetAllNotes();
            ////NotesList.ItemsSource = allNotes;
        }
    }
}