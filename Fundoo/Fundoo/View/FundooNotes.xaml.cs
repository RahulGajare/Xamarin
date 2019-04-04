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
            aboutList.ItemsSource = GetMenuList();

            var homePage = typeof(NotesPage);
            Detail = new NavigationPage((Page)Activator.CreateInstance(homePage));
        }
    

        public List<MasterMenuItems> GetMenuList()
        {
            List<MasterMenuItems> list = new List<MasterMenuItems>();

            list.Add(new MasterMenuItems()
            {
                Text = "Notes",
               //// Detail = "Basic Info",
                ImagePath = "notesIcon.png",
                TargetPage = typeof(NotesPage)
            });

            list.Add(new MasterMenuItems()
            {
                Text = "Reminders",
                //// Detail = "Basic Info",
                ImagePath = "reminderIcon.png",
                TargetPage = typeof(RemindersPage)
            });
            return list;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MasterMenuItems)e.SelectedItem;
            Type selectedPage = selectedMenuItem.TargetPage;
            Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
            IsPresented = false;
        }
    }
}