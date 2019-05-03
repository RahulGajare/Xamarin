// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FundooNotes.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.View
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Fundoo.DataHandler;
    using Fundoo.DependencyServices;
    using Fundoo.Interfaces;
    using Fundoo.Model;
    using Fundoo.ModelView;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Fundoo Notes Class
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FundooNotes : MasterDetailPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FundooNotes"/> class.
        /// </summary>
        public FundooNotes()
        {
            DataLogic dataLogic = new DataLogic();
            this.InitializeComponent();

            var imgsource = new UriImageSource { Uri = new Uri("https://firebasestorage.googleapis.com/v0/b/fundoousers-a9d30.appspot.com/o/XamarinMonkeys%2Fimage.jpg?alt=media&token=5b137659-5f00-4db5-a200-e56b7eca7e9a") };
            imgsource.CachingEnabled = false;
            ProfilePic.Source = imgsource;
            ProfilePic.HeightRequest = 100;
            ProfilePic.WidthRequest = 100;

            var userImage = new TapGestureRecognizer();
            //// Binding events 
            userImage.Tapped += this.userImage_Tapped;
            ///// Associating tap events to the image buttons   
            ProfilePic.GestureRecognizers.Add(userImage);

            var gridNotesPage = typeof(GridNotesPage);
            this.Detail = new NavigationPage((Page)Activator.CreateInstance(gridNotesPage));
        }

        /// <summary>
        /// Invokes when Current Page appears.
        /// </summary>
        protected async override void OnAppearing()
        {
            IList<MasterMenuItems> list1 = await GetMenuList();
            MenuItemList.ItemsSource = list1;
        }

        /// <summary>
        /// This Method is called whenever Clicked On ProfilePic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userImage_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePicEdit());
        }

        public async Task<IList<MasterMenuItems>> GetMenuList()
        {
            IList<MasterMenuItems> list = new List<MasterMenuItems>();

            list.Add(new MasterMenuItems()
            {
                Text = "Notes",
                ImagePath = "notesIcon.png",
                TargetPage = typeof(GridNotesPage)

            });

            list.Add(new MasterMenuItems()
            {
                Text = "Reminders",
                ImagePath = "reminderIcon.png",
                TargetPage = typeof(RemindersPage)
            });

            ////To add Lables Names To Master Page
            await MasterPageLable.AddLablestoMasterPage(list);

            list.Add(new MasterMenuItems()
            {
                Text = "CreateNewLabel",
                ImagePath = "addIcon.png",
                TargetPage = typeof(CreateLablePage)
            });

            list.Add(new MasterMenuItems()
            {
                Text = "Setting",
                ImagePath = "settingIcon.png",
                TargetPage = typeof(Setting)
            });

            list.Add(new MasterMenuItems()
            {
                Text = "Archive",
                ImagePath = "ArchiveIcon.png",
                TargetPage = typeof(ArchivePage)
            });

            list.Add(new MasterMenuItems()
            {
                Text = "Trash",
                ImagePath = "TrashIcon.png",
                TargetPage = typeof(Trash)
            });

            return list;
        }

        /// <summary>
        /// Called when [menu item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MasterMenuItems)e.SelectedItem;
            Type selectedPage = selectedMenuItem.TargetPage;

            if (selectedMenuItem.TargetPage == typeof(LabledNotePage))
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage, selectedMenuItem.Text, selectedMenuItem.lableKey));
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
            }

            IsPresented = false;
        }
    }
}