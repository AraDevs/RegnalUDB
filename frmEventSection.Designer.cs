namespace RegnalUDB
{
    partial class frmEventSection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstSection = new Syncfusion.WinForms.ListView.SfListView();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEventSection = new System.Windows.Forms.Label();
            this.autoLabel18 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.SuspendLayout();
            // 
            // lstSection
            // 
            this.lstSection.AccessibleName = "ScrollControl";
            this.lstSection.CheckBoxSelectionMode = Syncfusion.WinForms.ListView.Enums.CheckBoxSelectionMode.SynchronizeSelection;
            this.lstSection.Location = new System.Drawing.Point(157, 105);
            this.lstSection.Name = "lstSection";
            this.lstSection.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstSection.ShowCheckBoxes = true;
            this.lstSection.Size = new System.Drawing.Size(550, 199);
            this.lstSection.TabIndex = 178;
            this.lstSection.Text = "sfListView1";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveChanges.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(170)))));
            this.btnSaveChanges.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(251)))));
            this.btnSaveChanges.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(251)))));
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(170)))));
            this.btnSaveChanges.Location = new System.Drawing.Point(727, 259);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(242, 45);
            this.btnSaveChanges.TabIndex = 177;
            this.btnSaveChanges.Text = "Guardar cambios";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(153, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 176;
            this.label1.Text = "Secciones asignadas";
            // 
            // lblEventSection
            // 
            this.lblEventSection.AutoSize = true;
            this.lblEventSection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventSection.Location = new System.Drawing.Point(304, 29);
            this.lblEventSection.Name = "lblEventSection";
            this.lblEventSection.Size = new System.Drawing.Size(66, 20);
            this.lblEventSection.TabIndex = 175;
            this.lblEventSection.Text = "Ninguno";
            // 
            // autoLabel18
            // 
            this.autoLabel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel18.DX = -152;
            this.autoLabel18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel18.LabeledControl = this.lblEventSection;
            this.autoLabel18.Location = new System.Drawing.Point(152, 29);
            this.autoLabel18.Name = "autoLabel18";
            this.autoLabel18.Size = new System.Drawing.Size(148, 20);
            this.autoLabel18.TabIndex = 174;
            this.autoLabel18.Text = "Evento seleccionado:";
            this.autoLabel18.ThemeName = "Office2016White";
            // 
            // frmEventSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lstSection);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEventSection);
            this.Controls.Add(this.autoLabel18);
            this.Name = "frmEventSection";
            this.Size = new System.Drawing.Size(989, 338);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Syncfusion.WinForms.ListView.SfListView lstSection;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblEventSection;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel18;
    }
}
