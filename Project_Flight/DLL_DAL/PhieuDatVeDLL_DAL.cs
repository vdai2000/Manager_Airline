using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DLL_DAL;
using DLL_DAL.Model;
using Newtonsoft.Json;

namespace DLL_DAL
{
    public class PhieuDatVeDLL_DAL : AbstractDLL_DAL<PhieuDatVeModel>
    {
        public PhieuDatVeDLL_DAL(String url) : base(url)
        {
        }

        public Boolean checkKhachHang(List<KhachHangModel> listKH, String cmnd, Boolean check)
        {
            foreach(KhachHangModel item in listKH)
            {
                if(cmnd.Equals(item.cmnd))
                {
                    return check;
                }
            }

            return !check;
        }

    }
}
