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

namespace PersonelKayıtOtomasyonu
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        SqlBaglanti conn = new SqlBaglanti();
        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select *from Tbl_Giris where KullaniciAd=@p1 and KullaniciSifre=@p2", conn.connection());
            cmd.Parameters.AddWithValue("@p1", txtKulAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
                txtKulAd.Text = "";
                txtSifre.Text = "";
            }

        }
    }
}
