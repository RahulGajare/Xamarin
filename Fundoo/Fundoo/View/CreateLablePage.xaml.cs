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
    public partial class CreateLablePage : ContentPage
    {
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

            Model.LabelModel lable = new Model.LabelModel();
            lable.LableName = UserLable.Text;
            this.CallSaveLable(lable);

        }

        public async void CallSaveLable(Model.LabelModel lable)
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

            //LableList.ItemsSource = allLables;
            this.DynamicGridView(allLables);
        }

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
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += this.stackLayoutTap_Tapped;
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

                //var tapImage1 = new TapGestureRecognizer();
                ////// Binding events 
                //tapImage1.Tapped += this.DeleteIcon_Tapped;
                /////// Associating tap events to the image buttons    
                //deleteButton.GestureRecognizers.Add(tapImage1);

                //var tapImage2 = new TapGestureRecognizer();
                ////// Binding events 
                //tapImage2.Tapped += this.EditIcon_Tapped;
                /////// Associating tap events to the image buttons    
                //editButton.GestureRecognizers.Add(tapImage2);

                stackLayout.Children.Add(labelIcon);
                stackLayout.Children.Add(labelName);
                stackLayout.Children.Add(editButton);
                stackLayout.Children.Add(labelKey);



                //var frame = new Frame();
                ///// frame.BorderColor = Color.Black;
                //frame.Content = stackLayout;


                gridLayout.Children.Add(stackLayout, column, row);
                column++;

            }
        }

        private void stackLayoutTap_Tapped(object sender, EventArgs e)
        {
            StackLayout gridNoteStack = (StackLayout)sender;
            IList<Xamarin.Forms.View> item = gridNoteStack.Children;
            Xamarin.Forms.Label key = (Xamarin.Forms.Label)item[3];
            ///  Label noteColor = (Label)item[3];
            var labelKey = key.Text;
            Navigation.PushAsync(new EditLabel(labelKey));
        }

        //private void EditIcon_Tapped(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void DeleteIcon_Tapped(object sender, EventArgs e)
        //{
            
        //    throw new NotImplementedException();
        //}
    }
}