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
	public partial class ArchivePage : ContentPage
	{
		public ArchivePage()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            this.GetArchivedNotes();
            base.OnAppearing();
        }

        public async void GetArchivedNotes()
        {
            DataLogic dataLogic = new DataLogic();
            var allArchivedNotes = await dataLogic.GetAllArchivedNotes();

            List<Archive> notesList = new List<Archive>();
            foreach(Archive note in allArchivedNotes)
            {
                notesList.Add(note);
            }

            allArchivedNotes = null;


            this.DynamicGridView(notesList);
            //NotesList.ItemsSource = allArchivedNotes;
        }

        private void DynamicGridView(List<Model.Archive> archivedNotesList)
        {


            if (archivedNotesList.Count == 0)
            {
                return;
            }

            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(114.5, GridUnitType.Absolute) });
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(114.5, GridUnitType.Absolute) });
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(114.5, GridUnitType.Absolute) });
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
            gridLayout.Margin = new Thickness(2, 2, 2, 2);


            int column = 0;
            int row = 0;


            foreach(Archive note in archivedNotesList)
            {
                //// For after every 3rd Column adds a new row.
                if (column == 3)
                {
                    gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
                    column = 0;
                    row++;
                }

                var stackLayout1 = new StackLayout();

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += this.stackLayoutTap_Tapped;
                stackLayout1.GestureRecognizers.Add(tapGestureRecognizer);



                var titleLable = new Label
                {
                    Text = note.Title,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };

                var infoLable = new Label
                {
                    Margin = new Thickness(10, 10, 0, 0),
                    Text = note.Info,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.None,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };

                var noteKey = new Label
                {
                    Text = note.Key,
                    IsVisible = false
                };

                ////stackLayout1.Children.Add(boxview);
                stackLayout1.Children.Add(titleLable);
                stackLayout1.Children.Add(infoLable);
                stackLayout1.Children.Add(noteKey);
                stackLayout1.Spacing = 2;
                stackLayout1.Margin = 2;
                ////  stackLayout1.BackgroundColor = Color.BlanchedAlmond;

                //var stackLayout2 = new StackLayout();
                //stackLayout2.Margin = new Thickness(2,2,2,2);


                var frame = new Frame();
                frame.BorderColor = Color.Black;
                frame.BackgroundColor = Color.BlanchedAlmond;

                frame.Content = stackLayout1;


                gridLayout.Children.Add(frame, column, row);
                column++;

            }
        }

        private void stackLayoutTap_Tapped(object sender, EventArgs e)
        {
            StackLayout gridNoteStack = (StackLayout)sender;
            IList<Xamarin.Forms.View> item = gridNoteStack.Children;
            Label key = (Label)item[2];
            var notekey = key.Text;
            Navigation.PushAsync(new EditNote(notekey,true));
        }
    }
}  