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

          
            //var imgsource = new UriImageSource { Uri = new Uri("https://atlas-content-cdn.pixelsquid.com/stock-images/golden-soccer-ball-3yLR9z1-600.jpg") };
            //imgsource.CachingEnabled = false;
            //image.Source = imgsource;




            
        }
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
        private async void Save_Clicked(object sender, EventArgs e)
        {
            await StoreImages(file.GetStream());
        }

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

        //public void LoadPic(string url)
        //{
        //    var imgsource = new UriImageSource { Uri = new Uri(url) };
        //    imgsource.CachingEnabled = false;
        //    image.Source = imgsource;
        //}

        public async void SavePicURl(string url)
        {
            DataLogic dataLogic = new DataLogic();
            await dataLogic.SavePicUrl(url);
            Message.ShowToastMessage("Profile Saved");

        }


    }
}