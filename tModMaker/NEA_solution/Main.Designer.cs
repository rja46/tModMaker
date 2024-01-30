namespace NEA_solution
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.msMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveMod = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveModAs = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMod = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stsBottom = new System.Windows.Forms.StatusStrip();
            this.pbSave = new System.Windows.Forms.ToolStripProgressBar();
            this.pnlItem = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbNew = new System.Windows.Forms.ToolStripButton();
            this.tbOpen = new System.Windows.Forms.ToolStripButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.cb_theme = new System.Windows.Forms.CheckBox();
            this.msMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.stsBottom.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddItem.Location = new System.Drawing.Point(3, 350);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lbItems
            // 
            this.lbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(3, 4);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(156, 325);
            this.lbItems.TabIndex = 7;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            this.lbItems.DoubleClick += new System.EventHandler(this.lbItems_DoubleClick);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDeleteItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteItem.Location = new System.Drawing.Point(84, 350);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteItem.TabIndex = 10;
            this.btnDeleteItem.Text = "Delete Item";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMainFile,
            this.editToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(800, 24);
            this.msMain.TabIndex = 12;
            this.msMain.Text = "menuStrip1";
            // 
            // msMainFile
            // 
            this.msMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.fileSaveMod,
            this.fileSaveModAs,
            this.fileOpenMod,
            this.exportToolStripMenuItem});
            this.msMainFile.Name = "msMainFile";
            this.msMainFile.Size = new System.Drawing.Size(37, 20);
            this.msMainFile.Text = "File";
            // 
            // btnNew
            // 
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(142, 22);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // fileSaveMod
            // 
            this.fileSaveMod.Name = "fileSaveMod";
            this.fileSaveMod.Size = new System.Drawing.Size(142, 22);
            this.fileSaveMod.Text = "Save Mod";
            this.fileSaveMod.Click += new System.EventHandler(this.fileSaveMod_Click);
            // 
            // fileSaveModAs
            // 
            this.fileSaveModAs.Name = "fileSaveModAs";
            this.fileSaveModAs.Size = new System.Drawing.Size(142, 22);
            this.fileSaveModAs.Text = "Save Mod As";
            this.fileSaveModAs.Click += new System.EventHandler(this.fileSaveModAs_Click);
            // 
            // fileOpenMod
            // 
            this.fileOpenMod.Name = "fileOpenMod";
            this.fileOpenMod.Size = new System.Drawing.Size(142, 22);
            this.fileOpenMod.Text = "Open";
            this.fileOpenMod.Click += new System.EventHandler(this.fileOpenMod_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modDetailsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // modDetailsToolStripMenuItem
            // 
            this.modDetailsToolStripMenuItem.Name = "modDetailsToolStripMenuItem";
            this.modDetailsToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.modDetailsToolStripMenuItem.Text = "Mod Details";
            this.modDetailsToolStripMenuItem.Click += new System.EventHandler(this.modDetailsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbItems);
            this.panel1.Controls.Add(this.btnAddItem);
            this.panel1.Controls.Add(this.btnDeleteItem);
            this.panel1.Location = new System.Drawing.Point(624, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 373);
            this.panel1.TabIndex = 13;
            // 
            // stsBottom
            // 
            this.stsBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbSave});
            this.stsBottom.Location = new System.Drawing.Point(0, 428);
            this.stsBottom.Name = "stsBottom";
            this.stsBottom.Size = new System.Drawing.Size(800, 22);
            this.stsBottom.TabIndex = 14;
            this.stsBottom.Text = "statusStrip1";
            // 
            // pbSave
            // 
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(100, 16);
            // 
            // pnlItem
            // 
            this.pnlItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlItem.Location = new System.Drawing.Point(12, 56);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(606, 369);
            this.pnlItem.TabIndex = 15;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNew,
            this.tbOpen,
            this.tbSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbNew
            // 
            this.tbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbNew.Image = ((System.Drawing.Image)(resources.GetObject("tbNew.Image")));
            this.tbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(23, 22);
            this.tbNew.Text = "New";
            this.tbNew.Click += new System.EventHandler(this.tbNew_Click);
            // 
            // tbOpen
            // 
            this.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tbOpen.Image")));
            this.tbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.Size = new System.Drawing.Size(23, 22);
            this.tbOpen.Text = "Open";
            this.tbOpen.Click += new System.EventHandler(this.tbOpen_Click);
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.Image = ((System.Drawing.Image)(resources.GetObject("tbSave.Image")));
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(23, 22);
            this.tbSave.Text = "Save";
            this.tbSave.ToolTipText = "Save";
            this.tbSave.Click += new System.EventHandler(this.tbSave_Click);
            // 
            // cb_theme
            // 
            this.cb_theme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_theme.AutoSize = true;
            this.cb_theme.Location = new System.Drawing.Point(703, 33);
            this.cb_theme.Name = "cb_theme";
            this.cb_theme.Size = new System.Drawing.Size(79, 17);
            this.cb_theme.TabIndex = 17;
            this.cb_theme.Text = "Dark Mode";
            this.cb_theme.UseVisualStyleBackColor = true;
            this.cb_theme.CheckStateChanged += new System.EventHandler(this.cb_theme_CheckStateChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cb_theme);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlItem);
            this.Controls.Add(this.stsBottom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Main";
            this.Text = "Form1";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.stsBottom.ResumeLayout(false);
            this.stsBottom.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem msMainFile;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMod;
        private System.Windows.Forms.ToolStripMenuItem fileSaveModAs;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMod;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modDetailsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.StatusStrip stsBottom;
        private System.Windows.Forms.ToolStripProgressBar pbSave;
        private System.Windows.Forms.ToolStripMenuItem btnNew;
        private System.Windows.Forms.Panel pnlItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbNew;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.ToolStripButton tbOpen;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.CheckBox cb_theme;
    }
}

