using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fundoo.View.Others
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeviceInformation : ContentPage
	{
		public DeviceInformation ()
		{
			InitializeComponent ();

            // Device Model (SMG-950U, iPhone10,6)
            var device = DeviceInfo.Model;

            // Manufacturer (Samsung)
            var manufacturer = DeviceInfo.Manufacturer;

            // Device Name (Motz's iPhone)
            var deviceName = DeviceInfo.Name;

            // Operating System Version Number (7.0)
            var version = DeviceInfo.VersionString;

            // Platform (Android)
            var platform = DeviceInfo.Platform;

            // Idiom (Phone)
            var idiom = DeviceInfo.Idiom;

            // Device Type (Physical)
            var deviceType = DeviceInfo.DeviceType;

            Deviceinfo.Text = "DeviceInfo = " + device;
            Manufacturer.Text = "Manufacture = " + manufacturer;
            DeviceName.Text = "DeviceName = " + deviceName;
            VersionInfo.Text = "Version = " + version;
            Platform.Text = "Platform = " + platform;
            Idiom.Text = "Idiom = " + idiom;
            DeviceType.Text = "DeviceType = " + deviceType;
        }
	}
}