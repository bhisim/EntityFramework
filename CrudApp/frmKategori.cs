
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudApp.Models;  // ekledik

namespace CrudApp
{
    public partial class frmKategori : Form
    {
        CrudAppDbContext dbContext = new CrudAppDbContext();//başka bir namespaceden instance alınacaksa, o sınıfın namespace i using bölümüne eklenmelidir


        public frmKategori()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Categories C = new Categories();
            C.Name = txtKategori.Text;
            C.Description = txtAciklama.Text;

            dbContext.Kategori.Add(C);

            try
            {
                dbContext.SaveChanges();
                MessageBox.Show("Tebrikler. \n Kategori ekleme işlemi başarılı");
                Clear();

                KategoriDoldur();

            }
           catch(Exception ex)
            {
                MessageBox.Show("Bir hata oluştu");
            }

            
        }


        void Clear()

        {
            txtAciklama.Text = "";
            txtKategori.Text = "";

        }

        void KategoriDoldur()
        {
            //List<Categories> katList = dbContext.Kategori.ToList();
            //dgwKategoriler.DataSource = katList;

            var katList2 = dbContext.Kategori.Select(c => new  // new varsa anonimdir, var kullanmalısın, List<Categories> tipi kullanamazsın
            {
                c.ID,
                c.Name,
                c.Description,
                c.CreDate

            }).ToList();

            dgwKategoriler.DataSource = katList2;
            

        }

        private void frmKategori_Load(object sender, EventArgs e)
        {
            KategoriDoldur();
        }

        private void dgwKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;

            if (rowIndex == -1 || colIndex == -1)
                return;

            ID = (int)dgwKategoriler.Rows[rowIndex].Cells[0].Value;
            txtKategori.Text=(string)dgwKategoriler.Rows[rowIndex].Cells[1].Value;
            txtAciklama.Text = (string)dgwKategoriler.Rows[rowIndex].Cells[2].Value;

            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            
        }

        int ID;

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Categories kategori = dbContext.Kategori.Find(ID);

            kategori.Name = txtKategori.Text;  // yeni değeri eski değere set ettik
            kategori.Description = txtAciklama.Text;

         try
            { 
            dbContext.SaveChanges();
            MessageBox.Show("İşlem başarılı");
            Clear();
            ID = 0;
            KategoriDoldur();

            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            }
            

          catch(Exception ex)
            {
                MessageBox.Show("Hay aksi bir hata var");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Gerçekten silmek istiyor musun?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Information);

            if(result==DialogResult.No)
            { 
                return; 
            }


            Categories kategori = dbContext.Kategori.Find(ID);
            dbContext.Kategori.Remove(kategori);

            try
            { 
                dbContext.SaveChanges();
                MessageBox.Show("İşlem başarılı");
                Clear();
                ID = 0;
                KategoriDoldur();

                btnEkle.Enabled = true;
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Hay aksi bir hata var");
            }
        }
    }
}
