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
            this.txtItems = new System.Windows.Forms.TextBox();
            this.txtModName = new System.Windows.Forms.TextBox();
            this.btnEditDetails = new System.Windows.Forms.Button();
            this.txtTypes = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtItems
            // 
            this.txtItems.Location = new System.Drawing.Point(12, 38);
            this.txtItems.Multiline = true;
            this.txtItems.Name = "txtItems";
            this.txtItems.ReadOnly = true;
            this.txtItems.Size = new System.Drawing.Size(163, 371);
            this.txtItems.TabIndex = 0;
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
            // txtTypes
            // 
            this.txtTypes.Location = new System.Drawing.Point(181, 39);
            this.txtTypes.Multiline = true;
            this.txtTypes.Name = "txtTypes";
            this.txtTypes.ReadOnly = true;
            this.txtTypes.Size = new System.Drawing.Size(163, 371);
            this.txtTypes.TabIndex = 3;
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
            // ModOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.txtTypes);
            this.Controls.Add(this.btnEditDetails);
            this.Controls.Add(this.txtModName);
            this.Controls.Add(this.txtItems);
            this.Name = "ModOverview";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItems;
        private System.Windows.Forms.TextBox txtModName;
        private System.Windows.Forms.Button btnEditDetails;
        private System.Windows.Forms.TextBox txtTypes;
        private System.Windows.Forms.Button btnAddItem;
    }
}

