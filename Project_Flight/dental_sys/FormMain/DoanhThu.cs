using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL_DAL;
using DLL_DAL.Model;

namespace dental_sys
{
    public partial class DoanhThu : Form
    {
        NhanVienDLL_DAL nhanVien = new NhanVienDLL_DAL("nhanvien");
        NhanVienModel nhanVienModel;
        public DoanhThu(NhanVienModel nhanVien)
        {
            InitializeComponent();
            nhanVienModel = nhanVien;
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            Double doanhThu = 0;
            int slVe = 0, slNV = 0;

            List<NhanVienModel> listNV = nhanVien.findAll();
            NhanVienModel nhanVienTop = new NhanVienModel();
            nhanVienTop = listNV[0];
            foreach (NhanVienModel item in listNV)
            {
                doanhThu += item.TongDoanhThu;
                slVe += item.SoVeBan;
                slNV++;
                if (nhanVienTop.TongDoanhThu < item.TongDoanhThu)
                {
                    nhanVienTop = item;
                }
            }

            lblDT.Text = nhanVien.xuLyGia(doanhThu + "") + " VNĐ";
            lblSLNV.Text = slNV + "";
            lblSLVe.Text = slVe + "";
            lblNVTOP.Text = nhanVienTop.hoTen;
            txtUSER.Text = nhanVienModel.hoTen;
        }
    }
}
