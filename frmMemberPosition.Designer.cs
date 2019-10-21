namespace RegnalUDB
{
    partial class frmMemberPosition
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
            this.lblMember = new System.Windows.Forms.Label();
            this.autoLabel18 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.lstPosition = new Syncfusion.WinForms.ListView.SfListView();
            this.SuspendLayout();
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMember.Location = new System.Drawing.Point(391, 55);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(66, 20);
            this.lblMember.TabIndex = 160;
            this.lblMember.Text = "Ninguno";
            this.lblMember.Click += new System.EventHandler(this.lblMember_Click);
            // 
            // autoLabel18
            // 
            this.autoLabel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel18.DX = -168;
            this.autoLabel18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel18.LabeledControl = this.lblMember;
            this.autoLabel18.Location = new System.Drawing.Point(223, 55);
            this.autoLabel18.Name = "autoLabel18";
            this.autoLabel18.Size = new System.Drawing.Size(164, 20);
            this.autoLabel18.TabIndex = 159;
            this.autoLabel18.Text = "Miembro seleccionado:";
            this.autoLabel18.ThemeName = "Office2016White";
            this.autoLabel18.Click += new System.EventHandler(this.autoLabel18_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(222, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 165;
            this.label1.Text = "Cargos asignados";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.btnSaveChanges.Location = new System.Drawing.Point(767, 389);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(242, 45);
            this.btnSaveChanges.TabIndex = 167;
            this.btnSaveChanges.Text = "Guardar cambios";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // lstPosition
            // 
            this.lstPosition.AccessibleName = "ScrollControl";
            this.lstPosition.CheckBoxSelectionMode = Syncfusion.WinForms.ListView.Enums.CheckBoxSelectionMode.SynchronizeSelection;
            this.lstPosition.Location = new System.Drawing.Point(226, 142);
            this.lstPosition.Name = "lstPosition";
            this.lstPosition.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstPosition.ShowCheckBoxes = true;
            this.lstPosition.Size = new System.Drawing.Size(550, 199);
            this.lstPosition.TabIndex = 168;
            this.lstPosition.Text = "sfListView1";
            this.lstPosition.Click += new System.EventHandler(this.lstPosition_Click);
            // 
            // frmMemberPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lstPosition);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMember);
            this.Controls.Add(this.autoLabel18);
            this.Name = "frmMemberPosition";
            this.Size = new System.Drawing.Size(1038, 519);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveChanges;
        public Syncfusion.WinForms.ListView.SfListView lstPosition;
        public System.Windows.Forms.Label lblMember;
    }
}
