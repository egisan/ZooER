﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooER.DAL;
using ZooER.ViewModels;
using ZooER.Services;
using ZooER.Models;

namespace ZooER
{
    public partial class EditPanel : Form
    {
        // Global visibility in this class for all the methods
        Utility service;

        // variable used in Updating and Deleting Record  
        int lastSelectedRow = 0;

        int SelectedAnimalID = -1; // Initialize the ID (out of range!)

        // Used to detect changed in the textboxes/combos
        bool animalNameChgd;
        bool habitatChgd;
        bool speciesChgd;
        bool dietChgd;
        bool weightChgd;
        bool originChgd;
        bool parent1Chgd;
        bool parent2Chgd;



        public EditPanel()
        {
            InitializeComponent();
            LoadCurrentZoo();

            //BindingList<AnimalDetails> showAll = GetAnimalDetails();
            //dataGridVedit.DataSource = showAll;
        }

        private void SetComboBoxProperties()
        {
            // Habitat and Diets are not changeable by user
            cmbHabitat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDiet.DropDownStyle = ComboBoxStyle.DropDownList;

            // Perhaps this should be editable !!
            cmbSpecies.DropDownStyle = ComboBoxStyle.DropDownList;
            //cmbSpecies.Properties.TextEditStyle = DisableTextEditor;


        }


        public void LoadCurrentZoo()
        {
            service = new Utility();
            SetComboBoxProperties();
            FillComboBoxes();

            // Test
            var lista = service.GetAnimalDetails();
            if (lista.Count() != 0)
            {
                dataGridVedit.DataSource = lista;
            }
            else
            {
                while (dataGridVedit.Rows.Count > 0)
                {
                    dataGridVedit.Rows.RemoveAt(0);
                }
            }
        }


        private void FillComboBoxes()
        {
            FillSpeciesCombo();
            FillHabitatCombo();
            FillDietCombo();
            FillOrigin();
            FillParent1Combo();
            FillParent2Combo();
        }


        private BindingSource industryGroupFilter = new BindingSource();

        private void FillOrigin()
        {

            // Test - disconnecting ComboBox ORigin from table Origins!

            // var service = new Utility();

            using (var db = new ZooContext())
            {
                // Need tp remeber that "combobox.SelectedIndex = 0" is reserved for "all" data

                int count = db.Origins.ToList().Count();
                string[] mappedOrigins = new string[count + 1];
                mappedOrigins[0] = "All";

                for (int i = 0, j = 1; i < count; i++, j++)
                {
                    mappedOrigins[j] = db.Origins.ToList()[i].Name;
                }
                cmbOrigin.DataSource = mappedOrigins;

                //db.Origins.ToList();
                // cmbOrigin.ValueMember = "OriginId";
                // cmbOrigin.DisplayMember = "Name";

                // Default value
                // cmbOrigin.SelectedIndex = -1;
            }
        }


        private void FillDietCombo()
        {
            using (var db = new ZooContext())
            {
                int count = db.Diets.ToList().Count();
                string[] mappedDiets = new string[count + 1];
                mappedDiets[0] = "All";

                for (int i = 0, j = 1; i < count; i++, j++)
                {
                    mappedDiets[j] = db.Diets.ToList()[i].Name;
                }
                cmbDiet.DataSource = mappedDiets;


                // db.Diets.Add(0, new Diet() { DietId = 0, Name = "Select a sector." });

                //cmbDiet.DataSource = db.Diets.ToList();
                //cmbDiet.ValueMember = "DietId";
                //cmbDiet.DisplayMember = "Name";

                //// Default value
                //cmbDiet.SelectedIndex = -1;
            }
        }

        private void FillHabitatCombo()
        {
            using (var db = new ZooContext())
            {
                int count = db.Habitats.ToList().Count();
                string[] mappedHabitats = new string[count + 1];
                mappedHabitats[0] = "All";

                for (int i = 0, j = 1; i < count; i++, j++)
                {
                    mappedHabitats[j] = db.Habitats.ToList()[i].Name;
                }
                cmbHabitat.DataSource = mappedHabitats;
            }
        }


        private void FillSpeciesCombo()
        {
            using (var db = new ZooContext())
            {
                int count = db.Species.ToList().Count();
                string[] mappedSpecies = new string[count + 1];
                mappedSpecies[0] = "All";

                for (int i = 0, j = 1; i < count; i++, j++)
                {
                    mappedSpecies[j] = db.Species.ToList()[i].Name;
                }
                cmbSpecies.DataSource = mappedSpecies;
            }
        }


