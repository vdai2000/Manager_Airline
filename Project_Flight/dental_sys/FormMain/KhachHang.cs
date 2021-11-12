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

namespace dental_sys.FormMain
{
    public partial class KhachHang : Form
    {
        KhachHangDLL_DAL khachHang = new KhachHangDLL_DAL("khachhang");
        List<KhachHangModel> listKH;
        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            listKH = khachHang.findAll();
            guna2DataGridView1.Rows.Add(listKH.Count);
            slKH.Text = listKH.Count() + "";

            for (int i = 0; i < listKH.Count; i++)
            {
                guna2DataGridView1.Rows[i].Cells[0].Value = Image.FromFile("photos\\user.png");
                guna2DataGridView1.Rows[i].Cells[1].Value = listKH[i].hoTen; //"Nguyễn Thành Long";
                guna2DataGridView1.Rows[i].Cells[2].Value = listKH[i].soDienThoai; //"0356614606";
                guna2DataGridView1.Rows[i].Cells[3].Value = listKH[i].cmnd; //"30286654";
                guna2DataGridView1.Rows[i].Cells[4].Value = listKH[i].email; //"Longzip113";
                guna2DataGridView1.Rows[i].Cells[5].Value = listKH[i].SoVeDaBan; //"100";
                guna2DataGridView1.Rows[i].Cells[6].Value = khachHang.xuLyGia(listKH[i].TongChiPhi + ""); //"100,000,000";
            }
        }
    }
}
