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

namespace ZooER
{
    public partial class BookingPanel : Form
    {
        public BookingPanel()
        {
            InitializeComponent();
            SetComboBoxProperties();
            FillDoctorsCombo();
            FillAnimalsCombo();
            FillDrugsCombo();
        }


        private void SetComboBoxProperties()
        {
            // Doctor and Drugs are editable by user
            cmbDoctor.DropDownStyle = ComboBoxStyle.DropDown;
            cmbDrugs.DropDownStyle = ComboBoxStyle.DropDown;

            // Animal can only be selected
            cmbAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FillDoctorsCombo()
        {
            using (var db = new ZooContext())
            {
                int count = db.Veterinaries.ToList().Count();
                string[] mappedVeterinaries = new string[count + 1];
                mappedVeterinaries[0] = "-- Choose or insert a new veterinary --";

                for (int i = 0, j = 1; i < count; i++, j++)
                {
                    mappedVeterinaries[j] = db.Veterinaries.ToList()[i].Name;
                }
                cmbDoctor.DataSource = mappedVeterinaries;
            }
        }

        private void FillAnimalsCombo()
        {
            using (var db = new ZooContext())
            {
                int count = db.Animals.ToList().Count();
                string[] mappedAnimals = new string[count + 1];
                mappedAnimals[0] = "-- Choose an animal --";

                for (int i = 0, j = 1; i < count; i++, j++)
                {
                    mappedAnimals[j] = db.Animals.ToList()[i].Name;
                }
                cmbAnimal.DataSource = mappedAnimals;
               
            }
        }

        private void FillDrugsCombo()
        {
            using (var db = new ZooContext())
            {
                int count = db.Drugs.ToList().Count();
                string[] mappedDrugs = new string[count + 1];
                mappedDrugs[0] = "-- Choose or insert a new drug --";

                for (int i = 0, j = 1; i < count; i++, j++)
                {
                    mappedDrugs[j] = db.Drugs.ToList()[i].Name;
                }
                cmbDrugs.DataSource = mappedDrugs;

            }
        }




        private void btnBook_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
