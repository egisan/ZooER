namespace ZooER
{
    partial class SearchPanel
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.animalDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habitatTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dietTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originCountryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speciesTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fatherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speciesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dietBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.habitatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.habitatBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speciesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dietBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.habitatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.habitatBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn,
            this.habitatTypeDataGridViewTextBoxColumn,
            this.dietTypeDataGridViewTextBoxColumn,
            this.originCountryDataGridViewTextBoxColumn,
            this.speciesTypeDataGridViewTextBoxColumn,
            this.motherDataGridViewTextBoxColumn,
            this.fatherDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.animalDetailsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 228);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(944, 232);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.habitatBindingSource1, "Name", true));
            this.comboBox1.DataSource = this.habitatBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(381, 141);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "Name";
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.speciesBindingSource, "Name", true));
            this.comboBox2.DataSource = this.speciesBindingSource;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(130, 141);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.ValueMember = "Name";
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dietBindingSource, "Name", true));
            this.comboBox3.DataSource = this.dietBindingSource;
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(381, 95);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 3;
            this.comboBox3.ValueMember = "Name";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(130, 94);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(610, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 41);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(610, 111);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 41);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(610, 165);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 41);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(310, 192);
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
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Animal type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(290, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Diet:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(290, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Habitat:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Spieces:";
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
            // animalDetailsBindingSource
            // 
            this.animalDetailsBindingSource.DataSource = typeof(ZooER.ViewModels.AnimalDetails);
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
            this.habitatTypeDataGridViewTextBoxColumn.HeaderText = "HabitatType";
            this.habitatTypeDataGridViewTextBoxColumn.Name = "habitatTypeDataGridViewTextBoxColumn";
            // 
            // dietTypeDataGridViewTextBoxColumn
            // 
            this.dietTypeDataGridViewTextBoxColumn.DataPropertyName = "DietType";
            this.dietTypeDataGridViewTextBoxColumn.HeaderText = "DietType";
            this.dietTypeDataGridViewTextBoxColumn.Name = "dietTypeDataGridViewTextBoxColumn";
            // 
            // originCountryDataGridViewTextBoxColumn
            // 
            this.originCountryDataGridViewTextBoxColumn.DataPropertyName = "OriginCountry";
            this.originCountryDataGridViewTextBoxColumn.HeaderText = "OriginCountry";
            this.originCountryDataGridViewTextBoxColumn.Name = "originCountryDataGridViewTextBoxColumn";
            // 
            // speciesTypeDataGridViewTextBoxColumn
            // 
            this.speciesTypeDataGridViewTextBoxColumn.DataPropertyName = "SpeciesType";
            this.speciesTypeDataGridViewTextBoxColumn.HeaderText = "SpeciesType";
            this.speciesTypeDataGridViewTextBoxColumn.Name = "speciesTypeDataGridViewTextBoxColumn";
            // 
            // motherDataGridViewTextBoxColumn
            // 
            this.motherDataGridViewTextBoxColumn.DataPropertyName = "Mother";
            this.motherDataGridViewTextBoxColumn.HeaderText = "Mother";
            this.motherDataGridViewTextBoxColumn.Name = "motherDataGridViewTextBoxColumn";
            // 
            // fatherDataGridViewTextBoxColumn
            // 
            this.fatherDataGridViewTextBoxColumn.DataPropertyName = "Father";
            this.fatherDataGridViewTextBoxColumn.HeaderText = "Father";
            this.fatherDataGridViewTextBoxColumn.Name = "fatherDataGridViewTextBoxColumn";
            // 
            // speciesBindingSource
            // 
            this.speciesBindingSource.DataSource = typeof(ZooER.Models.Species);
            // 
            // dietBindingSource
            // 
            this.dietBindingSource.DataSource = typeof(ZooER.Models.Diet);
            // 
            // habitatBindingSource
            // 
            this.habitatBindingSource.DataSource = typeof(ZooER.Models.Habitat);
            // 
            // habitatBindingSource1
            // 
            this.habitatBindingSource1.DataSource = typeof(ZooER.Models.Habitat);
            // 
            // SearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 472);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SearchPanel";
            this.Text = "Animals Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speciesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dietBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.habitatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.habitatBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn habitatTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dietTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originCountryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatherDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource animalDetailsBindingSource;
        private System.Windows.Forms.BindingSource speciesBindingSource;
        private System.Windows.Forms.BindingSource dietBindingSource;
        private System.Windows.Forms.BindingSource habitatBindingSource1;
        private System.Windows.Forms.BindingSource habitatBindingSource;
    }
}