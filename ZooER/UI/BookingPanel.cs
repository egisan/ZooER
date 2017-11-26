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
using ZooER.UI;

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



        // *********************
        // Click on BOOK button
        // *********************
        private void btnBook_Click(object sender, EventArgs e)
        {
            if (cmbDoctor.SelectedIndex != 0 && cmbAnimal.SelectedIndex != 0 && cmbDrugs.SelectedIndex != 0 &&
                dateTimePicker1.Text != "")
            {
                // All fields are REQUIRED

                bool doctorIsIn = false;
                bool drugsIsIn = false;

                using (var db = new ZooContext())
                {
                    // Doctor Validation

                    var tmpDoctor = new Veterinary();
                    var doctor = new Veterinary();

                    if (cmbDoctor.SelectedIndex == 0 || cmbDoctor.Text == "") // All or empty
                    {
                        MessageBox.Show("Please choose or insert a new doctor ");
                    }
                    else
                    {
                        doctorIsIn = true;

                        tmpDoctor = (cmbDoctor.SelectedIndex == -1) ? db.Veterinaries.FirstOrDefault(c => c.Name == cmbDoctor.Text) : db.Veterinaries.Include("Animals").Include("Diagnosis").Include("VisitDrug").Include("Drug").FirstOrDefault(c => c.Name == cmbDoctor.SelectedItem.ToString());
                        if (tmpDoctor == null)
                        {
                            // A New doctor name has been inserted.
                            doctor = new Veterinary { Name = cmbDoctor.Text };

                            // invoke the form
                            Form frm = new SaveNewVet(doctor);
                            frm.Show();

                        }
                        else
                        {
                            doctor = tmpDoctor;
                        }

                    }

                    // Drug Validation
                    var tmpDrug = new Drug();
                    var drug = new Drug();

                    if (cmbDrugs.SelectedIndex == 0 || cmbDrugs.Text == "") // All or empty
                    {
                        MessageBox.Show("Please choose or insert a new drug");
                    }
                    else
                    {
                        drugsIsIn = true;

                        tmpDrug = (cmbDrugs.SelectedIndex == -1) ? db.Drugs.FirstOrDefault(c => c.Name == cmbDrugs.Text) : db.Drugs.Include("Visit").Include("VisitDrug").FirstOrDefault(c => c.Name == cmbDrugs.SelectedItem.ToString());
                        if (tmpDrug == null)
                        {
                            // A New doctor name has been inserted.
                            drug = new Drug { Name = cmbDrugs.Text };

                            // invoke the form
                            Form frm = new SaveNewDrug(drug);
                            frm.Show();

                        }
                        else
                        {
                            drug = tmpDrug;
                        }

                    }









                }
            }
            else
            {
                MessageBox.Show("All fields are required to book a visit!");

            }
        }


        private void btnPrevMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
