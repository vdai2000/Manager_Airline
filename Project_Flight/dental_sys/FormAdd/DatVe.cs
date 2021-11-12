using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL_DAL.Model;
using DLL_DAL;

namespace dental_sys.FormAdd
{
    public partial class DatVe : Form
    {
        long id, idNV;
        long? idVe;
        String gia;
        ChuyenBayDLL_DAL chuyenBay = new ChuyenBayDLL_DAL("chuyenbay");
        ChuyenBayModel chuyenBayItem;

        PhieuDatVeDLL_DAL phieuDatVe = new PhieuDatVeDLL_DAL("phieudatve");

        KhachHangDLL_DAL khachHang = new KhachHangDLL_DAL("khachhang");
        List<KhachHangModel> listKH;

        bool check = false;

        public DatVe(long id, String gia, long idNV, long? idVe)
        {
            InitializeComponent();
            this.id = id;
            this.gia = gia;
            this.idNV = idNV;
            this.idVe = idVe;
            listKH = khachHang.GetModels();
        }

        private void DatVe_Load(object sender, EventArgs e)
        {
            List<ChuyenBayModel> chuyenBayModels = chuyenBay.GetModels();
            chuyenBayItem = chuyenBay.findOneChuyenBayById(chuyenBayModels, id);

            lblnoidi.Text = chuyenBayItem.thanhPhoDi + " (" + chuyenBayItem.codeSanDi + ")";
            lblnoiden.Text = chuyenBayItem.thanhPhoDen + " (" + chuyenBayItem.codeSanDen + ")"; ;

            lblGioDI.Text = chuyenBayItem.gio;
            lblgioden.Text = chuyenBay.xuLyNgayDen(chuyenBayItem.gio, chuyenBayItem.thoiGianBay);

            lblNgayDi.Text = chuyenBayItem.ngay;
            lblGia.Text = "Thành tiền: " + gia + " VNĐ";

            if (chuyenBayItem.hangVe.Equals("BambooAirline"))
            {
                lblHinhAnh.Image = Properties.Resources.logo_bamboo;
            }
            else if (chuyenBayItem.hangVe.Equals("VietJetAirline"))
            {
                lblHinhAnh.Image = Properties.Resources.logo_vietjet;
            }
            else
            {
                lblHinhAnh.Image = Properties.Resources.logo_vnairlines;
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdTV_CheckedChanged(object sender, EventArgs e)
        {
            if(rdTV.Checked == true)
            {
                txtEmail.Enabled = false;
                txtHoTen.Enabled = false;
                txtSDT.Enabled = false;
                check = true;
            }
            else
            {
                txtEmail.Enabled = true;
                txtHoTen.Enabled = true;
                txtSDT.Enabled = true;
                check = false;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            PhieuDatVeModel phieuDatVeModel = new PhieuDatVeModel();
            phieuDatVeModel.cmnd = txtCMND.Text;
            phieuDatVeModel.email = txtEmail.Text;
            phieuDatVeModel.hoTen = txtHoTen.Text;
            phieuDatVeModel.soDienThoai = txtSDT.Text;
            phieuDatVeModel.thanhTien = float.Parse(gia);
            phieuDatVeModel.nguoiDatVe_id = idNV;
            phieuDatVeModel.roleDatVe = 1;
            phieuDatVeModel.vechuyenbayID = idVe;

            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd";
            phieuDatVeModel.ngayDat = time.ToString(format);
            if (check)
            {
                if (phieuDatVe.checkKhachHang(listKH, phieuDatVeModel.cmnd, check))
                {
                    phieuDatVe.saveModel(phieuDatVeModel);
                    MessageBox.Show("Đặt vé thành công nhắc khách hàng kiểm tra email !!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Khong co khach hang thanh vien voi cmnd nay xin kiem tra lai !!");
                }
            }
            else
            {
                if (phieuDatVe.checkKhachHang(listKH, phieuDatVeModel.cmnd, check))
                {
                    phieuDatVe.saveModel(phieuDatVeModel);
                    MessageBox.Show("Đặt vé thành công nhắc khách hàng kiểm tra email !!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("CMND nay la cua khach hang thanh vien xin kiem tra lai");
                }
            }
        }
    }
}
