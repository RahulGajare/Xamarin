using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Fundoo.Model;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;
using Fundoo.DependencyServices;

namespace Fundoo.DataHandler
{
    public class DataLogic
    {
        private FirebaseClient firebaseClient = new FirebaseClient("https://fundoousers-a9d30.firebaseio.com/");

        public async Task<bool> CreateNotes(string title, string info)
        {
            try
            {
                await this.firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid()).Child("Notes").PostAsync<Note>(new Note()
                {
                    Title = title,
                    Info = info
                });

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddArchiveNote(Archive archiveNote)
        {
            try
            {
                await this.firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid()).Child("ArchivedNotes").PostAsync<Archive>(archiveNote);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public async Task<List<Note>> GetAllNotes()
        {
            return (await this.firebaseClient
              .Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Notes")
              .OnceAsync<Note>()).Select(item => new Note
              {
                  Title = item.Object.Title,
                  Info = item.Object.Info,
                  Key = item.Key
              }).ToList();
        }

        public async Task<Note> GetNote(string noteKey)
        {
            Note note = await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Notes").Child(noteKey).OnceSingleAsync<Note>();
            return note;
        }

        public async Task<Archive> GetArchiveNote(string noteKey)
        {
            Archive note = await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("ArchivedNotes").Child(noteKey).OnceSingleAsync<Archive>();
            return note;
        }

        public async Task SaveEditedNotes(string noteKey , Note note)
        {
            await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Notes").Child(noteKey).PutAsync<Note>(new Note() { Title = note.Title, Info = note.Info, });
        }

        public async Task<bool> DeleteNote(string noteKey )
        {
            try
            {
                string uid = FireBaseThroughAuthentication.GetUid();
                await firebaseClient.Child("FundooUsers").Child(uid).Child("Notes").Child(noteKey).DeleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public async Task<bool> DeleteArchivedNote(string noteKey)
        {
            try
            {
                string uid = FireBaseThroughAuthentication.GetUid();
                await firebaseClient.Child("FundooUsers").Child(uid).Child("ArchivedNotes").Child(noteKey).DeleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<List<Archive>> GetAllArchivedNotes()
        {
            return (await this.firebaseClient
              .Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("ArchivedNotes")
              .OnceAsync<Archive>()).Select(item => new Archive
              {
                  Title = item.Object.Title,
                  Info = item.Object.Info,
                  Key = item.Key
              }).ToList();
        }
    }
}

        
    

