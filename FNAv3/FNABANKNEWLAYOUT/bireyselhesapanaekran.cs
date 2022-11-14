using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNABANKNEWLAYOUT
{
    public partial class bireyselhesapanaekran : Form
    {
        public bireyselhesapanaekran()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-DTFDPI9; Initial Catalog=FNABANK1; Integrated Security=SSPI");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        public string ID { get; set; }
        

        private void bireyselhesapanaekran_Load(object sender, EventArgs e)
        {

        
            cnn.Open();
            da = new SqlDataAdapter("SELECT hesapID, hesapAdı, hesapTürü,hesapBakiye FROM musteri JOIN hesap ON musteri.ID = hesap.ID;", cnn);

            dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            
            cnn.Close();

            comboBox3.Items.Add("Borsa Hesabı");
            comboBox3.Items.Add("Sanal Hesap"); 
            comboBox3.Items.Add("PREMİIM HESAP");

           
            label23.Text = ID;
         
            string sorgu = "SELECT Ad FROM musteri WHERE ID = '"+ID+ "'";
            string deger;
            SqlCommand komut = new SqlCommand(sorgu, cnn);
            cnn.Open();
            deger = (string)komut.ExecuteScalar();
            cnn.Close();
            label1.Text = deger;

            string soyad = "SELECT Soyad FROM musteri WHERE ID = '" + ID + "'";
            string degdi;
            SqlCommand komutt = new SqlCommand(soyad, cnn);
            cnn.Open();
            degdi = (string)komutt.ExecuteScalar();
            cnn.Close();
            label24.Text = degdi;

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string hesapekle = "INSERT INTO hesap(hesapID,hesapAdı,hesapBakiye,hesapTürü,ID) VALUES (@hesapID,@hesapAdı,@hesapBakiye,@hesapTürü,@ID)";
            cmd = new SqlCommand(hesapekle, cnn);
            cmd.Parameters.AddWithValue("@hesapID", textBox3.Text);
            cmd.Parameters.AddWithValue("@hesapAdı", textBox4.Text);
            cmd.Parameters.AddWithValue("@hesapTürü", comboBox3.Text);
            cmd.Parameters.AddWithValue("@hesapBakiye", "");
            cmd.Parameters.AddWithValue("@ID", label23.Text);
            
            cmd.ExecuteNonQuery();
            cnn.Close();
            cnn.Open();
            da = new SqlDataAdapter("SELECT hesapID,hesapAdı,hesapBakiye,hesapTürü FROM hesap JOIN musteri ON musteri.ID = hesap.ID;", cnn);

            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cnn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnn.Open();
            da = new SqlDataAdapter("SELECT hesapAdı,hesapBakiye,hesapID,hesapTürü FROM musteri JOIN hesap ON musteri.ID = hesap.ID;", cnn);

            dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            cnn.Close();
           
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            label17.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();      
            label6.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            parayatır py = new parayatır();
            py.bakiye = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value);
            py.hesapID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value);
            py.Show();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            paracek py = new paracek();
            py.bakiye = Convert.ToInt32(label6.Text);
            py.hesapID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value);
            py.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int transferMiktari = Convert.ToInt32(textBox9.Text);
            int hedefHesapId = Convert.ToInt32( textBox2.Text);

            if (transferMiktari>Convert.ToInt32( label15.Text))
            {
                MessageBox.Show("Transfer için Yeterli Limitiniz Yokdur");
                textBox9.Clear();
                return;
            }
            string soyad = "SELECT hesapBakiye FROM hesap WHERE hesapID = '" + hedefHesapId + "'";
            int bakiye;
            SqlCommand komutt = new SqlCommand(soyad, cnn);
            cnn.Open();
            bakiye = Convert.ToInt32(komutt.ExecuteScalar());
            cnn.Close();

            
            int yenibakiye = bakiye + transferMiktari;
           

            cnn.Open();
            string update = "Update hesap set hesapBakiye='" + yenibakiye + "' where hesapID ='" + hedefHesapId + "'";
            cmd = new SqlCommand(update, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            
            MessageBox.Show(+hedefHesapId+" Nin yeni bakiyesi " + yenibakiye + " dir");



            string dus = "SELECT hesapBakiye FROM hesap WHERE hesapID = '" + Convert.ToInt32( label13.Text )+ "'";
            int acıkbakıye;
            SqlCommand cnd = new SqlCommand(dus, cnn);
            cnn.Open();
            acıkbakıye = Convert.ToInt32(cnd.ExecuteScalar());
            cnn.Close();

            int cıkarılacak = Convert.ToInt32(textBox9.Text);
            int acıkyenibakiye = acıkbakıye - cıkarılacak;
            

            cnn.Open();
            string updatee = "Update hesap set hesapBakiye='" + acıkyenibakiye + "' where hesapID ='" + Convert.ToInt32(label13.Text) + "'";
            cnd = new SqlCommand(updatee, cnn);
            cnd.ExecuteNonQuery();
            cnn.Close();

            MessageBox.Show("Yeni Baktiyeniz " + acıkyenibakiye + " dir");

            dataGridView3.Refresh();
        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            label15.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            label13.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();  
        }

        private void dataGridView4_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }
       
       
           
        
        private void button13_Click(object sender, EventArgs e)
        {
           
        }
    }
}
