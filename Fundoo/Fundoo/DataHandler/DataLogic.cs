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
        public string responseKey;
        private FirebaseClient firebaseClient = new FirebaseClient("https://fundoousers-a9d30.firebaseio.com/");

        public async Task<bool> CreateNotes(string title, string info, string noteColor ,bool isPinned)
        {
            try
            {
            var note =  await this.firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid()).Child("Notes").PostAsync(new Note()
                {
                    Title = title,
                    Info = info,
                    Color = noteColor,
                    IsPinned = isPinned
                });

              string key = note.Key;
                this.responseKey = key;
                return true;


                ///this.responseKey = response.Key;
                
                //  await this.firebaseClient
                //.Child("FundooUsers")
                //.Child(FireBaseThroughAuthentication.GetUid())
                //.Child("Notes")
                //.OrderByKey()
                //.OnceAsync<Note>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveNote(Note note)
        {
            try
            {
                await this.firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid()).Child("Notes").PostAsync<Note>(note);
               
                return true;


                ///this.responseKey = response.Key;

                //  await this.firebaseClient
                //.Child("FundooUsers")
                //.Child(FireBaseThroughAuthentication.GetUid())
                //.Child("Notes")
                //.OrderByKey()
                //.OnceAsync<Note>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                  Color = item.Object.Color,
                  IsPinned = item.Object.IsPinned,
                  IsTrash = item.Object.IsTrash,
                  IsArchive = item.Object.IsArchive,
                  Key = item.Key
              }).ToList();
        }

        public async Task<Note> GetNote(string noteKey)
        {
            Note note = await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Notes").Child(noteKey).OnceSingleAsync<Note>();
            return note;
        }

        //public async Task<Archive> GetArchiveNote(string noteKey)
        //{
        //    Archive note = await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("ArchivedNotes").Child(noteKey).OnceSingleAsync<Archive>();
        //    return note;
        //}

        public async Task SaveEditedNote(string noteKey, Note note)
        {
            await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Notes").Child(noteKey).PutAsync<Note>(note);
        }

        //public async Task SaveEditedArchiveNote(string noteKey, Archive archiveNote)
        //{
        //    await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("ArchivedNotes").Child(noteKey).PutAsync<Archive>(archiveNote);
        //}

        public async Task<bool> DeleteNote(string noteKey)
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

        //public async Task<bool> DeleteArchivedNote(string noteKey)
        //{
        //    try
        //    {
        //        string uid = FireBaseThroughAuthentication.GetUid();
        //        await firebaseClient.Child("FundooUsers").Child(uid).Child("ArchivedNotes").Child(noteKey).DeleteAsync();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}

        //public async Task<List<Archive>> GetAllArchivedNotes()
        //{
        //    return (await this.firebaseClient
        //      .Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("ArchivedNotes")
        //      .OnceAsync<Archive>()).Select(item => new Archive
        //      {
        //          Title = item.Object.Title,
        //          Info = item.Object.Info,
        //          Color = item.Object.Color,
        //          IsPinned = item.Object.IsPinned,
        //          IsTrash = item.Object.IsTrash,
        //          Key = item.Key
        //      }).ToList();
        //}

        public async Task SaveLable(LabelModel lable)
        {
            await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Lables").PostAsync<LabelModel>(new LabelModel() { LableName = lable.LableName, NoteKeysList = lable.NoteKeysList });
        }

        public async Task<List<LabelModel>> GetAllLables()
        {
            try
            {
                    return (await this.firebaseClient
              .Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Lables")
              .OnceAsync<LabelModel>()).Select(item => new LabelModel
              {
                  LableName = item.Object.LableName,
                  NoteKeysList = item.Object.NoteKeysList,
                  lableKey = item.Key
              }).ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        
        public async Task<bool> SaveLableByKey(LabelModel lable, string lablekey)
        {
            try
            {
                await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Lables").Child(lablekey).PutAsync<LabelModel>(lable);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }


        public async Task<LabelModel> GetLableByKey(string lableKey)
        {
            LabelModel lable = await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Lables").Child(lableKey).OnceSingleAsync<LabelModel>();
            return lable;
        }

        public async Task<bool> DeleteLableByKey(string lableKey)
        {
            try
            {
                await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Lables").Child(lableKey).DeleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }                     
        }

       
    }
}




