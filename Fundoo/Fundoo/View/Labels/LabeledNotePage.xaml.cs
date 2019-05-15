// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabledNotePage.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.View
{
    using Fundoo.DataHandler;
    using Fundoo.DependencyServices;
    using Fundoo.Model;
    using Fundoo.ModelView;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabeledNotePage : ContentPage
    {
        /// <summary>
        /// The lable name
        /// </summary>
        public string labelName;

        /// <summary>
        /// The current label key
        /// </summary>
        public string currentLabelKey;

        /// <summary>
        /// The datalogic
        /// </summary>
        public LabelHandler labelHandler = new LabelHandler();

        /// <summary>
        /// The notelabel handler
        /// </summary>
        public NotesHandler noteHandler = new NotesHandler();

        /// <summary>
        /// Initializes a new instance of the <see cref="LabeldNotePage"/> class.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="labelKey">The lable key.</param>
        public LabeledNotePage(string labelName, string labelKey)
        {
            this.labelName = labelName;
            this.currentLabelKey = labelKey;
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabledNotePage"/> class.
        /// </summary>
        public LabeledNotePage()
        {

        }

        /// <summary>
        /// Handles the Clicked event of the Take a Note control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TakeaNote_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WriteNotesPage(true, currentLabelKey));
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            this.Call();
        }

        /// <summary>
        /// Calls this instance.
        /// </summary>
        public async void Call()
        {
            List<Note> notesList = new List<Note>();

            ////Getting the Current Label.
            Model.LabelModel lable = await this.labelHandler.GetLabelByKey(currentLabelKey);

            if(lable != null)
            {

            }
            //// Retrieving notes Under this Current Label.
            foreach (string notekey in lable.NoteKeysList)
            {
                Note retrievedNote = await noteHandler.GetNote(notekey);

                if (retrievedNote != null)
                {
                    retrievedNote.Key = notekey;
                    notesList.Add(retrievedNote);
                }
            }

            this.DynamicGridView(notesList);

            base.OnAppearing();
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
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175, GridUnitType.Absolute) });
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175, GridUnitType.Absolute) });
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

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += this.stackLayoutTap_Tapped;
                stackLayout1.GestureRecognizers.Add(tapGestureRecognizer);

                var titleLable = new Xamarin.Forms.Label
                {
                    Text = note.Title,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };

                var infoLable = new Xamarin.Forms.Label
                {
                    Margin = new Thickness(10, 10, 0, 0),
                    Text = note.Info,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.None,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };

                var noteKey = new Xamarin.Forms.Label
                {
                    Text = note.Key,
                    IsVisible = false
                };

                var noteColor = new Xamarin.Forms.Label
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
                gridLayout.Children.Add(frame, column, row);
                column++;
            }
        }

        /// <summary>
        /// Handles the Tapped event of the stackLayoutTap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void stackLayoutTap_Tapped(object sender, EventArgs e)
        {
            StackLayout gridNoteStack = (StackLayout)sender;
            IList<Xamarin.Forms.View> item = gridNoteStack.Children;
            Xamarin.Forms.Label key = (Xamarin.Forms.Label)item[2];
            ///  Label noteColor = (Label)item[3];
            var notekey = key.Text;
            Navigation.PushAsync(new EditNote(notekey));
        }

        /// <summary>
        /// Handles the Clicked event of the DeleteLable control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DeleteLable_Clicked(object sender, EventArgs e)
        {
            this.CallDeleteLable(this.currentLabelKey);
        }

        /// <summary>
        /// Calls the delete lable.
        /// </summary>
        /// <param name="labelKey">The label key.</param>
        public async void CallDeleteLable(string labelKey)
        {
            ////Deletes The Current Label.(Notes are Note Deleted)
            bool result = await this.labelHandler.DeleteLableByKey(currentLabelKey);
            if (result)
            {
                Message.ShowToastMessage("Label Deleted");
                await Navigation.PopAsync();
            }
            else
            {
                Message.ShowToastMessage("Label Not Deleted");
            }
        }
    }
}