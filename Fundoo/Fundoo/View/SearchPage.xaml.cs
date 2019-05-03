// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchPage.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------


using Fundoo.DataHandler;
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
	public partial class SearchPage : ContentPage
	{
        DataLogic dataLogic = new DataLogic();
        List<Note> notesList = new List<Note>();

        public SearchPage ()
		{
			InitializeComponent ();
            this.GetNotes();
           
        }

        public async void GetNotes()
        {
            var notes = await dataLogic.GetAllNotes();
            notes = notes.Where(a => a.IsTrash == false && a.IsArchive == false).ToList();
            this.notesList = notes;
        }

        private  void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //DataLogic dataLogic = new DataLogic();
            //var notesList = await dataLogic.GetAllNotes();
            //var keyWord = SearchBar.Text;
            //var suggestion = this.notesList.Where(c => c.Title.ToLower().Contains(keyWord.ToLower()));
            //list.ItemsSource = suggestion;

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