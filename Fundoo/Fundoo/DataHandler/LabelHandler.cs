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
    public class LabelHandler
    {
        public string responseKey;
        private FirebaseClient firebaseClient = new FirebaseClient("https://fundoousers-a9d30.firebaseio.com/");

        /// <summary>
        /// Saves the label.
        /// </summary>
        /// <param name="lable">The label.</param>
        /// <returns></returns>
        public async Task SaveLable(LabelModel label)
        {
            await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Lables").PostAsync<LabelModel>(new LabelModel() { LableName = label.LableName, NoteKeysList = label.NoteKeysList });
        }

        /// <summary>
        /// Gets all lables.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Saves the label by key.
        /// </summary>
        /// <param name="lable">The label.</param>
        /// <param name="lablekey">The labelkey.</param>
        /// <returns></returns>
        public async Task<bool> SaveLableByKey(LabelModel label, string labelkey)
        {
            try
            {
                await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Lables").Child(labelkey).PutAsync<LabelModel>(label);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Gets the label by key.
        /// </summary>
        /// <param name="labelKey">The label key.</param>
        /// <returns></returns>
        public async Task<LabelModel> GetLabelByKey(string labelKey)
        {
            LabelModel lable = await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Lables").Child(labelKey).OnceSingleAsync<LabelModel>();
            return lable;
        }

        /// <summary>
        /// Deletes the label by key.
        /// </summary>
        /// <param name="labelKey">The label key.</param>
        /// <returns></returns>
        public async Task<bool> DeleteLableByKey(string labelKey)
        {
            try
            {
                await firebaseClient.Child("FundooUsers").Child(FireBaseThroughAuthentication.GetUid).Child("Lables").Child(labelKey).DeleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
