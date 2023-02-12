using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace perpus
{
    public partial class form_peminjaman : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public form_peminjaman()
        {
            InitializeComponent();
            iduser = login.ID;
            load_buku();
            clear_data();
            load_id();
            load_data();
            load_idpetugas();
            load_idpinjam();
            load_anggota();
            tgl_balik.Value = DateTime.Now;
            tgl_pinjam.Value = DateTime.Now;
        }

        public void load_data()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter
                ("select pb.id as id_pinjam, p.nama_lengkap as nama_petugas, a.nama_lengkap as nama_anggota, b.judul as judul_buku ,pb.tgl_pinjam as tanggal_pinjam, pb.tgl_kembali as tanggal_kembali from peminjaman_buku as pb inner join peminjaman as pj on pb.id_pinjam = pj.id_pinjam inner join petugas p on p.id_petugas = pj.id_petugas inner join anggota a on a.id_anggota = pj.id_anggota inner join buku b on b.kode_buku = pb.kode_buku", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblPinjam.DataSource = dt;
            koneksi.Close();
        }

        public void clear_data()
        {
            txtJudul.Text = "";
            txtKat.Text = "";
            txtPenerbit.Text = "";
            txtPenulis.Text = "";
            cmbBuku.Text = "";
            tgl_balik.Value = DateTime.Today;
            tgl_pinjam.Value = DateTime.Today;
        }

        public void load_buku()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from buku", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbBuku.DataSource = dt;
            cmbBuku.ValueMember = dt.Columns["kode_buku"].ToString();
            cmbBuku.DisplayMember = dt.Columns["judul"].ToString();
            koneksi.Close();
        }

        public void load_anggota()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from anggota", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbanggota.DataSource = dt;
            cmbanggota.ValueMember = dt.Columns["id_anggota"].ToString();
            cmbanggota.DisplayMember = dt.Columns["nama_lengkap"].ToString();
            koneksi.Close();
        }

        int id;

        public void load_id()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select max(id) as idpinjambuku from peminjaman_buku", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);         
                foreach (DataRow dr in dt.Rows)
                {
                if (dr["idpinjambuku"].ToString() == null) {
                    id = 0;
                } 
                else
                {
                    id = int.Parse(dr["idpinjambuku"].ToString()) + 1;
                }
                }        
            koneksi.Close();
        }

        int idpinjam;

        public void load_idpinjam()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select max(id_pinjam) as id_pinjam from peminjaman", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                idpinjam = int.Parse(dr["id_pinjam"].ToString()) + 1;
            }
            koneksi.Close();
        }

        string idanggota;

        

        int iduser;
        string idPetugas;

        public void load_idpetugas()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select id_petugas as id from petugas where id_user = '"+ iduser + "'", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                idPetugas = dr["id"].ToString();
            }                                 
            koneksi.Close();
        }

        private void form_peminjaman_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtJudul.Text == "" || cmbanggota.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DateTime datebalik = DateTime.ParseExact(DateTime.Parse(tgl_balik.Text).ToString("MM/dd/yyyy"), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime datepinjam = DateTime.ParseExact(DateTime.Parse(tgl_pinjam.Text).ToString("MM/dd/yyyy"), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                cmd.CommandText = 
                    "update peminjaman_buku set kode_buku = '" + cmbBuku.SelectedValue + "',tgl_pinjam='" + datepinjam + "',tgl_kembali='" + datebalik + "', tgl_kembali_rill='"+datebalik+"' where id = '"+id+"'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                MessageBox.Show("berhasil update peminjaman buku");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtJudul.Text == "" || cmbanggota.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                load_id();
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DateTime datebalik = DateTime.ParseExact(DateTime.Parse(tgl_balik.Text).ToString("MM/dd/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime datepinjam = DateTime.ParseExact(DateTime.Parse(tgl_pinjam.Text).ToString("MM/dd/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cmd.CommandText = "insert into peminjaman values('"+idpinjam+"','"+idPetugas+"','"+cmbanggota.SelectedValue+"')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into peminjaman_buku (id,kode_buku,id_pinjam,tgl_pinjam,tgl_kembali,tgl_kembali_rill,denda,jml_hari_denda) values(@id, '" + cmbBuku.SelectedValue + "', @idpinjam,'" +  datepinjam+ "','" + datebalik + "','" + datebalik + "','" + 0 + "', '" + 0 + "')";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@idpinjam", idpinjam));
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                load_idpinjam();
                MessageBox.Show("berhasil input peminjaman buku");
            }
        }

        private void cmbBuku_SelectedIndexChanged(object sender, EventArgs e)
        {
            //koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select b.judul as judul,b.penerbit as penerbit, b.penulis as penulis, k.nama_kat as kategori from buku b inner join kategori k on k.id_kat = b.id_kat where kode_buku ='"+cmbBuku.SelectedValue+"'", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);           
            foreach(DataRow dr in dt.Rows)
            {
                txtJudul.Text = dr["judul"].ToString();
                txtPenerbit.Text = dr["penerbit"].ToString();
                txtPenulis.Text = dr["penulis"].ToString();
                txtKat.Text = dr["kategori"].ToString();
            }
            koneksi.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbanggota.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "delete from peminjaman_buku where id = '"+id+"'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                MessageBox.Show("berhasil delete peminjaman buku");
            }
        }

        private void tblPinjam_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            var idstring = tblPinjam.Rows[index].Cells[0].Value.ToString();
            id = int.Parse(idstring);
            cmbanggota.Text = tblPinjam.Rows[index].Cells[2].Value.ToString();
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select kode_buku from buku where judul = '" + tblPinjam.Rows[index].Cells[3].Value.ToString() + "'", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cmbBuku.SelectedValue = dr["kode_buku"].ToString();
            }
            koneksi.Close();
            tgl_pinjam.Text = DateTime.Parse(tblPinjam.Rows[index].Cells[4].Value.ToString()).ToString();
            tgl_balik.Text = DateTime.Parse(tblPinjam.Rows[index].Cells[5].Value.ToString()).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clear_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            peminjaman p = new peminjaman();
            p.Show();
        }
    }
}
