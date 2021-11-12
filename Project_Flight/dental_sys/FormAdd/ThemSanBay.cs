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

    public partial class ThemSanBay : Form
    {
        SanBayDLL_DAL sanBay = new SanBayDLL_DAL("SanBay");
        SanBayModel model;
        List<SanBayModel> listSB;

        public ThemSanBay(SanBayModel model, List<SanBayModel> listSB)
        {
            InitializeComponent();
            this.model = model;
            this.listSB = listSB;
            if (model != null)
            {
                load();
                guna2Button2.Text = "Sua";
            }
        }

        private void load()
        {
            txtMaCode.Text = model.code;
            txtQuocGia.Text = model.quocGia;
            txtTenSanBay.Text = model.tenSanBay;
            txtThanhPho.Text = model.tenThanhPho;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SanBayModel sanBayModel = new SanBayModel();
            sanBayModel.code = txtMaCode.Text.Trim();
            sanBayModel.tenSanBay = txtTenSanBay.Text.Trim();
            sanBayModel.tenThanhPho = txtThanhPho.Text.Trim();
            sanBayModel.quocGia = txtQuocGia.Text.Trim();
            sanBayModel.tinhTrang = true;

            if (guna2Button2.Text.Equals("Thêm"))
            {
                String check = sanBay.ischeckSanBay(sanBayModel, listSB);
                if (check == null)
                {
                    sanBay.saveModel(sanBayModel);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(check);
                }
            }
            else
            {
                sanBayModel.id = model.id;
                String check = sanBay.ischeckSanBay(sanBayModel, listSB);
                if (check == null)
                {
                    sanBay.update(sanBayModel);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(check);
                }
            }
        }
    }
}
