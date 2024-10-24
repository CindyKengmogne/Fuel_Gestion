using da3_intra_sommatif.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace da3_intra_sommatif.Presentation
{
    public partial class FuelView : Form
    {
        private FuelService service;

        

        public FuelView(FuelService service)
        {
            InitializeComponent();
            this.service = service;
            dataGridView1.DataSource= this.service.GetDataTable();

        }

        private void btnCharger_Click(object sender, EventArgs e)
        {
           service.ReloadDataTable();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            service.SaveChanges();
        }

        private void btnQuitter_Click(object sender, EventArgs e) 
        { 
                Application.Exit();
        }
    }
}
