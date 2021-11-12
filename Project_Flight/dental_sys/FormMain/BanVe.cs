using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dental_sys.UseControl;
using DLL_DAL;
using DLL_DAL.Model;
using Guna.UI2.WinForms;

namespace dental_sys
{
    public partial class BanVe : Form
    {
        ChuyenBayDLL_DAL chuyenBay = new ChuyenBayDLL_DAL("ChuyenBay");
        List<ChuyenBayModel> chuyenBayModels;
        NhanVienModel model;

        SanBayDLL_DAL sanBay = new SanBayDLL_DAL("SanBay");
        public BanVe(NhanVienModel model)
        {
            InitializeComponent();
            this.model = model;
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

        private void BanVe_Load(object sender, EventArgs e)
        {
            loadSanBay(null, guna2ComboBox1);
            loadRoleVe();
            guna2CustomRadioButton1.Checked = true;

            
        }

        private void loadRoleVe()
        {
            guna2ComboBox3.Items.Add("Loại vé.");
            guna2ComboBox3.Items.Add("Vé thương gia.");
            guna2ComboBox3.Items.Add("Vé phổ thông");

            guna2ComboBox3.SelectedItem = "Loại vé.";
        }

        private void loadItem(List<ChuyenBayModel> chuyenBayModels)
        {
            flowLayoutPanel1.Controls.Clear();

            if (chuyenBayModels.Count == 0)
            {
                MessageBox.Show("Hiện tại chưa có chuyến bay bạn muốn tìm kiếm");
                return;
            }
            ListItem[] list = new ListItem[chuyenBayModels.Count];

            for (int i = 0; i < chuyenBayModels.Count; i++)
            {
                list[i] = new ListItem();
                list[i].Noiden = chuyenBayModels[i].thanhPhoDi + " (" + chuyenBayModels[i].codeSanDi + ")";
                list[i].Noidi = chuyenBayModels[i].thanhPhoDen + " (" + chuyenBayModels[i].codeSanDen + ")";
                list[i].NgayDi = chuyenBayModels[i].ngay;
                list[i].Gioden = chuyenBay.xuLyNgayDen(chuyenBayModels[i].gio, chuyenBayModels[i].thoiGianBay);
                list[i].Giodi = chuyenBayModels[i].gio;
                list[i].Gia = chuyenBay.xuLyGia(chuyenBayModels[i].donGia + "");
                list[i].Id = chuyenBayModels[i].id;
                list[i].IdNV = model.id;
                list[i].IdVe = chuyenBayModels[i].idVe;

                if (chuyenBayModels[i].hangVe.Equals("BambooAirline"))
                {
                    list[i].Img = Properties.Resources.logo_bamboo;
                }
                else if (chuyenBayModels[i].hangVe.Equals("VietJetAirline"))
                {
                    list[i].Img = Properties.Resources.logo_vietjet;
                }
                else
                {
                    list[i].Img = Properties.Resources.logo_vnairlines;
                }

                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                {
                    flowLayoutPanel1.Controls.Add(list[i]);
                }
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanBayModel selected = (SanBayModel)guna2ComboBox1.SelectedItem;
            loadSanBay(selected, guna2ComboBox2);
        }

        private void guna2CustomRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2CustomRadioButton2.Checked == true)
            {
                guna2DateTimePicker2.Visible = false;
            }
            else
            {
                guna2DateTimePicker2.Visible = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ChuyenBayModel chuyenBayModel = new ChuyenBayModel();

            SanBayModel sanBayDi = (SanBayModel)guna2ComboBox1.SelectedItem;
            SanBayModel sanBayDen = (SanBayModel)guna2ComboBox2.SelectedItem;

            String loaiVe = guna2ComboBox3.SelectedItem.ToString();
            DateTime time = guna2DateTimePicker1.Value;
            string format = "yyyy-MM-dd";

            chuyenBayModel.sanBayDiId = sanBayDi.id;
            chuyenBayModel.sanBayDenId = sanBayDen.id;
            chuyenBayModel.ngayDi = time.ToString(format);
            chuyenBayModel.ngayVe = null;

            if (guna2ComboBox3.SelectedItem.ToString().Equals("Vé thương gia."))
            {
                chuyenBayModel.loaiVe = "TG";
            } 
            else
            {
                chuyenBayModel.loaiVe = "PT";
            }

            // Ham search chuyen bay
            chuyenBayModels = chuyenBay.searchChuyenBay(chuyenBayModel);
            loadItem(chuyenBayModels);
        }
    }
}
