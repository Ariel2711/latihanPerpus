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
    public partial class histori_peminjaman : Form
    {

        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public histori_peminjaman()
        {
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter
                ("select pb.id_pinjam, b.judul, k.nama_kat, a.nama_lengkap, pb.tgl_pinjam, pb.tgl_kembali from peminjaman_buku pb inner join peminjaman pj on pb.id_pinjam = pj.id_pinjam inner join buku b on b.kode_buku = pb.kode_buku inner join anggota a on a.id_anggota = pj.id_anggota inner join kategori k on k.id_kat = b.id_kat", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblHistoripinjam.DataSource = dt;
            koneksi.Close();
        }

        private void histori_peminjaman_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("kosong");
            }
            else
            {
                koneksi.Open();
                SqlDataAdapter sda = new SqlDataAdapter
                    ("select pb.id_pinjam, b.judul, k.nama_kat, a.nama_lengkap, pb.tgl_pinjam, pb.tgl_kembali from peminjaman_buku pb inner join peminjaman pj on pb.id_pinjam = pj.id_pinjam inner join buku b on b.kode_buku = pb.kode_buku inner join anggota a on a.id_anggota = pj.id_anggota inner join kategori k on k.id_kat = b.id_kat where pb.id_pinjam = '"+int.Parse(textBox1.Text) +"'", koneksi);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                tblHistoripinjam.DataSource = dt;
                koneksi.Close();
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
