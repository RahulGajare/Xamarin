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

            this.DynamicGridView(allNotes);
            //NotesList.ItemsSource = allNotes;
        }


        protected override void OnAppearing()
        {
            GetNotes();
            ////DataLogic dataLogic = new DataLogic();
            ////var allNotes = await dataLogic.GetAllNotes();
            ////NotesList.ItemsSource = allNotes;
        }

        private void DynamicGridView(List<Model.Note> notesList)
        {
            int row = 0;
            int column = 0;

            var stackLayout =new StackLayout();
            stackLayout.Spacing = 10;
            
            
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(150)});
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(150)});
            gridLayout.BackgroundColor = Color.DarkTurquoise;


            for (int i = 0; i < notesList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Auto)});
                   
                    row++;
                }

                var layout = new StackLayout();
                var title = new Label
                {
                    Text = notesList[i].Title,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };

                

                var info = new Label
                {
                    Text = notesList[i].Info,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };

                
                gridLayout.Children.Add(title, column, row);
                gridLayout.Children.Add(info, column, row);
                layout.Spacing = 2;

                var frame = new Frame();
                frame.BackgroundColor = Color.Black;
                frame.Content = layout;

                column++;

                if (column == 1)
                {
                    column = 0;
                }


            }
        }

    }
}