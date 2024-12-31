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
    public partial class FrmGuvenceKaydi : Form
    {
        public FrmGuvenceKaydi()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EczaneVT.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" )
                MessageBox.Show("lütfen guvence adını giriniz.", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
               
              
                    OleDbCommand komut = new OleDbCommand("insert into Guvenceler(guvenceAdi,durum) values(@p1, @p2)", con);
                    con.Open();

                    komut.Parameters.AddWithValue("@p1", txtAd.Text);
                    komut.Parameters.AddWithValue("@p2", true);
                    int sonuc = komut.ExecuteNonQuery();
                    if (sonuc > 0)
                        MessageBox.Show("kayıt tamam");
                    else
                        MessageBox.Show("kayıt hatası!", "hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();
                }

            }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }
    

