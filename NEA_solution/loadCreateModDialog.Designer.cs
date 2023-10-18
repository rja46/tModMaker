namespace NEA_solution
{
    partial class loadCreateModDialog
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
            this.btnLoadMod = new System.Windows.Forms.Button();
            this.btnCreateMod = new System.Windows.Forms.Button();
            this.lbRecentMods = new System.Windows.Forms.ListBox();
            this.lblLoadProject = new System.Windows.Forms.Label();
            this.lbItem = new System.Windows.Forms.ListBox();
            this.lbType = new System.Windows.Forms.ListBox();
            this.pbSprite = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTooltip = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTooltip = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadMod
            // 
            this.btnLoadMod.Location = new System.Drawing.Point(713, 417);
            this.btnLoadMod.Name = "btnLoadMod";
            this.btnLoadMod.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMod.TabIndex = 0;
            this.btnLoadMod.Text = "Load";
            this.btnLoadMod.UseVisualStyleBackColor = true;
            this.btnLoadMod.Click += new System.EventHandler(this.btnLoadMod_Click);
            // 
            // btnCreateMod
            // 
            this.btnCreateMod.Location = new System.Drawing.Point(299, 4);
            this.btnCreateMod.Name = "btnCreateMod";
            this.btnCreateMod.Size = new System.Drawing.Size(75, 23);
            this.btnCreateMod.TabIndex = 1;
            this.btnCreateMod.Text = "Create";
            this.btnCreateMod.UseVisualStyleBackColor = true;
            this.btnCreateMod.Click += new System.EventHandler(this.btnCreateMod_Click);
            // 
            // lbRecentMods
            // 
            this.lbRecentMods.FormattingEnabled = true;
            this.lbRecentMods.Location = new System.Drawing.Point(12, 33);
            this.lbRecentMods.Name = "lbRecentMods";
            this.lbRecentMods.Size = new System.Drawing.Size(362, 407);
            this.lbRecentMods.TabIndex = 2;
            // 
            // lblLoadProject
            // 
            this.lblLoadProject.AutoSize = true;
            this.lblLoadProject.Location = new System.Drawing.Point(9, 9);
            this.lblLoadProject.Name = "lblLoadProject";
            this.lblLoadProject.Size = new System.Drawing.Size(67, 13);
            this.lblLoadProject.TabIndex = 3;
            this.lblLoadProject.Text = "Load Project";
            // 
            // lbItem
            // 
            this.lbItem.FormattingEnabled = true;
            this.lbItem.Location = new System.Drawing.Point(380, 238);
            this.lbItem.Name = "lbItem";
            this.lbItem.Size = new System.Drawing.Size(200, 173);
            this.lbItem.TabIndex = 4;
            // 
            // lbType
            // 
            this.lbType.FormattingEnabled = true;
            this.lbType.Location = new System.Drawing.Point(588, 238);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(200, 173);
            this.lbType.TabIndex = 5;
            // 
            // pbSprite
            // 
            this.pbSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSprite.Location = new System.Drawing.Point(380, 33);
            this.pbSprite.Name = "pbSprite";
            this.pbSprite.Size = new System.Drawing.Size(200, 200);
            this.pbSprite.TabIndex = 6;
            this.pbSprite.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(585, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(585, 59);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type:";
            // 
            // lblTooltip
            // 
            this.lblTooltip.AutoSize = true;
            this.lblTooltip.Location = new System.Drawing.Point(585, 85);
            this.lblTooltip.Name = "lblTooltip";
            this.lblTooltip.Size = new System.Drawing.Size(42, 13);
            this.lblTooltip.TabIndex = 9;
            this.lblTooltip.Text = "Tooltip:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(629, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(159, 20);
            this.txtName.TabIndex = 10;
            // 
            // txtTooltip
            // 
            this.txtTooltip.Location = new System.Drawing.Point(629, 82);
            this.txtTooltip.Multiline = true;
            this.txtTooltip.Name = "txtTooltip";
            this.txtTooltip.Size = new System.Drawing.Size(159, 150);
            this.txtTooltip.TabIndex = 11;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(629, 56);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(159, 20);
            this.txtType.TabIndex = 12;
            // 
            // loadCreateModDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtTooltip);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTooltip);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbSprite);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbItem);
            this.Controls.Add(this.lblLoadProject);
            this.Controls.Add(this.lbRecentMods);
            this.Controls.Add(this.btnCreateMod);
            this.Controls.Add(this.btnLoadMod);
            this.Name = "loadCreateModDialog";
            this.Text = "loadCreateModDialog";
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadMod;
        private System.Windows.Forms.Button btnCreateMod;
        private System.Windows.Forms.ListBox lbRecentMods;
        private System.Windows.Forms.Label lblLoadProject;
        private System.Windows.Forms.ListBox lbItem;
        private System.Windows.Forms.ListBox lbType;
        private System.Windows.Forms.PictureBox pbSprite;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTooltip;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTooltip;
        private System.Windows.Forms.TextBox txtType;
    }
}