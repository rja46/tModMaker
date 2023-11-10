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
            this.pbSprite = new System.Windows.Forms.PictureBox();
            this.btnChangeSprite = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTooltip = new System.Windows.Forms.Label();
            this.txtTooltip = new System.Windows.Forms.TextBox();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.wvCode = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wvCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSprite
            // 
            this.pbSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSprite.Location = new System.Drawing.Point(47, 10);
            this.pbSprite.Name = "pbSprite";
            this.pbSprite.Size = new System.Drawing.Size(154, 154);
            this.pbSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSprite.TabIndex = 1;
            this.pbSprite.TabStop = false;
            this.pbSprite.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSprite_Paint);
            // 
            // btnChangeSprite
            // 
            this.btnChangeSprite.Location = new System.Drawing.Point(6, 170);
            this.btnChangeSprite.Name = "btnChangeSprite";
            this.btnChangeSprite.Size = new System.Drawing.Size(231, 23);
            this.btnChangeSprite.TabIndex = 2;
            this.btnChangeSprite.Text = "Change Sprite";
            this.btnChangeSprite.UseVisualStyleBackColor = true;
            this.btnChangeSprite.Click += new System.EventHandler(this.btnChangeSprite_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(3, 228);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type:";
            // 
            // lblTooltip
            // 
            this.lblTooltip.AutoSize = true;
            this.lblTooltip.Location = new System.Drawing.Point(3, 255);
            this.lblTooltip.Name = "lblTooltip";
            this.lblTooltip.Size = new System.Drawing.Size(42, 13);
            this.lblTooltip.TabIndex = 5;
            this.lblTooltip.Text = "Tooltip:";
            // 
            // txtTooltip
            // 
            this.txtTooltip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTooltip.Location = new System.Drawing.Point(47, 252);
            this.txtTooltip.Multiline = true;
            this.txtTooltip.Name = "txtTooltip";
            this.txtTooltip.Size = new System.Drawing.Size(190, 171);
            this.txtTooltip.TabIndex = 8;
            this.txtTooltip.TextChanged += new System.EventHandler(this.txtTooltip_TextChanged);
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(47, 199);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(190, 20);
            this.txtDisplayName.TabIndex = 12;
            this.txtDisplayName.TextChanged += new System.EventHandler(this.txtDisplayName_TextChanged);
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Location = new System.Drawing.Point(3, 194);
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
            this.cbType.Location = new System.Drawing.Point(47, 225);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(190, 21);
            this.cbType.TabIndex = 13;
            this.cbType.Click += new System.EventHandler(this.cbType_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.pbSprite);
            this.panel1.Controls.Add(this.btnChangeSprite);
            this.panel1.Controls.Add(this.cbType);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.txtDisplayName);
            this.panel1.Controls.Add(this.lblTooltip);
            this.panel1.Controls.Add(this.lblDisplayName);
            this.panel1.Controls.Add(this.txtTooltip);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 426);
            this.panel1.TabIndex = 16;
            // 
            // wvCode
            // 
            this.wvCode.AllowExternalDrop = true;
            this.wvCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wvCode.CreationProperties = null;
            this.wvCode.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wvCode.Location = new System.Drawing.Point(260, 12);
            this.wvCode.Name = "wvCode";
            this.wvCode.Size = new System.Drawing.Size(528, 426);
            this.wvCode.TabIndex = 17;
            this.wvCode.ZoomFactor = 1D;
            this.wvCode.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.wvCode_CoreWebView2InitializationCompleted);
            this.wvCode.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.wvCode_NavigationCompleted);
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wvCode);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditItem";
            this.Text = "editItem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditItem_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wvCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbSprite;
        private System.Windows.Forms.Button btnChangeSprite;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTooltip;
        private System.Windows.Forms.TextBox txtTooltip;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvCode;
    }
}