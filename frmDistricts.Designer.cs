namespace RegnalUDB
{
    partial class frmDistricts
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
            this.autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProvincess = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnNewClean = new System.Windows.Forms.Button();
            this.btnSaveModify = new System.Windows.Forms.Button();
            this.chbStatus = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.autoLabel8 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDistricts = new System.Windows.Forms.DataGridView();
            this.txtSearch = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProvincess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.autoLabel6);
            this.panel2.Controls.Add(this.cmbProvincess);
            this.panel2.Controls.Add(this.btnNewClean);
            this.panel2.Controls.Add(this.btnSaveModify);
            this.panel2.Controls.Add(this.chbStatus);
            this.panel2.Controls.Add(this.autoLabel8);
            this.panel2.Controls.Add(this.autoLabel2);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Location = new System.Drawing.Point(31, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1042, 171);
            this.panel2.TabIndex = 11;
            // 
            // autoLabel6
            // 
            this.autoLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel6.DX = -76;
            this.autoLabel6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel6.LabeledControl = this.cmbProvincess;
            this.autoLabel6.Location = new System.Drawing.Point(555, 29);
            this.autoLabel6.Name = "autoLabel6";
            this.autoLabel6.Size = new System.Drawing.Size(72, 20);
            this.autoLabel6.TabIndex = 127;
            this.autoLabel6.Text = "Provincia:";
            this.autoLabel6.ThemeName = "Office2016White";
            // 
            // cmbProvincess
            // 
            this.cmbProvincess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbProvincess.BeforeTouchSize = new System.Drawing.Size(220, 21);
            this.cmbProvincess.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.cmbProvincess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cmbProvincess.Location = new System.Drawing.Point(631, 29);
            this.cmbProvincess.Name = "cmbProvincess";
            this.cmbProvincess.Size = new System.Drawing.Size(220, 21);
            this.cmbProvincess.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016White;
            this.cmbProvincess.TabIndex = 126;
            this.cmbProvincess.ThemeName = "Office2016White";
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
            this.btnNewClean.Location = new System.Drawing.Point(904, 110);
            this.btnNewClean.Name = "btnNewClean";
            this.btnNewClean.Size = new System.Drawing.Size(120, 45);
            this.btnNewClean.TabIndex = 125;
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
            this.btnSaveModify.Location = new System.Drawing.Point(778, 110);
            this.btnSaveModify.Name = "btnSaveModify";
            this.btnSaveModify.Size = new System.Drawing.Size(120, 45);
            this.btnSaveModify.TabIndex = 124;
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
            this.chbStatus.Location = new System.Drawing.Point(227, 95);
            this.chbStatus.Name = "chbStatus";
            this.chbStatus.Size = new System.Drawing.Size(150, 21);
            this.chbStatus.TabIndex = 123;
            this.chbStatus.Text = "Estado";
            this.chbStatus.ThemeName = "Office2016White";
            // 
            // autoLabel8
            // 
            this.autoLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel8.DX = -127;
            this.autoLabel8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel8.LabeledControl = this.chbStatus;
            this.autoLabel8.Location = new System.Drawing.Point(100, 95);
            this.autoLabel8.Name = "autoLabel8";
            this.autoLabel8.Size = new System.Drawing.Size(123, 20);
            this.autoLabel8.TabIndex = 122;
            this.autoLabel8.Text = "Activo o Inactivo:";
            this.autoLabel8.ThemeName = "Office2016White";
            // 
            // autoLabel2
            // 
            this.autoLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel2.DX = -71;
            this.autoLabel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel2.LabeledControl = this.txtName;
            this.autoLabel2.Location = new System.Drawing.Point(100, 29);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(67, 20);
            this.autoLabel2.TabIndex = 111;
            this.autoLabel2.Text = "Nombre:";
            this.autoLabel2.ThemeName = "Office2016White";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtName.BeforeTouchSize = new System.Drawing.Size(244, 20);
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(170)))));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtName.Location = new System.Drawing.Point(171, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(220, 20);
            this.txtName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016White;
            this.txtName.TabIndex = 110;
            this.txtName.ThemeName = "Office2016White";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgvDistricts);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.autoLabel1);
            this.panel1.Location = new System.Drawing.Point(31, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 437);
            this.panel1.TabIndex = 10;
            // 
            // dgvDistricts
            // 
            this.dgvDistricts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistricts.Location = new System.Drawing.Point(16, 79);
            this.dgvDistricts.Name = "dgvDistricts";
            this.dgvDistricts.Size = new System.Drawing.Size(1011, 335);
            this.dgvDistricts.TabIndex = 3;
            this.dgvDistricts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDistricts_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtSearch.BeforeTouchSize = new System.Drawing.Size(244, 20);
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtSearch.Location = new System.Drawing.Point(179, 20);
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
            this.autoLabel1.DX = -165;
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel1.LabeledControl = this.txtSearch;
            this.autoLabel1.Location = new System.Drawing.Point(14, 20);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(161, 20);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Búsqueda de Distritos:";
            this.autoLabel1.ThemeName = "Office2016White";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Distritos";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // frmDistricts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDistricts";
            this.Text = "frmDistricts";
            this.Load += new System.EventHandler(this.frmDistricts_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProvincess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).EndInit();
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
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSearch;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProvincess;
        private System.Windows.Forms.DataGridView dgvDistricts;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}