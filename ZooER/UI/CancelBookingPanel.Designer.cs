namespace ZooER
{
    partial class CancelBookingPanel
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
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAnimal = new System.Windows.Forms.ComboBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.btnPrevMenu = new System.Windows.Forms.Button();
            this.btnConf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(89, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Cancel Booking";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Animal (patient):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(91, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Time:";
            // 
            // cmbAnimal
            // 
            this.cmbAnimal.FormattingEnabled = true;
            this.cmbAnimal.Location = new System.Drawing.Point(207, 150);
            this.cmbAnimal.Name = "cmbAnimal";
            this.cmbAnimal.Size = new System.Drawing.Size(121, 21);
            this.cmbAnimal.TabIndex = 15;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(207, 113);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 17;
            // 
            // btnPrevMenu
            // 
            this.btnPrevMenu.Location = new System.Drawing.Point(94, 244);
            this.btnPrevMenu.Name = "btnPrevMenu";
            this.btnPrevMenu.Size = new System.Drawing.Size(104, 28);
            this.btnPrevMenu.TabIndex = 20;
            this.btnPrevMenu.Text = "Previous menu";
            this.btnPrevMenu.UseVisualStyleBackColor = true;
            // 
            // btnConf
            // 
            this.btnConf.Location = new System.Drawing.Point(289, 228);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(107, 44);
            this.btnConf.TabIndex = 19;
            this.btnConf.Text = "CONFIRM";
            this.btnConf.UseVisualStyleBackColor = true;
            // 
            // CancelBookingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 384);
            this.Controls.Add(this.btnPrevMenu);
            this.Controls.Add(this.btnConf);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAnimal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Name = "CancelBookingPanel";
            this.Text = "Cancel Booking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAnimal;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button btnPrevMenu;
        private System.Windows.Forms.Button btnConf;
    }
}