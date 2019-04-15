using Fundoo.DataHandler;
using Fundoo.DependencyServices;
using Fundoo.Interfaces;
using Fundoo.Model;
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
	public partial class ListNotePage : ContentPage
	{
		public ListNotePage ()
		{
			InitializeComponent ();
		}


        /// <summary>
        /// Gets the notes.
        /// </summary>
        public async void GetNotes()
        {
            DataLogic dataLogic = new DataLogic();
            var allNotes = await dataLogic.GetAllNotes();

            List<Note> notesList = new List<Note>();
            foreach (Note note in allNotes)
            {
                notesList.Add(note);
            }

            allNotes = null;
           
            NotesList.ItemsSource = notesList;
        }

        protected override void OnAppearing()
        {
            GetNotes();
            base.OnAppearing();
        }

        private void LogoutIcon_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IFirebaseAuthenticator>().Signout();
            Message.ShowToastMessage("LoggedOut Successfully");

            Navigation.PopToRootAsync();
            Navigation.PushAsync(new Greeting());
        }

        private void GridIcontem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GridNotesPage());
            Navigation.RemovePage(this);
        }

        private void TakeaNote_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WriteNotesPage());
        }

    }
}