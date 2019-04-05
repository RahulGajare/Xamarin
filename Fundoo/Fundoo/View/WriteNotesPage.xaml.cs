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
        public WriteNotesPage()
        {
            this.InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {

            try
            {
                DataLogic dataLogic = new DataLogic();

                if (title.Text == null && info.Text == null)
                {
                    Message.ShowToastMessage("Empty Notes Discared");
                    return false;
                }

                var responce = dataLogic.CreateNotes(title.Text, info.Text);
                Message.ShowToastMessage("Notes Saved");
                
               return base.OnBackButtonPressed();
            }
            catch (Exception)
            {
                Message.ShowToastMessage("Notes Not saved, ERROR");
                return true;
            }
        }
    }
}