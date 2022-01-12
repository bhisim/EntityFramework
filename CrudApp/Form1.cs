using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            frmKategori frm = new frmKategori();
            frm.Show();
        }

        private void btnNakliye_Click(object sender, EventArgs e)
        {
            frmShipperscs frm = new frmShipperscs();
            frm.Show();
        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            frmKullanici frm = new frmKullanici();
            frm.Show();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            frmMusteri frm = new frmMusteri();
            frm.Show();
        }
    }
}
