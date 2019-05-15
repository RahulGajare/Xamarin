// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArchivePage.xaml.cs" company="Bridgelabz">
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
    using Fundoo.DataHandler;
    using Fundoo.DependencyServices;
    using Fundoo.Model;
    using Fundoo.ModelView;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// ArchivePage Class
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArchivePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArchivePage"/> class.
        /// </summary>
        public ArchivePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            this.GetNotes();
            base.OnAppearing();
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        public async void GetNotes()
        {
            NotesHandler notesHandler = new NotesHandler();
              var notesList = await notesHandler.GetAllNotes();
            List<Note> pinnedList = new List<Note>();
            List<Note> unpinnedList = new List<Note>();

            foreach (Note note in notesList)
            {
                ////Adding only Notes That are Archived
                if (note.IsArchive)
                {
                    if (note.IsPinned)
                    {
                        pinnedList.Add(note);
                    }
                    else
                    {
                        unpinnedList.Add(note);
                    }
                }
            }

            this.DynamicGridViewPinned(pinnedList);
            this.DynamicGridViewUnpinned(unpinnedList);
        }

        /// <summary>
        /// Dynamics the grid view pinned.
        /// </summary>
        /// <param name="notesList">The notes list.</param>
        private void DynamicGridViewPinned(List<Model.Note> notesList)
        {
            if (notesList.Count == 0)
            {
                return;
            }

            gridLayoutPinned.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175, GridUnitType.Absolute) });
            gridLayoutPinned.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175, GridUnitType.Absolute) });     
            gridLayoutPinned.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
            gridLayoutPinned.Margin = new Thickness(2, 2, 2, 2);

            int column = 0;
            int row = 0;
            foreach (Note note in notesList)
            {
                //// For after every 3rd Column adds a new row.
                if (column == 2)
                {
                    gridLayoutPinned.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
                    column = 0;
                    row++;
                }

                var stackLayout1 = new StackLayout();

                ////Adding TapGesture to StackLayout
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += this.StackLayoutTap_Tapped;
                stackLayout1.GestureRecognizers.Add(tapGestureRecognizer);
                ////Labee for Title
                var titleLable = new Label
                {
                    Text = note.Title,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };

                ////Label for Notes Descreption
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
                frame.CornerRadius = 20;
                frame.BorderColor = Color.Black;
                FrameColorSetter.GetColor(note, frame);
                frame.Content = stackLayout1;

                gridLayoutPinned.Children.Add(frame, column, row);
                column++;
            }
        }

        /// <summary>
        /// Dynamics the grid view unpinned.
        /// </summary>
        /// <param name="notesList">The notes list.</param>
        private void DynamicGridViewUnpinned(List<Model.Note> notesList)
        {
            if (notesList.Count == 0)
            {
                return;
            }

            gridLayoutUnpinned.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175, GridUnitType.Absolute) });
            gridLayoutUnpinned.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175, GridUnitType.Absolute) });
            gridLayoutUnpinned.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
            gridLayoutUnpinned.Margin = new Thickness(2, 2, 2, 2);

            int column = 0;
            int row = 0;
            foreach (Note note in notesList)
            {
                //// For after every 3rd Column adds a new row.
                if (column == 2)
                {
                    gridLayoutUnpinned.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
                    column = 0;
                    row++;
                }

                var stackLayout2 = new StackLayout();

                ////Adding TapGesture to StackLayout
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += this.StackLayoutTap_Tapped;
                stackLayout2.GestureRecognizers.Add(tapGestureRecognizer);

                ////Labee for Title
                var titleLable = new Label
                {
                    Text = note.Title,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };

                ////Label for Notes Description
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
              
                stackLayout2.Children.Add(titleLable);
                stackLayout2.Children.Add(infoLable);
                stackLayout2.Children.Add(noteKey);
                stackLayout2.Children.Add(noteColor);
                stackLayout2.Spacing = 2;
                stackLayout2.Margin = 2;

                var frame = new Frame();
                frame.BorderColor = Color.Black;
                frame.CornerRadius = 20;

                FrameColorSetter.GetColor(note, frame);
                frame.Content = stackLayout2;

                gridLayoutUnpinned.Children.Add(frame, column, row);
                column++;
            }
        }

        /// <summary>
        /// Handles the Tapped event of the stackLayoutTap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void StackLayoutTap_Tapped(object sender, EventArgs e)
        {
            StackLayout gridNoteStack = (StackLayout)sender;
            IList<Xamarin.Forms.View> item = gridNoteStack.Children;
            Label key = (Label)item[2];
            var notekey = key.Text;
            Navigation.PushAsync(new EditNote(notekey));
        }
    }
}