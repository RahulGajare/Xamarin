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

        /// <summary>
        /// Gets or sets the note keys list.
        /// </summary>
        /// <value>
        /// The note keys list.
        /// </value>
        public List<string> NoteKeysList { get => noteKeys; set => noteKeys = value; }

        /// <summary>
        /// Gets or sets the lable key.
        /// </summary>
        /// <value>
        /// The label key.
        /// </value>
       public string lableKey { get => key; set => key = value; }

        /// <summary>
        /// Gets or sets the name of the lable.
        /// </summary>
        /// <value>
        /// The name of the label.
        /// </value>
        public string LableName { get => lableName; set => lableName = value; }


    }
}
