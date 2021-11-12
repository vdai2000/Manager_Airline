using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_DAL.Model;

namespace DLL_DAL
{
    public class MayBayDLL_DAL : AbstractDLL_DAL<MayBayModel>
    {
        public MayBayDLL_DAL(String url) : base(url)
        {
        }
        public MayBayModel findMayBayByid(List<MayBayModel> listMB, string id)
        {
            foreach (MayBayModel item in listMB)
            {
                if (item.id.Equals(id))
                {
                    return item;
                }
            }

            return null;
        }

        

    }
}
