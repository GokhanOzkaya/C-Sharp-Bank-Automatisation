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

namespace FNAFİNANSBANK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-DTFDPI9; Initial Catalog=FNABANK; Integrated Security=SSPI");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public void griddoldur()
        {
            try
            {
                cnn.Open();
                da = new SqlDataAdapter("select * from Bireysel", cnn);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Veri Tabanı Bağlantısı Gerçekleştiremedi");
                throw;
            }


        }
        private void Form1_Load(object sender, EventArgs e)
        {
                if (radioButton1.Checked)
                    {
                        label14.Visible =false;
                        label10.Visible = false;
                        textBox11.Visible = false;  
                        textBox9.Visible = false;   
                    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string kayit = "INSERT INTO Musteri(musteriID,musteriAdı,musteriSoyadı,musteriMail,musteriTel) VALUES (@musteriID,@musteriAdı,@musteriSoyadı,@musteriMail,@musteriTel) "; 
            SqlCommand cmd = new SqlCommand(kayit, cnn);
            cmd.Parameters.AddWithValue("@musteriID", textBox6.Text.ToString());
            cmd.Parameters.AddWithValue("@musteriAdı", textBox1.Text);
            cmd.Parameters.AddWithValue("@musteriSoyadı", textBox2.Text);    
            cmd.Parameters.AddWithValue("@musteriMail", textBox5.Text);
            cmd.Parameters.AddWithValue("@musteriTel", textBox3.Text);

            string bireyselkayit = "INSERT INTO Bireysel(bireyselDogumTar,bireyselTCKimlikNo,musteriID) VALUES (@bireyselDogumTar,@bireyselTCKimlikNo,@musteriID) ";
            SqlCommand cld = new SqlCommand(bireyselkayit, cnn);
            cld.Parameters.AddWithValue("@musteriID", textBox6.Text.ToString());
            cld.Parameters.AddWithValue("@bireyselDogumTar", dateTimePicker1.Value);
            cld.Parameters.AddWithValue("@bireyselTCKimlikNo", textBox4.Text);
            cld.ExecuteNonQuery();
            cnn.Close();
            griddoldur();
        
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label14.Visible = true;
                label10.Visible = true;
                textBox11.Visible = true;
                textBox9.Visible = true;
                textBox4.Visible = false;
                dateTimePicker1.Visible = false; 
                label3.Visible = false; 
                label6.Visible = false; 
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                label14.Visible = false;
                label10.Visible = false;
                textBox11.Visible = false;
                textBox9.Visible = false;
                textBox4.Visible = true;
                dateTimePicker1.Visible = true;
                label3.Visible = true;
                label6.Visible = true;
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string sorgu = "DELETE FROM Musteri WHERE musteriID=@musteriID";
            cmd = new SqlCommand(sorgu, cnn);
            cmd.Parameters.AddWithValue("@musteriID", Convert.ToInt32(textBox6.Text));
            cmd.ExecuteNonQuery();
            cnn.Close();
            griddoldur();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
