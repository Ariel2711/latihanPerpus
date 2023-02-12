using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace perpus
{
    public partial class login : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=perpus;Integrated Security=True");
        public login()
        {
            InitializeComponent();
            loadCaptchaImage();
            textBox2.UseSystemPasswordChar = true;
        }
        public static int ID { get; set; }
        int number;
        private void loadCaptchaImage()
        {
            Random r1 = new Random();
            number = r1.Next(100, 1000);
            var image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("TimesNewRoman", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(number.ToString(), font, Brushes.Green, new Point(0, 0));
            pictureBox1.Image = image;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if(textBox1.Text=="" || textBox2.Text == "")
            {
                MessageBox.Show("Harap isi username dan password");
            }
            else
            {
                //if(textBox3.Text != number.ToString())
                //{
                  //MessageBox.Show("Captcha tidak valid");
                //}
               // else
                //{
                koneksi.Open();
                var hashpw = daftar.hashstring(textBox2.Text);
                SqlDataAdapter sda = new SqlDataAdapter("select * from [user] where username='" + textBox1.Text + "' and password='" + hashpw + "'", koneksi);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("User tidak valid");
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["level"].ToString() == "petugas")
                        {
                            this.Hide();
                            ID = int.Parse(dr["id_user"].ToString());
                            petugas p = new petugas();
                            p.Show();
                        }
                        else if (dr["level"].ToString() == "anggota")
                        {
                            this.Hide();
                            ID = int.Parse(dr["id_user"].ToString());
                            anggota a = new anggota();
                            a.Show();
                        }
                        else
                        {
                            MessageBox.Show("user tidak valid");
                        }
                    }                               
                    //}
                    koneksi.Close();
                }
            }
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            this.Hide();
            daftar d = new daftar();
            d.Show();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
            if (textBox2.UseSystemPasswordChar == true) {
                label1.Text = "show";
            }
            else
            {
                label1.Text = "hide";
            }
        }
    }
}
