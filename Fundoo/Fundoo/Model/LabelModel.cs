using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fundoo.Model
{
     public class LabelModel
    {
       private List<string> noteKeys = new List<string>();
        private string lableName;
        private string key;

        public List<string> NoteKeysList { get => noteKeys; set => noteKeys = value; }     
        public string lableKey { get => key; set => key = value; }
        public string LableName { get => lableName; set => lableName = value; }

       
    }
}
