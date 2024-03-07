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
        public RecipeEditor()
        {
            InitializeComponent();
            string[] items = File.ReadAllLines(Environment.CurrentDirectory + "\\itemIDs.txt");
            for (int i = 0; i < items.Length; i++)
            {
                cbIngredient.Items.Add(items[i]);
            }
        }
    }
}
