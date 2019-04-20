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
      


        public WriteNotesPage(bool isLabled)
        {
            this.InitializeComponent();
        }

        public WriteNotesPage(bool islabled, string lableKey)
        {
            this.lableKey = lableKey;
            this.isLabled = islabled;
            this.InitializeComponent();
           
        }


        //protected override bool OnBackButtonPressed()
        //{

        //    try
        //    {
        //        DataLogic dataLogic = new DataLogic();

        //        if (title.Text == null && info.Text == null)
        //        {
        //            Message.ShowToastMessage("Empty Notes Discared");
        //            return false;
        //        }

        //        var response = dataLogic.CreateNotes(title.Text, info.Text);
        //        Message.ShowToastMessage("Notes Saved");
                
        //       return base.OnBackButtonPressed();
        //    }
        //    catch (Exception)
        //    {
        //        Message.ShowToastMessage("Notes Not saved, ERROR");
        //        return true;
        //    }
        //}

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
             DataLogic dataLogic = new DataLogic();
              await dataLogic.CreateNotes(title.Text, info.Text, this.noteColor);
            this.noteKey = dataLogic.responseKey;
            return;
        }


        public async Task CallGetLableByKey()
        {
           
            DataLogic dataLogic = new DataLogic();
            Lable lable = await dataLogic.GetLableByKey(this.lableKey);

            lable.NoteKeysList.Add(this.noteKey);

            if (await dataLogic.SaveLableByKey(lable, this.lableKey))
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
    }
}