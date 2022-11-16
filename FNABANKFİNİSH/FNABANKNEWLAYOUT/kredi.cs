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

namespace FNABANKNEWLAYOUT
{
    public partial class kredi : Form
    {
        public kredi()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-DTFDPI9; Initial Catalog=FNABANK1; Integrated Security=SSPI");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        private void kredi_Load(object sender, EventArgs e)
        {
            cnn.Open();
            da = new SqlDataAdapter("SELECT * FROM kredi",cnn);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
