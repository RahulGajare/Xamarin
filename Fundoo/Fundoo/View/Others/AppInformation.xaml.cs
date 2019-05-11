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
    public partial class AppInformation : ContentPage
    {
        public AppInformation()
        {
            InitializeComponent();
            // Application Name
            var appName = AppInfo.Name;

            // Package Name/Application Identifier (com.microsoft.testapp)
            var packageName = AppInfo.PackageName;

            // Application Version (1.0.0)
            var version = AppInfo.VersionString;

            // Application Build Number (1)
            var build = AppInfo.BuildString;

            Name.Text = "App Name = " + appName;
            PackageName.Text = "PackageName = " + packageName;
            VersionString.Text = "Version = " + version;
            BuildString.Text = "BuildString = " + build;

        }
    }
}