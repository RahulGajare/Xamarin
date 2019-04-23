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
        //  Archive retrivedArchiveNote = null;
        bool DeleteButtonClicked = false;

        bool isArchive;
        bool isPinned;
        bool isTrash;

        string noteKey = string.Empty;


        private string noteColor = "white";

        public EditNote()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="noteKey"></param>
        /// <param name="isArchive"></param>
        public EditNote(string noteKey)
        {
            ToolbarItems.Clear();
            this.noteKey = noteKey;
            GetTappedNotes(noteKey);
            InitializeComponent();

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
            this.InitializeToolBarItems();

        }

        public void InitializeToolBarItems()
        {
            if (this.isArchive)
            {
                if (isPinned)
                {
                    ToolbarItems.Clear();
                    ToolbarItems.Add(this.DeleteIcon);
                    ToolbarItems.Add(this.PinnedIcon);
                    ToolbarItems.Add(this.UnarchiveIcon);
                    //ToolbarItems.Remove(this.UnPinnedIcon);
                }
                else
                {
                    ToolbarItems.Clear();
                    ToolbarItems.Add(this.DeleteIcon);
                    ToolbarItems.Add(this.UnPinnedIcon);
                    ToolbarItems.Add(this.UnarchiveIcon);
                    // ToolbarItems.Remove(this.PinnedIcon);
                }

            }
            else
            {
                if (isPinned)
                {
                    ToolbarItems.Clear();
                    ToolbarItems.Add(this.DeleteIcon);
                    ToolbarItems.Add(this.PinnedIcon);
                    ToolbarItems.Add(this.ArchiveIcon);
                    //ToolbarItems.Remove(this.UnPinnedIcon);
                }
                else
                {
                    ToolbarItems.Clear();
                    ToolbarItems.Add(this.DeleteIcon);
                    ToolbarItems.Add(this.UnPinnedIcon);
                    ToolbarItems.Add(this.ArchiveIcon);
                    // ToolbarItems.Remove(this.PinnedIcon);
                }
            }
        }

        private void UnPinnedIcon_Clicked(object sender, EventArgs e)
        {
            this.isPinned = true;
            ToolbarItems.Clear();
            ToolbarItems.Add(this.DeleteIcon);
            ToolbarItems.Add(PinnedIcon);
            ToolbarItems.Add(this.ArchiveIcon);
            ToolbarItems.Remove(UnPinnedIcon);


            ///this.OnAppearing();
        }

        private void PinnedIcon_Clicked(object sender, EventArgs e)
        {
            this.isPinned = false;
            ToolbarItems.Clear();
            ToolbarItems.Add(this.DeleteIcon);
            ToolbarItems.Add(UnPinnedIcon);
            ToolbarItems.Add(this.ArchiveIcon);
            ToolbarItems.Remove(PinnedIcon);
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

            if (string.IsNullOrEmpty(Entrytitle.Text) && string.IsNullOrEmpty(Editorinfo.Text))
            {
                Message.ShowToastMessage("Empty Notes Discared");
            }
            else
            {
                //if (isArchive)
                //{
                //    this.CallSaveEditedArchiveNote();
                //}
                //else
                //{

                //}

                this.CallSaveEditedNote();

            }

        }


        private async void CallSaveEditedNote()
        {

            Note editedNote = new Note()
            {
                Title = Entrytitle.Text,
                Info = Editorinfo.Text,
                Color = this.noteColor,
                IsPinned = this.isPinned,
                IsTrash = this.isTrash,
                IsArchive = this.isArchive

            };

            DataLogic datalogic = new DataLogic();
            await datalogic.SaveEditedNote(this.noteKey, editedNote);

            if (this.DeleteButtonClicked)
            {
                Message.ShowToastMessage("Moved To Trash");
            }
            else if (isArchive)
            {
                Message.ShowToastMessage("Notes moved to Archived");
            }
        }

        //private async void CallSaveEditedArchiveNote()
        //{

        //    Archive editedArchiveNote = new Archive()
        //    {
        //        Title = Entrytitle.Text,
        //        Info = Editorinfo.Text,
        //        Color = this.noteColor,
        //        IsPinned = this.isPinned,
        //        IsTrash = this.isTrash

        //    };

        //    DataLogic datalogic = new DataLogic();
        //    await datalogic.SaveEditedArchiveNote(this.noteKey, editedArchiveNote);
        //    if (this.DeleteButtonClicked)
        //    {
        //        Message.ShowToastMessage("Moved To Trash");
        //    }
        //    else
        //    {
        //        Message.ShowToastMessage("Notes Saved");
        //    }

        //}


        private async void DeleteIcon_Clicked(object sender, EventArgs e)
        {

            this.isTrash = true;
            this.DeleteButtonClicked = true;
            Message.ShowToastMessage("Note moved to Trash");
            await Navigation.PopAsync();



            //if (this.isArchive)
            //{
            //    this.CallDeleteArchivedNote(this.noteKey);
            //    this.DeleteButtonClicked = true;
            //}
            //else
            //{
            //    this.CallDeleteNote(this.noteKey);

            //    ////this because after deleting, page popsup and prevents running of code in OnDisappearing().
            //    this.DeleteButtonClicked = true;
            //}
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

        //public async void CallDeleteArchivedNote(string noteKey)
        //{
        //    DataLogic datalogic = new DataLogic();
        //    bool isDeleted = await datalogic.DeleteArchivedNote(noteKey);
        //    if (isDeleted)
        //    {
        //        Message.ShowToastMessage("Deleted");
        //        await Navigation.PopAsync();
        //    }
        //}

        private async void Archive_Clicked(object sender, EventArgs e)
        {
            // this.CallAddArchiveNote();
            this.isArchive = true;
            Message.ShowToastMessage("Notes moved to Archived");
            await Navigation.PopAsync();

        }



        //private async void CallAddArchiveNote()
        //{
        //    Archive archivedNote = new Archive()
        //    {
        //        Title = Entrytitle.Text,
        //        Info = Editorinfo.Text,
        //        Color = this.noteColor,
        //        IsPinned = this.isPinned
        //    };

        //    DataLogic datalogic = new DataLogic();
        //    bool isArchived = await datalogic.AddArchiveNote(archivedNote);
        //    if (isArchived)
        //    {
        //        Message.ShowToastMessage("Moved to Archived");
        //    }

        //    await datalogic.DeleteNote(noteKey);
        //    await Navigation.PopAsync();
        //}

        private async void UnarchiveIcon_Clicked(object sender, EventArgs e)
        {

            this.isArchive = false;
            Message.ShowToastMessage("Notes UnArchived");
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

        public void changeColor()
        {
            this.BackgroundColor = Color.MintCream;
            this.noteColor = "MintCream";
        }



    }
}
