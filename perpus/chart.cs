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
    public partial class chart : Form
    {

        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public chart()
        {
            InitializeComponent();
            load_data();
            load_peminjaman();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            petugas P = new petugas();
            P.Show();
        }

        private void chart_Load(object sender, EventArgs e)
        {

        }

        public void load_peminjaman()
        {
           string query= "select tgl_pinjam, count(kode_buku) as buku from peminjaman_buku group by tgl_pinjam";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            //cmd.CommandType = CommandType.Text;
            //cmd.Parameters.AddWithValue("@start", dateStart.Value);
            //cmd.Parameters.AddWithValue("@end", dateEnd.Value);
            //cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            chartBuku.Series["Tanggal"].Points.Clear();
            chartBuku.DataSource = dt;
            chartBuku.Series["Tanggal"].XValueMember = "tgl_pinjam";
            chartBuku.Series["Tanggal"].YValueMembers = "buku";
            chartBuku.Invalidate();
            koneksi.Close();
        }

        public void load_data()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count(*) as petugas from petugas";
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr = dt.Rows[0];
            chartUser.Series["Petugas"].Points.AddXY("Petugas", dr["petugas"]);
            SqlCommand cmd2 = koneksi.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select count(*) as anggota from anggota";
            cmd2.ExecuteNonQuery();
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            DataRow dr2 = dt2.Rows[0];
            chartUser.Series["Anggota"].Points.AddXY("Anggota", dr2["anggota"]);
            SqlCommand cmd3 = koneksi.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select count(*) as buku from buku";
            cmd3.ExecuteNonQuery();
            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            DataRow dr3 = dt3.Rows[0];
            chartUser.Series["Buku"].Points.AddXY("Buku", dr3["buku"]);
            SqlCommand cmd4 = koneksi.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "select count(*) as peminjaman from peminjaman_buku";
            cmd4.ExecuteNonQuery();
            SqlDataAdapter sda4 = new SqlDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            DataRow dr4 = dt4.Rows[0];
            chartUser.Series["Peminjaman"].Points.AddXY("Peminjaman", dr4["peminjaman"]);
            koneksi.Close();

        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filter_data(dateStart.Value, dateEnd.Value);
        }

        public void filter_data(DateTime start, DateTime end)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select tgl_pinjam, count(kode_buku) as buku from peminjaman_buku WHERE tgl_pinjam BETWEEN @start AND @end GROUP by tgl_pinjam";
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            //cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            chartBuku.Series["Tanggal"].Points.Clear();
            chartBuku.DataSource = dt;
            chartBuku.Series["Tanggal"].XValueMember = "tgl_pinjam";
            chartBuku.Series["Tanggal"].YValueMembers = "buku";
            chartBuku.Invalidate();
            koneksi.Close();
        }
    }
}
