using System;
using System.Collections.Generic;
using System.Text;

namespace Fundoo.Model
{
     public class Lable
    {
       private List<string> noteKeys = new List<string>();
        private string lableName;
        private string key;

        public List<string> NoteKeysList { get => noteKeys; set => noteKeys = value; }     
        public string lableKey { get => key; set => key = value; }
        public string LableName { get => lableName; set => lableName = value; }
    }
}
