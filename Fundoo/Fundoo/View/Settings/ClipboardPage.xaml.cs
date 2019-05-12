using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fundoo.View.Settings
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClipboardPage : ContentPage
	{
		public ClipboardPage ()
		{
			InitializeComponent ();
		}

     

        private async void CopyText_clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(userText.Text);
            await DisplayAlert("Alert", "Text Copied To Clipboard", "OK");
        }

        private async void PasteText_Clicked_(object sender, EventArgs e)
        {
            var text = await Clipboard.GetTextAsync();
            copiedText.Text = text;
        }
    }
}