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

namespace perpus
{
    public partial class form_petugas : Form
    {

        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public form_petugas()
        {
            InitializeComponent();
            load_data();
            load_idPetugas();
            load_idUser();
            iduser = login.ID;
        }
        

        public void load_idUser() { }

        public void load_data()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from petugas", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblPetugas.DataSource = dt;
            koneksi.Close();
        }

        public void clear_data()
        {
            txtNama.Text = "";
            txtAlamat.Text = "";
            txtNik.Text = "";
        }
        int iduser;
        int idint;
        string idstring = "P";
        string id;
        public void load_idPetugas()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select id_petugas as id_petugas from petugas order by id_petugas desc", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            idint = dt.Rows.Count + 1;
            id = string.Concat(idstring, idint);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (id == dt.Rows[i]["id_petugas"].ToString())
                    {
                        idint++;
                        id = string.Concat(idstring, idint);
                    }
                }
            }
            koneksi.Close();
        }
        private void form_petugas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtNik.Text == "" || txtAlamat.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into petugas values(@id,'" + txtNama.Text + "','" + txtNik.Text + "', '" + txtAlamat.Text + "', '"+iduser+"')";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_idPetugas();
                MessageBox.Show("berhasil input petugas");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("input keyword");
            }
            else
            {
                koneksi.Open();
                DataTable dta = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("select * from petugas where id_petugas = '" + textBox1.Text + "' OR nama_lengkap = '" + textBox1.Text + "'", koneksi);
                sda.Fill(dta);
                tblPetugas.DataSource = dta;
                koneksi.Close();
                textBox1.Text = "";
            }
        }

        private void tblPetugas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            id = tblPetugas.Rows[index].Cells[0].Value.ToString();
            txtNama.Text = tblPetugas.Rows[index].Cells[1].Value.ToString();
            txtNik.Text = tblPetugas.Rows[index].Cells[2].Value.ToString();
            txtAlamat.Text = tblPetugas.Rows[index].Cells[3].Value.ToString();
            iduser = int.Parse(tblPetugas.Rows[index].Cells[4].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtNik.Text == "" || txtAlamat.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update [petugas] set nama_lengkap='" + this.txtNama.Text + "', nik='" + txtNik.Text + "',alamat='" + this.txtAlamat.Text + "', id_user = '"+iduser+"'  where id_petugas = '" + id + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_idPetugas();
                MessageBox.Show("berhasil update petugas");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "")
            {
                MessageBox.Show("id tidak valid");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from petugas where id_petugas = '" + id + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_idPetugas();
                MessageBox.Show("berhasil hapus petugas");
            }
        }

        private void button6_Click(object sender, EventArgs e)
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
