using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNABANKNEWLAYOUT
{
    public partial class MusteriKayıt : Form
    {
        public MusteriKayıt()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-DTFDPI9; Initial Catalog=FNABANK1; Integrated Security=SSPI");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

       
        

        private void MusteriKayıt_Load(object sender, EventArgs e)
        {
            textBox10.Visible = false;
            textBox11.Visible = false;
            label2.Visible = false;
            label14.Visible = false;
            dateTimePicker1.Visible = true;
            textBox9.Visible = true;
            label12.Visible = true;
            label13.Visible = true;



        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            //if (radioButton2.Checked)
            //{
            //    cnn.Open();
            //    string sorgu = "INSERT INTO tablo1(ID,Ad,Soyad,TCKimlikno,Telefon,Mail,Şifre) VALUES (@ID,@Ad,@Soyad,@TCKimlikno,@Telefon,@Mail,@Şifre)";
            //    cmd = new SqlCommand(sorgu, cnn);

            //    cmd.Parameters.AddWithValue("@ID", textBox1.Text);
            //    cmd.Parameters.AddWithValue("@Ad", textBox2.Text);
            //    cmd.Parameters.AddWithValue("@TCKimlikNo", textBox3.Text);
            //    cmd.Parameters.AddWithValue("@Telefon", textBox4.Text);
            //    cmd.Parameters.AddWithValue("@Mail", textBox4.Text);
            //    cmd.Parameters.AddWithValue("@Şifre", textBox4.Text);
            //    cmd.ExecuteNonQuery();

            //    string bireysel = "INSERT INTO tablo3(firmano,firmisim,dogumtar,ID) VALUES (@firmano,@firmisim,@ID)";
            //    cmd = new SqlCommand(bireysel, cnn);
            //    cmd.Parameters.AddWithValue("@firmisim", textBox5.Text);
            //    cmd.Parameters.AddWithValue("@firmano", textBox6.Text);

            //    cmd.Parameters.AddWithValue("@ID", textBox1.Text);
            //    cmd.ExecuteNonQuery();


            //    cnn.Close();

            //}
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cnn.Open();
            da = new SqlDataAdapter("SELECT * FROM musteri JOIN bireyselMusteri ON musteri.ID = bireyselMusteri.ID;", cnn);

            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cnn.Close();
            radioButton1.Checked = true;
            radioButton2.Checked = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cnn.Open();
                string sorgu = "INSERT INTO musteri(ID,Ad,Soyad,TCKimlikno,Telefon,Mail,Şifre) VALUES (@ID,@Ad,@Soyad,@TCKimlikno,@Telefon,@Mail,@Şifre)";
                cmd = new SqlCommand(sorgu, cnn);
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Ad", textBox2.Text);
                cmd.Parameters.AddWithValue("@Soyad", textBox3.Text);
                cmd.Parameters.AddWithValue("@TCKimlikNo", textBox4.Text);
                cmd.Parameters.AddWithValue("@Telefon", textBox5.Text);
                cmd.Parameters.AddWithValue("@Mail", textBox6.Text);
                cmd.Parameters.AddWithValue("@Şifre", textBox7.Text);
               
                cmd.ExecuteNonQuery();
                string bireyselMusteri = "INSERT INTO bireyselMusteri(bireyselAdres,bireyselDogumTar,ID) VALUES (@bireyselAdres,@bireyselDogumTar,@ID)";
                cmd = new SqlCommand(bireyselMusteri, cnn);
                cmd.Parameters.AddWithValue("@bireyselAdres", textBox9.Text);
                cmd.Parameters.AddWithValue("@bireyseldogumtar", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.ExecuteNonQuery();


                cnn.Close();

            }
            if (radioButton2.Checked)
            {
                cnn.Open();
                string sorgu = "INSERT INTO musteri(ID,Ad,Soyad,TCKimlikno,Telefon,Mail,Şifre) VALUES (@ID,@Ad,@Soyad,@TCKimlikno,@Telefon,@Mail,@Şifre)";
                cmd = new SqlCommand(sorgu, cnn);

                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Ad", textBox2.Text);
                cmd.Parameters.AddWithValue("@Soyad", textBox3.Text);
                cmd.Parameters.AddWithValue("@TCKimlikNo", textBox4.Text);
                cmd.Parameters.AddWithValue("@Telefon", textBox5.Text);
                cmd.Parameters.AddWithValue("@Mail", textBox6.Text);
                cmd.Parameters.AddWithValue("@Şifre", textBox7.Text);
                cmd.ExecuteNonQuery();
                
                string kurumsalmusteri = "INSERT INTO kurumsalMusteri(kurumsalFirmaAdı,kurumsalFirmaVergiNo,ID) VALUES (@kurumsalFirmaAdı,@kurumsalFirmaVergiNo,@ID)";
                cmd = new SqlCommand(kurumsalmusteri, cnn);
                cmd.Parameters.AddWithValue("@kurumsalFirmaAdı", textBox10.Text);
                cmd.Parameters.AddWithValue("@kurumsalFirmaVergiNo",Convert.ToInt32( textBox11.Text));
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cnn.Open();
            da = new SqlDataAdapter("SELECT * FROM musteri JOIN kurumsalMusteri ON musteri.ID = kurumsalMusteri.ID;", cnn);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cnn.Close();
            radioButton1.Checked = false;
            radioButton2.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cnn.Open();
                string sorgu = "DELETE FROM musteri WHERE ID=@ID";
                cmd = new SqlCommand(sorgu, cnn);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox1.Text));
                cmd.ExecuteNonQuery();
                string bireysel = "DELETE FROM bireyselMusteri WHERE ID=@ID";
                cmd = new SqlCommand(bireysel, cnn);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox1.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show(textBox1.Text + "ID li kullanıcı başarıyla silindi");
                cnn.Close();

            }
            if (radioButton2.Checked)
            {
                cnn.Open();
                string sorgu = "DELETE FROM musteri WHERE ID=@ID";
                cmd = new SqlCommand(sorgu, cnn);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox1.Text));
                cmd.ExecuteNonQuery();
                string bireysel = "DELETE FROM kurumsalMusteri WHERE ID=@ID";
                cmd = new SqlCommand(bireysel, cnn);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox1.Text));
                MessageBox.Show(textBox1.Text + "ID li kullanıcı başarıyla silindi");
                cmd.ExecuteNonQuery();
                cnn.Close();

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox10.Visible = false;
            textBox11.Visible = false;
            label2.Visible = false;
            label14.Visible = false;
            dateTimePicker1.Visible = true;
            textBox9.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox10.Visible = true;
            textBox11.Visible = true;
            label2.Visible = true;
            label14.Visible = true;
            dateTimePicker1.Visible = false;
            textBox9.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cnn.Open();
                string sorgu = "update musteri SET ID=@ID,Ad=@Ad,Soyad=@Soyad,TCKimlikNo=@TCKimlikno,Telefon=@Telefon,Mail=Mail,Şifre=@Şifre where ID=@ID";
                cmd = new SqlCommand(sorgu, cnn);
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Ad", textBox2.Text);
                cmd.Parameters.AddWithValue("@Soyad", textBox3.Text);
                cmd.Parameters.AddWithValue("@TCKimlikNo", textBox4.Text);
                cmd.Parameters.AddWithValue("@Telefon", textBox5.Text);
                cmd.Parameters.AddWithValue("@Mail", textBox6.Text);
                cmd.Parameters.AddWithValue("@Şifre", textBox7.Text);
                cmd.ExecuteNonQuery();

                string bireyselMusteri = "update bireyselMusteri set bireyselAdres=@bireyselAdres,bireyselDogumTar=@bireyselDogumTar,ID=@ID where ID = @ID";
                cmd = new SqlCommand(bireyselMusteri, cnn);
                cmd.Parameters.AddWithValue("@bireyselAdres", textBox9.Text);
                cmd.Parameters.AddWithValue("@bireyseldogumtar", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.ExecuteNonQuery();
                cnn.Close();
                dataGridView1.Refresh();

            }
            if (radioButton2.Checked)
            {
                cnn.Open();
                string sorgu = "INSERT INTO musteri(ID,Ad,Soyad,TCKimlikno,Telefon,Mail,Şifre) VALUES (@ID,@Ad,@Soyad,@TCKimlikno,@Telefon,@Mail,@Şifre)";
                cmd = new SqlCommand(sorgu, cnn);

                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Ad", textBox2.Text);
                cmd.Parameters.AddWithValue("@Soyad", textBox3.Text);
                cmd.Parameters.AddWithValue("@TCKimlikNo", textBox4.Text);
                cmd.Parameters.AddWithValue("@Telefon", textBox5.Text);
                cmd.Parameters.AddWithValue("@Mail", textBox6.Text);
                cmd.Parameters.AddWithValue("@Şifre", textBox7.Text);
                cmd.ExecuteNonQuery();

                string kurumsalmusteri = "INSERT INTO kurumsalMusteri(kurumsalFirmaAdı,kurumsalFirmaVergiNo,ID) VALUES (@kurumsalFirmaAdı,@kurumsalFirmaVergiNo,@ID)";
                cmd = new SqlCommand(kurumsalmusteri, cnn);
                cmd.Parameters.AddWithValue("@kurumsalFirmaAdı", textBox10.Text);
                cmd.Parameters.AddWithValue("@kurumsalFirmaVergiNo", textBox11.Text);
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
