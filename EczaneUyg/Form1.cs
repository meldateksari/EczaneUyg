using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EczaneUyg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void ilaçlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EczaneVT.accdb");

        void listele()
        {
            OleDbCommand komut = new OleDbCommand("select * from satislar",con);
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtTcNo.Text==""|| txtBarkodNo.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz giriniz", "eksik kayıt hatası", MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            else
            {
                bool sonuc1 = true;
                bool sonuc2 = true;

                int toplamFiyat = 0, fyt = 0; ;
                OleDbCommand komut1 = new OleDbCommand("select * from Hastalar where TC =@p1", con);
                con.Open();
                komut1.Parameters.AddWithValue("@p1", txtTcNo.Text);
                OleDbDataReader dr = komut1.ExecuteReader();
                if (dr.Read())
                    sonuc1 = true;
                con.Close();
                
                
                OleDbCommand komut2 = new OleDbCommand("select * from Hastalar where TC =@p1", con);
                con.Open();
                komut2.Parameters.AddWithValue("@p1", txtTcNo.Text);
                OleDbDataReader dr2 = komut2.ExecuteReader();
                if (dr2.Read())
                {
                    fyt = int.Parse(dr2["fiyat"].ToString());
                    sonuc2 = true;
                }
                   
                   
                con.Close();

                if (!sonuc1)
                    MessageBox.Show("lütfen önce hasta kaydını yapınız", "hatalı işlem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if(!sonuc2)
                    MessageBox.Show("lütfen önce hasta kaydını yapınız", "hatalı işlem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {

                    OleDbCommand komut = new OleDbCommand("insert into satislar(hastaNo,ilacNo,adet,toplamFiyat,tarih,durum) values(@p1,p2,@p3, @p4,@p5,@p6 )", con);

                    con.Open();
                    toplamFiyat = fyt * int.Parse(numAdet.Value.ToString());
                    komut.Parameters.AddWithValue("@p1", txtTcNo.Text);
                    komut.Parameters.AddWithValue("@p2", txtBarkodNo.Text);
                    komut.Parameters.AddWithValue("@p1", numAdet.Value);
                    komut.Parameters.AddWithValue("@p1", toplamFiyat);
                    komut.Parameters.AddWithValue("@p1", DateTime.Today);
                    komut.Parameters.AddWithValue("@p1", true);

                    int sonuc = komut.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        MessageBox.Show("toplam fiyat:" + toplamFiyat);
                        MessageBox.Show("satis yapıldı", "satış");
                    }
                    else
                        MessageBox.Show("satış işleminde hata oluştu", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning
                            );


                    con.Close();
                }


                listele();
            }
        }

        private void hastaKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHastaKaydi fr = new FrmHastaKaydi();
            fr.Show();
        }

        private void hastalarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHastaListesi fr = new FrmHastaListesi();
            fr.Show();
        }

        private void hastaSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHastaSil fr = new FrmHastaSil();
            fr.Show();
        }

        private void hastaGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmhastaGüncelle fr = new FrmhastaGüncelle();
            fr.Show();

        }
        
        private void ilaçKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIlacKaydi fr = new FrmIlacKaydi();
            fr.Show();
        }

        private void ilaçlarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIlacListesi fr = new FrmIlacListesi();
            fr.Show();
        }

        private void ilaçSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIlacSil fr = new FrmIlacSil();
            fr.Show();
        }

        private void ilaçGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void güvenceEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGuvenceKaydi fr = new FrmGuvenceKaydi();
            fr.Show();
        }
    }

}
