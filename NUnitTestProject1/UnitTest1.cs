using Fundoo.DependencyServices;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
        }

        [Test]
        public void CreateNotes()
        {
            Label title = new Label();
            title.Text = "rhyrdyhhd";

            Label info = new Label();
            info.Text = "";

            //// DataLogic dataLogic = new DataLogic();

            if (title.Text == null && info.Text == null)
            {
                Message.ShowToastMessage("Empty Notes Discared");
            }
            else
            {
                if (title.Text == null)
                {
                    title.Text = string.Empty;
                }

                if (info.Text == null)
                {
                    info.Text = string.Empty;
                }
            }

            Assert.IsNotNull(title.Text);
            Assert.IsNotEmpty(title.Text);

        }

        [Test]
        public async Task Push()
        {
            var root = new ContentPage();
            var page = new ContentPage();
            await root.Navigation.PushAsync(page);
            Assert.AreEqual(root.Navigation.NavigationStack.Last(), page);
        }

        [Test]
        public async Task FadeTo()
        {
            var view = new BoxView();
            await view.FadeTo(0);
            Assert.AreEqual(0, view.Opacity);
        }

      
    }
}