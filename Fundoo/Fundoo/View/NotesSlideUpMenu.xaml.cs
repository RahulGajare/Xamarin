using Rg.Plugins.Popup.Pages;
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
	public partial class NotesSlideUpMenu : PopupPage
    {

        string colorName;

        public NotesSlideUpMenu ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            
            PopupNavigation.Instance.PopAsync(true);
          
        }

        protected override void OnDisappearing()
        {
            EditNote editnew = new EditNote();
            editnew.changeColor();
            base.OnDisappearing();

        }

    }
}