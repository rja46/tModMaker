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
            Mod theMod = new Mod("untitled", "null");
            loadedMod = theMod;
            //loadedMod.add_item(new Item("test", "null"));
            //loadedMod.add_item(new Item("test", "null"));

            txtModName.Text = loadedMod.get_name();

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
            EditDetailsDialog editDetailsDialog = new EditDetailsDialog(loadedMod.get_name(),loadedMod.get_author(), loadedMod.get_description());
            DialogResult result = editDetailsDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadedMod.set_name(editDetailsDialog.name);
                loadedMod.set_author(editDetailsDialog.author);
                loadedMod.set_description(editDetailsDialog.description);
                txtModName.Text = loadedMod.get_name();
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            CreateItemDialog createItemDialog = new CreateItemDialog();
            DialogResult result = createItemDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //get new item from CreateItem form
                loadedMod.add_item(createItemDialog.newItem);
                
                update_item_list();
            }
        }

        private void update_item_list()
        {
            lbType.Items.Clear();
            lbItems.Items.Clear();
            string[,] displayText = loadedMod.get_items_for_display();
            string items = "";
            string types = "";
            for (int i = 0; i < displayText.GetLength(0); i++)
            {
                lbItems.Items.Add(displayText[i,0]);
                lbType.Items.Add(displayText[i, 1]);
            }
        }
    }
}
