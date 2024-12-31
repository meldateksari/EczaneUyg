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
    public partial class Frm_IlacGuncelle : Form
    {
        public Frm_IlacGuncelle()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EczaneVT.accdb");

        private void btnAra_Click(object sender, EventArgs e)
        {
           if (txtNumara.Text == "")
            {
                MessageBox.Show("lütfen aradıgınız ilacın numarasını giriniz.", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           else
            {
           OleDbCommand komut = new OleDbCommand("select * from Ilaclar where  barkodNo=@p1",con);
            con.Open();
            OleDbDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtFirma.Text = dr[2].ToString();
                txtFiyat.Text = dr[3].ToString();
                txtAdet.Text = dr[4].ToString();
                cbDurum.Checked = bool.Parse(dr[5].ToString()) ? true : false;
            }
            else
                MessageBox.Show("aradığınız kayit bulunamadı", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            con.Close();
        }
            }
           

        private void Frm_IlacGuncelle_Load(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (txtAd.Text == "" || txtNumara.Text == "" || txtFirma.Text == "" || txtFirma.Text == ""|| txtAdet.Text=="")
                MessageBox.Show("lütfen tum alanları eksiksiz giriniz.", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                OleDbCommand komut = new OleDbCommand("update Ilaclar set ilacAdi =@p1,firmaAdi =@p2,fiyat=@p3,adet=@p4,durum=@p5 where barkodNo=@p6", con);
                con.Open();

                komut.Parameters.AddWithValue("@p1", txtAd.Text);
                komut.Parameters.AddWithValue("@p2", txtFirma.Text);
                komut.Parameters.AddWithValue("@p3", txtFiyat.Text);
                komut.Parameters.AddWithValue("@p4", txtAdet.Text);
                komut.Parameters.AddWithValue("@p5", cbDurum.Checked ? true : false);
                komut.Parameters.AddWithValue("@p6", txtNumara.Text);
                int sonuc = komut.ExecuteNonQuery();
                if (sonuc > 0)
                    MessageBox.Show(txtNumara.Text + "numaralı kayıt guncellendi");
                else
                    MessageBox.Show("guncelleme işlemi başarısız!", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                con.Close();
                txtAd.Text = "";
                txtFirma.Text = "";
                txtFiyat.Text = "";
                txtAdet.Text = "";

            }

        }
    }
}
