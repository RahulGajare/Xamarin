using Fundoo.DataHandler;
using Fundoo.DependencyServices;
using Fundoo.Model;
using Fundoo.View.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fundoo.View.Collabrators
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmailList : ContentPage
	{
        private string noteKey;
		public EmailList()
		{
			InitializeComponent ();
              var tapCancelIcon = new TapGestureRecognizer();
            //// Binding events 
            tapCancelIcon.Tapped += this.CancelImage_Tapped;
            ///// Associating tap events to the image buttons    
            CancelIcon.GestureRecognizers.Add(tapCancelIcon);

            var tapTickIcon = new TapGestureRecognizer();
            //// Binding events 
            tapTickIcon.Tapped += this.TickImage_Tapped;
            ///// Associating tap events to the image buttons    
            TickIcon.GestureRecognizers.Add(tapTickIcon);
        }

        public EmailList(string notekey)
        {
            InitializeComponent();
            var tapCancelIcon = new TapGestureRecognizer();
            //// Binding events 
            tapCancelIcon.Tapped += this.CancelImage_Tapped;
            ///// Associating tap events to the image buttons    
            CancelIcon.GestureRecognizers.Add(tapCancelIcon);

            var tapTickIcon = new TapGestureRecognizer();
            //// Binding events 
            tapTickIcon.Tapped += this.TickImage_Tapped;
            ///// Associating tap events to the image buttons    
            TickIcon.GestureRecognizers.Add(tapTickIcon);

            this.noteKey = notekey;
        }


        private void CancelImage_Tapped(object sender, EventArgs e)
        {
            collabratorsEmail.Text = string.Empty;
        }

        private async void TickImage_Tapped(object sender, EventArgs e)
        {
           
            Collaboratorshandler collabratorsHandler = new Collaboratorshandler();
            var UidList = await collabratorsHandler.GetUsersUid();

            Dictionary<string, string> uidList = UidList.UidList;

            foreach(KeyValuePair<string, string> entry in uidList)
            {
                if (entry.Value.Equals(collabratorsEmail.Text))
                {
                    NotesHandler notesHandler = new NotesHandler();
                    var note = await notesHandler.GetNote(this.noteKey);
                    note.IsCollaborated = true;
                    note.CollabratorsEmailList.Add(entry.Value);
                  await  notesHandler.SaveEditedNote(this.noteKey, note);
                     

                    ////Creating a Collaborator Object that will be saved under receiver UID.
                    CollaboratorModel collaboratorModel = new CollaboratorModel();
                    collaboratorModel.SenderUid = FireBaseThroughAuthentication.GetUid();
                    collaboratorModel.NoteKey = this.noteKey;
                    collaboratorModel.SenderEmail = entry.Value;
                    collaboratorModel.ReceiverEmail = collabratorsEmail.Text;


                    ////Storing Collaborator details under receiver UID.
                    collabratorsHandler.AddCollaborator(collaboratorModel,entry.Key);



                    //this.SendEmail();
                  

                    await DisplayAlert("Alert", "Notes will be shared With the Collabaorator", "OK");
                    return;
                }                         
            }
            await DisplayAlert("Alert", "The User with provided email Doesnot Exist", "Try Again");
            return;


        }


        //public void SendEmail()
        //{
        //    try
        //    {

        //        MailMessage mail = new MailMessage();
        //        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

        //        mail.From = new MailAddress(collabratorsEmail.Text);
        //        mail.To.Add(txtTo.Text);
        //        mail.Subject = "A note has been Shared with you";
        //        mail.Body = "FundooNotes";

        //        SmtpServer.Port = 587;
        //        SmtpServer.Host = "smtp.gmail.com";
        //        SmtpServer.EnableSsl = true;
        //        SmtpServer.UseDefaultCredentials = false;
        //        SmtpServer.Credentials = new System.Net.NetworkCredential("","");

        //        SmtpServer.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        DisplayAlert("Failed", ex.Message, "OK");
        //    }
        //}
    }
}