namespace RegnalUDB
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.roundedCorners = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.DragControlTop = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlMenuTop = new System.Windows.Forms.Panel();
            this.pcbInfo = new System.Windows.Forms.PictureBox();
            this.pcbRestoreWindow = new System.Windows.Forms.PictureBox();
            this.pcbCloseWindow = new System.Windows.Forms.PictureBox();
            this.pcbMaximizeWindow = new System.Windows.Forms.PictureBox();
            this.pcbMinimizeWindow = new System.Windows.Forms.PictureBox();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuFlatButton3 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.pcbIcono = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pcbMenuSidebar = new System.Windows.Forms.PictureBox();
            this.pnlMenuTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRestoreWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCloseWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMaximizeWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMinimizeWindow)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMenuSidebar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(241)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(300, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1100, 720);
            this.pnlContent.TabIndex = 1;
            // 
            // roundedCorners
            // 
            this.roundedCorners.ElipseRadius = 5;
            this.roundedCorners.TargetControl = this;
            // 
            // DragControlTop
            // 
            this.DragControlTop.Fixed = true;
            this.DragControlTop.Horizontal = true;
            this.DragControlTop.TargetControl = this.pnlMenuTop;
            this.DragControlTop.Vertical = true;
            // 
            // pnlMenuTop
            // 
            this.pnlMenuTop.BackColor = System.Drawing.Color.White;
            this.pnlMenuTop.Controls.Add(this.pcbInfo);
            this.pnlMenuTop.Controls.Add(this.pcbRestoreWindow);
            this.pnlMenuTop.Controls.Add(this.pcbCloseWindow);
            this.pnlMenuTop.Controls.Add(this.pcbMaximizeWindow);
            this.pnlMenuTop.Controls.Add(this.pcbMinimizeWindow);
            this.pnlMenuTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuTop.Location = new System.Drawing.Point(300, 0);
            this.pnlMenuTop.Name = "pnlMenuTop";
            this.pnlMenuTop.Size = new System.Drawing.Size(1100, 80);
            this.pnlMenuTop.TabIndex = 0;
            // 
            // pcbInfo
            // 
            this.pcbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbInfo.Image = global::RegnalUDB.Properties.Resources.info_40px;
            this.pcbInfo.Location = new System.Drawing.Point(906, 24);
            this.pcbInfo.Name = "pcbInfo";
            this.pcbInfo.Size = new System.Drawing.Size(32, 32);
            this.pcbInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbInfo.TabIndex = 6;
            this.pcbInfo.TabStop = false;
            this.pcbInfo.Click += new System.EventHandler(this.PcbInfo_Click);
            // 
            // pcbRestoreWindow
            // 
            this.pcbRestoreWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbRestoreWindow.Enabled = false;
            this.pcbRestoreWindow.Image = global::RegnalUDB.Properties.Resources.restore_window_40px;
            this.pcbRestoreWindow.Location = new System.Drawing.Point(1009, 24);
            this.pcbRestoreWindow.Name = "pcbRestoreWindow";
            this.pcbRestoreWindow.Size = new System.Drawing.Size(32, 32);
            this.pcbRestoreWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbRestoreWindow.TabIndex = 5;
            this.pcbRestoreWindow.TabStop = false;
            this.pcbRestoreWindow.Visible = false;
            this.pcbRestoreWindow.Click += new System.EventHandler(this.PcbRestoreWindow_Click);
            // 
            // pcbCloseWindow
            // 
            this.pcbCloseWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbCloseWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbCloseWindow.Image = global::RegnalUDB.Properties.Resources.close_window_40px;
            this.pcbCloseWindow.Location = new System.Drawing.Point(1047, 24);
            this.pcbCloseWindow.Name = "pcbCloseWindow";
            this.pcbCloseWindow.Size = new System.Drawing.Size(32, 32);
            this.pcbCloseWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCloseWindow.TabIndex = 4;
            this.pcbCloseWindow.TabStop = false;
            this.pcbCloseWindow.Click += new System.EventHandler(this.PcbCloseWindow_Click);
            // 
            // pcbMaximizeWindow
            // 
            this.pcbMaximizeWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbMaximizeWindow.Image = global::RegnalUDB.Properties.Resources.maximize_window_40px;
            this.pcbMaximizeWindow.Location = new System.Drawing.Point(1009, 24);
            this.pcbMaximizeWindow.Name = "pcbMaximizeWindow";
            this.pcbMaximizeWindow.Size = new System.Drawing.Size(32, 32);
            this.pcbMaximizeWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMaximizeWindow.TabIndex = 3;
            this.pcbMaximizeWindow.TabStop = false;
            this.pcbMaximizeWindow.Click += new System.EventHandler(this.PcbMaximizeWindow_Click);
            // 
            // pcbMinimizeWindow
            // 
            this.pcbMinimizeWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbMinimizeWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbMinimizeWindow.Image = global::RegnalUDB.Properties.Resources.minimize_window_40px;
            this.pcbMinimizeWindow.Location = new System.Drawing.Point(971, 24);
            this.pcbMinimizeWindow.Name = "pcbMinimizeWindow";
            this.pcbMinimizeWindow.Size = new System.Drawing.Size(32, 32);
            this.pcbMinimizeWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMinimizeWindow.TabIndex = 2;
            this.pcbMinimizeWindow.TabStop = false;
            this.pcbMinimizeWindow.Click += new System.EventHandler(this.PcbMinimizeWindow_Click);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.bunifuFlatButton3);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuFlatButton2);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuFlatButton1);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuSeparator1);
            this.bunifuGradientPanel1.Controls.Add(this.label2);
            this.bunifuGradientPanel1.Controls.Add(this.pcbIcono);
            this.bunifuGradientPanel1.Controls.Add(this.label1);
            this.bunifuGradientPanel1.Controls.Add(this.pcbMenuSidebar);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(32)))), ((int)(((byte)(197)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(32)))), ((int)(((byte)(197)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(32)))), ((int)(((byte)(197)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(122)))), ((int)(((byte)(57)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(300, 800);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // bunifuFlatButton3
            // 
            this.bunifuFlatButton3.Active = false;
            this.bunifuFlatButton3.Activecolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton3.BorderRadius = 0;
            this.bunifuFlatButton3.ButtonText = "    Secciones";
            this.bunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.Iconimage = global::RegnalUDB.Properties.Resources.generic_sorting_40px;
            this.bunifuFlatButton3.Iconimage_right = null;
            this.bunifuFlatButton3.Iconimage_right_Selected = null;
            this.bunifuFlatButton3.Iconimage_Selected = null;
            this.bunifuFlatButton3.IconMarginLeft = 0;
            this.bunifuFlatButton3.IconMarginRight = 0;
            this.bunifuFlatButton3.IconRightVisible = true;
            this.bunifuFlatButton3.IconRightZoom = 0D;
            this.bunifuFlatButton3.IconVisible = true;
            this.bunifuFlatButton3.IconZoom = 50D;
            this.bunifuFlatButton3.IsTab = false;
            this.bunifuFlatButton3.Location = new System.Drawing.Point(12, 280);
            this.bunifuFlatButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuFlatButton3.Name = "bunifuFlatButton3";
            this.bunifuFlatButton3.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.OnHovercolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton3.selected = false;
            this.bunifuFlatButton3.Size = new System.Drawing.Size(272, 48);
            this.bunifuFlatButton3.TabIndex = 6;
            this.bunifuFlatButton3.Text = "    Secciones";
            this.bunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton3.Textcolor = System.Drawing.Color.LightGray;
            this.bunifuFlatButton3.TextFont = new System.Drawing.Font("Yu Gothic UI", 10F);
            this.bunifuFlatButton3.Click += new System.EventHandler(this.BunifuFlatButton3_Click);
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Active = false;
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.ButtonText = "    Grupos";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = global::RegnalUDB.Properties.Resources.groups_40px;
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 50D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(12, 215);
            this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(272, 48);
            this.bunifuFlatButton2.TabIndex = 5;
            this.bunifuFlatButton2.Text = "    Grupos";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.LightGray;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Yu Gothic UI", 10F);
            this.bunifuFlatButton2.Click += new System.EventHandler(this.BunifuFlatButton2_Click);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Active = false;
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "    Miembros";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = global::RegnalUDB.Properties.Resources.user_group_man_woman_40px;
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 50D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(12, 150);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(272, 48);
            this.bunifuFlatButton1.TabIndex = 4;
            this.bunifuFlatButton1.Text = "    Miembros";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.LightGray;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Yu Gothic UI", 10F);
            this.bunifuFlatButton1.Click += new System.EventHandler(this.BunifuFlatButton1_Click);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.ForeColor = System.Drawing.Color.White;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(12, 123);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(272, 1);
            this.bunifuSeparator1.TabIndex = 3;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(62, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "REGNAL";
            // 
            // pcbIcono
            // 
            this.pcbIcono.BackColor = System.Drawing.Color.Transparent;
            this.pcbIcono.Image = global::RegnalUDB.Properties.Resources.icono;
            this.pcbIcono.Location = new System.Drawing.Point(16, 72);
            this.pcbIcono.Name = "pcbIcono";
            this.pcbIcono.Size = new System.Drawing.Size(40, 40);
            this.pcbIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbIcono.TabIndex = 0;
            this.pcbIcono.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "DASHBOARD";
            // 
            // pcbMenuSidebar
            // 
            this.pcbMenuSidebar.BackColor = System.Drawing.Color.Transparent;
            this.pcbMenuSidebar.Image = global::RegnalUDB.Properties.Resources.menu_32px;
            this.pcbMenuSidebar.Location = new System.Drawing.Point(15, 19);
            this.pcbMenuSidebar.Name = "pcbMenuSidebar";
            this.pcbMenuSidebar.Size = new System.Drawing.Size(32, 32);
            this.pcbMenuSidebar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMenuSidebar.TabIndex = 0;
            this.pcbMenuSidebar.TabStop = false;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenuTop);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDashboard";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.pnlMenuTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRestoreWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCloseWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMaximizeWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMinimizeWindow)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMenuSidebar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.PictureBox pcbMenuSidebar;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pcbIcono;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton3;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private Bunifu.Framework.UI.BunifuElipse roundedCorners;
        private Bunifu.Framework.UI.BunifuDragControl DragControlTop;
        private System.Windows.Forms.PictureBox pcbCloseWindow;
        private System.Windows.Forms.PictureBox pcbRestoreWindow;
        private System.Windows.Forms.PictureBox pcbMinimizeWindow;
        private System.Windows.Forms.PictureBox pcbMaximizeWindow;
        private System.Windows.Forms.Panel pnlMenuTop;
        private System.Windows.Forms.PictureBox pcbInfo;
    }
}