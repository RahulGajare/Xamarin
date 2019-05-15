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
    public class NotesHandler
    {
        public string responseKey;
        private FirebaseClient firebaseClient = new FirebaseClient("https://fundoousers-a9d30.firebaseio.com/");

        /// <summary>
        /// Creates the notes.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="info">The information.</param>
        /// <param name="noteColor">Color of the note.</param>
        /// <param name="isPinned">if set to <c>true</c> [is pinned].</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> CreateNotes(string title, string info, string noteColor, bool isPinned)
        {
            try
            {
                var note = await this.firebaseClient.Child("FundooUsers").Child("UserList").Child(FireBaseThroughAuthentication.GetUid()).Child("Notes").PostAsync(new Note()
                {
                    Title = title,
                    Info = info,
                    Color = noteColor,
                    IsPinned = isPinned,
                    SenderUid = FireBaseThroughAuthentication.GetUid()
                });

                string key = note.Key;
                this.responseKey = key;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Saves the note.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> SaveNote(Note note)
        {
            try
            {
                await this.firebaseClient.Child("FundooUsers").Child("UserList").Child(FireBaseThroughAuthentication.GetUid()).Child("Notes").PostAsync<Note>(note);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Note>> GetAllNotes()
        {
            return (await this.firebaseClient
              .Child("FundooUsers").Child("UserList").Child(FireBaseThroughAuthentication.GetUid()).Child("Notes")
              .OnceAsync<Note>()).Select(item => new Note
              {
                  Title = item.Object.Title,
                  Info = item.Object.Info,
                  Color = item.Object.Color,
                  IsPinned = item.Object.IsPinned,
                  IsTrash = item.Object.IsTrash,
                  IsArchive = item.Object.IsArchive,
                  Key = item.Key
              }).ToList();
        }

        /// <summary>
        /// Gets the note.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        /// <returns></returns>
        public async Task<Note> GetNote(string noteKey)
        {
            Note note = await firebaseClient.Child("FundooUsers").Child("UserList").Child(FireBaseThroughAuthentication.GetUid).Child("Notes").Child(noteKey).OnceSingleAsync<Note>();
            return note;
        }

        /// <summary>
        /// Gets the note.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        /// <returns></returns>
        public async Task<Note> GetNote(string noteKey, string senderUid)
        {
            Note note = await firebaseClient.Child("FundooUsers").Child("UserList").Child(senderUid).Child("Notes").Child(noteKey).OnceSingleAsync<Note>();
            return note;
        }

        /// <summary>
        /// Saves the edited note.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        /// <param name="note">The note.</param>
        /// <returns></returns>
        public async Task SaveEditedNote(string noteKey, Note note)
        {
            await firebaseClient.Child("FundooUsers").Child("UserList").Child(FireBaseThroughAuthentication.GetUid()).Child("Notes").Child(noteKey).PutAsync<Note>(note);
        }

        /// <summary>
        /// Saves the edited note.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        /// <param name="note">The note.</param>
        /// <param name="senderUid">The sender uid.</param>
        /// <returns></returns>
        public async Task SaveEditedNote(string noteKey, Note note,string senderUid)
        {
            await firebaseClient.Child("FundooUsers").Child("UserList").Child(senderUid).Child("Notes").Child(noteKey).PutAsync<Note>(note);
        }

        /// <summary>
        /// Deletes the note.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        /// <returns></returns>
        public async Task<bool> DeleteNote(string noteKey)
        {
            try
            {
                string uid = FireBaseThroughAuthentication.GetUid();
                await firebaseClient.Child("FundooUsers").Child("UserList").Child(uid).Child("Notes").Child(noteKey).DeleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
