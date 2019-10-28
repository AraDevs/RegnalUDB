namespace RegnalUDB
{
    partial class frmBlackList
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbMembers = new Syncfusion.WinForms.ListView.SfComboBox();
            this.cmbResponsable = new Syncfusion.WinForms.ListView.SfComboBox();
            this.btnNewClean = new System.Windows.Forms.Button();
            this.btnSaveModify = new System.Windows.Forms.Button();
            this.chbStatus = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.autoLabel8 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvBlackList = new System.Windows.Forms.DataGridView();
            this.txtSearch = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbResponsable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlackList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.cmbMembers);
            this.panel2.Controls.Add(this.cmbResponsable);
            this.panel2.Controls.Add(this.btnNewClean);
            this.panel2.Controls.Add(this.btnSaveModify);
            this.panel2.Controls.Add(this.chbStatus);
            this.panel2.Controls.Add(this.autoLabel8);
            this.panel2.Controls.Add(this.autoLabel6);
            this.panel2.Controls.Add(this.autoLabel5);
            this.panel2.Controls.Add(this.autoLabel2);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Location = new System.Drawing.Point(33, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1038, 204);
            this.panel2.TabIndex = 7;
            // 
            // cmbMembers
            // 
            this.cmbMembers.Location = new System.Drawing.Point(635, 74);
            this.cmbMembers.Name = "cmbMembers";
            this.cmbMembers.Size = new System.Drawing.Size(218, 28);
            this.cmbMembers.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbMembers.TabIndex = 125;
            // 
            // cmbResponsable
            // 
            this.cmbResponsable.Location = new System.Drawing.Point(635, 22);
            this.cmbResponsable.Name = "cmbResponsable";
            this.cmbResponsable.Size = new System.Drawing.Size(218, 28);
            this.cmbResponsable.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbResponsable.TabIndex = 124;
            // 
            // btnNewClean
            // 
            this.btnNewClean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewClean.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(170)))));
            this.btnNewClean.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(251)))));
            this.btnNewClean.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(251)))));
            this.btnNewClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewClean.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewClean.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(170)))));
            this.btnNewClean.Location = new System.Drawing.Point(906, 145);
            this.btnNewClean.Name = "btnNewClean";
            this.btnNewClean.Size = new System.Drawing.Size(120, 45);
            this.btnNewClean.TabIndex = 123;
            this.btnNewClean.Text = "Nuevo";
            this.btnNewClean.UseVisualStyleBackColor = true;
            this.btnNewClean.Click += new System.EventHandler(this.btnNewClean_Click);
            // 
            // btnSaveModify
            // 
            this.btnSaveModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveModify.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(170)))));
            this.btnSaveModify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(251)))));
            this.btnSaveModify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(251)))));
            this.btnSaveModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveModify.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveModify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(170)))));
            this.btnSaveModify.Location = new System.Drawing.Point(780, 145);
            this.btnSaveModify.Name = "btnSaveModify";
            this.btnSaveModify.Size = new System.Drawing.Size(120, 45);
            this.btnSaveModify.TabIndex = 122;
            this.btnSaveModify.Text = "Guardar";
            this.btnSaveModify.UseVisualStyleBackColor = true;
            this.btnSaveModify.Click += new System.EventHandler(this.btnSaveModify_Click);
            // 
            // chbStatus
            // 
            this.chbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chbStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.chbStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.chbStatus.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.chbStatus.Location = new System.Drawing.Point(198, 136);
            this.chbStatus.Name = "chbStatus";
            this.chbStatus.Size = new System.Drawing.Size(150, 21);
            this.chbStatus.TabIndex = 121;
            this.chbStatus.Text = "Estado";
            this.chbStatus.ThemeName = "Office2016White";
            // 
            // autoLabel8
            // 
            this.autoLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel8.DX = -124;
            this.autoLabel8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel8.LabeledControl = this.chbStatus;
            this.autoLabel8.Location = new System.Drawing.Point(74, 136);
            this.autoLabel8.Name = "autoLabel8";
            this.autoLabel8.Size = new System.Drawing.Size(120, 20);
            this.autoLabel8.TabIndex = 120;
            this.autoLabel8.Text = "Activo o Inactivo";
            this.autoLabel8.ThemeName = "Office2016White";
            // 
            // autoLabel6
            // 
            this.autoLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel6.DX = -77;
            this.autoLabel6.DY = 4;
            this.autoLabel6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel6.LabeledControl = this.cmbMembers;
            this.autoLabel6.Location = new System.Drawing.Point(558, 78);
            this.autoLabel6.Name = "autoLabel6";
            this.autoLabel6.Size = new System.Drawing.Size(73, 20);
            this.autoLabel6.TabIndex = 117;
            this.autoLabel6.Text = "Miembro:";
            this.autoLabel6.ThemeName = "Office2016White";
            // 
            // autoLabel5
            // 
            this.autoLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel5.DX = -100;
            this.autoLabel5.DY = 4;
            this.autoLabel5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel5.LabeledControl = this.cmbResponsable;
            this.autoLabel5.Location = new System.Drawing.Point(535, 26);
            this.autoLabel5.Name = "autoLabel5";
            this.autoLabel5.Size = new System.Drawing.Size(96, 20);
            this.autoLabel5.TabIndex = 115;
            this.autoLabel5.Text = "Responsable:";
            this.autoLabel5.ThemeName = "Office2016White";
            // 
            // autoLabel2
            // 
            this.autoLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel2.DX = -63;
            this.autoLabel2.DY = 35;
            this.autoLabel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel2.LabeledControl = this.txtDescription;
            this.autoLabel2.Location = new System.Drawing.Point(135, 57);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(59, 20);
            this.autoLabel2.TabIndex = 109;
            this.autoLabel2.Text = "Motivo:";
            this.autoLabel2.ThemeName = "Office2016White";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDescription.BeforeTouchSize = new System.Drawing.Size(244, 20);
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(170)))));
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtDescription.Location = new System.Drawing.Point(198, 22);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(220, 91);
            this.txtDescription.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016White;
            this.txtDescription.TabIndex = 108;
            this.txtDescription.ThemeName = "Office2016White";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgvBlackList);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.autoLabel1);
            this.panel1.Location = new System.Drawing.Point(33, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 419);
            this.panel1.TabIndex = 6;
            // 
            // dgvBlackList
            // 
            this.dgvBlackList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBlackList.Location = new System.Drawing.Point(15, 68);
            this.dgvBlackList.Name = "dgvBlackList";
            this.dgvBlackList.Size = new System.Drawing.Size(1011, 333);
            this.dgvBlackList.TabIndex = 3;
            this.dgvBlackList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBlackList_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtSearch.BeforeTouchSize = new System.Drawing.Size(244, 20);
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtSearch.Location = new System.Drawing.Point(183, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(244, 20);
            this.txtSearch.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016White;
            this.txtSearch.TabIndex = 1;
            this.txtSearch.ThemeName = "Office2016White";
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // autoLabel1
            // 
            this.autoLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel1.DX = -172;
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel1.LabeledControl = this.txtSearch;
            this.autoLabel1.Location = new System.Drawing.Point(11, 20);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(168, 20);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Búsqueda de Miembro:";
            this.autoLabel1.ThemeName = "Office2016White";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lista Negra";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // frmBlackList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBlackList";
            this.Text = "frmBlackList";
            this.Load += new System.EventHandler(this.frmBlackList_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbResponsable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlackList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNewClean;
        private System.Windows.Forms.Button btnSaveModify;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chbStatus;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel8;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvBlackList;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSearch;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.Label label1;
        private Syncfusion.WinForms.ListView.SfComboBox cmbResponsable;
        private Syncfusion.WinForms.ListView.SfComboBox cmbMembers;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}