using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace perpus
{
    public partial class form_user : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public form_user()
        {
            InitializeComponent();
            load_id();
            load_data();
        }

        public void load_data()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from [user]", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblUser.DataSource = dt;
            koneksi.Close();
        }

        public static string hashstring(string s)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
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
            txtUsername.Text = "";
            txtPassword.Text = "";
            cmbLevel.Text = "";
        }

        private void form_user_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "" || cmbLevel.Text == "")
            {
                MessageBox.Show("isi username dan password");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [user] values (@id,'" + txtUsername.Text + "',@hash,'" + cmbLevel.Text + "')";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@hash", hashstring(txtPassword.Text)));
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                MessageBox.Show("berhasil input user");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || cmbLevel.Text == "")
            {
                MessageBox.Show("isi username dan password");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update [user] set username='" + txtUsername.Text + "',level='" + cmbLevel.Text + "' where id_user=@id";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                MessageBox.Show("berhasil update user");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("id tidak valid");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from [user] where id_user='"+id+"'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                MessageBox.Show("berhasil hapus user");
            }
        }

        private void tblUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            id = int.Parse(tblUser.Rows[index].Cells[0].Value.ToString());
            txtUsername.Text = tblUser.Rows[index].Cells[1].Value.ToString();
            //txtPassword.Text = tblUser.Rows[index].Cells[2].Value.ToString();
            cmbLevel.Text = tblUser.Rows[index].Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clear_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            petugas p = new petugas();
            p.Show();
        }
    }
}
