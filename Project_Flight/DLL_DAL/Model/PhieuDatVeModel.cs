using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_DAL.Model
{
    public class PhieuDatVeModel
    {
        private long Id;
        private long? veChuyenBayID;
        private long khachHangID1;
        private int RoleDatVe;
        private Double ThanhTien;
        private long NguoiDatVe_Id;

        private String NgayDat1;
        private String HoTen;
        private String CMND;
        private String SoDienThoai;
        private String Email;

        private String hoTenNhanVien1;
        private string thoiGianBay1;
        private String tuyenBay1;

        public long id { get => Id; set => Id = value; }
        public int roleDatVe { get => RoleDatVe; set => RoleDatVe = value; }
        public Double thanhTien { get => ThanhTien; set => ThanhTien = value; }
        public long nguoiDatVe_id { get => NguoiDatVe_Id; set => NguoiDatVe_Id = value; }
        public string hoTen { get => HoTen; set => HoTen = value; }
        public string cmnd { get => CMND; set => CMND = value; }
        public string soDienThoai { get => SoDienThoai; set => SoDienThoai = value; }
        public string email { get => Email; set => Email = value; }
        public long? vechuyenbayID { get => veChuyenBayID; set => veChuyenBayID = value; }
        public long khachHangID { get => khachHangID1; set => khachHangID1 = value; }
        public string ngayDat { get => NgayDat1; set => NgayDat1 = value; }
        public string hoTenNhanVien { get => hoTenNhanVien1; set => hoTenNhanVien1 = value; }
        public string thoiGianBay { get => thoiGianBay1; set => thoiGianBay1 = value; }
        public string tuyenBay { get => tuyenBay1; set => tuyenBay1 = value; }
    }
}
