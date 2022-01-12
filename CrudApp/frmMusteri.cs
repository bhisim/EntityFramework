using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudApp.Models;
using CrudApp.Repository;
namespace CrudApp
{
    public partial class frmMusteri : Form
    {

        CustomersRepository repository = new CustomersRepository();

        public frmMusteri()
        {
            InitializeComponent();
        }

        private void dgwMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            ID = (int)dgwMusteri.Rows[e.RowIndex].Cells[0].Value;
            txtCompanyName.Text = (string)dgwMusteri.Rows[e.RowIndex].Cells[1].Value;
            txtCompanyTitle.Text = (string)dgwMusteri.Rows[e.RowIndex].Cells[2].Value;
            txtContactPhone.Text = (string)dgwMusteri.Rows[e.RowIndex].Cells[3].Value;
        }
        int ID;

        private void frmMusteri_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Customer customer = repository.FindById(ID);

            if (customer == null)
                customer = new Customer();

            customer.Name = txtCompanyName.Text;
            customer.CompanyTitle = txtCompanyTitle.Text;
            customer.ContactPhone = txtContactPhone.Text;

            int result = 0;
            if (ID == 0)
                result = repository.Create(customer);

            else
                result = repository.Update(customer
                    
                    );

            if (result > 0)
                MessageBox.Show("İşlem başarılı");
            else
                MessageBox.Show("İşlem başarısız");
            Doldur();
            Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("Silme işlemi için önce kayıt seç");
                return;
            }

            if (MessageBox.Show("Silmek istediğine emin misin?",
                "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)

            { return; }

            Customer customer = repository.FindById(ID);
            repository.Delete(customer);
            Doldur();
            Clear();

        }

        void Clear()
        {
            txtCompanyName.Clear();
            txtCompanyTitle.Clear();
            txtContactPhone.Clear();
            ID = 0;

        }
        void Doldur()
        {
            dgwMusteri.DataSource = repository.List().Select(c => new {
                c.ID,
                c.Name,
                c.CompanyTitle,
                c.ContactPhone,
                c.CreDate

            }).ToList();
        }

       
    }
}