        private void FillParent1Combo()
        {
            using (var db = new ZooContext())
            {
                int count = db.Animals.ToList().Count();    // Where(c => c.IsParentOf.Any()).ToList().Count();

                string[] mappedParent1 = new string[count + 1];
                mappedParent1[0] = "All";

                for (int i = 0, j = 1; i < count; i++, j++)
                {
                    mappedParent1[j] = db.Animals.ToList()[i].Name;
                }
                cmbParent1.DataSource = mappedParent1;
            }
        }

        private void FillParent2Combo()
        {
            using (var db = new ZooContext())
            {
                int count = db.Animals.ToList().Count();    // Where(c => c.IsParentOf.Any()).ToList().Count();

                string[] mappedParent2 = new string[count + 1];
                mappedParent2[0] = "All";

                for (int i = 0, j = 1; i < count; i++, j++)
                {
                    mappedParent2[j] = db.Animals.ToList()[i].Name;
                }
                cmbParent2.DataSource = mappedParent2;
            }
        }


        private void ClearData()
        {
            animalNameChgd = habitatChgd = speciesChgd = dietChgd = weightChgd = originChgd = parent1Chgd = parent2Chgd = false;

            mskTxtAnimal.Text = "";
            mskTxtWeight.Text = "";

            cmbSpecies.SelectedText = "";
            cmbHabitat.SelectedText = "";
            cmbDiet.SelectedText = "";
            cmbOrigin.SelectedText = "";
            cmbParent1.SelectedText = "";
            cmbParent2.SelectedText = "";
        }


        // Click on Clear Button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadCurrentZoo();


        }


        // Click on Previous Menu Button
        private void btnPrevMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void UpdateCombosWithDataGridSelection(int selectedAnimalID, int rowIndex)
        {
            // Animal Name
            mskTxtAnimal.Text = dataGridVedit.Rows[rowIndex].Cells[1].Value.ToString();

            // Weight
            mskTxtWeight.Text = dataGridVedit.Rows[rowIndex].Cells[2].Value.ToString();

            // Species
            using (var db = new ZooContext())
            {
                // retrieve animalId from the datagrid and find attached species value!
                var species = db.Animals.Where(c => c.AnimalId == selectedAnimalID).Select(c => c.Species).SingleOrDefault();
                cmbSpecies.SelectedItem = species.Name;

                // Habitat

                // retrieve animalId from the datagrid and find attached Habitat value!
                var habitat = db.Animals.Where(c => c.AnimalId == selectedAnimalID).Select(c => c.Habitat).SingleOrDefault();
                cmbHabitat.Text = habitat.Name;

                // Diet

                // retrieve animalId from the datagrid and find attached Habitat value!
                var diet = db.Animals.Where(c => c.AnimalId == selectedAnimalID).Select(c => c.Diet).SingleOrDefault();
                cmbDiet.Text = diet.Name;

                // Origin

                // retrieve animalId from the datagrid and find attached Habitat value!
                var origin = db.Animals.Where(c => c.AnimalId == selectedAnimalID).Select(c => c.Origin).SingleOrDefault();
                cmbOrigin.Text = origin.Name;

                // Parent 1
                // retrieve animalId from the datagrid and find attached Habitat value!
                if (dataGridVedit.Rows[rowIndex].Cells[7].Value.ToString() == "Not available")
                {
                    cmbParent1.SelectedIndex = 0;
                }
                else
                {
                    cmbParent1.SelectedIndex = cmbParent1.FindStringExact(dataGridVedit.Rows[rowIndex].Cells[7].Value.ToString());
                }

                // Parent 2
                // retrieve animalId from the datagrid and find attached Habitat value!
                if (dataGridVedit.Rows[rowIndex].Cells[8].Value.ToString() == "Not available")
                {
                    cmbParent2.SelectedIndex = 0;
                }
                else
                {
                    cmbParent2.SelectedIndex = cmbParent2.FindStringExact(dataGridVedit.Rows[rowIndex].Cells[8].Value.ToString());
                }

            }

            // Alternative way:
            // cmbParent2.SelectedIndex = cmbParent2.Items.IndexOf(gridViewRUD.Rows[e.RowIndex].Cells[8].Value.ToString().Trim());
        }


        // Click on one Cell in the DattaGrid
        private void dataGridVedit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // I need to save here the current "Animal information" before an "update/Delete"
            // is performed

