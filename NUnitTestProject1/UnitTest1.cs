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

        [Test]
        public void MarkupExtension()
        {
            var label = new Label();
            label.LoadFromXaml("<Label xmlns:f=\"clr-namespace:Xamarin.Forms.Mocks.Tests;assembly=Xamarin.Forms.Mocks.Tests\" Text=\"{f:Terrible}\" />");
            Assert.AreEqual("2016", label.Text); //amirite?
        }

       [Test]
        public void TestMethod1()
        {
            //Arrange  
            Method m1 = new Method();
            int expectedResult = 16;


            //Act  
            int actualResult = m1.Addition(11, 5);


            //Assert  
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}