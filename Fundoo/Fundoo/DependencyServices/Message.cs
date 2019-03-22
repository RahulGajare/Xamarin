using Fundoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fundoo.DependencyServices
{
    public class Message
    {
        public static void ShowToastMessage(string message)
        {
             DependencyService.Get<IMessage>().showToast(message);
        }
    }
}
