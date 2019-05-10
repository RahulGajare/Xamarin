// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Note.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Fundoo.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
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
       /// collaborators Uid
       /// </summary>
        private string senderUid;

        /// <summary>
        /// The is collaborated
        /// </summary>
        private bool isCollaborated;

        /// <summary>
        /// The collabrators email list
        /// </summary>
        private List<string> collabratorsEmailList = new List<string>();

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

     

        /// <summary>
        /// Gets or sets a value indicating whether this instance is collaborated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is collaborated; otherwise, <c>false</c>.
        /// </value>
        public bool IsCollaborated { get => isCollaborated; set => isCollaborated = value; }

        /// <summary>
        /// Gets or sets the collabrators email list.
        /// </summary>
        /// <value>
        /// The collabrators email list.
        /// </value>
        public List<string> CollabratorsEmailList { get => collabratorsEmailList; set => collabratorsEmailList = value; }

        /// <summary>
        /// Gets or sets the sender uid.
        /// </summary>
        /// <value>
        /// The sender uid.
        /// </value>
        public string SenderUid { get => senderUid; set => senderUid = value; }
    }

}
