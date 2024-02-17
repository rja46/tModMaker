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
            this.pbHeadSprite = new System.Windows.Forms.PictureBox();
            this.pbBodySprite = new System.Windows.Forms.PictureBox();
            this.pbLegsSprite = new System.Windows.Forms.PictureBox();
            this.btnChangeHeadSprite = new System.Windows.Forms.Button();
            this.btnChangeBodySprite = new System.Windows.Forms.Button();
            this.btnChangeLegsSprite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbWingSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBodySprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLegsSprite)).BeginInit();
            this.SuspendLayout();
            // 
            // pbWingSprite
            // 
            this.pbWingSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            // pbHeadSprite
            // 
            this.pbHeadSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbHeadSprite.Location = new System.Drawing.Point(172, 12);
            this.pbHeadSprite.Name = "pbHeadSprite";
            this.pbHeadSprite.Size = new System.Drawing.Size(154, 154);
            this.pbHeadSprite.TabIndex = 2;
            this.pbHeadSprite.TabStop = false;
            // 
            // pbBodySprite
            // 
            this.pbBodySprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBodySprite.Location = new System.Drawing.Point(332, 12);
            this.pbBodySprite.Name = "pbBodySprite";
            this.pbBodySprite.Size = new System.Drawing.Size(154, 154);
            this.pbBodySprite.TabIndex = 3;
            this.pbBodySprite.TabStop = false;
            // 
            // pbLegsSprite
            // 
            this.pbLegsSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLegsSprite.Location = new System.Drawing.Point(492, 12);
            this.pbLegsSprite.Name = "pbLegsSprite";
            this.pbLegsSprite.Size = new System.Drawing.Size(154, 154);
            this.pbLegsSprite.TabIndex = 4;
            this.pbLegsSprite.TabStop = false;
            // 
            // btnChangeHeadSprite
            // 
            this.btnChangeHeadSprite.Location = new System.Drawing.Point(172, 172);
            this.btnChangeHeadSprite.Name = "btnChangeHeadSprite";
            this.btnChangeHeadSprite.Size = new System.Drawing.Size(154, 23);
            this.btnChangeHeadSprite.TabIndex = 5;
            this.btnChangeHeadSprite.Text = "Change Head Sprite";
            this.btnChangeHeadSprite.UseVisualStyleBackColor = true;
            // 
            // btnChangeBodySprite
            // 
            this.btnChangeBodySprite.Location = new System.Drawing.Point(332, 172);
            this.btnChangeBodySprite.Name = "btnChangeBodySprite";
            this.btnChangeBodySprite.Size = new System.Drawing.Size(154, 23);
            this.btnChangeBodySprite.TabIndex = 6;
            this.btnChangeBodySprite.Text = "Change Body Sprite";
            this.btnChangeBodySprite.UseVisualStyleBackColor = true;
            // 
            // btnChangeLegsSprite
            // 
            this.btnChangeLegsSprite.Location = new System.Drawing.Point(492, 172);
            this.btnChangeLegsSprite.Name = "btnChangeLegsSprite";
            this.btnChangeLegsSprite.Size = new System.Drawing.Size(154, 23);
            this.btnChangeLegsSprite.TabIndex = 7;
            this.btnChangeLegsSprite.Text = "Change Legs Sprite";
            this.btnChangeLegsSprite.UseVisualStyleBackColor = true;
            // 
            // OtherSprites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 204);
            this.Controls.Add(this.btnChangeLegsSprite);
            this.Controls.Add(this.btnChangeBodySprite);
            this.Controls.Add(this.btnChangeHeadSprite);
            this.Controls.Add(this.pbLegsSprite);
            this.Controls.Add(this.pbBodySprite);
            this.Controls.Add(this.pbHeadSprite);
            this.Controls.Add(this.btnChangeWingSprite);
            this.Controls.Add(this.pbWingSprite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OtherSprites";
            this.Text = "OtherSprites";
            ((System.ComponentModel.ISupportInitialize)(this.pbWingSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBodySprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLegsSprite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbWingSprite;
        private System.Windows.Forms.Button btnChangeWingSprite;
        private System.Windows.Forms.PictureBox pbHeadSprite;
        private System.Windows.Forms.PictureBox pbBodySprite;
        private System.Windows.Forms.PictureBox pbLegsSprite;
        private System.Windows.Forms.Button btnChangeHeadSprite;
        private System.Windows.Forms.Button btnChangeBodySprite;
        private System.Windows.Forms.Button btnChangeLegsSprite;
    }
}