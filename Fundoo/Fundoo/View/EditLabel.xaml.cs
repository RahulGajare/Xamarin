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
	public partial class EditLabel : ContentPage
	{

        Fundoo.Model.LabelModel retrivedLabel = null;
        string labelKey; 

        public EditLabel ()
		{
			InitializeComponent ();
		}

        public EditLabel(string labelKey)
        {
            InitializeComponent();

            this.labelKey = labelKey;
            var tapCancelIcon = new TapGestureRecognizer();
            //// Binding events 
            tapCancelIcon.Tapped += this.DeleteIcon_Tapped;
            ///// Associating tap events to the image buttons    
            DeleteIcon.GestureRecognizers.Add(tapCancelIcon);

            var tapTickIcon = new TapGestureRecognizer();
            //// Binding events 
            tapTickIcon.Tapped += this.TickImage_Tapped;
            ///// Associating tap events to the image buttons    
            TickIcon.GestureRecognizers.Add(tapTickIcon);

          
            this.GetTappedNotes(labelKey);
        }

        public async void GetTappedNotes(string labelKey)
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

            this.retrivedLabel = await datalogic.GetLableByKey(labelKey);
            UserLable.Text = retrivedLabel.LableName;
     
        }

        private async void  DeleteIcon_Tapped(object sender, EventArgs e)
        {
           bool result = await DisplayAlert("Attention","Are you sure you want to delete this Label","Yes", "Cancel");
            if (true)
            {
                DataLogic dataLogic = new DataLogic();
                await dataLogic.DeleteLableByKey(this.labelKey);

                Message.ShowToastMessage("Label Deleted");
                await Navigation.PopAsync();
            }

          
        }

       

        private async void TickImage_Tapped(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(UserLable.Text) || UserLable.Text.Trim().Equals(""))
            {
                Message.ShowToastMessage("Lable must Not be Empty");
                return;
            }

            Model.LabelModel newLabel = new Model.LabelModel();
            newLabel.LableName = UserLable.Text;

            DataLogic dataLogic = new DataLogic();
            await dataLogic.SaveLableByKey(newLabel,this.labelKey);
            Message.ShowToastMessage("Label saved");
            await Navigation.PopAsync();
        }
    }
}