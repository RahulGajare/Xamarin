﻿using Fundoo.DataHandler;
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
        }


        private void DynamicGridView(List<Model.Note> notesList)
        {

            if (notesList.Count == 0)
            {
                return;
            }

            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(114.5, GridUnitType.Absolute) });
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(114.5, GridUnitType.Absolute) });
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(114.5, GridUnitType.Absolute) });
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
            gridLayout.Margin = new Thickness(2,2,2,2);
            
            
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

                var stackLayout1 = new StackLayout();
                  
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += this.stackLayoutTap_Tapped;
                stackLayout1.GestureRecognizers.Add(tapGestureRecognizer);

               

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

                var noteKey = new Label
                {
                    Text = note.Key,
                    IsVisible = false
                };

                ////stackLayout1.Children.Add(boxview);
                stackLayout1.Children.Add(titleLable);
                stackLayout1.Children.Add(infoLable);
                stackLayout1.Children.Add(noteKey);
                stackLayout1.Spacing = 2;
                stackLayout1.Margin = 2;
                ////  stackLayout1.BackgroundColor = Color.BlanchedAlmond;

                //var stackLayout2 = new StackLayout();
                //stackLayout2.Margin = new Thickness(2,2,2,2);
               

                var frame = new Frame();
                frame.BorderColor = Color.Black;
                frame.BackgroundColor = Color.BlanchedAlmond;
                
                frame.Content = stackLayout1;
               

                gridLayout.Children.Add(frame, column, row);
                column++;

            }            
        }

        private void stackLayoutTap_Tapped(object sender, EventArgs e)
        {
            StackLayout gridNoteStack = (StackLayout)sender;
            IList<Xamarin.Forms.View> item = gridNoteStack.Children;
            Label key = (Label)item[2];
            var notekey = key.Text;
            Navigation.PushAsync(new EditNote(notekey));
        }
        
    }
}