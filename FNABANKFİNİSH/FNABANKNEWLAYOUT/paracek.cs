using System;
using QRCoder;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using System.Data.SqlTypes;

namespace FNABANKNEWLAYOUT
{
    public partial class paracek : Form
    {
        public paracek()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-DTFDPI9; Initial Catalog=FNABANK1; Integrated Security=SSPI");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public int bakiye { get; set; }
        public int hesapID { get; set; }

        private void paracek_Load(object sender, EventArgs e)
        {
            string soyad = "SELECT hesapBakiye FROM hesap WHERE hesapID = '" + hesapID + "'";
            int bakiye;
            SqlCommand komutt = new SqlCommand(soyad, cnn);
            cnn.Open();
            bakiye = Convert.ToInt32(komutt.ExecuteScalar());
            cnn.Close();
            label2.Text = bakiye.ToString();

            label3.Visible = false;
            Random rnd = new Random();
            int RastgeleSayi1 = rnd.Next(1000, 9999);
            label3.Text = RastgeleSayi1.ToString();
            QRCodeEncoder enc = new QRCodeEncoder();
            pictureBox1.Image = enc.Encode(RastgeleSayi1.ToString());



        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            if ( Convert.ToInt32( textBox1.Text)> Convert.ToInt32( label2.Text))
            {
                MessageBox.Show("Bakiyenizden daha fazla niktar para çekemezsiniz");
                textBox1.Clear();
                return;
            }
            if (textBox2.Text==label3.Text)
            {
  string soyad = "SELECT hesapBakiye FROM hesap WHERE hesapID = '" + hesapID + "'";
                        int bakiye;
                        SqlCommand komutt = new SqlCommand(soyad, cnn);
                        cnn.Open();
                        bakiye = Convert.ToInt32(komutt.ExecuteScalar());
                        cnn.Close();

                        int cıkarılacak = Convert.ToInt32(textBox1.Text);
                        int yenibakiye = bakiye - cıkarılacak;
                        textBox1.Text = yenibakiye.ToString();

                        cnn.Open();
                        string update = "Update hesap set hesapBakiye='" + yenibakiye + "' where hesapID ='" + hesapID + "'";
                        cmd = new SqlCommand(update, cnn);
                        cmd.ExecuteNonQuery();
                        cnn.Close();

                        MessageBox.Show("Yeni Baktiyeniz " + yenibakiye + " dir. Lütfen Tabloyu yenileyiniz.");
            }

            else
            {
                MessageBox.Show("QR kodu yanlış girdiniz lütfen tekrar okutun");
            }

          
                    
  
            
        } 
        
   
    }
}
