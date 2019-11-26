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
    public partial class FrmGrafik : Form
    {
        SqlBaglanti conn = new SqlBaglanti();
        public FrmGrafik()
        {
            InitializeComponent();
        }

        private void FrmGrafik_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select PerSehir,COUNT(*) from Tbl_Personel group by PerSehir",conn.connection());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr[0], dr[1]);
            }
            conn.connection().Close();

            SqlCommand cmd2 = new SqlCommand("Select PerMeslek,Avg(PerMaas) from Tbl_Personel group by PerMeslek",conn.connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            conn.connection().Close();
        }
    }
}
