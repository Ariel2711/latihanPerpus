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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace perpus
{
    public partial class lokasi : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public lokasi()
        {
            InitializeComponent();
            load_data();
            load_id();
        }

        public void load_data()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from lokasi", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblLok.DataSource = dt;
            koneksi.Close();
        }

        public void clear_data()
        {
            txtLabel.Text = "";
            txtLantai.Text = "";
            txtRak.Text = "";
        }

        int idint;
        string idstring = "LK";
        string id;
        public void load_id()
        {
            koneksi.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select kode_lokasi as kode from lokasi order by kode_lokasi desc", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            idint = dt.Rows.Count + 1;
            id = string.Concat(idstring, idint);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if(i == 0)
                {
                    if(id == dt.Rows[i]["kode"].ToString())
                    {
                        idint++;
                        id = string.Concat(idstring, idint);
                    }
                }
            }
            koneksi.Close();
        }

        private void lokasi_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtLantai.Text == "" || txtLabel.Text == ""|| txtRak.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into lokasi values(@id,'"+txtLabel.Text+"','"+int.Parse(txtLantai.Text)+"', '"+txtRak.Text+"')";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                MessageBox.Show("berhasil input lokasi");
            }
        }

        private void tblLok_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            id = tblLok.Rows[index].Cells[0].Value.ToString();
            txtLabel.Text = tblLok.Rows[index].Cells[1].Value.ToString();
            txtLantai.Text = tblLok.Rows[index].Cells[2].Value.ToString();
            txtRak.Text = tblLok.Rows[index].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtLantai.Text == "" || txtLabel.Text == "" || txtRak.Text == "")
            {
                MessageBox.Show("Data belum terisi");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update [lokasi] set label='" + this.txtLabel.Text + "', lantai='" + int.Parse(this.txtLantai.Text) + "',rak='" + this.txtRak.Text + "'  where kode_lokasi = '" + id + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                MessageBox.Show("berhasil update lokasi");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtLabel.Text == "")
            {
                MessageBox.Show("id tidak valid");
            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from lokasi where kode_lokasi = '" + id + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                clear_data();
                load_data();
                load_id();
                MessageBox.Show("berhasil hapus lokasi");
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
