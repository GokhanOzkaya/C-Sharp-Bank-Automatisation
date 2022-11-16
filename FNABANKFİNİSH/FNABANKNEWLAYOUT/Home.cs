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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography.X509Certificates;

namespace FNABANKNEWLAYOUT
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-DTFDPI9; Initial Catalog=FNABANK1; Integrated Security=SSPI");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        IDataReader dr;
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != String.Empty || textBox5.Text != String.Empty)
            {


                cnn.Open();
                cmd = new SqlCommand("select * from admin where adminID='" + textBox6.Text.ToString() + "'AND adminsifre='"+textBox5.Text.ToString()+"'", cnn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MusteriKayıt mk = new MusteriKayıt();
                    mk.Show();
                    dr.Close();

                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Şifrenizi ve AdminID'nizi kontrol ediğ tekrar deneyiniz");
                }
            }
            cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            if (textBox1.Text != String.Empty || textBox2.Text != String.Empty)
            {


                cnn.Open();
                cmd = new SqlCommand("select * from bireyselMusteri join musteri on musteri.ID=bireyselMusteri.ID where bireyselMusteri.ID='" + textBox1.Text.ToString() + "'and musteri.Şifre ='"+textBox2.Text.ToString()+"'", cnn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    bireyselhesapanaekran f = new bireyselhesapanaekran();
                    f.ID = textBox1.Text;
                    f.Show();
                    dr.Close();

                }
                else
                {
                    dr.Close();
                    MessageBox.Show("böyle bir hesap bulunamadı");
                }
            }
            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != String.Empty || textBox3.Text != String.Empty)
            {


                cnn.Open();
                cmd = new SqlCommand("select * from kurumsalMusteri join musteri on musteri.ID=kurumsalMusteri.ID where kurumsalMusteri.ID='" + textBox4.Text.ToString() + "'and musteri.Şifre ='" + textBox3.Text.ToString() + "'", cnn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Kurumsal");
                    bireyselhesapanaekran f = new bireyselhesapanaekran();
                    f.ID = textBox1.Text;
                    f.Show();
                    dr.Close();

                }
                else
                {
                    dr.Close();
                    MessageBox.Show("böyle bir hesap bulunamadı");
                }
            }
            cnn.Close();
        }
    }
    
}
