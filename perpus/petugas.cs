using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace perpus
{
    public partial class petugas : Form
    {
        public petugas()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_user fu = new form_user();
            fu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            kategori k = new kategori();
            k.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            lokasi lok = new lokasi();
            lok.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_petugas fp = new form_petugas();
            fp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_anggota fa = new form_anggota();
            fa.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_buku fb = new form_buku();
            fb.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            peminjaman pj = new peminjaman();
            pj.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_pengembalian fpb = new form_pengembalian();
            fpb.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            chart c = new chart();
            c.Show();
        }
    }
}
