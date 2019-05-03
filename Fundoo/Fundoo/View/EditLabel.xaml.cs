// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditLabel.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------


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
        DataLogic dataLogic = new DataLogic();
        Fundoo.Model.LabelModel retrivedLabel = null;
        string labelKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditLabel"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets the tapped notes.
        /// </summary>
        /// <param name="labelKey">The label key.</param>
        public async void GetTappedNotes(string labelKey)
        {
            DataLogic datalogic = new DataLogic();
            
            this.retrivedLabel = await datalogic.GetLableByKey(labelKey);
            UserLable.Text = retrivedLabel.LableName;
     
        }

        /// <summary>
        /// Handles the Tapped event of the DeleteIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void  DeleteIcon_Tapped(object sender, EventArgs e)
        {
           bool result = await DisplayAlert("Attention","Are you sure you want to delete this Label","Yes", "Cancel");
            if (true)
            {
               
                await dataLogic.DeleteLableByKey(this.labelKey);

                Message.ShowToastMessage("Label Deleted");
                await Navigation.PopAsync();
            }

          
        }


        /// <summary>
        /// Handles the Tapped event of the TickImage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private async void TickImage_Tapped(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(UserLable.Text) || UserLable.Text.Trim().Equals(""))
            {
                Message.ShowToastMessage("Lable must Not be Empty");
                return;
            }


            retrivedLabel.LableName = UserLable.Text;

            await dataLogic.SaveLableByKey(retrivedLabel, this.labelKey);
            Message.ShowToastMessage("Label saved");
            await Navigation.PopAsync();
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected async override void OnAppearing()
        {
           this.retrivedLabel = await dataLogic.GetLableByKey(labelKey);
            base.OnAppearing();
        }
    }
}