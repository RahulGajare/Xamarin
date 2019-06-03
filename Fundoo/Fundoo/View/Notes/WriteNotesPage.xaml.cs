// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WriteNotesPage.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------


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
    public partial class WriteNotesPage : ContentPage
    {

        private string noteColor = "white";
        private bool isLabled = false;
        private string lableKey;
        private string noteKey;
        private bool isPinned = false;
  

        public WriteNotesPage(bool isLabled)
        {          
            this.InitializeComponent();
            this.InitializeToolBarItems();
        }

        public WriteNotesPage(bool islabled, string lableKey)
        {
            this.lableKey = lableKey;
            this.isLabled = islabled;
            this.InitializeComponent();
            this.InitializeToolBarItems();

        }

        public void InitializeToolBarItems()
        {
            ToolbarItems.Clear();
            ToolbarItems.Add(this.UnPinnedIcon);        
        }

       
        protected override async void OnDisappearing()
        {       
            try
            {
               //// DataLogic dataLogic = new DataLogic();

                if (title.Text == null && info.Text == null)
                {
                    Message.ShowToastMessage("Empty Notes Discared");
                }
                else
                {
                    if (title.Text == null)
                    {
                        title.Text = string.Empty;
                    }

                    if (info.Text == null)
                    {
                        info.Text = string.Empty;
                    }
                    await this.CallCreatenotes();

                    if (noteKey != null)
                    {
                        Message.ShowToastMessage("Notes Saved");
                    }

                    ////To Check If a Note belongs to a lable
                    if (isLabled)
                    {
                        ////Calling async method
                        await this.CallGetLableByKey();                           
                    }                    
                }        
            }
            catch (Exception)
            {
                Message.ShowToastMessage("Notes Not saved, ERROR");             
            }
        }


        public async Task CallCreatenotes()
        {
             NotesHandler notesHandler = new NotesHandler();
              await notesHandler.CreateNotes(title.Text, info.Text, this.noteColor ,this.isPinned);
            this.noteKey = notesHandler.responseKey;
            return;
        }


        public async Task CallGetLableByKey()
        {

            LabelHandler labelHandler = new LabelHandler();
            Model.LabelModel lable = await labelHandler.GetLabelByKey(this.lableKey);

            lable.NoteKeysList.Add(this.noteKey);

            if (await labelHandler.SaveLableByKey(lable, this.lableKey))
            {
                Message.ShowToastMessage("Notes Saved");
            }
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

        private void UnPinnedIcon_Clicked(object sender, EventArgs e)
        {
            ToolbarItems.Add(PinnedIcon);
            ToolbarItems.Remove(UnPinnedIcon);
            this.isPinned = true;
           
            ///this.OnAppearing();
        }

        private void PinnedIcon_Clicked(object sender, EventArgs e)
        {
            this.isPinned = false;
            ToolbarItems.Add(UnPinnedIcon);
            ToolbarItems.Remove(PinnedIcon);
        }
    }
}