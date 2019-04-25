using Fundoo.DataHandler;
using Fundoo.Model;
using Fundoo.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fundoo.ModelView
{
   public class MasterPageLable
    {
        public static async Task<IList<MasterMenuItems>> AddLablestoMasterPage(IList<MasterMenuItems> list)
        {
            DataLogic dataLogic = new DataLogic();
           var lablesList = await dataLogic.GetAllLables();

            if (lablesList == null)
            {
                return list;
            }

            if (lablesList.Count == 0)
            {
                return list;
            }

            foreach (LabelModel lable in lablesList)
            {
                list.Add(new MasterMenuItems()
                {
                    Text = lable.LableName,
                    ImagePath = "LableIcon.png",
                    lableKey = lable.lableKey,
                    TargetPage = typeof(LabledNotePage)
                });
            }

            return list;
        }
    }
}
