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

namespace dental_sys
{
    public partial class TuyenBay : Form
    {
        TuyenBayDLL_DAL tuyenBay = new TuyenBayDLL_DAL("tuyenbay");
        List<TuyenBayModel> listTB;
        TuyenBayModel itemTuyenBay;
        public TuyenBay()
        {
            InitializeComponent();
            Load_Form();
        }

        private void Load_Form()
        {
            guna2Button5.Enabled = false;
            listTB = tuyenBay.GetModels();
            slTB.Text = listTB.Count() + "";
            guna2DataGridView1.Rows.Add(listTB.Count);
            for (int i = 0; i < listTB.Count; i++)
            {
                guna2DataGridView1.Rows[i].Cells[0].Value = listTB[i].tenSanBayDi;
                guna2DataGridView1.Rows[i].Cells[1].Value = listTB[i].thanhPhoDi;
                guna2DataGridView1.Rows[i].Cells[2].Value = Image.FromFile("photos\\go.png");
                guna2DataGridView1.Rows[i].Cells[3].Value = listTB[i].tenSanBayDen;
                guna2DataGridView1.Rows[i].Cells[4].Value = listTB[i].thanhPhoDen;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormThem a = new FormThem(listTB, null);
            a.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            tuyenBay.delete(itemTuyenBay.id);
            guna2DataGridView1.Rows.Clear();
            Load_Form();
            MessageBox.Show("Delete success");
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            guna2Button5.Enabled = true;
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                itemTuyenBay = tuyenBay.findTuyenBayBySanBay(listTB, guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString(), guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            FormThem a = new FormThem(listTB, itemTuyenBay);
            a.Show();
        }
    }
}
