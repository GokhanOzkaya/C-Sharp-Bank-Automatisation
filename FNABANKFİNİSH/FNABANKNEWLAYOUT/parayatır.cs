using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Data.SqlTypes;

namespace FNABANKNEWLAYOUT
{
    public partial class parayatır : Form
    {
        public parayatır()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-DTFDPI9; Initial Catalog=FNABANK1; Integrated Security=SSPI");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public int bakiye { get; set; }
        public int hesapID { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {

            string soyad = "SELECT hesapBakiye FROM hesap WHERE hesapID = '" + hesapID + "'";
            int bakiye;
            SqlCommand komutt = new SqlCommand(soyad, cnn);
            cnn.Open();
            bakiye = Convert.ToInt32(komutt.ExecuteScalar());
            cnn.Close();
            
            int eklenecek = Convert.ToInt32(textBox1.Text);
            int yenibakiye = bakiye + eklenecek;
            label2.Text=yenibakiye.ToString();

            cnn.Open();
            string update = "Update hesap set hesapBakiye='"+yenibakiye+"' where hesapID ='"+hesapID+"'";
            cmd = new SqlCommand(update, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            
            MessageBox.Show("Yeni Baktiyeniz "+yenibakiye+" dir. Lütfen Tabloyu yenileyiniz");


        }


        private void parayatır_Load(object sender, EventArgs e)
        {
            string soyad = "SELECT hesapBakiye FROM hesap WHERE hesapID = '" + hesapID + "'";
            int bakiye;
            SqlCommand komutt = new SqlCommand(soyad, cnn);
            cnn.Open();
            bakiye = Convert.ToInt32(komutt.ExecuteScalar());
            cnn.Close();
            label2.Text = bakiye.ToString();
        }
    }
}
