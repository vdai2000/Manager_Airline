using DLL_DAL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DLL_DAL
{
    public class NhanVienDLL_DAL : AbstractDLL_DAL<NhanVienModel>
    {
        public NhanVienDLL_DAL(String url) : base(url)
        {
        }

        // chuc nang dang nhap
        public NhanVienModel login(NhanVienModel model)
        {
            _response = _client.GetAsync("nhanvien").Result;
            var user = _response.Content.ReadAsAsync<IEnumerable<NhanVienModel>>().Result;

            foreach (NhanVienModel item in user)
            {
                if (item.taiKhoan.Equals(model.taiKhoan) && item.matKhau.Equals(model.matKhau))
                {
                    return item;
                }
            }
            return null;
        }

        public NhanVienModel findNhanVienBycmnd(List<NhanVienModel> listNV, string cmnd)
        {
            foreach (NhanVienModel item in listNV)
            {
                if (item.cmnd.Equals(cmnd))
                {
                    return item;
                }
            }

            return null;
        }

        public Double getDoanhThu(long id, List<PhieuDatVeModel> listPDV,ref int sl)
        {
            Double total = 0;
            foreach (PhieuDatVeModel item in listPDV)
            {
                if(item.roleDatVe == 1 && item.nguoiDatVe_id == id)
                {
                    total += item.thanhTien;
                    sl++;
                }
            }
            return total;
        }
        public NhanVienModel findByid(List<NhanVienModel> listNV, string id)
        {
            foreach (NhanVienModel item in listNV)
            {
                if (item.id.Equals(id))
                {
                    return item;
                }
            }

            return null;
        }
        public List<NhanVienModel> findAll()
        {
            List<NhanVienModel> nhanVienModels = GetModels();
            PhieuDatVeDLL_DAL phieuDatVe = new PhieuDatVeDLL_DAL("phieudatve");
            List<PhieuDatVeModel> phieuDatVeModels = phieuDatVe.GetModels();

            foreach(NhanVienModel item in nhanVienModels)
            {
                int sl = 0;
                item.TongDoanhThu = getDoanhThu(item.id, phieuDatVeModels,ref sl);
                item.SoVeBan = sl;
            }

            return nhanVienModels;
        }

        public String isCheckNhanVien(List<NhanVienModel> listNV, NhanVienModel model)
        {
            foreach (NhanVienModel item in listNV)
            {
                if (item.id != model.id)
                {
                    if (item.cmnd.Equals(model.cmnd))
                    {
                        return "cmnd đã tồn tại !";
                    }

                    if (item.soDienThoai.Equals(model.soDienThoai))
                    {
                        return "Số điện thoại đã tồn tại !";
                    }

                    if (item.taiKhoan.Equals(model.taiKhoan))
                    {
                        return "Tài khoản đã tồn tại !";
                    }
                }
            }

            return null;
        }

        public String isCheckNhanVienDatVe(long id)
        {
            PhieuDatVeDLL_DAL phieuDatVeDLL_DAL = new PhieuDatVeDLL_DAL("phieudatve");
            List<PhieuDatVeModel> listPDV = phieuDatVeDLL_DAL.GetModels();

            foreach(PhieuDatVeModel item in listPDV)
            {
                if(item.roleDatVe == 1)
                {
                    if(item.nguoiDatVe_id == id)
                    {
                        return "Nhân viên đã có tên trong phiếu đặt vé không thể xóa được !!";
                    }
                }
            }
            return null;
        }
    }
}

