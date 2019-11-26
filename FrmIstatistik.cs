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
    public partial class FrmIstatistik : Form
    {
        SqlBaglanti conn = new SqlBaglanti();
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select count(*) from Tbl_Personel", conn.connection());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblPerSay.Text = dr[0].ToString();
            }
            conn.connection().Close();
            // Evli Personel Sayısı
            SqlCommand cmd2 = new SqlCommand("Select count(*) from Tbl_Personel where PerDurum=1", conn.connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                lblEvliPer.Text = dr2[0].ToString();
            }
            conn.connection().Close();

            //Bekar Personel Sayısı
            SqlCommand cmd3 = new SqlCommand("Select count(*) from Tbl_Personel where PerDurum=0", conn.connection());
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekarPer.Text = dr3[0].ToString();
            }
            conn.connection().Close();

            //Toplam Meslek Sayısı
            SqlCommand cmd4 = new SqlCommand("Select count(distinct(PerMeslek)) from Tbl_Personel", conn.connection());
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                lblToplamMeslek.Text = dr4[0].ToString();
            }
            conn.connection().Close();

            //Toplam Sehir Sayısı
            SqlCommand cmd5 = new SqlCommand("Select count(distinct(PerSehir)) from Tbl_Personel", conn.connection());
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamSehir.Text = dr5[0].ToString();
            }
            conn.connection().Close();

            //Toplam Maas
            SqlCommand cmd6 = new SqlCommand("Select sum(PerMaas) from Tbl_Personel", conn.connection());
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                lblToplamMaas.Text = dr6[0].ToString();
            }
            conn.connection().ToString();

            //Ortalama Maas
            SqlCommand cmd7 = new SqlCommand("Select avg(PerMaas) from Tbl_Personel",conn.connection());
            SqlDataReader dr7 = cmd7.ExecuteReader();
            while (dr7.Read())
            {
                lblOrtMaas.Text = dr7[0].ToString();
            }
            conn.connection().Close();
        }
    }
}
