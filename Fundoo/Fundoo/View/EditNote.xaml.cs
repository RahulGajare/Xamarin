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
        string noteKey = string.Empty;
        

        public EditNote(string noteKey)
        {
            InitializeComponent();
            this.noteKey = noteKey;
            GetTappedNotes(noteKey);

        }

        public async void GetTappedNotes(string noteKey)
        {
            DataLogic datalogic = new DataLogic();
            Note note = await datalogic.GetNote(noteKey);
            Entrytitle.Text = note.Title;
            Editorinfo.Text = note.Info;
        }

        protected override bool OnBackButtonPressed()
        {
            if (string.IsNullOrEmpty(Entrytitle.Text) && string.IsNullOrEmpty(Editorinfo.Text))
            {
                Message.ShowToastMessage("Empty Notes Discared");
                return false;
            }

                this.CallSaveEditedNoted();
               
            return base.OnBackButtonPressed();
        }

        public async void CallSaveEditedNoted()
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
            this.CallDeleteNote(this.noteKey);
        }

        public async void CallDeleteNote(string noteKey)
        {
            DataLogic datalogic = new DataLogic();
           await datalogic.DeleteNote(noteKey);
            Message.ShowToastMessage("Deleted");
            await Navigation.PopAsync();
           
        }
    }
}