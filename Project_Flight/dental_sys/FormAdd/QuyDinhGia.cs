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

namespace dental_sys.FormAdd
{
    public partial class QuyDinhGia : Form
    {
        VeChuyenBayDLL_DAL veChuyenBay = new VeChuyenBayDLL_DAL("vechuyenbay");
        long id;
        public QuyDinhGia(long id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            VeChuyenBayModel veChuyenBayModel = new VeChuyenBayModel();
            veChuyenBayModel.chuyenBayID = id;

            veChuyenBayModel.donGia = float.Parse(txtPT.Text);
            veChuyenBayModel.hangVeID = 1;
            veChuyenBay.saveModel(veChuyenBayModel);

            veChuyenBayModel.donGia = float.Parse(txtTG.Text);
            veChuyenBayModel.hangVeID = 2;
            veChuyenBay.saveModel(veChuyenBayModel);

            this.Close();
        }
    }
}
