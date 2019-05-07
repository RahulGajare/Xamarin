using System;
using System.Collections.Generic;
using System.Text;

namespace Fundoo.Model
{
     public class UsersUID
    {
       private Dictionary<string, string> uidList = new Dictionary<string, string>();

        public Dictionary<string, string> UidList { get => uidList; set => uidList = value; }
    }
}

