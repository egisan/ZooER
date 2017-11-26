namespace ZooER.UI
{
    partial class SaveNewDrug
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
            this.txtDrug = new System.Windows.Forms.TextBox();
            this.SaveDrug = new System.Windows.Forms.Label();
            this.DrugName = new System.Windows.Forms.Label();
            this.btnDrugSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDrug
            // 
            this.txtDrug.Location = new System.Drawing.Point(97, 75);
            this.txtDrug.Name = "txtDrug";
            this.txtDrug.ReadOnly = true;
            this.txtDrug.Size = new System.Drawing.Size(158, 20);
            this.txtDrug.TabIndex = 0;
            // 
            // SaveDrug
            // 
            this.SaveDrug.AutoSize = true;
            this.SaveDrug.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SaveDrug.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveDrug.Location = new System.Drawing.Point(45, 28);
            this.SaveDrug.Name = "SaveDrug";
            this.SaveDrug.Size = new System.Drawing.Size(175, 27);
            this.SaveDrug.TabIndex = 1;
            this.SaveDrug.Text = "Save a new drug";
            this.SaveDrug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DrugName
            // 
            this.DrugName.AutoSize = true;
            this.DrugName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrugName.Location = new System.Drawing.Point(11, 76);
            this.DrugName.Name = "DrugName";
            this.DrugName.Size = new System.Drawing.Size(80, 16);
            this.DrugName.TabIndex = 2;
            this.DrugName.Text = "Drug Name:";
            // 
            // btnDrugSave
            // 
            this.btnDrugSave.Location = new System.Drawing.Point(64, 119);
            this.btnDrugSave.Name = "btnDrugSave";
            this.btnDrugSave.Size = new System.Drawing.Size(126, 40);
            this.btnDrugSave.TabIndex = 3;
            this.btnDrugSave.Text = "SAVE";
            this.btnDrugSave.UseVisualStyleBackColor = true;
            // 
            // SaveNewDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 181);
            this.Controls.Add(this.btnDrugSave);
            this.Controls.Add(this.DrugName);
            this.Controls.Add(this.SaveDrug);
            this.Controls.Add(this.txtDrug);
            this.Name = "SaveNewDrug";
            this.Text = "New Drug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDrug;
        private System.Windows.Forms.Label SaveDrug;
        private System.Windows.Forms.Label DrugName;
        private System.Windows.Forms.Button btnDrugSave;
    }
}