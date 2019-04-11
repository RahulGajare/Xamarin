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
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            this.InitializeComponent();
            var tapGrid = new TapGestureRecognizer();

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
            if (notesList.Count == 0)
            {
                return;
            }

            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(110)});
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(110)});
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(110)});
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
            gridLayout.Margin = 5;

            int column = 0;
            int row = 0;


            foreach (Note note in notesList)
            {
                //// For after every 3rd Column adds a new row.
                if (column == 3)
                {
                    gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
                    column = 0;
                    row++;
                }

                var stackLayout = new StackLayout();
                //var boxview = new BoxView() { BackgroundColor = Color.BlanchedAlmond, HorizontalOptions = LayoutOptions.FillAndExpand , VerticalOptions = LayoutOptions.FillAndExpand};

                var titleLable = new Label
                {
                    Text = note.Title,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };

                var infoLable = new Label
                {
                    Margin = new Thickness(10, 10, 0, 0),
                    Text = note.Info,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.None,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };

                ////stackLayout.Children.Add(boxview);
                stackLayout.Children.Add(titleLable);
                stackLayout.Children.Add(infoLable);
                stackLayout.Spacing = 2;
                stackLayout.Margin = 2;
              ///  stackLayout.BackgroundColor = Color.BlanchedAlmond;

                var frame = new Frame();
                frame.BorderColor = Color.Black;
                
                frame.Content = stackLayout;


                gridLayout.Children.Add(frame, column, row);
                column++;

            }            
        }

    }
}