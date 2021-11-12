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
    public partial class XemVe : Form
    {
        PhieuDatVeDLL_DAL phieuDatVe = new PhieuDatVeDLL_DAL("phieudatve");
        List<PhieuDatVeModel> listPDV;
        public XemVe()
        {
            InitializeComponent();
        }

        private void XemVe_Load(object sender, EventArgs e)
        {
            listPDV = phieuDatVe.GetModels();
            guna2DataGridView1.Rows.Add(listPDV.Count);
            slVeBan.Text = listPDV.Count() + "";

            for (int i = 0; i < listPDV.Count; i++)
            {
                guna2DataGridView1.Rows[i].Cells[0].Value = Image.FromFile("photos\\user.png");
                guna2DataGridView1.Rows[i].Cells[1].Value = listPDV[i].hoTen; //"Nguyễn Thành Long";
                guna2DataGridView1.Rows[i].Cells[2].Value = listPDV[i].hoTenNhanVien; //"0356614606";
                guna2DataGridView1.Rows[i].Cells[3].Value = listPDV[i].tuyenBay; //"30286654";
                guna2DataGridView1.Rows[i].Cells[4].Value = listPDV[i].ngayDat; //"Longzip113";
                guna2DataGridView1.Rows[i].Cells[5].Value = listPDV[i].thoiGianBay; //"100";
                guna2DataGridView1.Rows[i].Cells[6].Value = phieuDatVe.xuLyGia(listPDV[i].thanhTien + ""); //"100,000,000";
            }
        }
    }
}
