// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrashNoteTap.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------


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

namespace Fundoo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrashNoteTap : ContentPage
    {
        public Note retrivedNote = null;
        public bool isArchive;
        public bool isPinned;
        public bool isTrash;

        string noteKey = string.Empty;


        private string noteColor = "white";

        public TrashNoteTap()
        {
            InitializeComponent();
        }

        public TrashNoteTap(string noteKey)
        {
            this.noteKey = noteKey;
            GetTappedNotes(noteKey);
            InitializeComponent();

        }

        /// <summary>
        /// Gets the tapped notes.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        public async void GetTappedNotes(string noteKey)
        {
            NotesHandler notesHandler = new NotesHandler(); ;
            this.retrivedNote = await notesHandler.GetNote(noteKey);
            Entrytitle.Text = retrivedNote.Title;
            Editorinfo.Text = retrivedNote.Info;
            this.noteColor = retrivedNote.Color;
            this.isPinned = retrivedNote.IsPinned;
            this.isTrash = retrivedNote.IsTrash;
            this.isArchive = retrivedNote.IsArchive;
            this.BackgroundColor = Color.FromHex(FrameColorSetter.GetHexColor(retrivedNote));
        }

        /// <summary>
        /// Handles the Clicked event of the RestoreIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void RestoreIcon_Clicked(object sender, EventArgs e)
        {
            this.isTrash = false;
            NotesHandler notesHandler = new NotesHandler();
              Note editedNote = new Note()
            {
                Title = Entrytitle.Text,
                Info = Editorinfo.Text,
                Color = this.noteColor,
                IsPinned = this.isPinned,
                IsTrash = this.isTrash,
                IsArchive = this.isArchive

            };

            await notesHandler.SaveNote(editedNote);
            await notesHandler.DeleteNote(noteKey);
            Message.ShowToastMessage("Notes Restored");
        }

        /// <summary>
        /// Handles the Clicked event of the DeleteIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void DeleteIcon_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Note will be Deleted forever", "OK", "Cancle");
            NotesHandler notesHandler = new NotesHandler();
            await notesHandler.DeleteNote(this.noteKey);
        }
    }
}