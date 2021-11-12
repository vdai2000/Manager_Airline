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

namespace dental_sys.UseControl
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }

        private long idNV;
        private long? idVe;
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
        private string gia;

        [Category("Custom Props")]
        public string Gia
        {
            get { return gia; }
            set { gia = value; lblgia.Text = value; }
        }

        private string ngayDi;
        [Category("Custom Props")]
        public string NgayDi
        {
            get { return ngayDi; }
            set { ngayDi = value; day.Text = value; }
        }

        private long id;
        [Category("Custom Props")]
        public long Id
        {
            get { return id; }
            set { id = value; guna2Button1.Tag = value; }
        }

        public long IdNV { get => idNV; set => idNV = value; }
        public long? IdVe { get => idVe; set => idVe = value; }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DatVe dv = new DatVe(id, lblgia.Text, idNV, idVe);
            dv.Show();
        }

        
    }
}
