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
using ZooER.Services;
using ZooER.UI;

namespace ZooER
{
    public partial class BookingPanel : Form
    {

        Utility service;

        public BookingPanel()
        {
            InitializeComponent();
            SetComboBoxProperties();
            LoadCurrentVisits();
        }


        private void SetComboBoxProperties()
        {
            // Doctor and Drugs are editable by user
            cmbDoctor.DropDownStyle = ComboBoxStyle.DropDown;
            cmbDrugs.DropDownStyle = ComboBoxStyle.DropDown;

            // Animal can only be selected
            cmbAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void LoadCurrentVisits()
        {
            service = new Utility();
            FillComboBoxes();

            var lista = service.GetVisitsDetails();
            if (lista.Count() != 0)
            {
                dataGridVisits.DataSource = lista;
            }
            else
            {
                while (dataGridVisits.Rows.Count > 0)
                {
                    dataGridVisits.Rows.RemoveAt(0);
                }
            }
        }

        private void FillComboBoxes()
        {
            FillDoctorsCombo();
            FillAnimalsCombo();
            FillDrugsCombo();
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


        private void ClearData()
        {
            cmbDoctor.SelectedIndex = 0;
            cmbAnimal.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
            mskTxtDesc.Text = "";
            cmbDrugs.SelectedIndex = 0;
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

                var newVisit = new Visit();

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

                        tmpDoctor = (cmbDoctor.SelectedIndex == -1) ? db.Veterinaries.FirstOrDefault(c => c.Name == cmbDoctor.Text) : db.Veterinaries.Include("Visits").FirstOrDefault(c => c.Name == cmbDoctor.SelectedItem.ToString());
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

                    if (doctorIsIn)
                    {
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

                            tmpDrug = (cmbDrugs.SelectedIndex == -1) ? db.Drugs.FirstOrDefault(c => c.Name == cmbDrugs.Text) : db.Drugs.Include("Visits").FirstOrDefault(c => c.Name == cmbDrugs.SelectedItem.ToString());
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

                        if (drugsIsIn)
                        {
                            // I can check the other fields
                            // I need to check whether this visit is already in DB (animal, doctor & Date/Time booking)


                            bool allFieldsAlreadyExist = db.Visits.Where(c => c.Start.Year == dateTimePicker1.Value.Year &&
                                                                              c.Start.Month == dateTimePicker1.Value.Month &&
                                                                              c.Start.Day == dateTimePicker1.Value.Day &&
                                                                              c.Start.Hour == dateTimePicker2.Value.Hour &&
                                                                              c.Start.Minute == dateTimePicker2.Value.Minute &&
                                                                              c.Animal.Name == cmbAnimal.SelectedItem.ToString() &&
                                                                              c.Veterinary.Name == cmbDoctor.SelectedItem.ToString()).Any();

                            bool doctorTimeExist = db.Visits.Where(c => c.Start.Year == dateTimePicker1.Value.Year &&
                                                                       c.Start.Month == dateTimePicker1.Value.Month &&
                                                                       c.Start.Day == dateTimePicker1.Value.Day &&
                                                                       c.Start.Hour == dateTimePicker2.Value.Hour &&
                                                                       c.Start.Minute == dateTimePicker2.Value.Minute &&
                                                                       c.Veterinary.Name == cmbDoctor.SelectedItem.ToString()).Any();

                            bool animalTimeExist = db.Visits.Where(c => c.Start.Year == dateTimePicker1.Value.Year &&
                                                                       c.Start.Month == dateTimePicker1.Value.Month &&
                                                                       c.Start.Day == dateTimePicker1.Value.Day &&
                                                                       c.Start.Hour == dateTimePicker2.Value.Hour &&
                                                                       c.Start.Minute == dateTimePicker2.Value.Minute &&
                                                                       c.Animal.Name == cmbAnimal.SelectedItem.ToString()).Any();

                            // Check overlapping of time/doctor/animal and visit
                            if (allFieldsAlreadyExist)
                            {
                                MessageBox.Show("This animal has already this time slot reserved with the same doctor. Please choose another time slot/doctor.");
                            }
                            else if (doctorTimeExist)
                            {
                                MessageBox.Show("This doctor has already this time slot reserved with another animal. Please choose another time slot/doctor.");
                            }
                            else if (animalTimeExist)
                            {
                                MessageBox.Show("This animal has already this time slot reserved with another doctor. Please choose another time slot.");
                            }
                            else
                            {
                                newVisit.Start = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
                                newVisit.Veterinary = doctor;
                                newVisit.Drugs.Add(
                                    new VisitDrug
                                    {
                                        Visit = newVisit,
                                        Drug = drug
                                    });
                                newVisit.Diagnosis = new Diagnosis { Description = mskTxtDesc.Text };
                                newVisit.Animal = db.Animals.Where(c => c.Name == cmbAnimal.SelectedItem.ToString()).FirstOrDefault();

                                db.Visits.Add(newVisit);
                                db.SaveChanges();
                                MessageBox.Show("A new visit has been reserved for this animal!");
                                LoadCurrentVisits();
                                ClearData();
                            }

                        }
                        else
                        {
                            // I have not inserted a valid Drug and need to repeat the input
                        }

                    }
                    else
                    {
                        // the doctor field is not valid and I need to repeat the input

                    }









                } // Using
            } // Check for empty fields at start
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
