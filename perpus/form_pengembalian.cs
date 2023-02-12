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
    public partial class form_pengembalian : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public form_pengembalian()
        {
            InitializeComponent();
            clear_data();
            load_data();
        }

        public void load_data()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter
                ("select pb.id as id_pinjam, p.nama_lengkap as nama_petugas, a.nama_lengkap as nama_anggota, b.judul as judul_buku ,pb.tgl_pinjam as tanggal_pinjam, pb.tgl_kembali as tanggal_kembali, pb.tgl_kembali_rill as tgl_kembali_rill ,pb.denda as denda from peminjaman_buku as pb inner join peminjaman as pj on pb.id_pinjam = pj.id_pinjam inner join petugas p on p.id_petugas = pj.id_petugas inner join anggota a on a.id_anggota = pj.id_anggota inner join buku b on b.kode_buku = pb.kode_buku", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblPengembalian.DataSource = dt;
            koneksi.Close();
        }

        DateTime kembali;
        DateTime kembali_rill;
        int denda;
        int dendatotal;
        int id;

        public void clear_data()
        {
            txtJudul.Text = "";
            txtID.Text = "";
            txtDenda.Text = "";
            tgl_balik.Value = DateTime.Now;
        }

        public void getDenda() {
            if(tgl_balik.Value == kembali_rill)
            {
                denda = int.Parse(kembali_rill.Subtract(kembali).TotalDays.ToString());
            }
            else
            {
                denda = int.Parse(tgl_balik.Value.Subtract(kembali).TotalDays.ToString());
            }
            dendatotal = denda * 2250;
            txtDenda.Text = dendatotal.ToString();
        }

        private void form_pengembalian_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter
                ("select pb.id as id_pinjam, p.nama_lengkap as nama_petugas, a.nama_lengkap as nama_anggota, b.judul as judul_buku ,pb.tgl_pinjam as tanggal_pinjam, pb.tgl_kembali as tanggal_kembali, pb.tgl_kembali_rill as tgl_kembali_rill, pb.denda as denda from peminjaman_buku as pb inner join peminjaman as pj on pb.id_pinjam = pj.id_pinjam inner join petugas p on p.id_petugas = pj.id_petugas inner join anggota a on a.id_anggota = pj.id_anggota inner join buku b on b.kode_buku = pb.kode_buku where pb.id = '"+int.Parse(txtCari.Text) +"'", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblPengembalian.DataSource = dt;
            koneksi.Close();
        }

        private void tblPengembalian_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            var idstring = tblPengembalian.Rows[index].Cells["id_pinjam"].Value.ToString();
            id = int.Parse(idstring);
            txtJudul.Text = tblPengembalian.Rows[index].Cells[3].Value.ToString();
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select kode_buku from buku where judul = '" + tblPengembalian.Rows[index].Cells[3].Value.ToString() + "'", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtID.Text = dr["kode_buku"].ToString();
            }
            koneksi.Close();
            tgl_balik.Text = DateTime.Parse(tblPengembalian.Rows[index].Cells["tgl_kembali_rill"].Value.ToString()).ToString("M/dd/yyyy");
            kembali_rill = DateTime.Parse(DateTime.Parse(tblPengembalian.Rows[index].Cells["tgl_kembali_rill"].Value.ToString()).ToString("M/dd/yyyy"));
            kembali = DateTime.Parse(DateTime.Parse(tblPengembalian.Rows[index].Cells["tanggal_kembali"].Value.ToString()).ToString("M/dd/yyyy"));
            txtDenda.Text = tblPengembalian.Rows[index].Cells["denda"].Value.ToString();
            getDenda();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime theDate = tgl_balik.Value;
            koneksi.Open();
            getDenda();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [peminjaman_buku] set tgl_kembali_rill='" + theDate + "', denda=@denda where id= @id";
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("denda", dendatotal));
            cmd.ExecuteNonQuery();
            koneksi.Close();
            clear_data();
            load_data();
        }

        private void tgl_balik_RegionChanged(object sender, EventArgs e)
        {

        }

        private void tgl_balik_ValueChanged(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {

            }
            else
            {
                getDenda();
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
