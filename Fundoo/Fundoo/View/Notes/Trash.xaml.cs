// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trash.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------


using Fundoo.DataHandler;
using Fundoo.Model;
using Fundoo.ModelView;
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
    public partial class Trash : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trash"/> class.
        /// </summary>
        public Trash()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            GetNotes();
            base.OnAppearing();
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        public async void GetNotes()
        {
            NotesHandler notesHandler = new NotesHandler();
             var notesList = await notesHandler.GetAllNotes();
            List<Note> trashNotesList = new List<Note>();

            foreach (Note note in notesList)
            {
                ////Adding only Notes that are trash.
                if (note.IsTrash == true)
                {
                    trashNotesList.Add(note);
                }
            }

            this.DynamicGridView(trashNotesList);
        }

        /// <summary>
        /// Dynamics the grid view.
        /// </summary>
        /// <param name="notesList">The notes list.</param>
        private void DynamicGridView(List<Model.Note> notesList)
        {
            if (notesList.Count == 0)
            {
                return;
            }
            ////initializing with 2 columns and 1 row.
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute) });
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute) });
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
            gridLayout.Margin = new Thickness(2, 2, 2, 2);

            int column = 0;
            int row = 0;

            foreach (Note note in notesList)
            {
                //// For after every 3rd Column adds a new row.
                if (column == 2)
                {
                    gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
                    column = 0;
                    row++;
                }

                var stackLayout1 = new StackLayout();

                ////Adding TapGesture to stackLayout1.
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += this.StackLayoutTap_Tapped;
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

                var noteColor = new Label
                {
                    Text = note.Color,
                    IsVisible = false
                };

                stackLayout1.Children.Add(titleLable);
                stackLayout1.Children.Add(infoLable);
                stackLayout1.Children.Add(noteKey);
                stackLayout1.Children.Add(noteColor);
                stackLayout1.Spacing = 2;
                stackLayout1.Margin = 2;

                var frame = new Frame();
                frame.BorderColor = Color.Black;
                frame.CornerRadius = 20;

                FrameColorSetter.GetColor(note, frame);
                frame.Content = stackLayout1;


                gridLayout.Children.Add(frame, column, row);
                column++;

            }
        }

        /// <summary>
        /// Handles the Tapped event of the StackLayoutTap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void StackLayoutTap_Tapped(object sender, EventArgs e)
        {
            StackLayout gridNoteStack = (StackLayout)sender;
            IList<Xamarin.Forms.View> item = gridNoteStack.Children;
            Label key = (Label)item[2];
            ///  Label noteColor = (Label)item[3];
            var notekey = key.Text;
            Navigation.PushAsync(new TrashNoteTap(notekey));
        }
    }
}