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
using Guna.UI2.WinForms;

namespace dental_sys.FormAdd
{
    public partial class ThemChuyenBay : Form
    {
        MayBayDLL_DAL mayBay = new MayBayDLL_DAL("maybay");
        List<MayBayModel> listMB;

        TuyenBayDLL_DAL tuyenBay = new TuyenBayDLL_DAL("TuyenBay");
        List<TuyenBayModel> listTB = new List<TuyenBayModel>();

        ChuyenBayDLL_DAL chuyenBay = new ChuyenBayDLL_DAL("ChuyenBay");
        ChuyenBayModel chuyenBayItem;
        List<ChuyenBayModel> listCB;

        public ThemChuyenBay(ChuyenBayModel chuyenBayItem, List<ChuyenBayModel> listCB)
        {
            InitializeComponent();
            listMB = mayBay.GetModels();
            listTB = tuyenBay.GetModels();
            foreach(TuyenBayModel item in listTB)
            {
                item.TuyenBay = item.tenSanBayDi + " -- " + item.tenSanBayDen;
            }
            this.chuyenBayItem = chuyenBayItem;
            this.listCB = listCB;
            if(chuyenBayItem != null)
            {
                guna2Button2.Text = "Sửa";
            }
        }

        private void loadUpdate()
        {
            TuyenBayModel item = tuyenBay.findTuyenBayBySanBay(listTB, chuyenBayItem.tenSanBayDi, chuyenBayItem.tenSanBayDen);
            guna2ComboBox1.SelectedValue = item.id;
            guna2TextBox1.Text = chuyenBayItem.thoiGianBay + "";
            guna2ComboBox3.SelectedItem = chuyenBayItem.hangVe;
            guna2ComboBox4.SelectedValue = chuyenBayItem.mayBayId;
            string[] days = chuyenBayItem.ngay.Split('-');
            string[] times = chuyenBayItem.gio.Split(':');

            int year = int.Parse(days[0]);
            int month = int.Parse(days[1]);
            int day = int.Parse(days[2]);

            guna2DateTimePicker1.Value = new DateTime(year, month, day);
            guna2ComboBox5.SelectedItem = int.Parse(times[0]);
            guna2ComboBox2.SelectedItem = int.Parse(times[1]);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemChuyenBay_Load(object sender, EventArgs e)
        {
            guna2ComboBox3.Items.Add("VietNamAirline");
            guna2ComboBox3.Items.Add("VietJetAirline");
            guna2ComboBox3.Items.Add("BambooAirline");
            guna2ComboBox3.Items.Add("Chọn hãng vé");

            guna2ComboBox3.SelectedItem = "Chọn hãng vé";
            guna2ComboBox4.Enabled = false;

            guna2ComboBox1.DataSource = listTB;
            guna2ComboBox1.DisplayMember = "TuyenBay";
            guna2ComboBox1.ValueMember = "id";


            for(int i = 0; i <= 60; i++)
            {
                if(i <= 23)
                {
                    guna2ComboBox5.Items.Add(i);
                }
                guna2ComboBox2.Items.Add(i);
            }
            loadMayBay(listMB);
            if (chuyenBayItem != null)
            {
                loadUpdate();
            }
        }

        private void loadMayBay(List<MayBayModel> listMB)
        {
            guna2ComboBox4.DataSource = listMB;
            guna2ComboBox4.DisplayMember = "TenMayBay";
            guna2ComboBox4.ValueMember = "id";
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selected = guna2ComboBox3.SelectedItem.ToString();
            List<MayBayModel> listMBItem = new List<MayBayModel>();
            foreach(MayBayModel item in listMB)
            {
                if(item.hangMayBay.Equals(selected))
                {
                    listMBItem.Add(item);
                }
            }

            loadMayBay(listMBItem);
            guna2ComboBox4.Enabled = true;

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ChuyenBayModel chuyenBayModel = new ChuyenBayModel();

            MayBayModel mayBayItem = (MayBayModel)guna2ComboBox4.SelectedItem;
            TuyenBayModel tuyenBayItem = (TuyenBayModel)guna2ComboBox1.SelectedItem;

            DateTime time = guna2DateTimePicker1.Value;
            string format = "yyyy-MM-dd";

            chuyenBayModel.mayBayId = mayBayItem.id;
            chuyenBayModel.tuyenBayId = tuyenBayItem.id;
            chuyenBayModel.thoiGianBay = float.Parse(guna2TextBox1.Text);
            chuyenBayModel.gio = guna2ComboBox5.SelectedItem.ToString() + chuyenBay.xuLyPhut(int.Parse(guna2ComboBox2.SelectedItem.ToString()));
            chuyenBayModel.ngay = time.ToString(format);
            chuyenBayModel.tinhTrang = true;
            
            if(guna2Button2.Text.Equals("Sửa"))
            {
                String checkChuyenBay = chuyenBay.isCheckChuyenBay(listCB, chuyenBayModel);
                chuyenBayModel.id = chuyenBayItem.id;
                if (checkChuyenBay == null)
                {
                    chuyenBay.update(chuyenBayModel);
                }
                else
                {
                    MessageBox.Show(checkChuyenBay);
                }
            }
            else
            {
                String checkChuyenBay = chuyenBay.isCheckChuyenBay(listCB, chuyenBayModel);
                if (checkChuyenBay == null)
                {
                    chuyenBay.saveModel(chuyenBayModel);
                }
                else
                {
                    MessageBox.Show(checkChuyenBay);
                }
            }
            this.Close();
        }
    }
}
