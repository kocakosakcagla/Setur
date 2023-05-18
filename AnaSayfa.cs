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
    public partial class AnaSayfa : Form
    {
        Personel personel = new Personel();
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void pERSONELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f1 = (Personel)Application.OpenForms["Personel"];
            if (f1 == null )
            {
                personel.MdiParent = this;
                personel.Dock=DockStyle.Fill;   
                personel.Show();

            }
            
         

        }

        private void oTELToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var f1 = (frm_otel)Application.OpenForms["Otel"];
            if (f1 == null)
            {
                personel.MdiParent = this;
                personel.Dock = DockStyle.Fill;
                personel.Show();

            }

        }
    }
}
