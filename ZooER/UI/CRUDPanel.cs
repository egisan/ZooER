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


        public EditPanel()
        {
            InitializeComponent();
            LoadCurrentZoo();

            //BindingList<AnimalDetails> showAll = GetAnimalDetails();
            //dataGridVedit.DataSource = showAll;
        }

        public void LoadCurrentZoo()
        {
            service = new Utility();
            dataGridVedit.DataSource = service.GetAnimalDetails();
        }

        private void ClearData()
        {
            //nameChgd = addrChgd = typChgd = postcChgd = cityChgd = phoneChgd = emailChgd = false;

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


        // Click on one Cell in the DattaGrid
        private void dataGridVedit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // I need to save here the current "Animal information" before an "update/Delete"
            // is performed

            if (e.RowIndex >= 0)
            {
                // TO BE REMOVED ??

                lastSelectedRow = e.RowIndex;
                // lastSelectedColumn = e.ColumnIndex;

                // Animal Name
                mskTxtAnimal.Text = dataGridVedit.Rows[e.RowIndex].Cells[1].Value.ToString();

                // Species
                cmbSpecies.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[6].Value.ToString();

                // Habitat
                cmbHabitat.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[3].Value.ToString();

                // Diet
                cmbDiet.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[4].Value.ToString();

                // Weight
                mskTxtWeight.Text = dataGridVedit.Rows[e.RowIndex].Cells[2].Value.ToString();

                // Origin
                cmbOrigin.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[5].Value.ToString();

                // Parent 1
                cmbParent1.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[7].Value.ToString();

                // Parent 2
                cmbParent2.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[8].Value.ToString();

                // Alternative way:
                // cmbParent2.SelectedIndex = cmbParent2.Items.IndexOf(gridViewRUD.Rows[e.RowIndex].Cells[8].Value.ToString().Trim());


                // I need to retrieve here the ID in 'Animals' table that need to be updated/deleted in the DB
                //SelectedAnimalID = RetrieveSelectedAnimalID();
                SelectedAnimalID = (int)dataGridVedit.Rows[e.RowIndex].Cells[0].Value;
            }

        }


        // Select a row in the DataGrid
        private void dataGridVedit_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                // TO BE REMOVED ??

                lastSelectedRow = e.RowIndex;
                // lastSelectedColumn = e.ColumnIndex;

                // Animal Name
                mskTxtAnimal.Text = dataGridVedit.Rows[e.RowIndex].Cells[1].Value.ToString();

                // Species
                cmbSpecies.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[6].Value.ToString();

                // Habitat
                cmbHabitat.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[3].Value.ToString();

                // Diet
                cmbDiet.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[4].Value.ToString();

                // Weight
                mskTxtWeight.Text = dataGridVedit.Rows[e.RowIndex].Cells[2].Value.ToString();

                // Origin
                cmbOrigin.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[5].Value.ToString();

                // Parent 1
                cmbParent1.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[7].Value.ToString();

                // Parent 2
                cmbParent2.SelectedItem = dataGridVedit.Rows[e.RowIndex].Cells[8].Value.ToString();

                // Alternative way:
                // cmbParent2.SelectedIndex = cmbParent2.Items.IndexOf(gridViewRUD.Rows[e.RowIndex].Cells[8].Value.ToString().Trim());


                // I need to retrieve here the ID in 'Animals' table that need to be updated/deleted in the DB
                //SelectedAnimalID = RetrieveSelectedAnimalID();
                SelectedAnimalID = (int)dataGridVedit.Rows[e.RowIndex].Cells[0].Value;
            }
        }






    }
}
