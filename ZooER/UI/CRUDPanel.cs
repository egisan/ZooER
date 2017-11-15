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
            dataGridVedit.DataSource = service.GetAnimalDetails();

            SetComboBoxProperties();
            FillComboBoxes();
        }


        private void FillComboBoxes()
        {
            FillSpeciesCombo();
            FillHabitatCombo();
            FillDietCombo();
            FillOrigin();
            //FillParent1();
            //FillParent2();
        }

        private void FillOrigin()
        {
            using (var db = new ZooContext())
            {
                cmbOrigin.DataSource = db.Origins.ToList();
                cmbOrigin.ValueMember = "OriginId";
                cmbOrigin.DisplayMember = "Name";

                // Default value
                cmbOrigin.SelectedIndex = -1;
            }
        }

        private void FillDietCombo()
        {
            using (var db = new ZooContext())
            {
                // db.Diets.Add(0, new Diet() { DietId = 0, Name = "Select a sector." });

                cmbDiet.DataSource = db.Diets.ToList();
                cmbDiet.ValueMember = "DietId";
                cmbDiet.DisplayMember = "Name";

                // Default value
                cmbDiet.SelectedIndex = -1;
            }
        }

        private void FillHabitatCombo()
        {
            using (var db = new ZooContext())
            {
                cmbHabitat.DataSource = db.Habitats.ToList();
                cmbHabitat.ValueMember = "HabitatId";
                cmbHabitat.DisplayMember = "Name";

                // Default value
                cmbHabitat.SelectedIndex = -1;

            }
        }

        private void FillSpeciesCombo()
        {
            using (var db = new ZooContext())
            {
                cmbSpecies.DataSource = db.Species.ToList();
                cmbSpecies.ValueMember = "SpeciesId";
                cmbSpecies.DisplayMember = "Name";

                // Default value
                cmbSpecies.SelectedIndex = -1;
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
            Form frm = new Menu();
            frm.Show();
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
                // retrieve animalId from the datagrid and find attached Habitat value!
                var species = db.Animals.Where(c => c.AnimalId == selectedAnimalID).SingleOrDefault();
                cmbSpecies.SelectedValue = species.SpeciesId;
            }

            // Habitat
            using (var db = new ZooContext())
            {
                // retrieve animalId from the datagrid and find attached Habitat value!
                var habitat = db.Animals.Where(c => c.AnimalId == selectedAnimalID).SingleOrDefault();
                cmbHabitat.SelectedValue = habitat.HabitatId;
            }

            // Diet
            using (var db = new ZooContext())
            {
                // retrieve animalId from the datagrid and find attached Habitat value!
                var diet = db.Animals.Where(c => c.AnimalId == selectedAnimalID).SingleOrDefault();
                cmbDiet.SelectedValue = diet.DietId;
            }

            // Origin
            using (var db = new ZooContext())
            {
                // retrieve animalId from the datagrid and find attached Habitat value!
                var origin = db.Animals.Where(c => c.AnimalId == selectedAnimalID).SingleOrDefault();
                cmbOrigin.SelectedValue = origin.OriginId;
            }

            // Parent 1
            using (var db = new ZooContext())
            {
                // retrieve animalId from the datagrid and find attached Habitat value!
                var par1 = db.Animals.Where(c => c.AnimalId == selectedAnimalID).SingleOrDefault();
                cmbParent1.SelectedValue = par1.OriginId;
            }

            // Parent 2
            using (var db = new ZooContext())
            {
                // retrieve animalId from the datagrid and find attached Habitat value!
                var par2 = db.Animals.Where(c => c.AnimalId == selectedAnimalID).SingleOrDefault();
                cmbParent2.SelectedValue = par2.OriginId;
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

            string conditionStr = "";
            string insertAND = " ";


            if (mskTxtAnimal.Text != "")
            {
                nameIn = true;
                conditionStr = "c.Name LIKE '%' + @Name + '%'";
            }

            if (cmbSpecies.SelectedItem.ToString() != "")
            {
                speciesIn = true;
                if (nameIn == true)
                {
                    insertAND = " AND ";
                }
                conditionStr = conditionStr + insertAND + "ct.TypeName LIKE '%' + @TypeName + '%'";
            }

            if (cmbHabitat.Text != "")
            {
                habitatIn = true;
                if (speciesIn == true || nameIn == true)
                {
                    insertAND = " AND ";
                }
                conditionStr = conditionStr + insertAND + "ct.City LIKE '%' + @City + '%'";
            }

            if (cmbDiet.Text != "")
            {
                dietIn = true;
                if (habitatIn == true || speciesIn == true || nameIn == true)
                {
                    insertAND = " AND ";
                }
                conditionStr = conditionStr + insertAND + "ct.Address LIKE '%' + @Address + '%'";
            }

            if (mskTxtWeight.Text != "")
            {
                weightIn = true;
                if (dietIn == true || habitatIn == true || speciesIn == true || nameIn == true)
                {
                    insertAND = " AND ";
                }
                conditionStr = conditionStr + insertAND + "ct.PostalCode LIKE '%' + @PostalCode + '%'";
            }

            if (cmbOrigin.Text != "")
            {
                originIn = true;
                if (weightIn == true || dietIn == true || habitatIn == true || speciesIn == true || nameIn == true)
                {
                    insertAND = " AND ";
                }
                conditionStr = conditionStr + insertAND + "ct.PhoneNo LIKE '%' + @PhoneNo + '%'";
            }

            if (cmbParent1.Text != "")
            {
                par1In = true;
                if (originIn == true || weightIn == true || dietIn == true || habitatIn == true || speciesIn == true || nameIn == true)
                {
                    insertAND = " AND ";
                }
                conditionStr = conditionStr + insertAND + "ct.Email LIKE '%' + @Email + '%'";
            }

            if (cmbParent2.Text != "")
            {
                par2In = true;
                if (par1In == true || originIn == true || weightIn == true || dietIn == true || habitatIn == true || speciesIn == true || nameIn == true)
                {
                    insertAND = " AND ";
                }
                conditionStr = conditionStr + insertAND + "ct.Email LIKE '%' + @Email + '%'";
            }


            if (nameIn || speciesIn || habitatIn || dietIn || weightIn || originIn || par1In || par2In)
            {
                using (var db = new ZooContext())
                {
                    var animals = new List<Animal>();

                    if (nameIn && speciesIn && habitatIn && dietIn)
                    {
                        animals = db.Animals.Where(c => c.Name.Contains(mskTxtAnimal.Text) &&
                                                        c.Species.Name == cmbSpecies.SelectedItem.ToString() &&
                                                        c.Habitat.Name == cmbHabitat.SelectedItem.ToString() &&
                                                        c.Diet.Name == cmbDiet.SelectedItem.ToString()).ToList();
                    }
                    else if (nameIn && speciesIn && habitatIn)
                    {
                        animals = db.Animals.Where(c => c.Name.Contains(mskTxtAnimal.Text) &&
                                                        c.Species.Name == cmbSpecies.SelectedItem.ToString() &&
                                                        c.Habitat.Name == cmbHabitat.SelectedItem.ToString()).ToList();
                    }
                    else if (nameIn && speciesIn)
                    {
                        animals = db.Animals.Where(c => c.Name.Contains(mskTxtAnimal.Text) &&
                                                        c.Species.Name == cmbSpecies.SelectedItem.ToString()).ToList();
                    }
                    else if (nameIn)
                    {
                        animals = db.Animals.Where(c => c != null && c.Name.Contains(mskTxtAnimal.Text)).ToList();
                    }
                    
                    if (animals.

                }

                var commandText = "SELECT c.Name, ct.TypeName, ct.Address, ct.PostalCode, ct.City, ct.PhoneNo, ct.Email " +
                              "FROM Contacts c INNER JOIN ContactsTypes bridge " +
                              "ON c.ContactId = bridge.ContactId " +
                              "INNER JOIN CTypes ct " +
                              "ON ct.TypeId = bridge.TypeId " +
                              "WHERE (" + conditionStr + ")";

            }
            BindingList<Contact> addresses = reader.GetContacts(commandText, CommandType.Text, searchParams);

            // Show the number of records found after applying Search()
            maskedTxtAddNo.Text = addresses.Count().ToString();

            // Fill the GridView with addresses
            gridViewRUD.DataSource = addresses;




        }






        // END OF EditPanel()
    }
}
