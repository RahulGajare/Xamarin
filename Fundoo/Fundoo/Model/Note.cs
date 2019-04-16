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
        /// The key
        /// </summary>
        private string key;

        /// <summary>
        /// The color
        /// </summary>
        private string color;

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

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get => key; set => key = value; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get => color; set => color = value; }
    }

}
