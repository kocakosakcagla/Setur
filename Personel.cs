using setur.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace setur
{
    public partial class Personel : Form
    {
        DBConnect dBConnect = new DBConnect();
        int personelID = -1;
        public Personel()
        {
            InitializeComponent();
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            personelGetir();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            frm_PersonelEkle frm_PersonelEkle = new frm_PersonelEkle();
            frm_PersonelEkle.ShowDialog();
        }

        private void Personel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void personelGetir()
        {
            DataTable dataTable = new DataTable();
            dataTable = dBConnect.ExecuteTable("select * from PERSONEL");
            dgv_personel.DataSource = dataTable;
        }


        private void dgv_personel_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                personelID = Convert.ToInt16(dgv_personel.SelectedRows[0].Cells[0].Value);
                btn_guncelle.Enabled = true;
                btn_sil.Enabled = true;
            }
            catch (Exception)
            {
                personelID = -1;
                btn_guncelle.Enabled = false;
                btn_sil.Enabled = false;
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            frm_PersonelEkle PersonelEkle = new frm_PersonelEkle(personelID);
            PersonelEkle.ShowDialog();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Silmek istediğinize" + " emin misiniz!"
                 , " Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            

            if (secenek == DialogResult.Yes)
            {

                string query = "delete from PERSONEL where ID=" +
                        "" + personelID.ToString();
                dBConnect.ExecuteNonQuery(query);
                MessageBox.Show("Personel Silindi");
                personelGetir();
           

            }
        }
    }
}
