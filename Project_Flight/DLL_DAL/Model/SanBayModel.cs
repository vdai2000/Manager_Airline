using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_DAL.Model
{
    public class SanBayModel
    {
		private long Id;
		private String Code;
		private String TenThanhPho;
		private String TenSanBay;
		private String QuocGia;
		private Boolean TinhTrang;

        public long id { get => Id; set => Id = value; }
        public string code { get => Code; set => Code = value; }
        public string tenThanhPho { get => TenThanhPho; set => TenThanhPho = value; }
        public string tenSanBay { get => TenSanBay; set => TenSanBay = value; }
        public string quocGia { get => QuocGia; set => QuocGia = value; }
        public bool tinhTrang { get => TinhTrang; set => TinhTrang = value; }
    }
}