            if (e.RowIndex >= 0)
            {
                // I need to retrieve here the ID in 'Animals' table that need to be updated/deleted in the DB
                //SelectedAnimalID = RetrieveSelectedAnimalID();
                SelectedAnimalID = (int)dataGridVedit.Rows[e.RowIndex].Cells[0].Value;

                lastSelectedRow = e.RowIndex;
                // lastSelectedColumn = e.ColumnIndex;

                UpdateCombosWithDataGridSelection(SelectedAnimalID, e.RowIndex);
            }
        }


        // Select a row in the DataGrid
        private void dataGridVedit_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // I need to retrieve here the ID in 'Animals' table that need to be updated/deleted in the DB
                //SelectedAnimalID = RetrieveSelectedAnimalID();
                SelectedAnimalID = (int)dataGridVedit.Rows[e.RowIndex].Cells[0].Value;

                lastSelectedRow = e.RowIndex;
                // lastSelectedColumn = e.ColumnIndex;

                UpdateCombosWithDataGridSelection(SelectedAnimalID, e.RowIndex);
            }
        }



        private void mskTxtAnimal_TextChanged(object sender, EventArgs e)
        {
            animalNameChgd = true;
        }

        private void cmbSpecies_TextChanged(object sender, EventArgs e)
        {
            speciesChgd = true;
        }


        private void cmbHabitat_TextChanged(object sender, EventArgs e)
        {
            habitatChgd = true;
        }

        private void cmbDiet_TextChanged(object sender, EventArgs e)
        {
            dietChgd = true;
        }


        private void mskTxtWeight_TextChanged(object sender, EventArgs e)
        {
            weightChgd = true;
        }

        private void cmbOrigin_TextChanged(object sender, EventArgs e)
        {
            originChgd = true;
        }

        private void cmbParent1_TextChanged(object sender, EventArgs e)
        {
            parent1Chgd = true;
        }

        private void cmbParent2_TextChanged(object sender, EventArgs e)
        {
            parent2Chgd = true;
        }


        // ****************
        // Pressing DELETE
        // ****************
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (mskTxtAnimal.Text != "" && cmbHabitat.SelectedIndex != 0 && cmbSpecies.SelectedIndex != 0 && cmbDiet.SelectedIndex != 0 &&
                mskTxtWeight.Text != "")
            {
                using (var db = new ZooContext())
                {
                    // I need to retrieve here the ID in 'Animals' table that need to be updated/deleted in the DB
                    // SelectedAnimalID = RetrieveSelectedAnimalID();
                    // SelectedAnimalID = (int)dataGridVedit.Rows[e.RowIndex].Cells[0].Value;

                    // I need to remove animal from any of the "1" relations,before that I need to 
                    // check that there are NO VISITS conection to Animal.
                    // IF YES, remove MESSAGE TO USER, REMOVE VISITS, then ANIMAL
                    if (SelectedAnimalID < 0)
                    {
                        MessageBox.Show("Please select an Animal to DELETE from the list below first.");
                    }
                    else
                    {
                        var parents = new List<Animal>();
                        var animalToRemove = db.Animals.Include("IsChildOf").Include("IsParentOf").FirstOrDefault(x => x.AnimalId == SelectedAnimalID);

                        if (animalToRemove.Visits.Count() != 0)
                        {
                            // Animal cannot be removed!
                            MessageBox.Show("Warning! The Animal has some pending visits at the veterinary. Cancel the visits first please.");
                        }
                        else
                        {
                            // call Remove method from navigation property for any instance

                            //  animalToRemove.IsChildOf
                            db.Animals.Remove(animalToRemove);     // REMOVE the animal from Animals!!

                            // call SaveChanges from context
                            db.SaveChanges();
                            MessageBox.Show("Animal removed!");
                            LoadCurrentZoo();
                            ClearData();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nothing Selected! Delete operation is not performed.");
            }
            // End DELETE
        }




        // ***************************
        // Pressing SAVE NEW - INSERT
        // ***************************
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mskTxtAnimal.Text != "" && cmbHabitat.SelectedIndex != 0 && cmbSpecies.SelectedIndex != 0 && cmbDiet.SelectedIndex != 0 &&
                  mskTxtWeight.Text != "")
            {

                // at least one field has been changed before pressin SAVE
                // Need to check:
                // - if data is ALREADY in DB or NEW records
                // 

                var newAnimal = new Animal();

                using (var db = new ZooContext())
                {
                    //Check against DB
                    var temp = Convert.ToDouble(mskTxtWeight.Text);


                    Origin newOrigin = new Origin();
                    newAnimal.Name = mskTxtAnimal.Text;

                    if (cmbOrigin.SelectedIndex == 0 || cmbOrigin.Text == "") // All or empty
                    {
                        MessageBox.Show("Please choose an Origin country/continent.");
                        // Need to jump all the code below!
                    }
                    else //if (cmbOrigin.SelectedIndex == -1)  // A new country/continent has been inserted
                    {
                        newOrigin = (cmbOrigin.SelectedIndex == -1) ? db.Origins.Include("Animals").FirstOrDefault(c => c.Name == cmbOrigin.Text) : db.Origins.Include("Animals").FirstOrDefault(c => c.Name == cmbOrigin.SelectedItem.ToString());
                        if (newOrigin == null)
                        {
                            // need to create a new origin object
                            newAnimal.Origin = new Origin { Name = cmbOrigin.Text };
                        }
                        else
                        {
                            // Search the ID of the existing country/continent and save it in "newAnimal"
                            newAnimal.Origin = newOrigin; // db.Origins.Where(c => c.Name == cmbOrigin.SelectedItem.ToString()).Select(c => c.OriginId).SingleOrDefault();
                        }

                        var animalReadyExist = db.Animals.Where(c => c.Name == mskTxtAnimal.Text && c.Weight == temp &&
                                                      c.Habitat.Name == cmbHabitat.SelectedItem.ToString() &&
                                                      c.Species.Name == cmbSpecies.SelectedItem.ToString() &&
                                                      c.Origin.Name == newAnimal.Origin.Name &&
                                                      c.Diet.Name == cmbDiet.SelectedItem.ToString()).Any();

                        newAnimal.Weight = Convert.ToDouble(mskTxtWeight.Text);
                        newAnimal.HabitatId = db.Habitats.Where(c => c.Name == cmbHabitat.SelectedItem.ToString()).Select(c => c.HabitatId).SingleOrDefault();
                        newAnimal.SpeciesId = db.Species.Where(c => c.Name == cmbSpecies.SelectedItem.ToString()).Select(c => c.SpeciesId).SingleOrDefault();
                        newAnimal.DietId = db.Diets.Where(c => c.Name == cmbDiet.SelectedItem.ToString()).Select(c => c.DietId).SingleOrDefault();

                        string parentInCombo1 = cmbParent1.SelectedItem?.ToString();
                        string parentInCombo2 = cmbParent2.SelectedItem?.ToString();
                        bool sameName = false;

                        if (parentInCombo1 != "All" && parentInCombo2 != "All" && parentInCombo1 == parentInCombo2)
                        {
                            MessageBox.Show("Select two different parents or set to 'All' for no parents");
                            sameName = true;
                        }
                        else if (parentInCombo1 != "All" && parentInCombo1 == mskTxtAnimal.Text)
                        {
                            // Parent1 name is SAME as Child --> update not possible
                            MessageBox.Show("Parent cannot have the same Name as the new Animal");
                            sameName = true;
                        }
                        else if (parentInCombo2 != "All" && parentInCombo2 == mskTxtAnimal.Text)
                        {
                            // Parent1 name is SAME as Child --> update not possible
                            MessageBox.Show("Parent cannot have the same Name as the new Animal");
                            sameName = true;
                        }
                        else if (animalReadyExist)
                        {
                            MessageBox.Show("Existing animal. Do you want to update perhaps?");

                        }
                        else if (parentInCombo1 != "All" || parentInCombo2 != "All")
                        {
                            if (parentInCombo1 != "All")
                            {
                                // I need to search in the db the Entities mapped to the parent 1/2 comboboxes and from there Add this new Animal as Child
                                // Of the Parents in the DB
                                var selectedParent = db.Animals.Include(c => c.IsChildOf).SingleOrDefault(c => c.Name == parentInCombo1);

                                // If there is an Animal with Name in comboBox1 I can add the new Child!
                                if (selectedParent != null)
                                {
                                    selectedParent.IsParentOf.Add(
                                        new ChildParent
                                        {
                                            Child = newAnimal,         // New Child
                                            Parent = selectedParent    // Existing Parent
                                        });
                                }
                            }
                            // I add th 2nd parent if it exist
                            if (parentInCombo2 != "All")
                            {
                                // I need to search in the db the Entities mapped to the parent 1/2 comboboxes and from there Add this new Animal as Child
                                // Of the Parents in the DB
                                var selectedParent = db.Animals.Include(c => c.IsChildOf).SingleOrDefault(c => c.Name == parentInCombo2);

                                if (selectedParent != null)
                                {
                                    selectedParent.IsParentOf.Add(
                                        new ChildParent
                                        {
                                            Child = newAnimal,          // New Child
                                            Parent = selectedParent     // Existing Parent
                                        });
                                }
                            }
                        }
                        if (!sameName && !animalReadyExist)
                        {
                            // This Below is necessary!!
                            db.Animals.Add(newAnimal);
                            // Saving in the DB
                            db.SaveChanges();
                            MessageBox.Show("A New animal has been saved successfully!");
                            LoadCurrentZoo();
                            ClearData();
                        }
                    }
                } // Using()
            }
            else
            {
                // None of the fields has been changed before SAVE
                MessageBox.Show("Nothing to Save.");
            }
        }



        // ********************************************************
        // SEARCH METHOD
        //
        // *******************************************************

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool nameIn = false;
            bool speciesIn = false;
            bool habitatIn = false;
            bool dietIn = false;
            bool weightIn = false;
            bool originIn = false;
            bool par1In = false;
            bool par2In = false;


            if (mskTxtAnimal.Text != "")
            {
                nameIn = true;

            }


            // QUI HO ENTITIES NO STRINGHE!!
            // String.IsNullOrEmpty(str)


            if (cmbSpecies.SelectedItem != null && cmbSpecies.SelectedItem?.ToString() != "" && cmbSpecies.SelectedItem?.ToString() != "All")
            {
                speciesIn = true;
            }

            if (cmbHabitat.SelectedItem != null && cmbHabitat.SelectedItem?.ToString() != "" && cmbHabitat.SelectedItem?.ToString() != "All")
            {
                habitatIn = true;
            }

            if (cmbDiet.SelectedItem != null && cmbDiet.SelectedItem?.ToString() != "" && cmbDiet.SelectedItem?.ToString() != "All")
            {
                dietIn = true;
            }

            if (mskTxtWeight.Text != "")
            {
                weightIn = true;
            }

            if (cmbOrigin.SelectedItem != null && cmbOrigin.SelectedItem?.ToString() != "" && cmbOrigin.SelectedItem?.ToString() != "All")
            {
                originIn = true;
            }

            if (cmbParent1.SelectedItem != null && cmbParent1.SelectedItem?.ToString() != "" && cmbParent1.SelectedItem?.ToString() != "All")
            {
                par1In = true;
            }

            if (cmbParent2.SelectedItem != null && cmbParent2.SelectedItem?.ToString() != "" && cmbParent2.SelectedItem?.ToString() != "All")
            {
                par2In = true;
            }

            using (var db = new ZooContext())
            {
                var animals = new List<AnimalDetails>();
                if (nameIn || speciesIn || habitatIn || dietIn) // || weightIn || originIn || par1In || par2In)
                {
                    // It is enough that ONE among: Animal Name, Species, Habitat, Diet is inserted to trigger the Search!


                    if (nameIn && speciesIn && habitatIn && dietIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c.Name.Contains(mskTxtAnimal.Text) &&
                                                        c.Species.Name == cmbSpecies.SelectedItem.ToString() &&
                                                        c.Habitat.Name == cmbHabitat.SelectedItem.ToString() &&
                                                        c.Diet.Name == cmbDiet.SelectedItem.ToString()).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);
                    }
                    else if (nameIn && speciesIn && habitatIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c.Name.Contains(mskTxtAnimal.Text) &&
                                                        c.Species.Name == cmbSpecies.SelectedItem.ToString() &&
                                                        c.Habitat.Name == cmbHabitat.SelectedItem.ToString()).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);
                    }
                    else if (nameIn && speciesIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c.Name.Contains(mskTxtAnimal.Text) &&
                                                        c.Species.Name == cmbSpecies.SelectedItem.ToString()).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);
                    }
                    else if (nameIn && habitatIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c.Name.Contains(mskTxtAnimal.Text) &&
                                                        c.Habitat.Name == cmbHabitat.SelectedItem.ToString()).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);
                    }
                    else if (nameIn && dietIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c.Name.Contains(mskTxtAnimal.Text) &&
                                                        c.Diet.Name == cmbDiet.SelectedItem.ToString()).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);
                    }
                    else if (habitatIn && dietIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c.Habitat.Name == cmbHabitat.SelectedItem.ToString() &&
                                                        c.Diet.Name == cmbDiet.SelectedItem.ToString()).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);
                    }
                    else if (habitatIn && speciesIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c.Habitat.Name == cmbHabitat.SelectedItem.ToString() &&
                                                        c.Species.Name == cmbSpecies.SelectedItem.ToString()).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);
                    }
                    else if (dietIn && speciesIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c.Diet.Name == cmbDiet.SelectedItem.ToString() &&
                                                        c.Species.Name == cmbSpecies.SelectedItem.ToString()).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);
                    }
                    else if (nameIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c != null && c.Name.Contains(mskTxtAnimal.Text)).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);
                    }
                    else if (speciesIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c.Species.Name == cmbSpecies.SelectedItem.ToString()).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);
                    }
                    else if (habitatIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c.Habitat.Name == cmbHabitat.SelectedItem.ToString()).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);
                    }
                    else if (dietIn)
                    {
                        var tempAnimals = db.Animals.Where(c => c.Diet.Name == cmbDiet.SelectedItem.ToString()).ToList();

                        animals = service.GetAllAnimalsInSublist(tempAnimals);

                        //.Select(x => new AnimalDetails()
                        //{
                        //    Id = x.AnimalId,
                        //    Name = x.Name,
                        //    Weight = x.Weight,
                        //    HabitatType = x.Habitat.Name,
                        //    DietType = x.Diet.Name,
                        //    OriginCountry = x.Origin.Name,
                        //    SpeciesType = x.Species.Name
                        //    // Parent1 = (x.IsChildOf.ToList().Any()) ? x.IsChildOf.ToList()[0].Name : "Not available",
                        //    // Parent2 = (x.IsChildOf.ToList().Count() == 2) ? x.IsChildOf.ToList()[1].Name : "Not available"
                        //}).ToList();
                    }
                    if (animals.Any())
                    {
                        // Create the binding List
                        BindingList<AnimalDetails> resultSearch = new BindingList<AnimalDetails>(animals);

                        mskTxtNoRec.Text = animals.Count().ToString();

                        // Fill the data grid
                        dataGridVedit.DataSource = resultSearch;
                    }
                    else
                    {
                        MessageBox.Show("No data can be retrieved with the current search criteria.");
                    }
                }

                else
                {
                    // All the Required fields are FALSE
                    // I need to diplay ALL data

                    var tempAnimals = db.Animals.ToList();
                    animals = service.GetAllAnimalsInSublist(tempAnimals);

                    if (animals.Any())
                    {
                        // Create the binding List
                        BindingList<AnimalDetails> resultSearch = new BindingList<AnimalDetails>(animals);

                        mskTxtNoRec.Text = animals.Count().ToString();

                        // Fill the data grid
                        dataGridVedit.DataSource = resultSearch;
                    }
                    else
                    {
                        //dataGridVedit.DataSource = null; // If dgv is bound to datatable
                        //dataGridVedit.Rows.Clear();
                        //dataGridVedit.Refresh();

                        MessageBox.Show("No data can be retrieved with the current search criteria.");
                        // None among among: Animal Name, Species, Habitat, Diet has been FILLED. THe Search cannot start!
                        MessageBox.Show("Please choose at least one among: Animal name, Habitat, Diet and Species to Search Animals");
                    }

                }
            }
        }




        // **************
        // UPDATE BUTTON
        // **************
        private void update_Click(object sender, EventArgs e)
        {
            if (mskTxtAnimal.Text != "" && cmbHabitat.SelectedIndex != 0 && cmbSpecies.SelectedIndex != 0 && cmbDiet.SelectedIndex != 0 &&
                mskTxtWeight.Text != "" && SelectedAnimalID > 0)
            {
                // at least one field has been changed before pressin SAVE
                // Need to check:
                // - if data is ALREADY in DB or NEW records
                // data is assumed the same if all data the same as existing

                using (var db = new ZooContext())
                {
                    // Case with UPDATE Existing record

                    var newAnimal = new Animal();
                    var newOrigin = new Origin();
                    var tmpOrigin = new Origin();

                    if (cmbOrigin.SelectedIndex == 0 || cmbOrigin.Text == "") // All or empty
                    {
                        MessageBox.Show("Please choose an Origin country/continent.");
                        // Need to jump all the code below!
                    }
                    else //if (cmbOrigin.SelectedIndex == -1)  // A new country/continent has been inserted
                    {

                        tmpOrigin = (cmbOrigin.SelectedIndex == -1) ? db.Origins.Include("Animals").FirstOrDefault(c => c.Name == cmbOrigin.Text) : db.Origins.Include("Animals").FirstOrDefault(c => c.Name == cmbOrigin.SelectedItem.ToString());
                        if (tmpOrigin == null)
                        {
                            newOrigin.Name = cmbOrigin.Text;
                            newOrigin.Animals.Add(newAnimal);
                        }
                        else
                        {
                           // newAnimal.Origin.OriginId = tmpOrigin.OriginId;
                            
                            // Search the ID of the existing country/continent and save it in "newAnimal"
                           newAnimal.Origin = tmpOrigin; // db.Origins.Where(c => c.Name == cmbOrigin.SelectedItem.ToString()).Select(c => c.OriginId).SingleOrDefault();
                        }

                        //Check against DB
                        var temp = Convert.ToDouble(mskTxtWeight.Text);
                        var animalReadyExist = db.Animals.Where(c => c.Name == mskTxtAnimal.Text && c.Weight == temp &&
                                                      c.Habitat.Name == cmbHabitat.SelectedItem.ToString() &&
                                                      c.Species.Name == cmbSpecies.SelectedItem.ToString() &&
                                                      c.Origin.Name == newAnimal.Origin.Name &&
                                                      c.Diet.Name == cmbDiet.SelectedItem.ToString()).Any();

                        // Initializing some variables
                        var currentAnimaltoUpdate = service.GetSelectedAnimal(db, SelectedAnimalID);
                        var childParentsLinks = service.GetParentsLinks(db, currentAnimaltoUpdate.Name);
                        string parentInCombo1 = cmbParent1.SelectedItem?.ToString();
                        string parentInCombo2 = cmbParent2.SelectedItem?.ToString();
                        int childTotParents = childParentsLinks.Count(); // there might be links to parents which ave ParentID = null! I need to check these fields in the update!

                        bool skipUpdate = false;
                        var childChildrenLinks = currentAnimaltoUpdate.IsParentOf.ToList();

                        // Check that the current Animal´s parents are NOT the same as his/her own children
                        // Only 1-level is verified. Need a method for analysis av the full tree.
                        switch (childChildrenLinks.Count())
                        {
                            case 0: // current animal has NO children
                                break;
                            case 1:
                                if (childChildrenLinks[0].Child.Name == parentInCombo1 || (childChildrenLinks[0].Child.Name == parentInCombo2))
                                {
                                    MessageBox.Show("This Animal cannot have Parent(s) with same Name as his own children");
                                    skipUpdate = true;
                                }
                                break;
                            case 2:
                                if (childChildrenLinks[0].Child.Name == parentInCombo1 ||
                                    childChildrenLinks[0].Child.Name == parentInCombo2 ||
                                    childChildrenLinks[1].Child.Name == parentInCombo1 ||
                                    childChildrenLinks[1].Child.Name == parentInCombo2)
                                {
                                    MessageBox.Show("This Animal cannot have Parent(s) with same Name as his own children");
                                    skipUpdate = true;
                                }
                                break;
                        }
                        if (!skipUpdate)
                        {
                            bool addParent1 = false;
                            bool addParent2 = false;
                            bool remParent1 = false;
                            bool remParent2 = false;
                            bool sameName = false;

                            if (parentInCombo1 != "All" && parentInCombo2 != "All" && parentInCombo1 == parentInCombo2)
                            {
                                MessageBox.Show("Select two different parents or set to 'All' for no parents");
                                sameName = true;
                            }
                            else if (parentInCombo1 != "All" && parentInCombo1 == currentAnimaltoUpdate.Name)
                            {
                                // Parent1 name is SAME as Child --> update not possible
                                MessageBox.Show("Parent cannot have the same Name as the Animal");
                                sameName = true;
                            }
                            else if (parentInCombo2 != "All" && parentInCombo2 == currentAnimaltoUpdate.Name)
                            {
                                // Parent1 name is SAME as Child --> update not possible
                                MessageBox.Show("Parent cannot have the same Name as the Animal");
                                sameName = true;
                            }
                            else
                            {
                                switch (childTotParents)
                                {
                                    case 0: // no parents
                                        if (parentInCombo1 != "All")
                                        {
                                            addParent1 = true;
                                        }
                                        if (parentInCombo2 != "All")
                                        {
                                            addParent2 = true;
                                        }
                                        break;
                                    case 1: // 1 parent
                                        if (parentInCombo1 != "All")
                                        {
                                            if (parentInCombo1 == childParentsLinks.ToList()[0].Parent.Name)
                                            {
                                                addParent1 = false;
                                            }
                                            else
                                            {
                                                addParent1 = true;
                                            }
                                        }
                                        else
                                        {
                                            remParent1 = true;
                                        }

                                        if (parentInCombo2 != "All")
                                        {
                                            if (parentInCombo2 == childParentsLinks.ToList()[0].Parent.Name)
                                            {
                                                addParent2 = false;
                                            }
                                            else
                                            {
                                                addParent2 = true;
                                            }
                                        }
                                        break;
                                    case 2:  // 2 parents
                                        if (parentInCombo1 != "All")
                                        {
                                            if (parentInCombo1 == childParentsLinks.ToList()[0].Parent.Name)
                                            {
                                                addParent1 = false;
                                            }
                                            else if (parentInCombo1 == childParentsLinks.ToList()[1].Parent.Name)
                                            {
                                                addParent1 = false;
                                            }
                                            else
                                            {
                                                addParent1 = true;

                                            }
                                        }
                                        else
                                        {
                                            remParent1 = true;
                                        }

                                        if (parentInCombo2 != "All")
                                        {
                                            if (parentInCombo2 == childParentsLinks.ToList()[0].Parent.Name)
                                            {
                                                addParent2 = false;
                                            }
                                            else if (parentInCombo2 == childParentsLinks.ToList()[1].Parent.Name)
                                            {
                                                addParent2 = false;
                                            }
                                            else
                                            {
                                                addParent2 = true;
                                            }
                                        }
                                        else
                                        {
                                            remParent2 = true;
                                        }
                                        break;
                                }
                            }

                            //  animalReadyExist = (!addParent1 && !addParent2) || (!remParent1 && !remParent2);

                            if (animalReadyExist && !addParent1 && !addParent2 && !remParent1 && !remParent2)
                            {
                                if (!sameName)
                                {
                                    MessageBox.Show("Animal is already registered");
                                }
                            }
                            else
                            {
                                // Animal IS NOT in DB 
                                // OK Proceed with MODIFING One existing Animal detected by SelectedAnimalID Globl VAriable

                                // save all data in an new Animal() istance

                                newAnimal.Name = mskTxtAnimal.Text;
                                if (mskTxtWeight.Text == "")
                                {
                                    newAnimal.Weight = 0.0;
                                }
                                else
                                {
                                    newAnimal.Weight = Convert.ToDouble(mskTxtWeight.Text);
                                }
                                newAnimal.HabitatId = db.Habitats.Where(c => c.Name == cmbHabitat.SelectedItem.ToString()).Select(c => c.HabitatId).SingleOrDefault();
                                newAnimal.SpeciesId = db.Species.Where(c => c.Name == cmbSpecies.SelectedItem.ToString()).Select(c => c.SpeciesId).SingleOrDefault();
                                newAnimal.OriginId = newAnimal.Origin.OriginId; // db.Origins.Where(c => c.Name == newAnimal.Origin.Name).Select(c => c.OriginId).SingleOrDefault();
                                newAnimal.DietId = db.Diets.Where(c => c.Name == cmbDiet.SelectedItem.ToString()).Select(c => c.DietId).SingleOrDefault();

                                db.SaveChanges(); // I need this because when i create a new Origin, I have NO id assigned to the class Origin.
                                // Updating...
                                currentAnimaltoUpdate.Name = newAnimal.Name;
                                currentAnimaltoUpdate.Weight = newAnimal.Weight;
                                currentAnimaltoUpdate.HabitatId = newAnimal.HabitatId;
                                currentAnimaltoUpdate.SpeciesId = newAnimal.SpeciesId;
                                currentAnimaltoUpdate.OriginId = newAnimal.OriginId;
                                currentAnimaltoUpdate.DietId = newAnimal.DietId;


                                // Since animalReadyExist = false, then it is more efficient to REMOVE the links to the Parent(s) of the currentAnimaltoUpdate
                                // and ADD the names in the Comboboxes if any.
                                //foreach (var linkToParent in childParentsLinks)
                                var myanimal = new Animal();
                                var relation = new ChildParent();
                                while (currentAnimaltoUpdate.IsChildOf.Count() != 0)
                                {
                                    myanimal = db.Animals.Include("IsChildOf").Where(c => c.AnimalId == SelectedAnimalID).FirstOrDefault();
                                    relation = myanimal.IsChildOf.FirstOrDefault();
                                    myanimal.IsChildOf.Remove(relation);
                                    db.SaveChanges();
                                }

                                // I need to search in the db the Entities mapped to the parent 1/2 comboboxes and from there Add this new Animal
                                // as Child 
                                if (service.UpdateChildParentsLinks(db, currentAnimaltoUpdate, parentInCombo1))
                                {
                                    // test message to be removed
                                    MessageBox.Show("Parent 1 has been updated!");
                                }
                                // I re-evaluate the links attached to the child before calling the method.

                                if (service.UpdateChildParentsLinks(db, currentAnimaltoUpdate, parentInCombo2))
                                {
                                    // test message to be removed
                                    MessageBox.Show("Parent 2 has been updated!");
                                }
                                db.SaveChanges();
                                MessageBox.Show("Updated record successfull");
                            }
                        }
                        LoadCurrentZoo();
                        ClearData();
                    }
                } // Using()
            }
            else
            {
                // None of the fields has been changed before SAVE
                MessageBox.Show("Nothing to Update");
            }
        }
        // END OF EditPanel()
    }
}
