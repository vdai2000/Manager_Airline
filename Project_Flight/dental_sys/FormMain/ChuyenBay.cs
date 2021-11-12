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
using DLL_DAL.Model;
using DLL_DAL;
using System.Globalization;

namespace dental_sys
{
    public partial class ChuyenBay : Form
    {
        ChuyenBayDLL_DAL chuyenBay = new ChuyenBayDLL_DAL("ChuyenBay");
        List<ChuyenBayModel> listCB;
        ChuyenBayModel chuyenBayItem;
        public ChuyenBay()
        {
            InitializeComponent();
        }

        private void ChuyenBay_Load(object sender, EventArgs e)
        {
            load_Form();
        }

        private void load_Form()
        {
            listCB = chuyenBay.GetModels();

            guna2DataGridView1.Rows.Add(listCB.Count);
            slCB.Text = listCB.Count() + "";
            for (int i = 0; i < listCB.Count; i++)
            {
                guna2DataGridView1.Rows[i].Cells[0].Value = listCB[i].tenSanBayDi;
                guna2DataGridView1.Rows[i].Cells[1].Value = listCB[i].thanhPhoDi;
                guna2DataGridView1.Rows[i].Cells[2].Value = listCB[i].ngay + " - " + listCB[i].gio;
                guna2DataGridView1.Rows[i].Cells[3].Value = Image.FromFile("photos\\direct-flight.png");
                guna2DataGridView1.Rows[i].Cells[4].Value = listCB[i].thoiGianBay;
                guna2DataGridView1.Rows[i].Cells[5].Value = listCB[i].tenSanBayDen;
                guna2DataGridView1.Rows[i].Cells[6].Value = listCB[i].thanhPhoDen;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ThemChuyenBay themChuyenBay = new ThemChuyenBay(null, listCB);
            themChuyenBay.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ThemChuyenBay themChuyenBay = new ThemChuyenBay(chuyenBayItem, listCB);
            themChuyenBay.Show();
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            guna2Button5.Enabled = true;
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                chuyenBayItem = chuyenBay.findChuyenBayBySanBay(listCB, guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString(), guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString(), guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            chuyenBay.delete(chuyenBayItem.id);
            guna2DataGridView1.Rows.Clear();
            load_Form();
            MessageBox.Show("Delete success");
        }
    }
}
