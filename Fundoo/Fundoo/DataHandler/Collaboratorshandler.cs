using Firebase.Database;
using Firebase.Database.Query;
using Fundoo.DependencyServices;
using Fundoo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundoo.DataHandler
{
    public class Collaboratorshandler
    {
        private string UserListKey = "-LeHGFGRRmhcnWQddRWC";
        private FirebaseClient firebaseClient = new FirebaseClient("https://fundoousers-a9d30.firebaseio.com/");

        public async Task<UsersUID> GetUserUid()
        {
            var result = await this.firebaseClient.Child("FundooUsers").Child("UserList").Child(UserListKey).OnceSingleAsync<UsersUID>();
            return result;
        }

        public async void AddCollaborator(CollaboratorModel collaboratorModel, string userUid)
        {
          var result =  await this.firebaseClient.Child("FundooUsers").Child("UserList").Child(userUid).Child("Collaborators").PostAsync<CollaboratorModel>(collaboratorModel);
           
        }

        public async Task<List<Note>> GetCollaboratorNotes()
        {
            var list = (await this.firebaseClient
                .Child("FundooUsers").Child("UserList").Child(FireBaseThroughAuthentication.GetUid).Child("Collaborators")
                .OnceAsync<CollaboratorModel>()).Select(item => new CollaboratorModel
                {
                    SenderUid = item.Object.SenderUid,
                    NoteKey = item.Object.NoteKey,

              }).ToList();

            List<Note> noteList = new List<Note>();
            foreach(CollaboratorModel collaborator in list)
            {
                noteList.Add(await firebaseClient.Child("FundooUsers").Child("UserList").Child(collaborator.SenderUid).Child("Notes").Child(collaborator.NoteKey).OnceSingleAsync<Note>());
            }

            return noteList;
        }

    }
}
