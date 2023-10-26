namespace NEA_solution
{
    partial class EditItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditItem));
            this.pbSprite = new System.Windows.Forms.PictureBox();
            this.btnChangeSprite = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTooltip = new System.Windows.Forms.Label();
            this.txtTooltip = new System.Windows.Forms.TextBox();
            this.webViewCode = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.stsBottom = new System.Windows.Forms.StatusStrip();
            this.pbSave = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFullscreen = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewCode)).BeginInit();
            this.stsBottom.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbSprite
            // 
            this.pbSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSprite.Location = new System.Drawing.Point(53, 28);
            this.pbSprite.Name = "pbSprite";
            this.pbSprite.Size = new System.Drawing.Size(154, 154);
            this.pbSprite.TabIndex = 1;
            this.pbSprite.TabStop = false;
            // 
            // btnChangeSprite
            // 
            this.btnChangeSprite.Location = new System.Drawing.Point(12, 188);
            this.btnChangeSprite.Name = "btnChangeSprite";
            this.btnChangeSprite.Size = new System.Drawing.Size(231, 23);
            this.btnChangeSprite.TabIndex = 2;
            this.btnChangeSprite.Text = "button1";
            this.btnChangeSprite.UseVisualStyleBackColor = true;
            this.btnChangeSprite.Click += new System.EventHandler(this.btnChangeSprite_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(9, 246);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type:";
            // 
            // lblTooltip
            // 
            this.lblTooltip.AutoSize = true;
            this.lblTooltip.Location = new System.Drawing.Point(9, 273);
            this.lblTooltip.Name = "lblTooltip";
            this.lblTooltip.Size = new System.Drawing.Size(42, 13);
            this.lblTooltip.TabIndex = 5;
            this.lblTooltip.Text = "Tooltip:";
            // 
            // txtTooltip
            // 
            this.txtTooltip.Location = new System.Drawing.Point(53, 270);
            this.txtTooltip.Multiline = true;
            this.txtTooltip.Name = "txtTooltip";
            this.txtTooltip.Size = new System.Drawing.Size(190, 155);
            this.txtTooltip.TabIndex = 8;
            // 
            // webViewCode
            // 
            this.webViewCode.AllowExternalDrop = true;
            this.webViewCode.CreationProperties = null;
            this.webViewCode.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewCode.Location = new System.Drawing.Point(249, 28);
            this.webViewCode.Name = "webViewCode";
            this.webViewCode.Size = new System.Drawing.Size(539, 397);
            this.webViewCode.Source = new System.Uri("C:\\Users\\rjand\\Documents\\GitHub\\tModMaker\\Blockly Editor\\index.html", System.UriKind.Absolute);
            this.webViewCode.TabIndex = 9;
            this.webViewCode.ZoomFactor = 1D;
            this.webViewCode.WebMessageReceived += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs>(this.webViewCode_WebMessageReceived);
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(53, 217);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(190, 20);
            this.txtDisplayName.TabIndex = 12;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Location = new System.Drawing.Point(9, 212);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(42, 29);
            this.lblDisplayName.TabIndex = 11;
            this.lblDisplayName.Text = "Display Name:";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Tool",
            "Accessory",
            "Tile",
            "Consumable",
            "Projectile",
            "NPC",
            "AI"});
            this.cbType.Location = new System.Drawing.Point(53, 243);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(190, 21);
            this.cbType.TabIndex = 13;
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
            this.btnSave,
            this.toolStripSeparator1,
            this.btnFullscreen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFullscreen
            // 
            this.btnFullscreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFullscreen.Image = ((System.Drawing.Image)(resources.GetObject("btnFullscreen.Image")));
            this.btnFullscreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullscreen.Name = "btnFullscreen";
            this.btnFullscreen.Size = new System.Drawing.Size(23, 22);
            this.btnFullscreen.Text = "Fullscreen Editor";
            this.btnFullscreen.Click += new System.EventHandler(this.btnFullscreen_Click);
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.stsBottom);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.lblDisplayName);
            this.Controls.Add(this.webViewCode);
            this.Controls.Add(this.txtTooltip);
            this.Controls.Add(this.lblTooltip);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnChangeSprite);
            this.Controls.Add(this.pbSprite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditItem";
            this.Text = "editItem";
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewCode)).EndInit();
            this.stsBottom.ResumeLayout(false);
            this.stsBottom.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbSprite;
        private System.Windows.Forms.Button btnChangeSprite;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTooltip;
        private System.Windows.Forms.TextBox txtTooltip;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewCode;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.StatusStrip stsBottom;
        private System.Windows.Forms.ToolStripProgressBar pbSave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFullscreen;
    }
}