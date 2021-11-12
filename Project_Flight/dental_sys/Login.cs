using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using Newtonsoft.Json;
using DLL_DAL;
using DLL_DAL.Model;

namespace dental_sys
{
    public partial class Login : Form
    {
        NhanVienDLL_DAL nhanviens = new NhanVienDLL_DAL("nhanvien");

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }
        public void login(String userName, String passWord)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NhanVienModel model = new NhanVienModel();
            model.taiKhoan = guna2TextBox1.Text;
            model.matKhau = guna2TextBox2.Text;

            model = nhanviens.login(model);
            if(model != null)
            {
                Loading _load = new Loading(model);
                _load.Show();
                this.Hide();
            }
            else
            {
                notification.Text = "Tài khoản hoặc mật khẩu sai xin kiểm tra lại !";
            }

            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
