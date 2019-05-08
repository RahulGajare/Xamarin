using System;
using System.Collections.Generic;
using System.Text;

namespace Fundoo.Model
{
    public class CollaboratorModel
    {
        private string senderUid;
        private string noteKey;
        private string senderEmail;
        private string receiverEmail;

        public string SenderUid { get => senderUid; set => senderUid = value; }
        public string NoteKey { get => noteKey; set => noteKey = value; }
        public string SenderEmail { get => senderEmail; set => senderEmail = value; }
        public string ReceiverEmail { get => receiverEmail; set => receiverEmail = value; }
    }
}
