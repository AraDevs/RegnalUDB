namespace RegnalUDB
{
    partial class frmGroups
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
            Syncfusion.Windows.Forms.BannerTextInfo bannerTextInfo16 = new Syncfusion.Windows.Forms.BannerTextInfo();
            Syncfusion.Windows.Forms.BannerTextInfo bannerTextInfo17 = new Syncfusion.Windows.Forms.BannerTextInfo();
            Syncfusion.Windows.Forms.BannerTextInfo bannerTextInfo18 = new Syncfusion.Windows.Forms.BannerTextInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.skinManager1 = new Syncfusion.Windows.Forms.SkinManager(this.components);
            this.bannerTextProvider1 = new Syncfusion.Windows.Forms.BannerTextProvider(this.components);
            this.txtSchedule = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtGroup = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.txtSearch = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbRegistration = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.dtpRegistration = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.autoLabel9 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnNewClean = new System.Windows.Forms.Button();
            this.btnSaveModify = new System.Windows.Forms.Button();
            this.chbStatus = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.autoLabel8 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel7 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dtpFundation = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbLocations = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbDistricts = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.sectionsPage = new System.Windows.Forms.TabPage();
            this.dgvSections = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbRegistration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpRegistration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFundation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDistricts)).BeginInit();
            this.sectionsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grupos";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // skinManager1
            // 
            this.skinManager1.Controls = this;
            this.skinManager1.VisualTheme = Syncfusion.Windows.Forms.VisualTheme.Office2016White;
            // 
            // txtSchedule
            // 
            this.txtSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bannerTextInfo16.Color = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            bannerTextInfo16.Mode = Syncfusion.Windows.Forms.BannerTextMode.EditMode;
            bannerTextInfo16.Text = "Ingrese el nombre del grupo";
            bannerTextInfo16.Visible = true;
            this.bannerTextProvider1.SetBannerText(this.txtSchedule, bannerTextInfo16);
            this.txtSchedule.BeforeTouchSize = new System.Drawing.Size(220, 22);
            this.txtSchedule.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.txtSchedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSchedule.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(170)))));
            this.txtSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtSchedule.Location = new System.Drawing.Point(633, 113);
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.Size = new System.Drawing.Size(220, 22);
            this.txtSchedule.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016White;
            this.txtSchedule.TabIndex = 112;
            this.txtSchedule.ThemeName = "Office2016White";
            // 
            // txtGroup
            // 
            this.txtGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bannerTextInfo17.Color = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            bannerTextInfo17.Mode = Syncfusion.Windows.Forms.BannerTextMode.EditMode;
            bannerTextInfo17.Text = "Ingrese el nombre del grupo";
            bannerTextInfo17.Visible = true;
            this.bannerTextProvider1.SetBannerText(this.txtGroup, bannerTextInfo17);
            this.txtGroup.BeforeTouchSize = new System.Drawing.Size(220, 22);
            this.txtGroup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.txtGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroup.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(170)))));
            this.txtGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtGroup.Location = new System.Drawing.Point(198, 66);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(220, 22);
            this.txtGroup.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016White;
            this.txtGroup.TabIndex = 110;
            this.txtGroup.ThemeName = "Office2016White";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bannerTextInfo18.Color = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            bannerTextInfo18.Mode = Syncfusion.Windows.Forms.BannerTextMode.EditMode;
            bannerTextInfo18.Text = "Ingrese el nombre del grupo";
            bannerTextInfo18.Visible = true;
            this.bannerTextProvider1.SetBannerText(this.txtName, bannerTextInfo18);
            this.txtName.BeforeTouchSize = new System.Drawing.Size(220, 22);
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(170)))));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtName.Location = new System.Drawing.Point(198, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(220, 22);
            this.txtName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016White;
            this.txtName.TabIndex = 108;
            this.txtName.ThemeName = "Office2016White";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.sectionsPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1076, 647);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1068, 621);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Registro de grupo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgvGroups);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.autoLabel1);
            this.panel1.Location = new System.Drawing.Point(6, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 290);
            this.panel1.TabIndex = 7;
            // 
            // dgvGroups
            // 
            this.dgvGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroups.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Location = new System.Drawing.Point(16, 45);
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.Size = new System.Drawing.Size(1010, 238);
            this.dgvGroups.TabIndex = 3;
            this.dgvGroups.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtSearch.BeforeTouchSize = new System.Drawing.Size(220, 22);
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtSearch.Location = new System.Drawing.Point(174, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(244, 22);
            this.txtSearch.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016White;
            this.txtSearch.TabIndex = 1;
            this.txtSearch.ThemeName = "Office2016White";
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // autoLabel1
            // 
            this.autoLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel1.DX = -158;
            this.autoLabel1.DY = 1;
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel1.LabeledControl = this.txtSearch;
            this.autoLabel1.Location = new System.Drawing.Point(16, 18);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(154, 20);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Búsqueda de Grupos:";
            this.autoLabel1.ThemeName = "Office2016White";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.chbRegistration);
            this.panel2.Controls.Add(this.dtpRegistration);
            this.panel2.Controls.Add(this.autoLabel9);
            this.panel2.Controls.Add(this.btnNewClean);
            this.panel2.Controls.Add(this.btnSaveModify);
            this.panel2.Controls.Add(this.chbStatus);
            this.panel2.Controls.Add(this.autoLabel8);
            this.panel2.Controls.Add(this.autoLabel7);
            this.panel2.Controls.Add(this.dtpFundation);
            this.panel2.Controls.Add(this.autoLabel6);
            this.panel2.Controls.Add(this.cmbLocations);
            this.panel2.Controls.Add(this.autoLabel5);
            this.panel2.Controls.Add(this.cmbDistricts);
            this.panel2.Controls.Add(this.autoLabel4);
            this.panel2.Controls.Add(this.txtSchedule);
            this.panel2.Controls.Add(this.autoLabel3);
            this.panel2.Controls.Add(this.txtGroup);
            this.panel2.Controls.Add(this.autoLabel2);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Location = new System.Drawing.Point(6, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1043, 284);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // chbRegistration
            // 
            this.chbRegistration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chbRegistration.BeforeTouchSize = new System.Drawing.Size(220, 21);
            this.chbRegistration.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.chbRegistration.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbRegistration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.chbRegistration.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.chbRegistration.Location = new System.Drawing.Point(198, 154);
            this.chbRegistration.Name = "chbRegistration";
            this.chbRegistration.Size = new System.Drawing.Size(220, 21);
            this.chbRegistration.TabIndex = 127;
            this.chbRegistration.Text = "Registrado";
            this.chbRegistration.ThemeName = "Office2016White";
            // 
            // dtpRegistration
            // 
            this.dtpRegistration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpRegistration.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpRegistration.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.dtpRegistration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtpRegistration.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpRegistration.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpRegistration.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpRegistration.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpRegistration.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpRegistration.Culture = new System.Globalization.CultureInfo("es-SV");
            this.dtpRegistration.DropDownImage = null;
            this.dtpRegistration.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpRegistration.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRegistration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpRegistration.Location = new System.Drawing.Point(633, 68);
            this.dtpRegistration.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpRegistration.MinValue = new System.DateTime(((long)(0)));
            this.dtpRegistration.Name = "dtpRegistration";
            this.dtpRegistration.ShowCheckBox = false;
            this.dtpRegistration.Size = new System.Drawing.Size(220, 20);
            this.dtpRegistration.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016White;
            this.dtpRegistration.TabIndex = 125;
            this.dtpRegistration.Value = new System.DateTime(2019, 10, 16, 19, 47, 40, 775);
            // 
            // autoLabel9
            // 
            this.autoLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel9.Location = new System.Drawing.Point(486, 68);
            this.autoLabel9.Name = "autoLabel9";
            this.autoLabel9.Size = new System.Drawing.Size(126, 20);
            this.autoLabel9.TabIndex = 124;
            this.autoLabel9.Text = "Fecha de registro:";
            this.autoLabel9.ThemeName = "Office2016White";
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
            this.btnNewClean.Location = new System.Drawing.Point(906, 217);
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
            this.btnSaveModify.Location = new System.Drawing.Point(780, 217);
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
            this.chbStatus.Location = new System.Drawing.Point(198, 205);
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
            this.autoLabel8.Location = new System.Drawing.Point(74, 205);
            this.autoLabel8.Name = "autoLabel8";
            this.autoLabel8.Size = new System.Drawing.Size(120, 20);
            this.autoLabel8.TabIndex = 120;
            this.autoLabel8.Text = "Activo o Inactivo";
            this.autoLabel8.ThemeName = "Office2016White";
            // 
            // autoLabel7
            // 
            this.autoLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel7.DX = -147;
            this.autoLabel7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel7.LabeledControl = this.dtpFundation;
            this.autoLabel7.Location = new System.Drawing.Point(486, 23);
            this.autoLabel7.Name = "autoLabel7";
            this.autoLabel7.Size = new System.Drawing.Size(143, 20);
            this.autoLabel7.TabIndex = 119;
            this.autoLabel7.Text = "Fecha de Fundación:";
            this.autoLabel7.ThemeName = "Office2016White";
            // 
            // dtpFundation
            // 
            this.dtpFundation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpFundation.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpFundation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.dtpFundation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtpFundation.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpFundation.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpFundation.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpFundation.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpFundation.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpFundation.Culture = new System.Globalization.CultureInfo("es-SV");
            this.dtpFundation.DropDownImage = null;
            this.dtpFundation.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtpFundation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFundation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dtpFundation.Location = new System.Drawing.Point(633, 23);
            this.dtpFundation.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpFundation.MinValue = new System.DateTime(((long)(0)));
            this.dtpFundation.Name = "dtpFundation";
            this.dtpFundation.ShowCheckBox = false;
            this.dtpFundation.Size = new System.Drawing.Size(220, 20);
            this.dtpFundation.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016White;
            this.dtpFundation.TabIndex = 118;
            this.dtpFundation.Value = new System.DateTime(2019, 10, 16, 19, 47, 40, 775);
            // 
            // autoLabel6
            // 
            this.autoLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel6.DX = -78;
            this.autoLabel6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel6.LabeledControl = this.cmbLocations;
            this.autoLabel6.Location = new System.Drawing.Point(555, 153);
            this.autoLabel6.Name = "autoLabel6";
            this.autoLabel6.Size = new System.Drawing.Size(74, 20);
            this.autoLabel6.TabIndex = 117;
            this.autoLabel6.Text = "Localidad";
            this.autoLabel6.ThemeName = "Office2016White";
            // 
            // cmbLocations
            // 
            this.cmbLocations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbLocations.BeforeTouchSize = new System.Drawing.Size(220, 21);
            this.cmbLocations.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.cmbLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cmbLocations.Location = new System.Drawing.Point(633, 153);
            this.cmbLocations.Name = "cmbLocations";
            this.cmbLocations.Size = new System.Drawing.Size(220, 21);
            this.cmbLocations.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016White;
            this.cmbLocations.TabIndex = 116;
            this.cmbLocations.ThemeName = "Office2016White";
            // 
            // autoLabel5
            // 
            this.autoLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel5.DX = -65;
            this.autoLabel5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel5.LabeledControl = this.cmbDistricts;
            this.autoLabel5.Location = new System.Drawing.Point(133, 113);
            this.autoLabel5.Name = "autoLabel5";
            this.autoLabel5.Size = new System.Drawing.Size(61, 20);
            this.autoLabel5.TabIndex = 115;
            this.autoLabel5.Text = "Distrito:";
            this.autoLabel5.ThemeName = "Office2016White";
            // 
            // cmbDistricts
            // 
            this.cmbDistricts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbDistricts.BeforeTouchSize = new System.Drawing.Size(220, 21);
            this.cmbDistricts.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.cmbDistricts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistricts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cmbDistricts.Location = new System.Drawing.Point(198, 113);
            this.cmbDistricts.Name = "cmbDistricts";
            this.cmbDistricts.Size = new System.Drawing.Size(220, 21);
            this.cmbDistricts.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016White;
            this.cmbDistricts.TabIndex = 114;
            this.cmbDistricts.ThemeName = "Office2016White";
            // 
            // autoLabel4
            // 
            this.autoLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel4.DX = -67;
            this.autoLabel4.DY = 1;
            this.autoLabel4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel4.LabeledControl = this.txtSchedule;
            this.autoLabel4.Location = new System.Drawing.Point(566, 114);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(63, 20);
            this.autoLabel4.TabIndex = 113;
            this.autoLabel4.Text = "Horario:";
            this.autoLabel4.ThemeName = "Office2016White";
            // 
            // autoLabel3
            // 
            this.autoLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel3.DX = -136;
            this.autoLabel3.DY = 1;
            this.autoLabel3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel3.LabeledControl = this.txtGroup;
            this.autoLabel3.Location = new System.Drawing.Point(62, 67);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(132, 20);
            this.autoLabel3.TabIndex = 111;
            this.autoLabel3.Text = "Número de Grupo:";
            this.autoLabel3.ThemeName = "Office2016White";
            // 
            // autoLabel2
            // 
            this.autoLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLabel2.DX = -71;
            this.autoLabel2.DY = 1;
            this.autoLabel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.autoLabel2.LabeledControl = this.txtName;
            this.autoLabel2.Location = new System.Drawing.Point(127, 23);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(67, 20);
            this.autoLabel2.TabIndex = 109;
            this.autoLabel2.Text = "Nombre:";
            this.autoLabel2.ThemeName = "Office2016White";
            // 
            // sectionsPage
            // 
            this.sectionsPage.Controls.Add(this.dgvSections);
            this.sectionsPage.Location = new System.Drawing.Point(4, 22);
            this.sectionsPage.Name = "sectionsPage";
            this.sectionsPage.Padding = new System.Windows.Forms.Padding(3);
            this.sectionsPage.Size = new System.Drawing.Size(1068, 621);
            this.sectionsPage.TabIndex = 1;
            this.sectionsPage.Text = "Secciones adjuntas al grupo";
            this.sectionsPage.ToolTipText = "Seleccione un grupo";
            this.sectionsPage.UseVisualStyleBackColor = true;
            // 
            // dgvSections
            // 
            this.dgvSections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSections.BackgroundColor = System.Drawing.Color.White;
            this.dgvSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSections.Location = new System.Drawing.Point(15, 41);
            this.dgvSections.Name = "dgvSections";
            this.dgvSections.Size = new System.Drawing.Size(1035, 357);
            this.dgvSections.TabIndex = 6;
            // 
            // frmGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGroups";
            this.Text = "frmGroups";
            this.Load += new System.EventHandler(this.frmGroups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbRegistration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpRegistration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFundation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDistricts)).EndInit();
            this.sectionsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Syncfusion.Windows.Forms.SkinManager skinManager1;
        private Syncfusion.Windows.Forms.BannerTextProvider bannerTextProvider1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNewClean;
        private System.Windows.Forms.Button btnSaveModify;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chbStatus;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel8;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel7;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtpFundation;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbLocations;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbDistricts;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSchedule;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtGroup;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private System.Windows.Forms.TabPage sectionsPage;
        private System.Windows.Forms.DataGridView dgvSections;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvGroups;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSearch;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtpRegistration;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel9;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chbRegistration;
    }
}