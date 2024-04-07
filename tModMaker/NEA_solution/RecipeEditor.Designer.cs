namespace NEA_solution
{
    partial class RecipeEditor
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
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lbIngredients = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.cbIngredient = new System.Windows.Forms.ComboBox();
            this.cbStation = new System.Windows.Forms.ComboBox();
            this.lblStation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(138, 41);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 20);
            this.numQuantity.TabIndex = 2;
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // lbIngredients
            // 
            this.lbIngredients.FormattingEnabled = true;
            this.lbIngredients.Location = new System.Drawing.Point(12, 14);
            this.lbIngredients.Name = "lbIngredients";
            this.lbIngredients.Size = new System.Drawing.Size(120, 108);
            this.lbIngredients.TabIndex = 3;
            this.lbIngredients.SelectedIndexChanged += new System.EventHandler(this.lbIngredients_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(138, 67);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Ingredient";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(138, 96);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Ingredient";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // cbIngredient
            // 
            this.cbIngredient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbIngredient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbIngredient.FormattingEnabled = true;
            this.cbIngredient.Location = new System.Drawing.Point(138, 14);
            this.cbIngredient.Name = "cbIngredient";
            this.cbIngredient.Size = new System.Drawing.Size(120, 21);
            this.cbIngredient.TabIndex = 6;
            this.cbIngredient.TextChanged += new System.EventHandler(this.cbIngredient_TextChanged);
            // 
            // cbStation
            // 
            this.cbStation.FormattingEnabled = true;
            this.cbStation.Items.AddRange(new object[] {
            "By Hand",
            "Work Bench",
            "Furnace",
            "Hellforge",
            "Anvil",
            "Bottle",
            "Alchemy Table",
            "Sink",
            "Sawmill",
            "Loom",
            "Cooking Pot",
            "Tinkerer\'s Workbench",
            "Imbuing Station",
            "Dye Vat",
            "Heavy Work Bench",
            "Demon Altar",
            "Mythril Anvil",
            "Adamantite Forge",
            "Bookcase",
            "Crystal Ball",
            "Autohammer",
            "Lunar Crafting Station",
            "Keg",
            "Teapot",
            "Blend-O-Matic",
            "Meat Grinder",
            "Bone Welder",
            "Glass Kiln",
            "Honey Dispenser",
            "Ice Machine",
            "Living Loom",
            "Sky Mill",
            "Solidifer",
            "Decay Chamber",
            "Flesh Cloning Vat",
            "Steampunk Boiler",
            "Lihzahrd Furnace"});
            this.cbStation.Location = new System.Drawing.Point(100, 125);
            this.cbStation.Name = "cbStation";
            this.cbStation.Size = new System.Drawing.Size(158, 21);
            this.cbStation.TabIndex = 7;
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Location = new System.Drawing.Point(12, 128);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(82, 13);
            this.lblStation.TabIndex = 8;
            this.lblStation.Text = "Crafting Station:";
            // 
            // RecipeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 158);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.cbStation);
            this.Controls.Add(this.cbIngredient);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbIngredients);
            this.Controls.Add(this.numQuantity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RecipeEditor";
            this.Text = "Edit Recipe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecipeEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.ListBox lbIngredients;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox cbIngredient;
        private System.Windows.Forms.ComboBox cbStation;
        private System.Windows.Forms.Label lblStation;
    }
}