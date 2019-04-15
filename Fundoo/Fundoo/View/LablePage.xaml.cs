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
	public partial class LablePage : ContentPage
	{ 
		public LablePage ()
		{
			InitializeComponent ();
            var tapImage = new TapGestureRecognizer();
            //// Binding events 
            tapImage.Tapped += this.CancelImage_Tapped;
            ///// Associating tap events to the image buttons    
            CancelIcon.GestureRecognizers.Add(tapImage);
        }

        private void CancelImage_Tapped(object sender, EventArgs e)
        {
            lable.Text = string.Empty;
        }
    }
}