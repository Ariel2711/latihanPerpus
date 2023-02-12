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
using static System.Net.Mime.MediaTypeNames;

namespace perpus
{
    public partial class kategori : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public kategori()
        {
            InitializeComponent();
            load_data();
            load_id();
        }

        public void load_data()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from kategori", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblKat.DataSource=dt;
            koneksi.Close();
        }

        public void clear_data()
        {
            textBox1.Text = "";
        }

        int id;

        public void load_id()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select max(id_kat) as id_kat from kategori", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                id = int.Parse(dr["id_kat"].ToString()) + 1;
            }
            koneksi.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kategori_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into kategori values(@id, '" + textBox1.Text + "')";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                MessageBox.Show("berhasil input kategori");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from kategori where id_kat = '" + id + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                MessageBox.Show("berhasil hapus kategori");
            }
        }

        private void tblKat_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            var idstring = tblKat.Rows[index].Cells[0].Value.ToString();
            id = int.Parse(idstring);
            textBox1.Text = tblKat.Rows[index].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update [kategori] set  " +
                "nama_kat = '" + this.textBox1.Text + "' where id_kat = '" + id + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                MessageBox.Show("berhasil update kategori");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            petugas p = new petugas();
            p.Show();
        }
    }
}
