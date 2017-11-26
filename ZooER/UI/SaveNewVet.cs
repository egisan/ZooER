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
    public partial class SaveNewVet : Form
    {

        Veterinary myDoctor = new Veterinary();

        public SaveNewVet(Veterinary doctor)
        {
            InitializeComponent();
            myDoctor = doctor;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnDoctorSave_Click(object sender, EventArgs e)
        {
            using (var db = new ZooContext())
            {
                db.Veterinaries.Add(myDoctor);
                db.SaveChanges();
            }
        }
    }
}
