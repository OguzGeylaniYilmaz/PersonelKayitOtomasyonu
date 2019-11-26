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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DbPersonelKayıtVT;Integrated Security=True");
        SqlBaglanti bgl = new SqlBaglanti();

        public string durum;
        void Listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select *from Tbl_Meslek", bgl.connection());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Tbl_Personel", bgl.connection());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        void Temizle()
        {
            txtPerID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTC.Text = "";
            cmbSehir.Text = "";
            cmbMeslek.Text = "";
            mskMaas.Text = "";
            rdBekar.Checked = false;
            rdEvli.Checked = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
            cmbMeslek.Items.Clear();
            SqlCommand cmd2 = new SqlCommand("Select MeslekAd from  Tbl_Meslek", bgl.connection());
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                cmbMeslek.Items.Add(dr[0]);
            }

            bgl.connection().Close();
        }

        private void BtnMeslekEkle_Click(object sender, EventArgs e)
        {
            cmbMeslek.Items.Clear();
            SqlCommand cmd = new SqlCommand("Insert into Tbl_Meslek(MeslekAd) values(@p1)",bgl.connection());
            cmd.Parameters.AddWithValue("@p1", txtMeslek.Text);
            cmd.ExecuteNonQuery();
            bgl.connection().Close();
            Listele();
            MessageBox.Show("Meslek eklendi", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);

            SqlCommand cmd2 = new SqlCommand("Select MeslekAd from  Tbl_Meslek",bgl.connection());
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                cmbMeslek.Items.Add(dr[0]);
            }

            bgl.connection().Close();
        }

        private void BtnMeslekSil_Click(object sender, EventArgs e)
        {
            cmbMeslek.Items.Clear();
            SqlCommand cmd = new SqlCommand("Delete from Tbl_Meslek Where ID=@m1", bgl.connection());
            cmd.Parameters.AddWithValue("@m1", txtMeslekID.Text);
            cmd.ExecuteNonQuery();
            Listele();
            MessageBox.Show("Meslek silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SqlCommand cmd2 = new SqlCommand("Select MeslekAd from  Tbl_Meslek", bgl.connection());
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                cmbMeslek.Items.Add(dr[0]);
            }

            bgl.connection().Close();
        }

        private void BtnMeslekGuncelle_Click(object sender, EventArgs e)
        {
            cmbMeslek.Items.Clear();
            SqlCommand cmd = new SqlCommand("Update Tbl_Meslek set MeslekAd=@p1 Where ID=@p2", bgl.connection());
            cmd.Parameters.AddWithValue("@p1", txtMeslek.Text);
            cmd.Parameters.AddWithValue("@p2", txtMeslekID.Text);
            cmd.ExecuteNonQuery();        
            Listele();
            MessageBox.Show("Meslek güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SqlCommand cmd2 = new SqlCommand("Select MeslekAd from  Tbl_Meslek", bgl.connection());
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                cmbMeslek.Items.Add(dr[0]);
            }

            bgl.connection().Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtMeslekID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void BtnPerEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into Tbl_Personel(PerAd,PerSoyad,PerTC,PerSehir,PerMeslek,PerMaas,PerDurum) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.connection());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", mskTC.Text);
            cmd.Parameters.AddWithValue("@p4", cmbSehir.Text);
            cmd.Parameters.AddWithValue("@p5", cmbMeslek.Text);
            cmd.Parameters.AddWithValue("@p6", mskMaas.Text);
            cmd.Parameters.AddWithValue("@p7", durum);
            cmd.ExecuteNonQuery();
            bgl.connection().Close();
            Listele();
            MessageBox.Show("Personel eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RdEvli_CheckedChanged(object sender, EventArgs e)
        {
            durum = "1";
        }

        private void RdBekar_CheckedChanged(object sender, EventArgs e)
        {
            durum = "0";
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtPerID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            mskTC.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            cmbSehir.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            cmbMeslek.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
            mskMaas.Text = dataGridView2.Rows[secilen].Cells[6].Value.ToString();

            if (dataGridView2.Rows[secilen].Cells[7].Value.ToString() == "True")
            {
                rdEvli.Checked = true;
            }
            else
            {
                rdBekar.Checked = false;
            }
        }

        private void BtnPerSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Tbl_Personel where PerID =@p1", bgl.connection());
            cmd.Parameters.AddWithValue("@p1", txtPerID.Text);
            cmd.ExecuteNonQuery();
            bgl.connection().Close();
            Listele();
            MessageBox.Show("Personel silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnPerGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Personel set PerAd=@p1,PerSoyad=@p2,PerTC=@p3,PerSehir=@p4,PerMeslek=@p5,PerMaas=@p6,PerDurum=@p7 where PerID=@p8" , bgl.connection());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", mskTC.Text);
            cmd.Parameters.AddWithValue("@p4", cmbSehir.Text);
            cmd.Parameters.AddWithValue("@p5", cmbMeslek.Text);
            cmd.Parameters.AddWithValue("@p6", mskMaas.Text);
            cmd.Parameters.AddWithValue("@p7", durum);
            cmd.Parameters.AddWithValue("@p8", txtPerID.Text);
            cmd.ExecuteNonQuery();
            bgl.connection().Close();
            Listele();
            MessageBox.Show("Personel güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnIstatistik_Click(object sender, EventArgs e)
        {
            FrmIstatistik frm = new FrmIstatistik();
            frm.Show();
            this.Hide();
        }

        private void BtnPerGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafik grafik = new FrmGrafik();
            grafik.Show();
            this.Hide();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Personel where PerAd like '%" + txtAra.Text + "%' or PerSoyad like '%" + txtAra.Text + "%'" , bgl.connection());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
    }
}
