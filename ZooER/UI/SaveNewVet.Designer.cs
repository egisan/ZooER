﻿namespace ZooER.UI
{
    partial class SaveNewVet
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
            this.btnDoctorSave = new System.Windows.Forms.Button();
            this.DoctorName = new System.Windows.Forms.Label();
            this.SaveDoctor = new System.Windows.Forms.Label();
            this.textDoctor = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDoctorSave
            // 
            this.btnDoctorSave.Location = new System.Drawing.Point(176, 133);
            this.btnDoctorSave.Name = "btnDoctorSave";
            this.btnDoctorSave.Size = new System.Drawing.Size(84, 28);
            this.btnDoctorSave.TabIndex = 7;
            this.btnDoctorSave.Text = "SAVE";
            this.btnDoctorSave.UseVisualStyleBackColor = true;
            this.btnDoctorSave.Click += new System.EventHandler(this.btnDoctorSave_Click);
            // 
            // DoctorName
            // 
            this.DoctorName.AutoSize = true;
            this.DoctorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoctorName.Location = new System.Drawing.Point(5, 81);
            this.DoctorName.Name = "DoctorName";
            this.DoctorName.Size = new System.Drawing.Size(91, 16);
            this.DoctorName.TabIndex = 6;
            this.DoctorName.Text = "Doctor Name:";
            // 
            // SaveDoctor
            // 
            this.SaveDoctor.AutoSize = true;
            this.SaveDoctor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SaveDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveDoctor.Location = new System.Drawing.Point(42, 25);
            this.SaveDoctor.Name = "SaveDoctor";
            this.SaveDoctor.Size = new System.Drawing.Size(192, 27);
            this.SaveDoctor.TabIndex = 5;
            this.SaveDoctor.Text = "Save a new doctor";
            this.SaveDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textDoctor
            // 
            this.textDoctor.Location = new System.Drawing.Point(102, 80);
            this.textDoctor.Name = "textDoctor";
            this.textDoctor.ReadOnly = true;
            this.textDoctor.Size = new System.Drawing.Size(158, 20);
            this.textDoctor.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(42, 133);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SaveNewVet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 192);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDoctorSave);
            this.Controls.Add(this.DoctorName);
            this.Controls.Add(this.SaveDoctor);
            this.Controls.Add(this.textDoctor);
            this.Name = "SaveNewVet";
            this.Text = "New Doctor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDoctorSave;
        private System.Windows.Forms.Label DoctorName;
        private System.Windows.Forms.Label SaveDoctor;
        private System.Windows.Forms.TextBox textDoctor;
        private System.Windows.Forms.Button btnCancel;
    }
}