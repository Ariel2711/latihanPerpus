using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace perpus
{
    public partial class cari_buku : Form
    {

        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public cari_buku()
        {
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from buku", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblBuku.DataSource = dt;
            koneksi.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("input keyword");
            }
            else
            {
                koneksi.Open();
                //SqlCommand cmd = koneksi.CreateCommand();
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "select * from buku where kode_buku = '" + textBox1.Text + "' or judul = '" + textBox1.Text + "' or penulis = '" + textBox1.Text + "' or deskripsi = '" + textBox1.Text + "' or harga = '" + int.Parse(textBox1.Text) + "' or stok = '" + int.Parse(textBox1.Text) + "'";
                DataTable dta = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("select * from buku where kode_buku = '" + textBox1.Text + "' or judul = '"+textBox1.Text+"'", koneksi);
                sda.Fill(dta);
                tblBuku.DataSource = dta;
                koneksi.Close();
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            anggota a = new anggota();
            a.Show();
        }
    }
}
