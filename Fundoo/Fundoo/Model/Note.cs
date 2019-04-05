using System;
using System.Collections.Generic;
using System.Text;

namespace Fundoo.Model
{
    public class Note
    {
        /// <summary>
        /// The title
        /// </summary>
        private string title;

        /// <summary>
        /// The information
        /// </summary>
        private string info;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get => this.title; set => this.title = value; }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public string Info { get => this.info; set => this.info = value; }
    }

}
