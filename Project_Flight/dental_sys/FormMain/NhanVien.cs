using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dental_sys.FormAdd;
using DLL_DAL;
using DLL_DAL.Model;

namespace dental_sys
{
    public partial class NhanVien : Form
    {
        NhanVienDLL_DAL nhanVien = new NhanVienDLL_DAL("nhanvien");
        List<NhanVienModel> listNV;
        NhanVienModel itemNhanVien;
        public NhanVien()
        {
            InitializeComponent();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            listNV = nhanVien.findAll();
            guna2DataGridView1.Rows.Add(listNV.Count);
            slNV.Text = listNV.Count() + "";

            for (int i = 0; i < listNV.Count; i++)
            {
                guna2DataGridView1.Rows[i].Cells[0].Value = Image.FromFile("photos\\user.png");
                guna2DataGridView1.Rows[i].Cells[1].Value = listNV[i].hoTen; //"Nguyễn Thành Long";
                guna2DataGridView1.Rows[i].Cells[2].Value = listNV[i].soDienThoai; //"0356614606";
                guna2DataGridView1.Rows[i].Cells[3].Value = listNV[i].cmnd; //"30286654";
                guna2DataGridView1.Rows[i].Cells[4].Value = listNV[i].taiKhoan; //"Longzip113";
                guna2DataGridView1.Rows[i].Cells[5].Value = listNV[i].SoVeBan; //"100";
                guna2DataGridView1.Rows[i].Cells[6].Value = nhanVien.xuLyGia(listNV[i].TongDoanhThu + ""); //"100,000,000";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ThemNhanVien add = new ThemNhanVien(null, listNV);
            add.Show();
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            guna2Button5.Enabled = true;
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                itemNhanVien = nhanVien.findNhanVienBycmnd(listNV, guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ThemNhanVien add = new ThemNhanVien(itemNhanVien, listNV);
            add.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            String checkNhanVien = nhanVien.isCheckNhanVienDatVe(itemNhanVien.id);
            if (checkNhanVien == null)
            {
                nhanVien.delete(itemNhanVien.id);
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show(checkNhanVien);
            }
        }
    }
}
