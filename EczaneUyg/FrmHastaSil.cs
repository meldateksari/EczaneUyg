using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneUyg
{
    public partial class FrmHastaSil : Form
    {
        public FrmHastaSil()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EczaneVT.accdb");

        public void listele()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Hastalar where durum=true", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        private void FrmHastaSil_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtNumara.Text == "")
            {
                MessageBox.Show("aradıgınız kişinin numarasını giriniz", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
 OleDbDataAdapter da = new OleDbDataAdapter("select * from Hastalar where durum=true and TC='"+txtNumara.Text+"'", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;

            }
           
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            OleDbCommand komut = new OleDbCommand("update Hastalar set durum =false where TC=@p1", con);
            con.Open();
            komut.Parameters.AddWithValue("@p1", txtNumara.Text);
            int sonuc = komut.ExecuteNonQuery();
            if (sonuc > 0)
            {
                MessageBox.Show(txtNumara.Text + "numaralı kayıt silindi ");


            }
            else
                MessageBox.Show("silme işlemi başarısız", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            con.Close();
            listele();

        }

        private void txtNumara_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
