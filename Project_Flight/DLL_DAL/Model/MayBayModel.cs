using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_DAL.Model
{
    public class MayBayModel
    {
        private long Id;
        private String TenMayBay;
        private String HangMayBay;
        private int SoGheHang1;
        private int SoGheHang2;

        public long id { get => Id; set => Id = value; }
        public string tenMayBay { get => TenMayBay; set => TenMayBay = value; }
        public string hangMayBay { get => HangMayBay; set => HangMayBay = value; }
        public int soGheHang1 { get => SoGheHang1; set => SoGheHang1 = value; }
        public int soGheHang2 { get => SoGheHang2; set => SoGheHang2 = value; }
    }
}
