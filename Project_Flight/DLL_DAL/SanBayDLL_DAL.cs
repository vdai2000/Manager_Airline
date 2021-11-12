using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using DLL_DAL.Model;
using Newtonsoft.Json;

namespace DLL_DAL
{
    public class SanBayDLL_DAL:AbstractDLL_DAL<SanBayModel>
    {
        public SanBayDLL_DAL(String url):base(url)
        {
        }

        public SanBayModel findSanBayByCode(List<SanBayModel> listSB, string code)
        {
            foreach (SanBayModel item in listSB)
            {
                if (code.Equals(item.code))
                {
                    return item;
                }
            }

            return null;
        }

        public String ischeckSanBay(SanBayModel model, List<SanBayModel> sanBayModels)
        {
            foreach(SanBayModel item in sanBayModels)
            {
                if(item.code.Equals(model.code) && model.id != item.id)
                {
                    return "Code sân bay đã tồn tại";
                }

                if (item.tenSanBay.Equals(model.tenSanBay) && model.id != item.id)
                {
                    return "Tên sân bay đã tồn tại";
                }
            }
            return null;
        }

    }
}
