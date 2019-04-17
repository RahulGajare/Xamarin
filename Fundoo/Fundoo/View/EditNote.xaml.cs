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

namespace Fundoo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNote : ContentPage
    {
        Note retrivedNote = null;
        Archive retrivedArchiveNote = null;
        bool DeleteButtonClicked = false;
        bool ArchivedClicked = false;
        bool isArchive = false;
        string noteKey = string.Empty;


        public Color ColorBackground { get; set; }

        private Color backGroundColor;
        private string noteColor = "white";

        public EditNote()
        {

        }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="noteKey"></param>
            /// <param name="isArchive"></param>
            public EditNote(string noteKey, bool isArchive)
        {
            InitializeComponent();
            this.noteKey = noteKey;
            this.isArchive = isArchive;
            GetTappedNotes(noteKey);

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

        public async void GetTappedNotes(string noteKey)
        {
            DataLogic datalogic = new DataLogic();
            if (isArchive)
            {
                this.retrivedArchiveNote = await datalogic.GetArchiveNote(noteKey);
                Entrytitle.Text = retrivedArchiveNote.Title;
                Editorinfo.Text = retrivedArchiveNote.Info;
                this.noteColor = retrivedArchiveNote.Color;
                this.BackgroundColor = Color.FromHex(FrameColorSetter.GetHexColor(retrivedArchiveNote));
            }
            else
            {
                this.retrivedNote = await datalogic.GetNote(noteKey);
                Entrytitle.Text = retrivedNote.Title;
                Editorinfo.Text = retrivedNote.Info;
                this.noteColor = retrivedNote.Color;
                this.BackgroundColor = Color.FromHex(FrameColorSetter.GetHexColor(retrivedNote));
            }
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    if (string.IsNullOrEmpty(Entrytitle.Text) && string.IsNullOrEmpty(Editorinfo.Text))
        //    {
        //        Message.ShowToastMessage("Empty Notes Discared");
        //        return false;
        //    }

        //    this.CallSaveEditedNote();

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
                    if (isArchive)
                    {
                        this.CallSaveEditedArchiveNote();
                    }
                    else
                    {
                        this.CallSaveEditedNote();
                    }

                }
            }
        }


        private async void CallSaveEditedNote()
        {

            Note editedNote = new Note()
            {
                Title = Entrytitle.Text,
                Info = Editorinfo.Text,
                Color = this.noteColor

            };

            DataLogic datalogic = new DataLogic();
            await datalogic.SaveEditedNote(this.noteKey, editedNote);
            Message.ShowToastMessage("Notes Saved");
        }

        private async void CallSaveEditedArchiveNote()
        {

            Archive editedArchiveNote = new Archive()
            {
                Title = Entrytitle.Text,
                Info = Editorinfo.Text,
                Color = this.noteColor

            };

            DataLogic datalogic = new DataLogic();
            await datalogic.SaveEditedArchiveNote(this.noteKey, editedArchiveNote);
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

                ////this because after deleting, page popsup and prevents running of code in OnDisappearing().
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
                Info = Editorinfo.Text,
                Color = this.noteColor
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

        public void AddBoxIcon_Tapped(object sender, EventArgs e)
        {
            //// handles the tap over google icon   
            this.DisplayAlert("Alert", "AddBoxIcon", "OK");
        }

        public void VerticalMenuIcon_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new NotesSlideUpMenu()); ;
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
       
        public  void changeColor()
        {
            this.BackgroundColor = Color.MintCream;
            this.noteColor = "MintCream";
        }

        protected override void OnAppearing()
        {
            this.BackgroundColor = Color.DeepPink;
            base.OnAppearing();
        }
    }
    }
