// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelModel.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

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
