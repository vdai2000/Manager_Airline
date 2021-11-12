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

namespace dental_sys
{
    public partial class SanBay : Form
    {
        SanBayDLL_DAL sanBay = new SanBayDLL_DAL("sanbay");
        List<SanBayModel> listSB;
        SanBayModel sanBayItem;
        public SanBay()
        {
            InitializeComponent();
            load_Form();
        }

        private void load_Form()
        {
            SanBay_Load();
            guna2Button5.Enabled = false;
            guna2Button4.Enabled = false;
            slSB.Text = listSB.Count() + "";
        }
        private void SanBay_Load()
        {
            listSB = sanBay.GetModels();
            

            guna2DataGridView1.Rows.Add(listSB.Count);
            for(int i = 0; i < listSB.Count; i++)
            {
                guna2DataGridView1.Rows[i].Cells[0].Value = Image.FromFile("photos\\flight.png");
                guna2DataGridView1.Rows[i].Cells[1].Value = listSB[i].tenSanBay;
                guna2DataGridView1.Rows[i].Cells[2].Value = listSB[i].code;
                guna2DataGridView1.Rows[i].Cells[3].Value = listSB[i].tenThanhPho;
                guna2DataGridView1.Rows[i].Cells[4].Value = listSB[i].quocGia;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ThemSanBay themsanbay = new ThemSanBay(null, listSB);
            themsanbay.Show();
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            guna2Button5.Enabled = true;
            guna2Button4.Enabled = true;
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                sanBayItem = sanBay.findSanBayByCode(listSB, guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            sanBay.delete(sanBayItem.id);
            guna2DataGridView1.Rows.Clear();
            load_Form();
            MessageBox.Show("Delete success");
        }

       

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ThemSanBay themsanbay = new ThemSanBay(sanBayItem, listSB);
            themsanbay.Show();
        }
    }
}
