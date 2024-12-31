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
    public partial class FrmIlacKaydi : Form
    {
        public FrmIlacKaydi()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EczaneVT.accdb");
    
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtFirma.Text == "" || txtAdet.Text == "")
                MessageBox.Show("lütfen tum alanları eksiksiz giriniz.", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                
                    OleDbCommand komut = new OleDbCommand("insert into Ilaclar(ilacAdi, firmaAdi,fiyat,adet,durum) values(@p1, @p2,@p3,@p4,@p5)", con);
                    con.Open();
                   
                    komut.Parameters.AddWithValue("@p1", txtAd.Text);
                    komut.Parameters.AddWithValue("@p2", txtFirma.Text);
                    komut.Parameters.AddWithValue("@p3", txtFiyat.Text);
                    komut.Parameters.AddWithValue("@p4", txtAdet.Text);
                    komut.Parameters.AddWithValue("@p5", true);
                    int sonuc = komut.ExecuteNonQuery();
                    if (sonuc > 0)
                        MessageBox.Show("kayıt tamam");
                    else
                        MessageBox.Show("kayıt hatası!", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();
                

            }
           
            txtAd.Text = "";
            txtFirma.Text = "";
            txtAdet.Text = "";
            txtFiyat.Text = "";

        }
    }
    }

