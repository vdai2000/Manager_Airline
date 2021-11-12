using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_DAL.Model
{
    public class KhachHangModel
    {
        private long Id;
        private String hoTen1;
        private String cmnd1;
        private String soDienThoai1;
        private String email1;
        private int soVeDaBan;
        private Double tongChiPhi;

        public long id { get => Id; set => Id = value; }
        public string hoTen { get => hoTen1; set => hoTen1 = value; }
        public string cmnd { get => cmnd1; set => cmnd1 = value; }
        public string soDienThoai { get => soDienThoai1; set => soDienThoai1 = value; }
        public string email { get => email1; set => email1 = value; }
        public int SoVeDaBan { get => soVeDaBan; set => soVeDaBan = value; }
        public Double TongChiPhi { get => tongChiPhi; set => tongChiPhi = value; }
    }
}
