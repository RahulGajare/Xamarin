using Fundoo.DataHandler;
using Fundoo.DependencyServices;
using Fundoo.Model;
using Fundoo.ModelView;
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
	public partial class LabledNotePage : ContentPage
	{
        string lableName;
        string currentLableKey;

        DataLogic datalogic = new DataLogic();


		public LabledNotePage (string lableName, string lableKey)
		{
            this.lableName = lableName;
            this.currentLableKey = lableKey;
			InitializeComponent ();
		}

        public LabledNotePage()
        {

        }


        private void TakeaNote_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WriteNotesPage(true, currentLableKey));
        }

        protected override void OnAppearing()
        {
            this.Call();
        }

        public async void Call()
        {
            List<Note> notesList = new List<Note>();
            Model.LabelModel lable = await this.datalogic.GetLableByKey(currentLableKey);

            foreach (string notekey in lable.NoteKeysList)
            {
              Note retrievedNote = await datalogic.GetNote(notekey);
               
                if (retrievedNote != null)
                {
                    retrievedNote.Key = notekey;
                    notesList.Add(retrievedNote);
                }           
            }

            this.DynamicGridView(notesList);


            base.OnAppearing();
        }

        private void DynamicGridView(List<Model.Note> notesList)
        {
            if (notesList.Count == 0)
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


            foreach(Note note in notesList)
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



                var titleLable = new Xamarin.Forms.Label
                {
                    Text = note.Title,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };

                var infoLable = new Xamarin.Forms.Label
                {
                    Margin = new Thickness(10, 10, 0, 0),
                    Text = note.Info,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.None,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };

                var noteKey = new Xamarin.Forms.Label
                {
                    Text = note.Key,
                    IsVisible = false
                };

                var noteColor = new Xamarin.Forms.Label
                {
                    Text = note.Color,
                    IsVisible = false
                };

                ////stackLayout1.Children.Add(boxview);
                stackLayout1.Children.Add(titleLable);
                stackLayout1.Children.Add(infoLable);
                stackLayout1.Children.Add(noteKey);
                stackLayout1.Children.Add(noteColor);
                stackLayout1.Spacing = 2;
                stackLayout1.Margin = 2;



                var frame = new Frame();
                /// frame.BorderColor = Color.Black;
                frame.CornerRadius = 20;

                FrameColorSetter.GetColor(note, frame);
                frame.Content = stackLayout1;


                gridLayout.Children.Add(frame, column, row);
                column++;

            }         
        }

        private void stackLayoutTap_Tapped(object sender, EventArgs e)
        {
            StackLayout gridNoteStack = (StackLayout)sender;
            IList<Xamarin.Forms.View> item = gridNoteStack.Children;
            Xamarin.Forms.Label key = (Xamarin.Forms.Label)item[2];
            ///  Label noteColor = (Label)item[3];
            var notekey = key.Text;
            Navigation.PushAsync(new EditNote(notekey));
        }

        private void DeleteLable_Clicked(object sender, EventArgs e)
        {             
            this.CallDeleteLable(this.currentLableKey);
        }

        public async void CallDeleteLable(string lableKey)
        {
           
            bool result = await this.datalogic.DeleteLableByKey(currentLableKey);
            if (result)
            {
                Message.ShowToastMessage("Label Deleted");
                await Navigation.PopAsync();
            }
            else
            {
                Message.ShowToastMessage("Label Not Deleted");
            }
        }
    }
}