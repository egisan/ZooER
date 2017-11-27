using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooER.DAL;
using ZooER.Models;

namespace ZooER.UI
{
    public partial class SaveNewDrug : Form
    {
        Drug myDrug = new Drug();

        public SaveNewDrug(Drug drug)
        {
            InitializeComponent();
            myDrug = drug;
            txtDrug.Text = myDrug.Name;
        }

        private void btnConfirmDrug_Click(object sender, EventArgs e)
        {
            using (var db = new ZooContext())
            {
                db.Drugs.Add(myDrug);
                db.SaveChanges();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
