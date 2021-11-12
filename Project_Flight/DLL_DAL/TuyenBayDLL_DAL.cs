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
    public class TuyenBayDLL_DAL : AbstractDLL_DAL<TuyenBayModel>
    {
        public TuyenBayDLL_DAL(String url):base(url)
        {}

        public TuyenBayModel findTuyenBayBySanBay(List<TuyenBayModel> listTB, string sanBaydi, string sanBayDen)
        {
            foreach (TuyenBayModel item in listTB)
            {
                if (item.tenSanBayDi.Equals(sanBaydi) && item.tenSanBayDen.Equals(sanBayDen))
                {
                    return item;
                }
            }

            return null;
        }

        public String isCheckTuyenBay(List<TuyenBayModel> listTB, long sanBayDenId, long sanBayDiId)
        {
            foreach(TuyenBayModel item in listTB)
            {
                if(item.sanBayDiID == sanBayDiId && item.sanBayDenID == sanBayDenId)
                {
                    return "Tuyến bay đã tồn tại";
                }
            }
            return null;
        }
    }
}
