using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_solution
{
    public partial class Form1 : Form
    {
        //load this value from path
        Mod loadedMod;
        public Form1()
        {
            InitializeComponent();

            //placeholder
            Mod theMod = new Mod("testMod", "null");
            loadedMod = theMod;

            txtModName.Text = loadedMod.get_name();
            theMod.add_item(new Item("testItem", "testType"));
            theMod.add_item(new Item("testThing", "Type"));
            theMod.add_item(new Item("aaaaa", "aaaaa"));
            theMod.add_item(new Item("12345", "12345"));
            
            //load items into lists
            string[,] displayText = loadedMod.get_items_for_display();
            string items = "";
            string types = "";
            for (int i = 0; i < displayText.GetLength(0); i++)
            {
                items += displayText[i, 0] + "\r\n";
                types += displayText[i, 1] + "\r\n";
            }
            txtItems.Text = items;
            txtTypes.Text = types;
        }

        private void txtModName_TextChanged(object sender, EventArgs e)
        {
            if (txtModName.Text != loadedMod.get_name())
            {
                loadedMod.set_name(txtModName.Text);
            }
        }

        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show(loadedMod.get_name());
        }
    }
}
