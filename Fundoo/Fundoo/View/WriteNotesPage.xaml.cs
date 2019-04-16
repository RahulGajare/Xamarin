using Fundoo.DataHandler;
using Fundoo.DependencyServices;
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

        public WriteNotesPage()
        {
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

        //        var responce = dataLogic.CreateNotes(title.Text, info.Text);
        //        Message.ShowToastMessage("Notes Saved");
                
        //       return base.OnBackButtonPressed();
        //    }
        //    catch (Exception)
        //    {
        //        Message.ShowToastMessage("Notes Not saved, ERROR");
        //        return true;
        //    }
        //}

        protected override void OnDisappearing()
        {
           
            try
            {
                DataLogic dataLogic = new DataLogic();

                if (title.Text == null && info.Text == null)
                {
                    Message.ShowToastMessage("Empty Notes Discared");

                }
                else
                {
                    var responce = dataLogic.CreateNotes(title.Text, info.Text ,this.noteColor);
                    Message.ShowToastMessage("Notes Saved");
                }
          
            }
            catch (Exception)
            {
                Message.ShowToastMessage("Notes Not saved, ERROR");             
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