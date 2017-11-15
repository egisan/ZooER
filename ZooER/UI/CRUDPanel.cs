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
                cmbOrigin.Text = "Select an item";
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

                //cmbDiet.SelectedIndex = -1;
                //cmbDiet.Text = "Select an item";
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
                //cmbHabitat.SelectedIndex = -1;
                //cmbHabitat.Text = "Select an item";


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
                cmbSpecies.Text = "Select an item";
            }
        }


        private void ClearData()
        {
            animalNameChgd = habitatChgd = speciesChgd = dietChgd = weightChgd = originChgd = parent1Chgd = parent2Chgd = false;

            mskTxtAnimal.Text = "";

            //  cmbSpieces.SelectedIndex = cmbSpieces.Items.IndexOf("All");
            cmbSpecies.SelectedText = "";

            //  cmbHabitat.SelectedIndex = cmbHabitat.Items.IndexOf("All");
            cmbHabitat.SelectedText = "";

            //  cmbDiet.SelectedIndex = cmbDiet.Items.IndexOf("All");
            cmbDiet.SelectedText = "";

            mskTxtWeight.Text = "";

            //  cmbOrigin.SelectedIndex = cmbOrigin.Items.IndexOf("All");
            cmbOrigin.SelectedText = "";

            // cmbParent1.SelectedIndex = cmbParent1.Items.IndexOf("All");
            cmbParent1.SelectedText = "";

            // cmbParent2.SelectedIndex = cmbParent2.Items.IndexOf("All");
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






        // END OF EditPanel()
    }
}
