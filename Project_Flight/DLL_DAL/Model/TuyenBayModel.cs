using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_DAL.Model
{
    public class TuyenBayModel
    {
		private long Id;
		private long SanBayDiID;
		private long SanBayDenID;
		private Boolean TinhTrang;

		private String TenSanBayDi;
		private String ThanhPhoDi;

		private String ThanhPhoDen;
		private String TenSanBayDen;

        private String tuyenBay;


        public long id { get => Id; set => Id = value; }
        public long sanBayDiID { get => SanBayDiID; set => SanBayDiID = value; }
        public long sanBayDenID { get => SanBayDenID; set => SanBayDenID = value; }
        public bool tinhTrang { get => TinhTrang; set => TinhTrang = value; }
        public string tenSanBayDi { get => TenSanBayDi; set => TenSanBayDi = value; }
        public string thanhPhoDi { get => ThanhPhoDi; set => ThanhPhoDi = value; }
        public string thanhPhoDen { get => ThanhPhoDen; set => ThanhPhoDen = value; }
        public string tenSanBayDen { get => TenSanBayDen; set => TenSanBayDen = value; }
        public string TuyenBay { get => tuyenBay; set => tuyenBay = value; }
    }
}
