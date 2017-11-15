namespace ZooER
{
    partial class EditPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridVedit = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habitatTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dietTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originCountryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speciesTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.animalDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbHabitat = new System.Windows.Forms.ComboBox();
            this.habitatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.habitatBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cmbSpecies = new System.Windows.Forms.ComboBox();
            this.speciesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbDiet = new System.Windows.Forms.ComboBox();
            this.dietBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mskTxtAnimal = new System.Windows.Forms.MaskedTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbOrigin = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mskTxtWeight = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPrevMenu = new System.Windows.Forms.Button();
            this.cmbParent2 = new System.Windows.Forms.ComboBox();
            this.cmbParent1 = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.habitatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.habitatBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speciesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dietBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridVedit
            // 
            this.dataGridVedit.AutoGenerateColumns = false;
            this.dataGridVedit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVedit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn,
            this.habitatTypeDataGridViewTextBoxColumn,
            this.dietTypeDataGridViewTextBoxColumn,
            this.originCountryDataGridViewTextBoxColumn,
            this.speciesTypeDataGridViewTextBoxColumn,
            this.parent1DataGridViewTextBoxColumn,
            this.parent2DataGridViewTextBoxColumn});
            this.dataGridVedit.DataSource = this.animalDetailsBindingSource;
            this.dataGridVedit.Location = new System.Drawing.Point(29, 266);
            this.dataGridVedit.Name = "dataGridVedit";
            this.dataGridVedit.Size = new System.Drawing.Size(944, 223);
            this.dataGridVedit.TabIndex = 0;
            this.dataGridVedit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridVedit_CellClick);
            this.dataGridVedit.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridVedit_RowHeaderMouseClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            this.weightDataGridViewTextBoxColumn.HeaderText = "Weight";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            // 
            // habitatTypeDataGridViewTextBoxColumn
            // 
            this.habitatTypeDataGridViewTextBoxColumn.DataPropertyName = "HabitatType";
            this.habitatTypeDataGridViewTextBoxColumn.HeaderText = "Habitat";
            this.habitatTypeDataGridViewTextBoxColumn.Name = "habitatTypeDataGridViewTextBoxColumn";
            // 
            // dietTypeDataGridViewTextBoxColumn
            // 
            this.dietTypeDataGridViewTextBoxColumn.DataPropertyName = "DietType";
            this.dietTypeDataGridViewTextBoxColumn.HeaderText = "Diet";
            this.dietTypeDataGridViewTextBoxColumn.Name = "dietTypeDataGridViewTextBoxColumn";
            // 
            // originCountryDataGridViewTextBoxColumn
            // 
            this.originCountryDataGridViewTextBoxColumn.DataPropertyName = "OriginCountry";
            this.originCountryDataGridViewTextBoxColumn.HeaderText = "Origin";
            this.originCountryDataGridViewTextBoxColumn.Name = "originCountryDataGridViewTextBoxColumn";
            // 
            // speciesTypeDataGridViewTextBoxColumn
            // 
            this.speciesTypeDataGridViewTextBoxColumn.DataPropertyName = "SpeciesType";
            this.speciesTypeDataGridViewTextBoxColumn.HeaderText = "Species";
            this.speciesTypeDataGridViewTextBoxColumn.Name = "speciesTypeDataGridViewTextBoxColumn";
            // 
            // parent1DataGridViewTextBoxColumn
            // 
            this.parent1DataGridViewTextBoxColumn.DataPropertyName = "Parent1";
            this.parent1DataGridViewTextBoxColumn.HeaderText = "Parent 1";
            this.parent1DataGridViewTextBoxColumn.Name = "parent1DataGridViewTextBoxColumn";
            // 
            // parent2DataGridViewTextBoxColumn
            // 
            this.parent2DataGridViewTextBoxColumn.DataPropertyName = "Parent2";
            this.parent2DataGridViewTextBoxColumn.HeaderText = "Parent 2";
            this.parent2DataGridViewTextBoxColumn.Name = "parent2DataGridViewTextBoxColumn";
            // 
            // animalDetailsBindingSource
            // 
            this.animalDetailsBindingSource.DataSource = typeof(ZooER.ViewModels.AnimalDetails);
            // 
            // cmbHabitat
            // 
            this.cmbHabitat.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.habitatBindingSource, "Name", true));
            this.cmbHabitat.DataSource = this.habitatBindingSource;
            this.cmbHabitat.DisplayMember = "Name";
            this.cmbHabitat.FormattingEnabled = true;
            this.cmbHabitat.Location = new System.Drawing.Point(140, 166);
            this.cmbHabitat.Name = "cmbHabitat";
            this.cmbHabitat.Size = new System.Drawing.Size(121, 21);
            this.cmbHabitat.TabIndex = 1;
            this.cmbHabitat.ValueMember = "Name";
            // 
            // habitatBindingSource
            // 
            this.habitatBindingSource.DataSource = typeof(ZooER.Models.Habitat);
            // 
            // habitatBindingSource1
            // 
            this.habitatBindingSource1.DataSource = typeof(ZooER.Models.Habitat);
            // 
            // cmbSpecies
            // 
            this.cmbSpecies.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.speciesBindingSource, "Name", true));
            this.cmbSpecies.DataSource = this.speciesBindingSource;
            this.cmbSpecies.DisplayMember = "Name";
            this.cmbSpecies.FormattingEnabled = true;
            this.cmbSpecies.Location = new System.Drawing.Point(140, 130);
            this.cmbSpecies.Name = "cmbSpecies";
            this.cmbSpecies.Size = new System.Drawing.Size(121, 21);
            this.cmbSpecies.TabIndex = 2;
            this.cmbSpecies.ValueMember = "Name";
            this.cmbSpecies.TextChanged += new System.EventHandler(this.cmbSpecies_TextChanged);
            // 
            // speciesBindingSource
            // 
            this.speciesBindingSource.DataSource = typeof(ZooER.Models.Species);
            // 
            // cmbDiet
            // 
            this.cmbDiet.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dietBindingSource, "Name", true));
            this.cmbDiet.DataSource = this.dietBindingSource;
            this.cmbDiet.DisplayMember = "Name";
            this.cmbDiet.FormattingEnabled = true;
            this.cmbDiet.Location = new System.Drawing.Point(399, 95);
            this.cmbDiet.Name = "cmbDiet";
            this.cmbDiet.Size = new System.Drawing.Size(121, 21);
            this.cmbDiet.TabIndex = 3;
            this.cmbDiet.ValueMember = "Name";
            // 
            // dietBindingSource
            // 
            this.dietBindingSource.DataSource = typeof(ZooER.Models.Diet);
            // 
            // mskTxtAnimal
            // 
            this.mskTxtAnimal.Location = new System.Drawing.Point(140, 94);
            this.mskTxtAnimal.Name = "mskTxtAnimal";
            this.mskTxtAnimal.Size = new System.Drawing.Size(100, 20);
            this.mskTxtAnimal.TabIndex = 4;
            this.mskTxtAnimal.TextChanged += new System.EventHandler(this.mskTxtAnimal_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(852, 155);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(852, 120);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 29);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(852, 83);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 31);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Results panel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Animal Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(290, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Diet:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Habitat:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Species:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(324, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Search - Edit - Remove Animals";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(570, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Parent 1:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(290, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Origin Country:";
            // 
            // cmbOrigin
            // 
            this.cmbOrigin.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dietBindingSource, "Name", true));
            this.cmbOrigin.DataSource = this.dietBindingSource;
            this.cmbOrigin.DisplayMember = "Name";
            this.cmbOrigin.FormattingEnabled = true;
            this.cmbOrigin.Location = new System.Drawing.Point(399, 166);
            this.cmbOrigin.Name = "cmbOrigin";
            this.cmbOrigin.Size = new System.Drawing.Size(121, 21);
            this.cmbOrigin.TabIndex = 16;
            this.cmbOrigin.ValueMember = "Name";
            this.cmbOrigin.TextChanged += new System.EventHandler(this.cmbOrigin_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(290, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Weight:";
            // 
            // mskTxtWeight
            // 
            this.mskTxtWeight.Location = new System.Drawing.Point(399, 133);
            this.mskTxtWeight.Name = "mskTxtWeight";
            this.mskTxtWeight.Size = new System.Drawing.Size(121, 20);
            this.mskTxtWeight.TabIndex = 20;
            this.mskTxtWeight.TextChanged += new System.EventHandler(this.mskTxtWeight_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(570, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Parent 2:";
            // 
            // btnPrevMenu
            // 
            this.btnPrevMenu.Location = new System.Drawing.Point(884, 220);
            this.btnPrevMenu.Name = "btnPrevMenu";
            this.btnPrevMenu.Size = new System.Drawing.Size(89, 31);
            this.btnPrevMenu.TabIndex = 24;
            this.btnPrevMenu.Text = "Previous Menu";
            this.btnPrevMenu.UseVisualStyleBackColor = true;
            this.btnPrevMenu.Click += new System.EventHandler(this.btnPrevMenu_Click);
            // 
            // cmbParent2
            // 
            this.cmbParent2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dietBindingSource, "Name", true));
            this.cmbParent2.DataSource = this.dietBindingSource;
            this.cmbParent2.DisplayMember = "Name";
            this.cmbParent2.FormattingEnabled = true;
            this.cmbParent2.Location = new System.Drawing.Point(642, 134);
            this.cmbParent2.Name = "cmbParent2";
            this.cmbParent2.Size = new System.Drawing.Size(121, 21);
            this.cmbParent2.TabIndex = 25;
            this.cmbParent2.ValueMember = "Name";
            this.cmbParent2.TextChanged += new System.EventHandler(this.cmbParent2_TextChanged);
            // 
            // cmbParent1
            // 
            this.cmbParent1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dietBindingSource, "Name", true));
            this.cmbParent1.DataSource = this.dietBindingSource;
            this.cmbParent1.DisplayMember = "Name";
            this.cmbParent1.FormattingEnabled = true;
            this.cmbParent1.Location = new System.Drawing.Point(642, 95);
            this.cmbParent1.Name = "cmbParent1";
            this.cmbParent1.Size = new System.Drawing.Size(121, 21);
            this.cmbParent1.TabIndex = 26;
            this.cmbParent1.ValueMember = "Name";
            this.cmbParent1.TextChanged += new System.EventHandler(this.cmbParent1_TextChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(776, 222);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 29);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "CLEAR Data";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // EditPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 519);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbParent1);
            this.Controls.Add(this.cmbParent2);
            this.Controls.Add(this.btnPrevMenu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.mskTxtWeight);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbOrigin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.mskTxtAnimal);
            this.Controls.Add(this.cmbDiet);
            this.Controls.Add(this.cmbSpecies);
            this.Controls.Add(this.cmbHabitat);
            this.Controls.Add(this.dataGridVedit);
            this.Name = "EditPanel";
            this.Text = "Animals Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.habitatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.habitatBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speciesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dietBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridVedit;
        private System.Windows.Forms.ComboBox cmbHabitat;
        private System.Windows.Forms.ComboBox cmbSpecies;
        private System.Windows.Forms.ComboBox cmbDiet;
        private System.Windows.Forms.MaskedTextBox mskTxtAnimal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn motherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatherDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource animalDetailsBindingSource;
        private System.Windows.Forms.BindingSource speciesBindingSource;
        private System.Windows.Forms.BindingSource dietBindingSource;
        private System.Windows.Forms.BindingSource habitatBindingSource1;
        private System.Windows.Forms.BindingSource habitatBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbOrigin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mskTxtWeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPrevMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn habitatTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dietTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originCountryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent2DataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmbParent2;
        private System.Windows.Forms.ComboBox cmbParent1;
        private System.Windows.Forms.Button btnClear;
    }
}