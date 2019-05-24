// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditNote.xaml.cs" company="Bridgelabz">
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
    using Rg.Plugins.Popup.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNote : ContentPage
    {

        Note retrivedNote = null;

        private bool DeleteButtonClicked = false;
        private bool isArchive;
        private bool isPinned;
        private bool isTrash;
        private string noteKey = string.Empty;
        private bool isCollaborated;
        private string senderUid;
        private string noteColor = "white";

        /// <summary>
        /// Initializes a new instance of the <see cref="EditNote"/> class.
        /// </summary>
        public EditNote()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditNote"/> class.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        public EditNote(string noteKey)
        {
            this.InitializeComponent();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.OrangeRed;

            ToolbarItems.Clear();
            this.noteKey = noteKey;
            this.GetTappedNotes(noteKey);
         

            var AddBoxIconTap = new TapGestureRecognizer();
            //// Binding events 
            AddBoxIconTap.Tapped += this.AddBoxIcon_Tapped;
            ///// Associating tap events to the image buttons    
            AddBoxIcon.GestureRecognizers.Add(AddBoxIconTap);

            var VerticalMenuIconTap = new TapGestureRecognizer();
            //// Binding events 
            VerticalMenuIconTap.Tapped += this.VerticalMenuIcon_Tapped;
            ///// Associating tap events to the image buttons    
            VerticalMenuIcon.GestureRecognizers.Add(VerticalMenuIconTap);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditNote"/> class.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        /// <param name="isCollaborated">if set to <c>true</c> [is collaborated].</param>
        /// <param name="senderUid">The sender uid.</param>
        public EditNote(string noteKey, bool isCollaborated, string senderUid)
        {
            ToolbarItems.Clear();
            this.noteKey = noteKey;
            this.isCollaborated = isCollaborated;
            this.senderUid = senderUid;
            this.GetTappedNotes(noteKey);
            this.InitializeComponent();

            var AddBoxIconTap = new TapGestureRecognizer();
            //// Binding events 
            AddBoxIconTap.Tapped += this.AddBoxIcon_Tapped;
            ///// Associating tap events to the image buttons    
            AddBoxIcon.GestureRecognizers.Add(AddBoxIconTap);

            var VerticalMenuIconTap = new TapGestureRecognizer();
            //// Binding events 
            VerticalMenuIconTap.Tapped += this.VerticalMenuIcon_Tapped;
            ///// Associating tap events to the image buttons    
            VerticalMenuIcon.GestureRecognizers.Add(VerticalMenuIconTap);
        }

        protected async override void OnAppearing()
        {
            NotesHandler notesHandler = new NotesHandler();

            if (this.isCollaborated)
            {
                this.retrivedNote = await notesHandler.GetNote(noteKey, this.senderUid);
            }
            else
            {
                this.retrivedNote = await notesHandler.GetNote(noteKey);
            }

          

            Entrytitle.Text = this.retrivedNote.Title;
            Editorinfo.Text = this.retrivedNote.Info;
            this.senderUid = this.retrivedNote.SenderUid;
            this.isCollaborated = this.retrivedNote.IsCollaborated;
            this.noteColor = this.retrivedNote.Color;
            this.isPinned = this.retrivedNote.IsPinned;
            this.isTrash = this.retrivedNote.IsTrash;
            this.isArchive = this.retrivedNote.IsArchive;
            this.BackgroundColor = Color.FromHex(FrameColorSetter.GetHexColor(retrivedNote));
            this.InitializeToolBarItems();
            base.OnAppearing();
        }

        ///// <summary>
        ///// Changes the color.
        ///// </summary>
        //public void changeColor()
        //{
        //    this.BackgroundColor = Color.MintCream;
        //    this.noteColor = "MintCream";
        //}

        /// <summary>
        /// Gets the tapped notes.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        public async void GetTappedNotes(string noteKey)
        {
            NotesHandler notesHandler = new NotesHandler();

            if (this.isCollaborated)
            {
                this.retrivedNote = await notesHandler.GetNote(noteKey,this.senderUid);
            }
            else
            {
                this.retrivedNote = await notesHandler.GetNote(noteKey);
            }
           
            Entrytitle.Text = this.retrivedNote.Title;
            Editorinfo.Text = this.retrivedNote.Info;
            this.senderUid = this.retrivedNote.SenderUid;
            this.isCollaborated = this.retrivedNote.IsCollaborated;
            this.noteColor = this.retrivedNote.Color;
            this.isPinned = this.retrivedNote.IsPinned;
            this.isTrash = this.retrivedNote.IsTrash;
            this.isArchive = this.retrivedNote.IsArchive;
            this.BackgroundColor = Color.FromHex(FrameColorSetter.GetHexColor(retrivedNote));
            this.InitializeToolBarItems();
        }

        /// <summary>
        /// Initializes the tool bar items.
        /// </summary>
        public void InitializeToolBarItems()
        {
            ////Adds ToolBar Items Based On Condition.
            if (this.isArchive)
            {
                if (this.isPinned)
                {
                    ToolbarItems.Clear();
                    ToolbarItems.Add(this.DeleteIcon);
                    ToolbarItems.Add(this.ReminderAddIcon);
                    ToolbarItems.Add(this.PinnedIcon);
                    ToolbarItems.Add(this.UnarchiveIcon);
                }
                else
                {
                    ToolbarItems.Clear();
                    ToolbarItems.Add(this.DeleteIcon);
                    ToolbarItems.Add(this.ReminderAddIcon);
                    ToolbarItems.Add(this.UnPinnedIcon);
                    ToolbarItems.Add(this.UnarchiveIcon);
                }
            }
            else
            {
                if (this.isPinned)
                {
                    ToolbarItems.Clear();
                    ToolbarItems.Add(this.DeleteIcon);
                    ToolbarItems.Add(this.ReminderAddIcon);
                    ToolbarItems.Add(this.PinnedIcon);
                    ToolbarItems.Add(this.ArchiveIcon);

                }
                else
                {
                    ToolbarItems.Clear();
                    ToolbarItems.Add(this.DeleteIcon);
                    ToolbarItems.Add(this.ReminderAddIcon);
                    ToolbarItems.Add(this.UnPinnedIcon);
                    ToolbarItems.Add(this.ArchiveIcon);

                }
            }
        }

        /// <summary>
        /// Handles the Clicked event of the UnPinnedIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void UnPinnedIcon_Clicked(object sender, EventArgs e)
        {
            this.isPinned = true;
            ToolbarItems.Clear();
            ToolbarItems.Add(this.DeleteIcon);
            ToolbarItems.Add(this.ReminderAddIcon);
            ToolbarItems.Add(this.PinnedIcon);
            ToolbarItems.Add(this.ArchiveIcon);
            ToolbarItems.Remove(this.UnPinnedIcon);
        }

        /// <summary>
        /// Handles the Clicked event of the PinnedIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PinnedIcon_Clicked(object sender, EventArgs e)
        {
            this.isPinned = false;
            ToolbarItems.Clear();
            ToolbarItems.Add(this.DeleteIcon);
            ToolbarItems.Add(this.ReminderAddIcon);
            ToolbarItems.Add(UnPinnedIcon);
            ToolbarItems.Add(this.ArchiveIcon);
            ToolbarItems.Remove(this.PinnedIcon);
        }

        /// <summary>
        /// When overridden, allows the application developer to customize behavior as the <see cref="T:Xamarin.Forms.Page" /> disappears.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnDisappearing()
        {
            if (string.IsNullOrEmpty(Entrytitle.Text) && string.IsNullOrEmpty(Editorinfo.Text))
            {
                Message.ShowToastMessage("Empty Notes Discared");
            }
            else
            {
                this.CallSaveEditedNote();
            }
        }

        /// <summary>
        /// Calls the save edited note.
        /// </summary>
        private async void CallSaveEditedNote()
        {

            Note editedNote = new Note()
            {
                Title = Entrytitle.Text,
                Info = Editorinfo.Text,
                Color = this.noteColor,
                IsPinned = this.isPinned,
                IsTrash = this.isTrash,
                IsArchive = this.isArchive,
                SenderUid = this.senderUid,
                IsCollaborated = this.isCollaborated              
            };

            NotesHandler notesHandler = new NotesHandler();

            if (this.isCollaborated)
            {
                await notesHandler.SaveEditedNote(this.noteKey, editedNote,this.senderUid);
            }
            else
            {
                await notesHandler.SaveEditedNote(this.noteKey, editedNote);
            }
           

            if (this.DeleteButtonClicked)
            {
                Message.ShowToastMessage("Moved To Trash");
            }
            else if (this.isArchive)
            {
                Message.ShowToastMessage("Notes moved to Archived");
            }
        }

        /// <summary>
        /// Handles the Clicked event of the DeleteIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void DeleteIcon_Clicked(object sender, EventArgs e)
        {
            this.isTrash = true;
            this.isArchive = false; //// Removing from archive,when deleted.
            this.DeleteButtonClicked = true;
            Message.ShowToastMessage("Note moved to Trash");
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Calls the delete note.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        public async void CallDeleteNote(string noteKey)
        {

            NotesHandler notesHandler = new NotesHandler();
            bool isDeleted = await notesHandler.DeleteNote(noteKey);
            if (isDeleted)
            {
                Message.ShowToastMessage("Deleted");
                await Navigation.PopAsync();
            }
        }

        /// <summary>
        /// Handles the Clicked event of the Archive control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Archive_Clicked(object sender, EventArgs e)
        {
            // this.CallAddArchiveNote();
            this.isArchive = true;
            Message.ShowToastMessage("Notes moved to Archived");
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Handles the Clicked event of the UnarchiveIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void UnarchiveIcon_Clicked(object sender, EventArgs e)
        {
            this.isArchive = false;
            Message.ShowToastMessage("Notes UnArchived");
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Handles the Tapped event of the AddBoxIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void AddBoxIcon_Tapped(object sender, EventArgs e)
        {
            //// handles the tap over google icon   
            this.DisplayAlert("Alert", "AddBoxIcon", "OK");
        }

        /// <summary>
        /// Handles the Tapped event of the VerticalMenuIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void VerticalMenuIcon_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new NotesSlideUpMenu(noteKey));
        }

        private void Aqua_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Aqua;
            this.noteColor = "Aqua";
        }

        private void DarkGoldenrod_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.DarkGoldenrod;
            this.noteColor = "DarkGoldenrod";
        }

        private void Green_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Green;
            this.noteColor = "Green";
        }

        private void Gold_Clicked_(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Gold;
            this.noteColor = "Gold";
        }

        private void GreenYellow_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.GreenYellow;
            this.noteColor = "GreenYellow";
        }

        private void Gray_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Gray;
            this.noteColor = "Gray";
        }

        private void Lavender_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Lavender;
            this.noteColor = "Lavender";
        }

        private void MintCream_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.MintCream;
            this.noteColor = "MintCream";
        }

        private void LightPink_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.LightPink;
            this.noteColor = "LightPink";
        }

        /// <summary>
        /// Handles the Clicked event of the ReminderIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ReminderIcon_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RemindersPage(this.retrivedNote.Title, this.retrivedNote.Info));
        }

        
    }
}
