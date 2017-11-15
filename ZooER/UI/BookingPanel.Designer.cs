namespace ZooER
{
    partial class BookingPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.cmbAnimal = new System.Windows.Forms.ComboBox();
            this.mskTxtDes = new System.Windows.Forms.MaskedTextBox();
            this.cmbDrugs = new System.Windows.Forms.ComboBox();
            this.mskTxtTime = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnPrevMenu = new System.Windows.Forms.Button();
            this.bookingModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookingModelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bookingModelBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bookingModelBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.bookingModelBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bookingModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingModelBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingModelBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingModelBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingModelBindingSource4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doctor Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Animal (patient):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Drugs:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Diagnosis:";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bookingModelBindingSource1, "DoctorName", true));
            this.cmbDoctor.DataSource = this.bookingModelBindingSource;
            this.cmbDoctor.DisplayMember = "DoctorName";
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(223, 100);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(121, 21);
            this.cmbDoctor.TabIndex = 5;
            this.cmbDoctor.ValueMember = "DoctorName";
            // 
            // cmbAnimal
            // 
            this.cmbAnimal.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bookingModelBindingSource3, "NamePatient", true));
            this.cmbAnimal.DataSource = this.bookingModelBindingSource2;
            this.cmbAnimal.DisplayMember = "NamePatient";
            this.cmbAnimal.FormattingEnabled = true;
            this.cmbAnimal.Location = new System.Drawing.Point(223, 137);
            this.cmbAnimal.Name = "cmbAnimal";
            this.cmbAnimal.Size = new System.Drawing.Size(121, 21);
            this.cmbAnimal.TabIndex = 6;
            this.cmbAnimal.ValueMember = "NamePatient";
            // 
            // mskTxtDes
            // 
            this.mskTxtDes.Location = new System.Drawing.Point(223, 214);
            this.mskTxtDes.Name = "mskTxtDes";
            this.mskTxtDes.Size = new System.Drawing.Size(208, 20);
            this.mskTxtDes.TabIndex = 9;
            // 
            // cmbDrugs
            // 
            this.cmbDrugs.FormattingEnabled = true;
            this.cmbDrugs.Location = new System.Drawing.Point(223, 251);
            this.cmbDrugs.Name = "cmbDrugs";
            this.cmbDrugs.Size = new System.Drawing.Size(121, 21);
            this.cmbDrugs.TabIndex = 8;
            // 
            // mskTxtTime
            // 
            this.mskTxtTime.Location = new System.Drawing.Point(223, 175);
            this.mskTxtTime.Mask = "00/00/0000 90:00";
            this.mskTxtTime.Name = "mskTxtTime";
            this.mskTxtTime.Size = new System.Drawing.Size(100, 20);
            this.mskTxtTime.TabIndex = 10;
            this.mskTxtTime.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(85, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "Book Visit";
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(388, 294);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(107, 44);
            this.btnBook.TabIndex = 13;
            this.btnBook.Text = "BOOK";
            this.btnBook.UseVisualStyleBackColor = true;
            // 
            // btnPrevMenu
            // 
            this.btnPrevMenu.Location = new System.Drawing.Point(91, 310);
            this.btnPrevMenu.Name = "btnPrevMenu";
            this.btnPrevMenu.Size = new System.Drawing.Size(104, 28);
            this.btnPrevMenu.TabIndex = 14;
            this.btnPrevMenu.Text = "Previous menu";
            this.btnPrevMenu.UseVisualStyleBackColor = true;
            // 
            // bookingModelBindingSource
            // 
            this.bookingModelBindingSource.DataSource = typeof(ZooER.ViewModels.BookingModel);
            // 
            // bookingModelBindingSource1
            // 
            this.bookingModelBindingSource1.DataSource = typeof(ZooER.ViewModels.BookingModel);
            // 
            // bookingModelBindingSource2
            // 
            this.bookingModelBindingSource2.DataSource = typeof(ZooER.ViewModels.BookingModel);
            // 
            // bookingModelBindingSource3
            // 
            this.bookingModelBindingSource3.DataSource = typeof(ZooER.ViewModels.BookingModel);
            // 
            // bookingModelBindingSource4
            // 
            this.bookingModelBindingSource4.DataSource = typeof(ZooER.ViewModels.BookingModel);
            // 
            // BookingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 382);
            this.Controls.Add(this.btnPrevMenu);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mskTxtTime);
            this.Controls.Add(this.mskTxtDes);
            this.Controls.Add(this.cmbDrugs);
            this.Controls.Add(this.cmbAnimal);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BookingPanel";
            this.Text = "Veterinary Booking Panel";
            ((System.ComponentModel.ISupportInitialize)(this.bookingModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingModelBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingModelBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingModelBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingModelBindingSource4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.ComboBox cmbAnimal;
        private System.Windows.Forms.MaskedTextBox mskTxtDes;
        private System.Windows.Forms.ComboBox cmbDrugs;
        private System.Windows.Forms.MaskedTextBox mskTxtTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnPrevMenu;
        private System.Windows.Forms.BindingSource bookingModelBindingSource1;
        private System.Windows.Forms.BindingSource bookingModelBindingSource;
        private System.Windows.Forms.BindingSource bookingModelBindingSource3;
        private System.Windows.Forms.BindingSource bookingModelBindingSource2;
        private System.Windows.Forms.BindingSource bookingModelBindingSource4;
    }
}