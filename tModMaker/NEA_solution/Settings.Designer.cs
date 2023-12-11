namespace NEA_solution
{
    partial class Settings
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFolderDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(297, 20);
            this.txtPath.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(270, 38);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(189, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnFolderDialog
            // 
            this.btnFolderDialog.Location = new System.Drawing.Point(312, 12);
            this.btnFolderDialog.Name = "btnFolderDialog";
            this.btnFolderDialog.Size = new System.Drawing.Size(30, 20);
            this.btnFolderDialog.TabIndex = 3;
            this.btnFolderDialog.Text = "...";
            this.btnFolderDialog.UseVisualStyleBackColor = true;
            this.btnFolderDialog.Click += new System.EventHandler(this.btnFolderDialog_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 68);
            this.Controls.Add(this.btnFolderDialog);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtPath);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFolderDialog;
    }
}