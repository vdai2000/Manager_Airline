using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_DAL.Model;

namespace DLL_DAL
{
    public class KhachHangDLL_DAL : AbstractDLL_DAL<KhachHangModel>
    {
        public KhachHangDLL_DAL(String url) : base(url)
        {
        }

        private Double setVeKhachHang(ref int sl ,long id, List<PhieuDatVeModel> listPDV)
        {

            Double chiTieu = 0;
            KhachHangModel khachHang = new KhachHangModel();
            foreach (PhieuDatVeModel item in listPDV)
            {
                if(item.khachHangID == id)
                {
                    sl++;
                    chiTieu += item.thanhTien;
                }
            }
            return chiTieu;
        }

        public List<KhachHangModel> findAll()
        {
            PhieuDatVeDLL_DAL phieuDatVe = new PhieuDatVeDLL_DAL("phieudatve");
            List<PhieuDatVeModel> listPDV = phieuDatVe.GetModels();
            List<KhachHangModel> listKH = GetModels();

            foreach (KhachHangModel item in listKH)
            {
                int sl = 0;
                Double chitieu = setVeKhachHang(ref sl ,item.id, listPDV);
                item.SoVeDaBan = sl;
                item.TongChiPhi = chitieu;
            }
            return listKH;
        }

        public KhachHangModel findByid(List<KhachHangModel> listMB, string id)
        {
            foreach (KhachHangModel item in listMB)
            {
                if (item.id.Equals(id))
                {
                    return item;
                }
            }

            return null;
        }
    }
}
