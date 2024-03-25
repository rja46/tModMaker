using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NEA_solution
{
    public partial class RecipeEditor : Form
    {
        RecipeItem currentItem;
        List<RecipeItem> IngredientsList = new List<RecipeItem>();
        public RecipeItem[] outputArray;
        public RecipeEditor(Item item)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            string[] items = File.ReadAllLines(Environment.CurrentDirectory + "\\itemIDs.txt");
            for (int i = 0; i < items.Length; i++)
            {
                cbIngredient.Items.Add(items[i]);
            }
            if (item.get_ingredients() != null)
            {
                for (int i = 0; i < item.get_ingredients().Length; i++)
                {
                    lbIngredients.Items.Add(item.get_ingredients()[i].itemName);
                    IngredientsList.Add(item.get_ingredients()[i]);
                }
            }
            lbIngredients.SelectedIndex = 0;
            numQuantity.Value = IngredientsList[0].quantity;
        }

        private void lbIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbIngredients.SelectedIndex != -1)
            {
                currentItem = IngredientsList[lbIngredients.SelectedIndex];
                cbIngredient.Text = currentItem.itemName;
                numQuantity.Value = currentItem.quantity;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lbIngredients.Items.Add("NEW ITEM");
            numQuantity.Value = 1;
            IngredientsList.Add(new RecipeItem("NEW ITEM", 1));
        }

        private void cbIngredient_TextChanged(object sender, EventArgs e)
        {
            currentItem.itemName = cbIngredient.Text;
            lbIngredients.Items[lbIngredients.SelectedIndex] = cbIngredient.Text;
            lbIngredients.Refresh();
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            currentItem.quantity = (int)numQuantity.Value;
        }

        private void lbIngredients_SelectedValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine(lbIngredients.SelectedIndex);
        }

        private void RecipeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            outputArray = IngredientsList.ToArray();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            IngredientsList.Remove(currentItem);
            lbIngredients.Items.Clear();
            foreach (RecipeItem item in IngredientsList)
            {
                lbIngredients.Items.Add(item.itemName);
            }
            lbIngredients.Refresh();
        }
    }
}
