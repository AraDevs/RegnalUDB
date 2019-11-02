namespace RegnalUDB
{
    partial class frmInscriptions
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
            this.components = new System.ComponentModel.Container();
            this.autoLabel7 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dtpStart = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.lblMemberI = new System.Windows.Forms.Label();
            this.autoLabel39 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dtpFinish = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.autoLabel19 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.chbStatus = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSaveChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // autoLabel7
            // 
            this.autoLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel7.DX = -121;
            this.autoLabel7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel7.LabeledControl = this.dtpStart;
            this.autoLabel7.Location = new System.Drawing.Point(112, 135);
            this.autoLabel7.Name = "autoLabel7";
            this.autoLabel7.Size = new System.Drawing.Size(117, 20);
            this.autoLabel7.TabIndex = 131;
            this.autoLabel7.Text = "Miembro desde:";
            this.autoLabel7.ThemeName = "Office2016White";
            // 
            // dtpStart
            // 
            this.dtpStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpStart.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpStart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.dtpStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtpStart.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpStart.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpStart.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpStart.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpStart.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpStart.Culture = new System.Globalization.CultureInfo("es-SV");
            this.dtpStart.DropDownImage = null;
            this.dtpStart.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpStart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpStart.Location = new System.Drawing.Point(233, 135);
            this.dtpStart.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpStart.MinValue = new System.DateTime(((long)(0)));
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowCheckBox = false;
            this.dtpStart.Size = new System.Drawing.Size(220, 20);
            this.dtpStart.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016White;
            this.dtpStart.TabIndex = 130;
            this.dtpStart.Value = new System.DateTime(2019, 10, 16, 19, 47, 40, 775);
            // 
            // lblMemberI
            // 
            this.lblMemberI.AutoSize = true;
            this.lblMemberI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberI.Location = new System.Drawing.Point(209, 86);
            this.lblMemberI.Name = "lblMemberI";
            this.lblMemberI.Size = new System.Drawing.Size(66, 20);
            this.lblMemberI.TabIndex = 164;
            this.lblMemberI.Text = "Ninguno";
            // 
            // autoLabel39
            // 
            this.autoLabel39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel39.DX = -168;
            this.autoLabel39.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel39.LabeledControl = this.lblMemberI;
            this.autoLabel39.Location = new System.Drawing.Point(41, 86);
            this.autoLabel39.Name = "autoLabel39";
            this.autoLabel39.Size = new System.Drawing.Size(164, 20);
            this.autoLabel39.TabIndex = 163;
            this.autoLabel39.Text = "Miembro seleccionado:";
            this.autoLabel39.ThemeName = "Office2016White";
            // 
            // autoLabel1
            // 
            this.autoLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel1.DX = -73;
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel1.LabeledControl = this.dtpFinish;
            this.autoLabel1.Location = new System.Drawing.Point(540, 135);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(69, 20);
            this.autoLabel1.TabIndex = 166;
            this.autoLabel1.Text = "Vigencia:";
            this.autoLabel1.ThemeName = "Office2016White";
            // 
            // dtpFinish
            // 
            this.dtpFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpFinish.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpFinish.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.dtpFinish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtpFinish.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpFinish.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpFinish.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpFinish.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpFinish.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpFinish.Culture = new System.Globalization.CultureInfo("es-SV");
            this.dtpFinish.DropDownImage = null;
            this.dtpFinish.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpFinish.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpFinish.Location = new System.Drawing.Point(613, 135);
            this.dtpFinish.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpFinish.MinValue = new System.DateTime(((long)(0)));
            this.dtpFinish.Name = "dtpFinish";
            this.dtpFinish.ShowCheckBox = false;
            this.dtpFinish.Size = new System.Drawing.Size(220, 20);
            this.dtpFinish.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016White;
            this.dtpFinish.TabIndex = 165;
            this.dtpFinish.Value = new System.DateTime(2019, 10, 16, 19, 47, 40, 775);
            // 
            // autoLabel19
            // 
            this.autoLabel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel19.DX = -127;
            this.autoLabel19.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel19.LabeledControl = this.chbStatus;
            this.autoLabel19.Location = new System.Drawing.Point(486, 191);
            this.autoLabel19.Name = "autoLabel19";
            this.autoLabel19.Size = new System.Drawing.Size(123, 20);
            this.autoLabel19.TabIndex = 171;
            this.autoLabel19.Text = "Activo o Inactivo:";
            this.autoLabel19.ThemeName = "Office2016White";
            // 
            // chbStatus
            // 
            this.chbStatus.Location = new System.Drawing.Point(613, 191);
            this.chbStatus.Name = "chbStatus";
            this.chbStatus.Size = new System.Drawing.Size(150, 21);
            this.chbStatus.TabIndex = 172;
            this.chbStatus.Text = "Estado";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
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
            this.btnSaveChanges.Location = new System.Drawing.Point(674, 260);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(159, 45);
            this.btnSaveChanges.TabIndex = 173;
            this.btnSaveChanges.Text = "Guardar cambios";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // frmInscriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.chbStatus);
            this.Controls.Add(this.autoLabel19);
            this.Controls.Add(this.autoLabel1);
            this.Controls.Add(this.dtpFinish);
            this.Controls.Add(this.lblMemberI);
            this.Controls.Add(this.autoLabel39);
            this.Controls.Add(this.autoLabel7);
            this.Controls.Add(this.dtpStart);
            this.Name = "frmInscriptions";
            this.Size = new System.Drawing.Size(1038, 519);
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel7;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtpStart;
        public System.Windows.Forms.Label lblMemberI;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel39;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtpFinish;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel19;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chbStatus;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnSaveChanges;
    }
}
