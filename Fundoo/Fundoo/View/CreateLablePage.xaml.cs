﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateLablePage.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Fundoo.DataHandler;
    using Fundoo.DependencyServices;
    using Fundoo.Model;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateLablePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLablePage"/> class.
        /// </summary>
        public CreateLablePage()
        {
            InitializeComponent();

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

        /// <summary>
        /// Calls the save lable.
        /// </summary>
        /// <param name="lable">The lable.</param>
        public async void CallSaveLable(Model.LabelModel lable)
        {
            DataLogic dataLogic = new DataLogic();
            await dataLogic.SaveLable(lable);

            ////Calling OnAppearing beacuse to update the page with newly Created Lable.
            this.OnAppearing();
        }

        /// <summary>
        /// Handles the Tapped event of the CancelImage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CancelImage_Tapped(object sender, EventArgs e)
        {
            UserLable.Text = string.Empty;
        }

        /// <summary>
        /// Handles the Tapped event of the TickImage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TickImage_Tapped(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserLable.Text) || UserLable.Text.Trim().Equals(string.Empty))
            {
                Message.ShowToastMessage("Lable must Not be Empty");
                return;
            }

            Model.LabelModel lable = new Model.LabelModel();
            lable.LableName = UserLable.Text;
            this.CallSaveLable(lable);
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            this.GetAllLables();
            base.OnAppearing();
        }

        /// <summary>
        /// Gets all lables.
        /// </summary>
        public async void GetAllLables()
        {
            DataLogic dataLogic = new DataLogic();
            var allLables = await dataLogic.GetAllLables();
            this.DynamicGridView(allLables);
        }

        /// <summary>
        /// Dynamics the grid view.
        /// </summary>
        /// <param name="lablesList">The labels list.</param>
        private void DynamicGridView(List<Model.LabelModel> lablesList)
        {
            if (lablesList.Count == 0)
            {
                return;
            }

            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(350, GridUnitType.Absolute) });
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });
            gridLayout.Margin = new Thickness(2, 2, 2, 2);
            gridLayout.RowSpacing = 5;

            int column = 0;
            int row = 0;

            foreach (Model.LabelModel lable in lablesList)
            {
                ////Inserting new row after each label as list.
                if (column == 1)
                {
                    gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });
                    column = 0;
                    row++;
                }

                var stackLayout = new StackLayout();
                stackLayout.Orientation = StackOrientation.Horizontal;
                stackLayout.VerticalOptions = LayoutOptions.StartAndExpand;
                stackLayout.BackgroundColor = Color.AliceBlue;
                stackLayout.HeightRequest = 60;
                stackLayout.Margin = 20;

                ////Adding stackLayout to TapGesture.
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += this.StackLayoutTap_Tapped;
                stackLayout.GestureRecognizers.Add(tapGestureRecognizer);

                var labelName = new Xamarin.Forms.Label
                {
                    Text = lable.LableName,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };

                var labelKey = new Xamarin.Forms.Label
                {
                    Text = lable.lableKey,
                    IsVisible = false
                };

                var labelIcon = new Image
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                    HeightRequest = 20,
                    WidthRequest = 20,
                    Source = "LableIcon",
                };

                var editButton = new Image
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    HeightRequest = 20,
                    WidthRequest = 20,
                    Source = "EditIcon",
                };

                stackLayout.Children.Add(labelIcon);
                stackLayout.Children.Add(labelName);
                stackLayout.Children.Add(editButton);
                stackLayout.Children.Add(labelKey);

                gridLayout.Children.Add(stackLayout, column, row);
                column++;
            }
        }

        /// <summary>
        /// Handles the Tapped event of the stackLayoutTap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void StackLayoutTap_Tapped(object sender, EventArgs e)
        {
            StackLayout gridNoteStack = (StackLayout)sender;
            IList<Xamarin.Forms.View> item = gridNoteStack.Children;
            Xamarin.Forms.Label key = (Xamarin.Forms.Label)item[3];
            var labelKey = key.Text;
            Navigation.PushAsync(new EditLabel(labelKey));
        }
    }
}