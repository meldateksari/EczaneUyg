using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneUyg
{
    public partial class FrmIlacSil : Form
    {
        public FrmIlacSil()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EczaneVT.accdb");

        public void listele()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Ilaclar where durum=true", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void FrmIlacSil_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtNumara.Text == "")
            {
                MessageBox.Show("aradıgınız ilacın numarasını giriniz", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                OleDbCommand komut = new OleDbCommand("select * from Ilaclar where durum=true and barkodNo=@p1", con);
                komut.Parameters.AddWithValue("@p1", int.Parse(txtNumara.Text));
                OleDbDataAdapter da = new OleDbDataAdapter();
                con.Open();
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
                con.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtNumara.Text == "")
            {
                MessageBox.Show("silmek istediginiz ilacın numarasını giriniz", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                OleDbCommand komut = new OleDbCommand("update Ilaclar set durum =false where barkodNo=@p1", con);
                
                komut.Parameters.AddWithValue("@p1", txtNumara.Text);
                con.Open();
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
        }
    }
}
