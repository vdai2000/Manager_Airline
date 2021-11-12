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
    public class ChuyenBayDLL_DAL : AbstractDLL_DAL<ChuyenBayModel>
    {
        public ChuyenBayDLL_DAL(String url) : base(url)
        {
        }


        public ChuyenBayModel findChuyenBayBySanBay(List<ChuyenBayModel> listCB, string sanBaydi, string sanBayDen, string time)
        {
            foreach (ChuyenBayModel item in listCB)
            {
                String day = item.ngay + " - " + item.gio;
                if (item.tenSanBayDi.Equals(sanBaydi) && item.tenSanBayDen.Equals(sanBayDen) && day.Equals(time))
                {
                    return item;
                }
            }

            return null;
        }

        public ChuyenBayModel findOneChuyenBayById(List<ChuyenBayModel> chuyenBayModels, long id)
        {
            foreach (ChuyenBayModel item in chuyenBayModels)
            {
                if (item.id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<ChuyenBayModel> findChuyenBayByVe()
        {
            VeChuyenBayDLL_DAL veChuyenBay = new VeChuyenBayDLL_DAL("vechuyenbay");
            List<VeChuyenBayModel> veChuyenBayModels = veChuyenBay.GetModels();
            List<ChuyenBayModel> chuyenBayModels = GetModels();
            List<ChuyenBayModel> result = new List<ChuyenBayModel>();

            foreach (ChuyenBayModel item in chuyenBayModels)
            {
                Boolean check = true;
                foreach (VeChuyenBayModel itemVe in veChuyenBayModels)
                {
                    if (item.id == itemVe.chuyenBayID)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<ChuyenBayModel> searchChuyenBay(ChuyenBayModel model)
        {
            ChuyenBayDLL_DAL chuyenBay = new ChuyenBayDLL_DAL("chuyenbay");
            VeChuyenBayDLL_DAL veChuyenBay = new VeChuyenBayDLL_DAL("vechuyenbay");

            List<ChuyenBayModel> chuyenBayModels = chuyenBay.GetModels();
            List<VeChuyenBayModel> veChuyenBayModels = veChuyenBay.GetModels();

            List<ChuyenBayModel> result = new List<ChuyenBayModel>();

            foreach (ChuyenBayModel item in chuyenBayModels)
            {
                if (!item.ngay.Equals(model.ngayDi))
                {
                    continue;
                }

                if (item.sanBayDenId == model.sanBayDenId && item.sanBayDiId == model.sanBayDiId)
                {

                    //Kiểm tra vé và set giá
                    foreach (VeChuyenBayModel veItem in veChuyenBayModels)
                    {
                        if (veItem.chuyenBayID == item.id)
                        {
                            item.idVe = veItem.id;
                            if (model.loaiVe.Equals("TG") && veItem.hangVeID == 2)
                            {
                                item.donGia = veItem.donGia;
                            }

                            if (model.loaiVe.Equals("PT") && veItem.hangVeID == 1)
                            {
                                item.donGia = veItem.donGia;
                            }
                        }
                    }


                    if (item.donGia != null)
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public String isCheckChuyenBay(List<ChuyenBayModel> listCB, ChuyenBayModel model)
        {
            String day = model.ngay + " - " + model.gio;
            foreach (ChuyenBayModel item in listCB)
            {
                if (model.id != item.id)
                {
                    String time = item.ngay + " - " + item.gio;
                    if (item.tuyenBayId == model.tuyenBayId && day.Equals(time))
                    {
                        return "Chuyến bay cùng giờ đã tồn tại";
                    }
                }
            }

            return null;
        }

        public String xuLyPhut(int phut)
        {
            string result = "";

            if (phut < 10)
            {
                result += ":0" + phut;
            }
            else
            {
                result += ":" + phut;
            }

            return result;
        }

        public String xuLyNgayDen(String time, float gioBay)
        {
            string[] times = time.Split(':');
            int phut = int.Parse(times[1]);
            int gio = int.Parse(times[0]);
            float gioDi = gio + gioBay;
            string result;

            // xu ly gio
            if (gioDi > 24)
            {
                result = gioDi - 24 + "";
            }
            else
            {
                result = gioDi + "";
            }
            return result + xuLyPhut(phut);
        }
    }
}
