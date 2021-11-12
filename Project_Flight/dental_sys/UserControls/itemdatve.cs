using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dental_sys.FormAdd;

namespace dental_sys.UserControls
{
    public partial class itemdatve : UserControl
    {
        public itemdatve()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            QuyDinhGia qd = new QuyDinhGia(id);
            qd.Show();
        }

        private long id;

        private string giodi;

        [Category("Custom Props")]
        public string Giodi
        {
            get { return giodi; }
            set { giodi = value; lblGioDI.Text = value; }
        }

        private string gioden;

        [Category("Custom Props")]
        public string Gioden
        {
            get { return gioden; }
            set { gioden = value; lblgioden.Text = value; }
        }
        private string noidi;

        [Category("Custom Props")]
        public string Noidi
        {
            get { return noidi; }
            set { noidi = value; lblnoidi.Text = value; }
        }
        private string noiden;

        [Category("Custom Props")]
        public string Noiden
        {
            get { return noiden; }
            set { noiden = value; lblnoiden.Text = value; }
        }
        private Image img;

        [Category("Custom Props")]
        public Image Img
        {
            get { return img; }
            set { img = value; image.Image = value; }
        }

        private string ngayDi;
        [Category("Custom Props")]
        public string NgayDi
        {
            get { return ngayDi; }
            set { ngayDi = value; day.Text = value; }
        }

        public long Id { get => id; set => id = value; }
    }
}
