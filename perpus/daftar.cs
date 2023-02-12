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
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;

namespace perpus
{
    public partial class daftar : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public daftar()
        {
            InitializeComponent();
            load_id();
        }

        public static string hashstring(string s) {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
            var sb = new StringBuilder();
            for (int i=0;i<bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        int id;

        public void load_id()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select max(id_user) as id_user from [user]", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id = int.Parse(dr["id_user"].ToString()) + 1;
            }
            koneksi.Close();
        }

        public void clear_data()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            cmbLevel.Text = "";
        }

        private void daftar_Load(object sender, EventArgs e)
        {

        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="" || textBox2.Text == "" || cmbLevel.Text == "")
            {
                MessageBox.Show("isi username dan password");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [user] values (@id,'"+ textBox1.Text+"',@hash,'"+cmbLevel.Text+"')";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@hash", hashstring(textBox2.Text)));
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_id();
                MessageBox.Show("berhasil input user");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
