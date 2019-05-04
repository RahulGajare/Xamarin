// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchPage.xaml.cs" company="Bridgelabz">
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
    using Fundoo.Model;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        NotesHandler notesHandler = new NotesHandler();
        public List<Note> notesList = new List<Note>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchPage"/> class.
        /// </summary>
        public SearchPage()
        {
            InitializeComponent();
            this.GetNotes();
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        public async void GetNotes()
        {
            var notes = await notesHandler.GetAllNotes();
            notes = notes.Where(a => a.IsTrash == false && a.IsArchive == false).ToList();
            this.notesList = notes;
        }

        /// <summary>
        /// Handles the TextChanged event of the SearchBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                list.ItemsSource = this.notesList;
            }
            else
            {
                list.ItemsSource = this.notesList.Where(x => x.Title.ToLower().Contains(e.NewTextValue.ToLower())
                || x.Info.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }
    }
}