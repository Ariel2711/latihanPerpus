using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace perpus
{
    public partial class form_anggota : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public form_anggota()
        {
            InitializeComponent();
            load_data();
            load_idAnggota();
            load_idUser();
            iduser = login.ID;
        }

        private void form_anggota_Load(object sender, EventArgs e)
        {

        }

        public void load_idUser() { }

        public void load_data()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from anggota", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblAnggota.DataSource = dt;
            koneksi.Close();
        }

        public void clear_data()
        {
            txtNama.Text = "";
            txtAlamat.Text = "";
            txtNik.Text = "";
            pictureBox1.ImageLocation = null;
        }
        string img = "";
        int iduser;
        int idint;
        string idstring = "A";
        string id;
        public void load_idAnggota()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select id_anggota as id_anggota from anggota order by id_anggota desc", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            idint = dt.Rows.Count + 1;
            id = string.Concat(idstring, idint);
                    if (id == dt.Rows[0]["id_anggota"].ToString())
                    {
                        idint++;
                        id = string.Concat(idstring, idint);
                    }
            koneksi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtNik.Text == "" || txtAlamat.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                DateTime now = DateTime.Today;
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into anggota values(@id,'" + txtNama.Text + "','" + txtNik.Text + "', '" + txtAlamat.Text + "', @now, '" + iduser + "',@images)";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@images", img.ToString()));
                cmd.Parameters.Add(new SqlParameter("@now", now));
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_idAnggota();
                MessageBox.Show("berhasil input anggota");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                img = dialog.FileName.ToString();
                pictureBox1.ImageLocation = img;


            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                cmd.CommandText = "update [anggota] set nama_lengkap='"+this.txtNama.Text+"', nik='"+this.txtNik.Text +"', alamat='"+this.txtAlamat.Text+"', foto=@images, id_user='"+iduser+"' where id_anggota=@id";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@images", img));
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_idAnggota();
                MessageBox.Show("berhasil update anggota");
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                cmd.CommandText = "delete from anggota where id_anggota = '" + id + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_idAnggota();
                MessageBox.Show("berhasil hapus anggota");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("input keyword");
            }
            else
            {
                koneksi.Open();
                DataTable dta = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("select * from anggota where id_anggota = '" + textBox1.Text + "' OR nama_lengkap = '" + textBox1.Text + "'", koneksi);
                sda.Fill(dta);
                tblAnggota.DataSource = dta;
                koneksi.Close();
                textBox1.Text = "";
            }
        }

        private void tblAnggota_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void tblAnggota_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            id = tblAnggota.Rows[index].Cells[0].Value.ToString();
            txtNama.Text = tblAnggota.Rows[index].Cells[1].Value.ToString();
            txtNik.Text = tblAnggota.Rows[index].Cells[2].Value.ToString();
            txtAlamat.Text = tblAnggota.Rows[index].Cells[3].Value.ToString();
            iduser = int.Parse(tblAnggota.Rows[index].Cells[5].Value.ToString());
            pictureBox1.ImageLocation = tblAnggota.Rows[index].Cells[6].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            petugas p = new petugas();
            p.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear_data();
        }
    }
}
