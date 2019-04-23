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
        /// The is pinned
        /// </summary>
        private bool isPinned = false;

        /// <summary>
        /// The is trash
        /// </summary>
        private bool isTrash;

        /// <summary>
        /// The is archive
        /// </summary>
        private bool isArchive;

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

        /// <summary>
        /// Gets or sets a value indicating whether this instance is pinned.
        /// </summary>
        /// <value>

            ///   <c>true</c> if this instance is pinned; otherwise, <c>false</c>.
        /// </value>
        public bool IsPinned { get => isPinned; set => isPinned = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is trash.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is trash; otherwise, <c>false</c>.
        /// </value>
        public bool IsTrash { get => isTrash; set => isTrash = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is archive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is archive; otherwise, <c>false</c>.
        /// </value>
        public bool IsArchive { get => isArchive; set => isArchive = value; }
    }

}
