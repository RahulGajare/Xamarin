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
	public partial class LablePage : ContentPage
	{ 
		public LablePage ()
		{
			InitializeComponent ();
            var tapCancelIcon = new TapGestureRecognizer();
            //// Binding events 
            tapCancelIcon.Tapped += this.CancelImage_Tapped;
            ///// Associating tap events to the image buttons    
            CancelIcon.GestureRecognizers.Add(tapCancelIcon);

            var tapTickIcon = new TapGestureRecognizer();
            //// Binding events 
            tapTickIcon.Tapped += this.TickImage_Tapped;
            ///// Associating tap events to the image buttons    
            TickIcon.GestureRecognizers.Add(tapTickIcon);

        }

        private void CancelImage_Tapped(object sender, EventArgs e)
        {
            UserLable.Text = string.Empty;
        }

        private void TickImage_Tapped(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(UserLable.Text) || UserLable.Text.Trim().Equals(""))
            {
                Message.ShowToastMessage("Lable must Not be Empty");
                return;
            }

            Lable lable = new Lable();
            lable.LableName = UserLable.Text;
            this.CallSaveLable(lable);
            
        }

        public async void CallSaveLable(Lable lable)
        {
            DataLogic dataLogic = new DataLogic();
            await dataLogic.SaveLable(lable);

            ////Calling OnAppearing beacuse to update the page with newly Created Lable.
            this.OnAppearing();
        }

        protected override void OnAppearing()
        {
            GetAllLables();
            base.OnAppearing();
        }

        public async void GetAllLables()
        {
            DataLogic dataLogic = new DataLogic();
            var allLables = await dataLogic.GetAllLables();

            List<Lable> LablesList = new List<Lable>();
            foreach (Lable note in allLables)
            {
                LablesList.Add(note);
            }

            allLables = null;

            LableList.ItemsSource = LablesList;
        }
    }
}