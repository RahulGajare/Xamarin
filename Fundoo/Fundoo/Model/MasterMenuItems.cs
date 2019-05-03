// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasterMenuItems.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Fundoo.Model
{
   public class MasterMenuItems
    {
        public string Text { get; set; }
        public string Detail { get; set; }
        public string ImagePath { get; set; }
        public Type TargetPage { get; set; }
        public string lableKey { get; set; }
    }
}
