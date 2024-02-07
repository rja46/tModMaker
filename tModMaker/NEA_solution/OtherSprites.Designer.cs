namespace NEA_solution
{
    partial class OtherSprites
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
            this.pbWingSprite = new System.Windows.Forms.PictureBox();
            this.btnChangeWingSprite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbWingSprite)).BeginInit();
            this.SuspendLayout();
            // 
            // pbWingSprite
            // 
            this.pbWingSprite.Location = new System.Drawing.Point(12, 12);
            this.pbWingSprite.Name = "pbWingSprite";
            this.pbWingSprite.Size = new System.Drawing.Size(154, 154);
            this.pbWingSprite.TabIndex = 0;
            this.pbWingSprite.TabStop = false;
            this.pbWingSprite.Paint += new System.Windows.Forms.PaintEventHandler(this.pbWingSprite_Paint);
            // 
            // btnChangeWingSprite
            // 
            this.btnChangeWingSprite.Location = new System.Drawing.Point(12, 172);
            this.btnChangeWingSprite.Name = "btnChangeWingSprite";
            this.btnChangeWingSprite.Size = new System.Drawing.Size(154, 23);
            this.btnChangeWingSprite.TabIndex = 1;
            this.btnChangeWingSprite.Text = "Change Wing Sprite";
            this.btnChangeWingSprite.UseVisualStyleBackColor = true;
            this.btnChangeWingSprite.Click += new System.EventHandler(this.btnChangeWingSprite_Click);
            // 
            // OtherSprites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 204);
            this.Controls.Add(this.btnChangeWingSprite);
            this.Controls.Add(this.pbWingSprite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OtherSprites";
            this.Text = "OtherSprites";
            ((System.ComponentModel.ISupportInitialize)(this.pbWingSprite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbWingSprite;
        private System.Windows.Forms.Button btnChangeWingSprite;
    }
}