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
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openExportDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stsBottom = new System.Windows.Forms.StatusStrip();
            this.pbSave = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbNew = new System.Windows.Forms.ToolStripButton();
            this.tbOpen = new System.Windows.Forms.ToolStripButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.wvCode = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.txtTooltip = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblTooltip = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.btnChangeSprite = new System.Windows.Forms.Button();
            this.pbSprite = new System.Windows.Forms.PictureBox();
            this.btnAdditionalSprites = new System.Windows.Forms.Button();
            this.btnRecipe = new System.Windows.Forms.Button();
            this.wvSave = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.msMain.SuspendLayout();
            this.stsBottom.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wvSave)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Location = new System.Drawing.Point(624, 400);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lbItems
            // 
            this.lbItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(624, 58);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(156, 340);
            this.lbItems.TabIndex = 7;
            this.lbItems.DoubleClick += new System.EventHandler(this.lbItems_DoubleClick);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteItem.Location = new System.Drawing.Point(705, 400);
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
            this.openRecentToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.openExportDirectoryToolStripMenuItem});
            this.msMainFile.Name = "msMainFile";
            this.msMainFile.Size = new System.Drawing.Size(37, 20);
            this.msMainFile.Text = "File";
            // 
            // btnNew
            // 
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(191, 22);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // fileSaveMod
            // 
            this.fileSaveMod.Name = "fileSaveMod";
            this.fileSaveMod.Size = new System.Drawing.Size(191, 22);
            this.fileSaveMod.Text = "Save Project";
            this.fileSaveMod.Click += new System.EventHandler(this.fileSaveMod_Click);
            // 
            // fileSaveModAs
            // 
            this.fileSaveModAs.Name = "fileSaveModAs";
            this.fileSaveModAs.Size = new System.Drawing.Size(191, 22);
            this.fileSaveModAs.Text = "Save Project As";
            this.fileSaveModAs.Click += new System.EventHandler(this.fileSaveModAs_Click);
            // 
            // fileOpenMod
            // 
            this.fileOpenMod.Name = "fileOpenMod";
            this.fileOpenMod.Size = new System.Drawing.Size(191, 22);
            this.fileOpenMod.Text = "Open";
            this.fileOpenMod.Click += new System.EventHandler(this.fileOpenMod_Click);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openRecentToolStripMenuItem.Text = "Open Recent";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // openExportDirectoryToolStripMenuItem
            // 
            this.openExportDirectoryToolStripMenuItem.Name = "openExportDirectoryToolStripMenuItem";
            this.openExportDirectoryToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openExportDirectoryToolStripMenuItem.Text = "Open Export Directory";
            this.openExportDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openExportDirectoryToolStripMenuItem_Click);
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
            this.modDetailsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.modDetailsToolStripMenuItem.Text = "Project Details";
            this.modDetailsToolStripMenuItem.Click += new System.EventHandler(this.modDetailsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNew,
            this.tbOpen,
            this.tbSave,
            this.toolStripSeparator1,
            this.btnUndo,
            this.btnRedo});
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(23, 22);
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(23, 22);
            this.btnRedo.Text = "Redo";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // wvCode
            // 
            this.wvCode.AllowExternalDrop = true;
            this.wvCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wvCode.CreationProperties = null;
            this.wvCode.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wvCode.Location = new System.Drawing.Point(247, 58);
            this.wvCode.Name = "wvCode";
            this.wvCode.Size = new System.Drawing.Size(371, 367);
            this.wvCode.Source = new System.Uri("C:\\Users\\rjand\\Documents\\GitHub\\tModMaker\\Blockly Editor", System.UriKind.Absolute);
            this.wvCode.TabIndex = 25;
            this.wvCode.ZoomFactor = 1D;
            this.wvCode.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.wvCode_NavigationCompleted);
            this.wvCode.WebMessageReceived += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs>(this.wvCode_WebMessageReceived);
            // 
            // txtTooltip
            // 
            this.txtTooltip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTooltip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTooltip.Location = new System.Drawing.Point(51, 302);
            this.txtTooltip.Multiline = true;
            this.txtTooltip.Name = "txtTooltip";
            this.txtTooltip.Size = new System.Drawing.Size(190, 96);
            this.txtTooltip.TabIndex = 22;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Location = new System.Drawing.Point(7, 273);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(42, 29);
            this.lblDisplayName.TabIndex = 23;
            this.lblDisplayName.Text = "Display Name:";
            // 
            // lblTooltip
            // 
            this.lblTooltip.AutoSize = true;
            this.lblTooltip.Location = new System.Drawing.Point(7, 304);
            this.lblTooltip.Name = "lblTooltip";
            this.lblTooltip.Size = new System.Drawing.Size(42, 13);
            this.lblTooltip.TabIndex = 21;
            this.lblTooltip.Text = "Tooltip:";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDisplayName.Location = new System.Drawing.Point(51, 276);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(190, 20);
            this.txtDisplayName.TabIndex = 24;
            // 
            // btnChangeSprite
            // 
            this.btnChangeSprite.Location = new System.Drawing.Point(10, 218);
            this.btnChangeSprite.Name = "btnChangeSprite";
            this.btnChangeSprite.Size = new System.Drawing.Size(231, 23);
            this.btnChangeSprite.TabIndex = 20;
            this.btnChangeSprite.Text = "Change Sprite";
            this.btnChangeSprite.UseVisualStyleBackColor = true;
            this.btnChangeSprite.Click += new System.EventHandler(this.btnChangeSprite_Click);
            // 
            // pbSprite
            // 
            this.pbSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSprite.Location = new System.Drawing.Point(51, 58);
            this.pbSprite.Name = "pbSprite";
            this.pbSprite.Size = new System.Drawing.Size(154, 154);
            this.pbSprite.TabIndex = 19;
            this.pbSprite.TabStop = false;
            this.pbSprite.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSprite_Paint);
            // 
            // btnAdditionalSprites
            // 
            this.btnAdditionalSprites.Location = new System.Drawing.Point(10, 247);
            this.btnAdditionalSprites.Name = "btnAdditionalSprites";
            this.btnAdditionalSprites.Size = new System.Drawing.Size(231, 23);
            this.btnAdditionalSprites.TabIndex = 26;
            this.btnAdditionalSprites.Text = "Additional Sprites";
            this.btnAdditionalSprites.UseVisualStyleBackColor = true;
            this.btnAdditionalSprites.Click += new System.EventHandler(this.btnAdditionalSprites_Click);
            // 
            // btnRecipe
            // 
            this.btnRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecipe.Location = new System.Drawing.Point(51, 402);
            this.btnRecipe.Name = "btnRecipe";
            this.btnRecipe.Size = new System.Drawing.Size(190, 23);
            this.btnRecipe.TabIndex = 27;
            this.btnRecipe.Text = "Edit Recipe";
            this.btnRecipe.UseVisualStyleBackColor = true;
            this.btnRecipe.Click += new System.EventHandler(this.btnRecipe_Click);
            // 
            // wvSave
            // 
            this.wvSave.AllowExternalDrop = true;
            this.wvSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wvSave.CreationProperties = null;
            this.wvSave.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wvSave.Location = new System.Drawing.Point(624, 12);
            this.wvSave.Name = "wvSave";
            this.wvSave.Size = new System.Drawing.Size(156, 40);
            this.wvSave.Source = new System.Uri("C:\\Users\\rjand\\Documents\\GitHub\\tModMaker\\Blockly Editor", System.UriKind.Absolute);
            this.wvSave.TabIndex = 28;
            this.wvSave.Visible = false;
            this.wvSave.ZoomFactor = 1D;
            this.wvSave.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.wvSave_NavigationCompleted);
            this.wvSave.WebMessageReceived += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs>(this.wvSave_WebMessageReceived);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wvSave);
            this.Controls.Add(this.btnRecipe);
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnAdditionalSprites);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pbSprite);
            this.Controls.Add(this.btnChangeSprite);
            this.Controls.Add(this.stsBottom);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.lblTooltip);
            this.Controls.Add(this.msMain);
            this.Controls.Add(this.lblDisplayName);
            this.Controls.Add(this.wvCode);
            this.Controls.Add(this.txtTooltip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Main";
            this.Text = "Form1";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.stsBottom.ResumeLayout(false);
            this.stsBottom.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wvSave)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.StatusStrip stsBottom;
        private System.Windows.Forms.ToolStripProgressBar pbSave;
        private System.Windows.Forms.ToolStripMenuItem btnNew;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbNew;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.ToolStripButton tbOpen;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvCode;
        private System.Windows.Forms.TextBox txtTooltip;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblTooltip;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Button btnChangeSprite;
        private System.Windows.Forms.PictureBox pbSprite;
        private System.Windows.Forms.Button btnAdditionalSprites;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openExportDirectoryToolStripMenuItem;
        private System.Windows.Forms.Button btnRecipe;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
    }
}

