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
            this.btnBack = new System.Windows.Forms.Button();
            this.pbSprite = new System.Windows.Forms.PictureBox();
            this.btnChangeSprite = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTooltip = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtTooltip = new System.Windows.Forms.TextBox();
            this.webViewCode = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewCode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(55, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pbSprite
            // 
            this.pbSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSprite.Location = new System.Drawing.Point(73, 12);
            this.pbSprite.Name = "pbSprite";
            this.pbSprite.Size = new System.Drawing.Size(170, 170);
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
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 234);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(9, 260);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type:";
            // 
            // lblTooltip
            // 
            this.lblTooltip.AutoSize = true;
            this.lblTooltip.Location = new System.Drawing.Point(9, 286);
            this.lblTooltip.Name = "lblTooltip";
            this.lblTooltip.Size = new System.Drawing.Size(42, 13);
            this.lblTooltip.TabIndex = 5;
            this.lblTooltip.Text = "Tooltip:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(53, 231);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(190, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(53, 257);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(190, 20);
            this.txtType.TabIndex = 7;
            // 
            // txtTooltip
            // 
            this.txtTooltip.Location = new System.Drawing.Point(53, 283);
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
            this.webViewCode.Location = new System.Drawing.Point(249, 12);
            this.webViewCode.Name = "webViewCode";
            this.webViewCode.Size = new System.Drawing.Size(539, 397);
            this.webViewCode.Source = new System.Uri("C:\\Users\\rjand\\Documents\\GitHub\\tModMaker\\Blockly Editor\\index.html", System.UriKind.Absolute);
            this.webViewCode.TabIndex = 9;
            this.webViewCode.ZoomFactor = 1D;
            this.webViewCode.WebMessageReceived += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs>(this.webViewCode_WebMessageReceived);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(713, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.webViewCode);
            this.Controls.Add(this.txtTooltip);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTooltip);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnChangeSprite);
            this.Controls.Add(this.pbSprite);
            this.Controls.Add(this.btnBack);
            this.Name = "EditItem";
            this.Text = "editItem";
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox pbSprite;
        private System.Windows.Forms.Button btnChangeSprite;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTooltip;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtTooltip;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewCode;
        private System.Windows.Forms.Button btnSave;
    }
}