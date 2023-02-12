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
    public partial class peminjaman : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public peminjaman()
        {
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter
                ("select pj.id_pinjam as id_pinjam, p.nama_lengkap as nama_petugas, a.nama_lengkap as nama_anggota, pb.tgl_pinjam as tanggal_pinjam from peminjaman_buku as pb inner join peminjaman as pj on pb.id_pinjam = pj.id_pinjam inner join petugas p on p.id_petugas = pj.id_petugas inner join anggota a on a.id_anggota = pj.id_anggota", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblPinjam.DataSource = dt;
            koneksi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_peminjaman fp = new form_peminjaman();
            fp.Show();
        }

        private void peminjaman_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            detail_peminjaman dp = new detail_peminjaman();
            dp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            petugas p = new petugas();
            p.Show();
        }
    }
}
