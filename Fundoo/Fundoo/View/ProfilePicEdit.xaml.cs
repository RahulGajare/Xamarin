// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfilePicEdit.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------


using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Storage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Diagnostics;
using Fundoo.DependencyServices;
using Fundoo.DataHandler;

namespace Fundoo.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePicEdit : ContentPage
	{
        public Xamarin.Forms.ImageSource img { get; set; }
        MediaFile file;
        string imgurl;

        public UriImageSource ProductImage { get; set; }

        public ProfilePicEdit()
        {
            InitializeComponent();             
        }

        /// <summary>
        /// Handles the Clicked event of the Edit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Edit_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });

                if (file == null)
                    return;

                imgChoosed.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;
                });
                await StoreImages(file.GetStream());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Clicked event of the Save control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Save_Clicked(object sender, EventArgs e)
        {
            await StoreImages(file.GetStream());
        }

        /// <summary>
        /// Stores the images.
        /// </summary>
        /// <param name="imageStream">The image stream.</param>
        /// <returns></returns>
        public async Task StoreImages(Stream imageStream)
        {
            var stroageImage = await new FirebaseStorage("fundoousers-a9d30.appspot.com")
                .Child("XamarinMonkeys")
                .Child("image.jpg")
                .PutAsync(imageStream);
            string imgurl = stroageImage;
            this.imgurl = imgurl;
            this.SavePicURl(imgurl);
        }

        /// <summary>
        /// Saves the pic url.
        /// </summary>
        /// <param name="url">The URL.</param>
        public async void SavePicURl(string url)
        {
            DataLogic dataLogic = new DataLogic();
            await dataLogic.SavePicUrl(url);
            Message.ShowToastMessage("Profile Saved");
        }
    }
}