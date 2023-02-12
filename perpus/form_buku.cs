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
    public partial class form_buku : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public form_buku()
        {
            InitializeComponent();
            load_data();
            load_idBuku();
            load_kategori();
            load_lokasi();
            clear_data();
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

        public void load_lokasi()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from lokasi", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbLok.DataSource = dt;
            cmbLok.ValueMember = dt.Columns["kode_lokasi"].ToString();
            cmbLok.DisplayMember = dt.Columns["label"].ToString();
            koneksi.Close();
        }

        public void load_kategori()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from kategori", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbKat.DataSource = dt;
            cmbKat.ValueMember = dt.Columns["id_kat"].ToString();
            cmbKat.DisplayMember = dt.Columns["nama_kat"].ToString();
            koneksi.Close();
        }

        public void clear_data()
        {
            txtDeskripsi.Text = "";
            txtHarga.Text = "";
            txtJudul.Text = "";
            txtPenerbit.Text = "";
            txtPenulis.Text = "";
            txtStok.Text = "";
            cmbKat.SelectedText = null;
            cmbLok.SelectedText = null;
        }
        int idint;
        string idstring = "B";
        string id;
        public void load_idBuku()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select kode_buku as kode_buku from buku order by kode_buku desc", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            idint = dt.Rows.Count + 1;
            id = string.Concat(idstring, idint);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (id == dt.Rows[i]["kode_buku"].ToString())
                    {
                        idint++;
                        id = string.Concat(idstring, idint);
                    }
                }
            }
            koneksi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtJudul.Text == "" || txtHarga.Text == "" || txtDeskripsi.Text
                == "" || txtStok.Text == "" || txtPenulis.Text == "" || txtPenerbit.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into buku values(@id,'" + cmbLok.SelectedValue + "','" + cmbKat.SelectedValue + "', '" + txtJudul.Text + "', '" + txtPenulis.Text + "', '"+txtPenerbit.Text+"', '"+txtDeskripsi.Text+"', '"+int.Parse(txtHarga.Text)+"', '"+int.Parse(txtStok.Text)+"')";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_idBuku();
                MessageBox.Show("berhasil input buku");
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
                SqlDataAdapter sda = new SqlDataAdapter("select * from buku where kode_buku = '" + textBox1.Text + "' or judul = '" + textBox1.Text + "'", koneksi);
                sda.Fill(dta);
                tblBuku.DataSource = dta;
                koneksi.Close();
                textBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtJudul.Text == "" || txtHarga.Text == "" || txtDeskripsi.Text
                == "" || txtStok.Text == "" || txtPenulis.Text == "" || txtPenerbit.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update buku set kode_lokasi='" + cmbLok.SelectedValue + "',id_kat='" + cmbKat.SelectedValue + "', judul='" + txtJudul.Text + "',penulis= '" + txtPenulis.Text + "', penerbit='"+txtPenerbit.Text+"', deskripsi='"+txtDeskripsi.Text+"', harga='"+int.Parse(txtHarga.Text)+"',stok= '"+int.Parse(txtStok.Text)+"' where kode_buku = '"+id+"'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_idBuku();
                MessageBox.Show("berhasil update buku");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtJudul.Text == "")
            {
                MessageBox.Show("id tidak valid");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from buku where kode_buku = '" + id + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_idBuku();
                MessageBox.Show("berhasil hapus buku");
            }
        }

        private void tblBuku_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            id = tblBuku.Rows[index].Cells[0].Value.ToString();
            cmbLok.SelectedValue = tblBuku.Rows[index].Cells[1].Value.ToString();
            cmbKat.SelectedValue = tblBuku.Rows[index].Cells[2].Value.ToString();
            txtJudul.Text = tblBuku.Rows[index].Cells[3].Value.ToString();
            txtPenulis.Text = tblBuku.Rows[index].Cells[4].Value.ToString();
            txtPenerbit.Text = tblBuku.Rows[index].Cells[5].Value.ToString();
            txtDeskripsi.Text = tblBuku.Rows[index].Cells[6].Value.ToString();
            txtHarga.Text = tblBuku.Rows[index].Cells[7].Value.ToString();
            txtStok.Text =tblBuku.Rows[index].Cells[8].Value.ToString();
        }

        private void form_buku_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            clear_data();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            petugas p = new petugas();
            p.Show();
        }
    }
}
