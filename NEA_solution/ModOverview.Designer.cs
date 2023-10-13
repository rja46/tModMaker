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
            this.lblItemName = new System.Windows.Forms.Label();
            this.pbSprite = new System.Windows.Forms.PictureBox();
            this.lblItemType = new System.Windows.Forms.Label();
            this.btnChangeSprite = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.pnlItemPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            this.SuspendLayout();
            // 
            // txtModName
            // 
            this.txtModName.Location = new System.Drawing.Point(12, 12);
            this.txtModName.Name = "txtModName";
            this.txtModName.Size = new System.Drawing.Size(192, 20);
            this.txtModName.TabIndex = 1;
            this.txtModName.TextChanged += new System.EventHandler(this.txtModName_TextChanged);
            // 
            // btnEditDetails
            // 
            this.btnEditDetails.Location = new System.Drawing.Point(210, 10);
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
            this.lblName.Location = new System.Drawing.Point(74, 35);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(246, 35);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Type";
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(12, 51);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(163, 355);
            this.lbItems.TabIndex = 7;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            // 
            // lbType
            // 
            this.lbType.FormattingEnabled = true;
            this.lbType.Location = new System.Drawing.Point(181, 51);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(163, 355);
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
            this.pnlItemPreview.Location = new System.Drawing.Point(350, 51);
            this.pnlItemPreview.Name = "pnlItemPreview";
            this.pnlItemPreview.Size = new System.Drawing.Size(303, 144);
            this.pnlItemPreview.TabIndex = 9;
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
            // pbSprite
            // 
            this.pbSprite.Location = new System.Drawing.Point(12, 12);
            this.pbSprite.Name = "pbSprite";
            this.pbSprite.Size = new System.Drawing.Size(120, 120);
            this.pbSprite.TabIndex = 1;
            this.pbSprite.TabStop = false;
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
            // btnChangeSprite
            // 
            this.btnChangeSprite.Location = new System.Drawing.Point(138, 64);
            this.btnChangeSprite.Name = "btnChangeSprite";
            this.btnChangeSprite.Size = new System.Drawing.Size(156, 23);
            this.btnChangeSprite.TabIndex = 3;
            this.btnChangeSprite.Text = "sprite";
            this.btnChangeSprite.UseVisualStyleBackColor = true;
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
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(219, 93);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(75, 23);
            this.btnEditItem.TabIndex = 11;
            this.btnEditItem.Text = "Edit Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            // 
            // ModOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlItemPreview);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnEditDetails);
            this.Controls.Add(this.txtModName);
            this.Name = "ModOverview";
            this.Text = "Form1";
            this.pnlItemPreview.ResumeLayout(false);
            this.pnlItemPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
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
    }
}

