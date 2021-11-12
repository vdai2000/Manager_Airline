using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_DAL.Model
{
    public class ChuyenBayModel
    {
		private long Id;
		private long TuyenBayId;
		private long MayBayId;

        private String Ngay;
        private String Gio;

		private String TenSanBayDi; 
		private String ThanhPhoDi;
        private String CodeSanDi;
        private long SanBayDiId;
        private String NgayDi;

        private String TenSanBayDen;
		private String ThanhPhoDen;
        private String CodeSanDen;
        private long SanBayDenId;
        private String NgayVe;

        private float ThoiGianBay;

        private Double? DonGia;
        private String HangVe;
        private String TenMayBay;
        private String LoaiVe;
        private long? IdVe;

        private Boolean TinhTrang;

        public long id { get => Id; set => Id = value; }
        public long tuyenBayId { get => TuyenBayId; set => TuyenBayId = value; }
        public long mayBayId { get => MayBayId; set => MayBayId = value; }
        public string ngay { get => Ngay; set => Ngay = value; }
        public string gio { get => Gio; set => Gio = value; }
        public string tenSanBayDi { get => TenSanBayDi; set => TenSanBayDi = value; }
        public string thanhPhoDi { get => ThanhPhoDi; set => ThanhPhoDi = value; }
        public string codeSanDi { get => CodeSanDi; set => CodeSanDi = value; }
        public string tenSanBayDen { get => TenSanBayDen; set => TenSanBayDen = value; }
        public string thanhPhoDen { get => ThanhPhoDen; set => ThanhPhoDen = value; }
        public string codeSanDen { get => CodeSanDen; set => CodeSanDen = value; }
        public float thoiGianBay { get => ThoiGianBay; set => ThoiGianBay = value; }
        public Double? donGia { get => DonGia; set => DonGia = value; }
        public string hangVe { get => HangVe; set => HangVe = value; }
        public bool tinhTrang { get => TinhTrang; set => TinhTrang = value; }
        public string tenMayBay { get => TenMayBay; set => TenMayBay = value; }
        public long sanBayDiId { get => SanBayDiId; set => SanBayDiId = value; }
        public string ngayDi { get => NgayDi; set => NgayDi = value; }
        public long sanBayDenId { get => SanBayDenId; set => SanBayDenId = value; }
        public string ngayVe { get => NgayVe; set => NgayVe = value; }
        public string loaiVe { get => LoaiVe; set => LoaiVe = value; }
        public long? idVe { get => IdVe; set => IdVe = value; }
    }
}
