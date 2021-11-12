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

namespace dental_sys
{
    public partial class Loading : Form
    {
        NhanVienModel model;
        public Loading(NhanVienModel model)
        {
            InitializeComponent();
            this.model = model;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(guna2CircleProgressBar1.Value==100)
            {
                timer1.Stop();

                Main p = new Main(model);
                p.Show();
                this.Hide();

            }
            else
            { 
            guna2CircleProgressBar1.Value += 1;
            label_val.Text = (Convert.ToInt32(label_val.Text) + 1).ToString();
              }
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            timer1.Start();
        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label_val_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
