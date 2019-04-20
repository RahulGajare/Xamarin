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
            this.InitializeComponent();
            var gridNotesPage = typeof(GridNotesPage);
            this.Detail = new NavigationPage((Page)Activator.CreateInstance(gridNotesPage));         
        }

        protected async override void OnAppearing()
        {
            IList<MasterMenuItems> list1 = await GetMenuList();
            MenuItemList.ItemsSource = list1;
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

            ////To add Lables To Master Page
          await MasterPageLable.AddLablestoMasterPage(list);

            list.Add(new MasterMenuItems()
            {
                Text = "CreateNewLabel",
                ImagePath = "addIcon.png",
                TargetPage = typeof(LablePage)
            });

            list.Add(new MasterMenuItems()
            {
                Text = "Setting",
                ImagePath = "settingIcon.png",
                TargetPage = typeof(RemindersPage)
            });

            list.Add(new MasterMenuItems()
            {
                Text = "Archive",
                ImagePath = "ArchiveIcon.png",
                TargetPage = typeof(ArchivePage)
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
                Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage, selectedMenuItem.Text , selectedMenuItem.lableKey));
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
            }
           
            IsPresented = false;
        }
    }
}