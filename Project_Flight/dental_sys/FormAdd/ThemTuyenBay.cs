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
using Guna.UI2.WinForms;

namespace dental_sys
{
    public partial class FormThem : Form
    {
        SanBayDLL_DAL sanBay = new SanBayDLL_DAL("SanBay");
        TuyenBayDLL_DAL tuyenBay = new TuyenBayDLL_DAL("TuyenBay");

        TuyenBayModel itemTuyenBay = null;
        List<TuyenBayModel> listTB;
        public FormThem(List<TuyenBayModel> listTB, TuyenBayModel itemTuyenBay)
        {
            InitializeComponent();
            this.itemTuyenBay = itemTuyenBay;
            this.listTB = listTB;
            loadSanBay(null, guna2ComboBox1);
            if (this.itemTuyenBay != null)
            {
                loadTuyenBay();
                guna2Button2.Text = "Sua";
            }
        }

        private void loadTuyenBay()
        {
            List<SanBayModel> sanBayModels = sanBay.GetModels();
            var itemDi = sanBayModels.Single(r => r.id == itemTuyenBay.sanBayDiID);
            guna2ComboBox1.SelectedValue = itemDi.code;

            var itemDen = sanBayModels.Single(r => r.id == itemTuyenBay.sanBayDenID);
            guna2ComboBox3.SelectedValue = itemDen.code;
        }

        private void loadSanBay(SanBayModel model, Guna2ComboBox comboBox)
        {
            if (model == null)
            {
                List<SanBayModel> sanBayModels = sanBay.GetModels();
                comboBox.DataSource = sanBayModels;
                comboBox.DisplayMember = "TenSanBay";
                comboBox.ValueMember = "Code";
            }
            else
            {
                List<SanBayModel> sanBayModels = sanBay.GetModels();
                var itemToRemove = sanBayModels.Single(r => r.code == model.code);
                sanBayModels.Remove(itemToRemove);

                comboBox.DataSource = sanBayModels;
                comboBox.DisplayMember = "TenSanBay";
                comboBox.ValueMember = "Code";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanBayModel selected = (SanBayModel)guna2ComboBox1.SelectedItem;
            loadSanBay(selected, guna2ComboBox3);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SanBayModel sanBayDi = (SanBayModel)guna2ComboBox1.SelectedItem;
            SanBayModel sanBayDen = (SanBayModel)guna2ComboBox3.SelectedItem;

            TuyenBayModel tuyenBayModel = new TuyenBayModel();
            tuyenBayModel.sanBayDenID = sanBayDen.id;
            tuyenBayModel.sanBayDiID = sanBayDi.id;
            tuyenBayModel.tenSanBayDen = sanBayDen.tenSanBay;
            tuyenBayModel.tenSanBayDi = sanBayDi.tenSanBay;
            tuyenBayModel.thanhPhoDen = sanBayDen.tenThanhPho;
            tuyenBayModel.thanhPhoDi = sanBayDi.tenThanhPho;
            tuyenBayModel.tinhTrang = true;

            String checkTuyenBay = tuyenBay.isCheckTuyenBay(listTB, tuyenBayModel.sanBayDenID, tuyenBayModel.sanBayDiID);

            if (checkTuyenBay == null)
            {
                if (guna2Button2.Text.Equals("Sua"))
                {
                    tuyenBayModel.id = itemTuyenBay.id;
                    tuyenBay.update(tuyenBayModel);
                }
                else
                {
                    tuyenBay.saveModel(tuyenBayModel);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(checkTuyenBay);
            }

        }
    }
}
