// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GridNotesPage.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

using Fundoo.DataHandler;
using Fundoo.DependencyServices;
using Fundoo.Interfaces;
using Fundoo.Model;
using Fundoo.ModelView;
using Plugin.Media;
using Rg.Plugins.Popup.Services;
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
    public partial class GridNotesPage : ContentPage
    {
        List<Note> notesList = new List<Note>();
        public GridNotesPage()
        {
            this.InitializeComponent();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += this.Camaera_Tapped;
            cameraIcon.GestureRecognizers.Add(tapGestureRecognizer);

        }

        private async void Camaera_Tapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsTakePhotoSupported && CrossMedia.Current.IsPickPhotoSupported)
            {
                await this.DisplayAlert("alert", "take photo not supported", "ok");
                return;
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Images",
                    Name = DateTime.Now + "_test.jpg"
                });

                if (file == null)
                    return;
                await this.DisplayAlert("file path", file.Path, "ok");

                cameraIcon.Source = ImageSource.FromStream(() =>
                 {
                     var steam = file.GetStream();
                     return steam;
                 });
            }
            //await Navigation.PushModalAsync(new CameraPermition());
            await PopupNavigation.Instance.PopAsync(true);
        }

        /// <summary>
        /// Handles the Clicked event of the LogoutIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LogoutIcon_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IFirebaseAuthenticator>().Signout();
            Message.ShowToastMessage("LoggedOut Successfully");

            Navigation.PopToRootAsync();
            Navigation.PushAsync(new Greeting());
        }

        /// <summary>
        /// Handles the Clicked event of the Take a Note control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TakeaNote_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WriteNotesPage(false));
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        public async void GetNotes()
        {
            DataLogic dataLogic = new DataLogic();
            var notesList = await dataLogic.GetAllNotes();
            var labelsList = await dataLogic.GetAllLables();

            ////List Of Pinned Notes.
            List<Note> pinnedList = new List<Note>();

            ////List Of UnPinned Notes.
            List<Note> UnpinnedList = new List<Note>();

            ////Showing Only The Notes That are not archive or Trash
            foreach (Note note in notesList)
            {
                if (note.IsTrash == false && note.IsArchive == false)
                {
                    if (note.IsPinned)
                    {
                        pinnedList.Add(note);
                    }
                    else
                    {
                        UnpinnedList.Add(note);
                    }
                }

            }

            this.DynamicGridViewPinned(pinnedList, labelsList);
            this.DynamicGridViewUnpinned(UnpinnedList, labelsList);
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            GetNotes();
            base.OnAppearing();
        }

        /// <summary>
        /// Dynamics the grid view pinned.
        /// </summary>
        /// <param name="notesList">The notes list.</param>
        /// <param name="labelsList">The labels list.</param>
        private void DynamicGridViewPinned(List<Model.Note> notesList, List<LabelModel> labelsList)
        {
            if (notesList.Count == 0)
            {
                return;
            }

            ////initializing with 2 columns and 1 row.
            gridLayoutPinned.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175, GridUnitType.Absolute) });
            gridLayoutPinned.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175, GridUnitType.Absolute) });        
            gridLayoutPinned.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Auto) });
            gridLayoutPinned.Margin = new Thickness(2, 2, 2, 2);

            int column = 0;
            int row = 0;

            foreach (Note note in notesList)
            {
                //// For after every 3rd Column adds a new row.
                if (column == 2)
                {
                    gridLayoutPinned.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Auto) });
                    column = 0;
                    row++;
                }

                var stackLayout1 = new StackLayout();

                ////Adding Tap Gesture To StackLayout1.
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

                var noteColor = new Label
                {
                    Text = note.Color,
                    IsVisible = false
                };

                stackLayout1.Children.Add(titleLable);
                stackLayout1.Children.Add(infoLable);
                stackLayout1.Children.Add(noteKey);
                stackLayout1.Children.Add(noteColor);
                stackLayout1.Spacing = 2;
                stackLayout1.Margin = 2;

                foreach (LabelModel label in labelsList)
                {
                    List<string> noteKeyList = label.NoteKeysList;
                    foreach (string id in noteKeyList)
                    {
                        if (note.Key.Equals(id))
                        {
                            var labelName = new Label
                            {
                                Text = label.LableName,
                                TextColor = Color.Black
                            };

                            ////Creating a new frame for Displaying label Name.
                            var labelFrame = new Frame();
                            labelFrame.BorderColor = Color.Black;
                            labelFrame.CornerRadius = 30;
                            labelFrame.HeightRequest = 20;
                            labelFrame.Content = labelName;
                            stackLayout1.Children.Add(labelFrame);

                            ////this Methods Set the BackGround Color Of frame same as notes Color.
                            FrameColorSetter.GetColor(note, labelFrame);
                        }
                    }
                }

                var frame = new Frame();
                /// frame.BorderColor = Color.Black;
                frame.CornerRadius = 20;

                FrameColorSetter.GetColor(note, frame);
                frame.Content = stackLayout1;
                gridLayoutPinned.Children.Add(frame, column, row);
                column++;
            }
        }

        /// <summary>
        /// Dynamics the grid view unpinned.
        /// </summary>
        /// <param name="notesList">The notes list.</param>
        /// <param name="labelsList">The labels list.</param>
        private void DynamicGridViewUnpinned(List<Model.Note> notesList, List<LabelModel> labelsList)
        {
            if (notesList.Count == 0)
            {
                return;
            }

            ////initializing with 2 columns and 1 row.
            gridLayoutUnpinned.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175, GridUnitType.Absolute) });
            gridLayoutUnpinned.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175, GridUnitType.Absolute) });
            gridLayoutUnpinned.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Auto) });
            gridLayoutUnpinned.Margin = new Thickness(2, 2, 2, 2);


            int column = 0;
            int row = 0;


            foreach (Note note in notesList)
            {
                //// For after every 3rd Column adds a new row.
                if (column == 2)
                {
                    gridLayoutUnpinned.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Auto) });
                    column = 0;
                    row++;
                }

                var stackLayout2 = new StackLayout();

                //// Adding TapGesture To stackLayout2.
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += this.stackLayoutTap_Tapped;
                stackLayout2.GestureRecognizers.Add(tapGestureRecognizer);



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

                var noteColor = new Label
                {
                    Text = note.Color,
                    IsVisible = false
                };

              
                stackLayout2.Children.Add(titleLable);
                stackLayout2.Children.Add(infoLable);
                stackLayout2.Children.Add(noteKey);
                stackLayout2.Children.Add(noteColor);
                stackLayout2.Spacing = 2;
                stackLayout2.Margin = 2;

                foreach (LabelModel label in labelsList)
                {
                    List<string> noteKeyList = label.NoteKeysList;
                    foreach (string id in noteKeyList)
                    {
                        if (note.Key.Equals(id))
                        {
                            var labelName = new Label
                            {
                                Text = label.LableName,
                                TextColor = Color.Black,

                                VerticalOptions = LayoutOptions.Center
                            };

                            ////Creating a new frame for Displaying label Name.
                            var labelFrame = new Frame();
                            labelFrame.BorderColor = Color.Black;
                            labelFrame.CornerRadius = 30;
                            labelFrame.HeightRequest = 20;
                            labelFrame.WidthRequest = 5;

                            ////this Methods Set the BackGround Color Of frame same as notes Color.
                            FrameColorSetter.GetColor(note, labelFrame);

                            labelFrame.Content = labelName;
                            stackLayout2.Children.Add(labelFrame);
                        }
                    }
                }


                var frame = new Frame();
                /// frame.BorderColor = Color.Black;
                frame.CornerRadius = 20;

                FrameColorSetter.GetColor(note, frame);
                frame.Content = stackLayout2;

                gridLayoutUnpinned.Children.Add(frame, column, row);
                column++;

            }
        }

        /// <summary>
        /// Handles the Tapped event of the stackLayoutTap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void stackLayoutTap_Tapped(object sender, EventArgs e)
        {
            StackLayout gridNoteStack = (StackLayout)sender;
            IList<Xamarin.Forms.View> item = gridNoteStack.Children;
            Label key = (Label)item[2];
            ///  Label noteColor = (Label)item[3];
            var notekey = key.Text;
            Navigation.PushAsync(new EditNote(notekey));
        }

        /// <summary>
        /// Handles the Clicked event of the ListIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ListIcon_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListNotePage());
            this.Navigation.RemovePage(this);
        }

        /// <summary>
        /// Handles the clicked event of the SearchIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SearchIcon_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }
    }
}