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
        Note retrivedNote = null;
        bool isArchive;
        bool isPinned;
        bool isTrash;

        string noteKey = string.Empty;


        private string noteColor = "white";

        public TrashNoteTap()
		{
			InitializeComponent ();
		}

        public TrashNoteTap(string noteKey)
        {
            this.noteKey = noteKey;
            GetTappedNotes(noteKey);
            InitializeComponent();

        }

        public async void GetTappedNotes(string noteKey)
        {
            DataLogic datalogic = new DataLogic();
            //if (this.isArchive)
            //{              
            //    this.retrivedArchiveNote = await datalogic.GetArchiveNote(noteKey);
            //    Entrytitle.Text = retrivedArchiveNote.Title;
            //    Editorinfo.Text = retrivedArchiveNote.Info;
            //    this.noteColor = retrivedArchiveNote.Color;
            //    this.isPinned = retrivedArchiveNote.IsPinned;
            //    this.isTrash = retrivedArchiveNote.IsTrash;
            //    this.BackgroundColor = Color.FromHex(FrameColorSetter.GetHexColor(retrivedArchiveNote));
            //    this.InitializeToolBarItems();


            //}
            //else
            //{   
            // }

            this.retrivedNote = await datalogic.GetNote(noteKey);
            Entrytitle.Text = retrivedNote.Title;
            Editorinfo.Text = retrivedNote.Info;
            this.noteColor = retrivedNote.Color;
            this.isPinned = retrivedNote.IsPinned;
            this.isTrash = retrivedNote.IsTrash;
            this.isArchive = retrivedNote.IsArchive;
            this.BackgroundColor = Color.FromHex(FrameColorSetter.GetHexColor(retrivedNote));
            
        }

        private async void RestoreIcon_Clicked(object sender, EventArgs e)
        {
            this.isTrash = false;
            DataLogic dataLogic = new DataLogic();
            Note editedNote = new Note()
            {
                Title = Entrytitle.Text,
                Info = Editorinfo.Text,
                Color = this.noteColor,
                IsPinned = this.isPinned,
                IsTrash = this.isTrash,
                IsArchive = this.isArchive

            };


            await dataLogic.SaveNote(editedNote);
            await dataLogic.DeleteNote(noteKey);
            Message.ShowToastMessage("Notes Restored");
        }

        private async void DeleteIcon_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Note will be Deleted forever", "OK","Cancle");
            DataLogic dataLogic = new DataLogic();
            await dataLogic.DeleteNote(this.noteKey);
        }
    }
}