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
    public partial class ModOverview : Form
    {
        //load this value from path
        Mod loadedMod;
        public ModOverview()
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

            update_item_list();
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

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            CreateItem createItem = new CreateItem();
            DialogResult result = createItem.ShowDialog();
            if (result == DialogResult.OK)
            {
                //get new item from CreateItem form
                loadedMod.add_item(createItem.newItem);
                
                update_item_list();
            }
        }

        private void update_item_list()
        {
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
    }
}
