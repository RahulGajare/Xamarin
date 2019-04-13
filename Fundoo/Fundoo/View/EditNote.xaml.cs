using Fundoo.DataHandler;
using Fundoo.DependencyServices;
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
    public partial class EditNote : ContentPage
    {
        bool DeleteButtonClicked = false;
        bool ArchivedClicked = false;
        bool isArchive = false;
        string noteKey = string.Empty;


        public EditNote(string noteKey, bool isArchive)
        {
            InitializeComponent();
            this.noteKey = noteKey;
            this.isArchive = isArchive;
            GetTappedNotes(noteKey);
        }

        public async void GetTappedNotes(string noteKey)
        {
            DataLogic datalogic = new DataLogic();
            if (isArchive)
            {
                Archive archivedNote = await datalogic.GetArchiveNote(noteKey);
                Entrytitle.Text = archivedNote.Title;
                Editorinfo.Text = archivedNote.Info;
            }
            else
            {
                Note note = await datalogic.GetNote(noteKey);
                Entrytitle.Text = note.Title;
                Editorinfo.Text = note.Info;
            }
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    if (string.IsNullOrEmpty(Entrytitle.Text) && string.IsNullOrEmpty(Editorinfo.Text))
        //    {
        //        Message.ShowToastMessage("Empty Notes Discared");
        //        return false;
        //    }

        //    this.CallSaveEditedNoted();

        //    return base.OnBackButtonPressed();
        //}

        protected override void OnDisappearing()
        {
            if (DeleteButtonClicked == false && ArchivedClicked == false)
            {
                if (string.IsNullOrEmpty(Entrytitle.Text) && string.IsNullOrEmpty(Editorinfo.Text))
                {
                    Message.ShowToastMessage("Empty Notes Discared");
                }
                else
                {
                    this.CallSaveEditedNoted();
                }
            }
        }


        private async void CallSaveEditedNoted()
        {

            Note editedNote = new Note()
            {
                Title = Entrytitle.Text,
                Info = Editorinfo.Text
            };

            DataLogic datalogic = new DataLogic();
            await datalogic.SaveEditedNotes(this.noteKey, editedNote);
            Message.ShowToastMessage("Notes Saved");
        }


        private void DeleteIcon_Clicked(object sender, EventArgs e)
        {
            if (this.isArchive)
            {
                this.CallDeleteArchivedNote(this.noteKey);
                this.DeleteButtonClicked = true;
            }
            else
            {
                this.CallDeleteNote(this.noteKey);

                ////this because after deleting pagepopsup and prevents running of code in OnDisappearing().
                this.DeleteButtonClicked = true;
            }
          
        }


        public async void CallDeleteNote(string noteKey)
        {
            
            DataLogic datalogic = new DataLogic();
            bool isDeleted = await datalogic.DeleteNote(noteKey);
            if (isDeleted)
            {
                Message.ShowToastMessage("Deleted");
                await Navigation.PopAsync();
            }

        }

        public async void CallDeleteArchivedNote(string noteKey)
        {
            DataLogic datalogic = new DataLogic();
            bool isDeleted = await datalogic.DeleteArchivedNote(noteKey);
            if (isDeleted)
            {
                Message.ShowToastMessage("Deleted");
                await Navigation.PopAsync();
            }
        }

        private void Archive_Clicked(object sender, EventArgs e)
        {
            this.CallArchiveNote();
            this.ArchivedClicked = true;
        }

        private async void CallArchiveNote()
        {
            Archive archivedNote = new Archive()
            {
                Title = Entrytitle.Text,
                Info = Editorinfo.Text
            };

            DataLogic datalogic = new DataLogic();
            bool isArchived = await datalogic.AddArchiveNote(archivedNote);
            if (isArchived)
            {
                Message.ShowToastMessage("Moved to Archived");
            }

            await datalogic.DeleteNote(noteKey);
            await Navigation.PopAsync();
        }
    }
}