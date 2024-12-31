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
using System.Xml.Linq;

namespace EczaneUyg
{
    public partial class FrmHastaListesi : Form
    {
        public FrmHastaListesi()
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
        private void FrmHastaListesi_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
