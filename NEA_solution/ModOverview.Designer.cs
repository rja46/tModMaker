namespace NEA_solution
{
    partial class ModOverview
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
            this.txtModName = new System.Windows.Forms.TextBox();
            this.btnEditDetails = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.lbType = new System.Windows.Forms.ListBox();
            this.pnlItemPreview = new System.Windows.Forms.Panel();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnChangeSprite = new System.Windows.Forms.Button();
            this.lblItemType = new System.Windows.Forms.Label();
            this.pbSprite = new System.Windows.Forms.PictureBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnViewFiles = new System.Windows.Forms.Button();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.msMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveMod = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveModAs = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMod = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlItemPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtModName
            // 
            this.txtModName.Location = new System.Drawing.Point(12, 37);
            this.txtModName.Name = "txtModName";
            this.txtModName.Size = new System.Drawing.Size(192, 20);
            this.txtModName.TabIndex = 1;
            this.txtModName.TextChanged += new System.EventHandler(this.txtModName_TextChanged);
            // 
            // btnEditDetails
            // 
            this.btnEditDetails.Location = new System.Drawing.Point(210, 35);
            this.btnEditDetails.Name = "btnEditDetails";
            this.btnEditDetails.Size = new System.Drawing.Size(75, 23);
            this.btnEditDetails.TabIndex = 2;
            this.btnEditDetails.Text = "Edit Details";
            this.btnEditDetails.UseVisualStyleBackColor = true;
            this.btnEditDetails.Click += new System.EventHandler(this.btnEditDetails_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(12, 415);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(74, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(246, 60);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Type";
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(12, 77);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(163, 329);
            this.lbItems.TabIndex = 7;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            // 
            // lbType
            // 
            this.lbType.FormattingEnabled = true;
            this.lbType.Location = new System.Drawing.Point(181, 77);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(163, 329);
            this.lbType.TabIndex = 8;
            this.lbType.SelectedIndexChanged += new System.EventHandler(this.lbType_SelectedIndexChanged);
            // 
            // pnlItemPreview
            // 
            this.pnlItemPreview.Controls.Add(this.btnEditItem);
            this.pnlItemPreview.Controls.Add(this.btnDeleteItem);
            this.pnlItemPreview.Controls.Add(this.btnChangeSprite);
            this.pnlItemPreview.Controls.Add(this.lblItemType);
            this.pnlItemPreview.Controls.Add(this.pbSprite);
            this.pnlItemPreview.Controls.Add(this.lblItemName);
            this.pnlItemPreview.Location = new System.Drawing.Point(350, 60);
            this.pnlItemPreview.Name = "pnlItemPreview";
            this.pnlItemPreview.Size = new System.Drawing.Size(303, 144);
            this.pnlItemPreview.TabIndex = 9;
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(219, 93);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(75, 23);
            this.btnEditItem.TabIndex = 11;
            this.btnEditItem.Text = "Edit Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(138, 93);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteItem.TabIndex = 10;
            this.btnDeleteItem.Text = "Delete Item";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            // 
            // btnChangeSprite
            // 
            this.btnChangeSprite.Location = new System.Drawing.Point(138, 64);
            this.btnChangeSprite.Name = "btnChangeSprite";
            this.btnChangeSprite.Size = new System.Drawing.Size(156, 23);
            this.btnChangeSprite.TabIndex = 3;
            this.btnChangeSprite.Text = "sprite";
            this.btnChangeSprite.UseVisualStyleBackColor = true;
            this.btnChangeSprite.Click += new System.EventHandler(this.btnChangeSprite_Click);
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Location = new System.Drawing.Point(138, 38);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(31, 13);
            this.lblItemType.TabIndex = 2;
            this.lblItemType.Text = "Type";
            // 
            // pbSprite
            // 
            this.pbSprite.ImageLocation = "";
            this.pbSprite.Location = new System.Drawing.Point(12, 12);
            this.pbSprite.Name = "pbSprite";
            this.pbSprite.Size = new System.Drawing.Size(120, 120);
            this.pbSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSprite.TabIndex = 1;
            this.pbSprite.TabStop = false;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(138, 12);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(35, 13);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Name";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(713, 415);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnViewFiles
            // 
            this.btnViewFiles.Location = new System.Drawing.Point(291, 34);
            this.btnViewFiles.Name = "btnViewFiles";
            this.btnViewFiles.Size = new System.Drawing.Size(75, 23);
            this.btnViewFiles.TabIndex = 11;
            this.btnViewFiles.Text = "View Files";
            this.btnViewFiles.UseVisualStyleBackColor = true;
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMainFile});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(800, 24);
            this.msMain.TabIndex = 12;
            this.msMain.Text = "menuStrip1";
            // 
            // msMainFile
            // 
            this.msMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSaveMod,
            this.fileSaveModAs,
            this.fileOpenMod});
            this.msMainFile.Name = "msMainFile";
            this.msMainFile.Size = new System.Drawing.Size(37, 20);
            this.msMainFile.Text = "File";
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
            // ModOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnViewFiles);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pnlItemPreview);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnEditDetails);
            this.Controls.Add(this.txtModName);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "ModOverview";
            this.Text = "Form1";
            this.pnlItemPreview.ResumeLayout(false);
            this.pnlItemPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtModName;
        private System.Windows.Forms.Button btnEditDetails;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.ListBox lbType;
        private System.Windows.Forms.Panel pnlItemPreview;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.PictureBox pbSprite;
        private System.Windows.Forms.Button btnChangeSprite;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnViewFiles;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem msMainFile;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMod;
        private System.Windows.Forms.ToolStripMenuItem fileSaveModAs;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMod;
    }
}

