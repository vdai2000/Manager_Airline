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
    public partial class ThemNhanVien : Form
    {
        NhanVienDLL_DAL nhanVien = new NhanVienDLL_DAL("nhanvien");
        NhanVienModel itemNhanVien = null;
        List<NhanVienModel> listNV;
        public ThemNhanVien(NhanVienModel itemNhanVien, List<NhanVienModel> listNV)
        {
            InitializeComponent();
            this.itemNhanVien = itemNhanVien;
            this.listNV = listNV;
        }

        private void ThemNhanVien_Load(object sender, EventArgs e)
        {
            if (itemNhanVien != null)
            {
                guna2Button2.Text = "Sua";
                txtCMND.Text = itemNhanVien.cmnd;
                txtSDT.Text = itemNhanVien.soDienThoai;
                txtTen.Text = itemNhanVien.hoTen;
                txtTenTK.Text = itemNhanVien.taiKhoan;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "" && txtSDT.Text == "" && txtCMND.Text == "" && txtTenTK.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin !");
                return;
            }

            NhanVienModel nhanVienModel = new NhanVienModel();
            nhanVienModel.chucVuID = 1;
            nhanVienModel.cmnd = txtCMND.Text;
            nhanVienModel.hoTen = txtTen.Text;
            nhanVienModel.soDienThoai = txtSDT.Text;
            nhanVienModel.taiKhoan = txtTenTK.Text;
            nhanVienModel.matKhau = "123";
            nhanVienModel.tinhTrang = true;

            if (guna2Button2.Text.Equals("Sua"))
            {
                nhanVienModel.id = itemNhanVien.id;
                String checkNhanVien = nhanVien.isCheckNhanVien(listNV, nhanVienModel);
                if (checkNhanVien == null)
                {
                    nhanVien.update(nhanVienModel);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(checkNhanVien);
                }
            }
            else
            {
                nhanVienModel.id = itemNhanVien.id;
                String checkNhanVien = nhanVien.isCheckNhanVien(listNV, nhanVienModel);
                if (checkNhanVien == null)
                {
                    nhanVien.saveModel(nhanVienModel);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(checkNhanVien);
                }

            }

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
