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
            this.SuspendLayout();
            // 
            // btnLoadMod
            // 
            this.btnLoadMod.Location = new System.Drawing.Point(93, 12);
            this.btnLoadMod.Name = "btnLoadMod";
            this.btnLoadMod.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMod.TabIndex = 0;
            this.btnLoadMod.Text = "Load";
            this.btnLoadMod.UseVisualStyleBackColor = true;
            this.btnLoadMod.Click += new System.EventHandler(this.btnLoadMod_Click);
            // 
            // btnCreateMod
            // 
            this.btnCreateMod.Location = new System.Drawing.Point(12, 12);
            this.btnCreateMod.Name = "btnCreateMod";
            this.btnCreateMod.Size = new System.Drawing.Size(75, 23);
            this.btnCreateMod.TabIndex = 1;
            this.btnCreateMod.Text = "Create";
            this.btnCreateMod.UseVisualStyleBackColor = true;
            this.btnCreateMod.Click += new System.EventHandler(this.btnCreateMod_Click);
            // 
            // loadCreateModDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateMod);
            this.Controls.Add(this.btnLoadMod);
            this.Name = "loadCreateModDialog";
            this.Text = "loadCreateModDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadMod;
        private System.Windows.Forms.Button btnCreateMod;
    }
}