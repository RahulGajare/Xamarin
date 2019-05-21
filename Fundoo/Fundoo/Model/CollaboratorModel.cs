using System;
using System.Collections.Generic;
using System.Text;

namespace Fundoo.Model
{
    public class CollaboratorModel
    {
        /// <summary>
        /// The sender uid
        /// </summary>
        private string senderUid;

        /// <summary>
        /// The note key
        /// </summary>
        private string noteKey;

        /// <summary>
        /// The sender email
        /// </summary>
        private string senderEmail;

        /// <summary>
        /// The receiver email
        /// </summary>
        private string receiverEmail;

        /// <summary>
        /// Gets or sets the sender uid.
        /// </summary>
        /// <value>
        /// The sender uid.
        /// </value>
        public string SenderUid { get => senderUid; set => senderUid = value; }

        /// <summary>
        /// Gets or sets the note key.
        /// </summary>
        /// <value>
        /// The note key.
        /// </value>
        public string NoteKey { get => noteKey; set => noteKey = value; }

        /// <summary>
        /// Gets or sets the sender email.
        /// </summary>
        /// <value>
        /// The sender email.
        /// </value>
        public string SenderEmail { get => senderEmail; set => senderEmail = value; }

        /// <summary>
        /// Gets or sets the receiver email.
        /// </summary>
        /// <value>
        /// The receiver email.
        /// </value>
        public string ReceiverEmail { get => receiverEmail; set => receiverEmail = value; }
    }
}
