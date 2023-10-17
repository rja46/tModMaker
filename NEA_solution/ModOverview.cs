using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace NEA_solution
{
    public partial class ModOverview : Form
    {
        //load this value from path
        Mod loadedMod;
        Item loadedItem;
        public ModOverview()
        {
            InitializeComponent();
            pnlItemPreview.Visible = false;

            loadCreateModDialog loadCreateModDialog = new loadCreateModDialog();
            loadCreateModDialog.ShowDialog();
            loadedMod = loadCreateModDialog.theMod;

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
            EditDetailsDialog editDetailsDialog = new EditDetailsDialog(loadedMod.get_name(), loadedMod.get_author(), loadedMod.get_description());
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
            for (int i = 0; i < displayText.GetLength(0); i++)
            {
                lbItems.Items.Add(displayText[i, 0]);
                lbType.Items.Add(displayText[i, 1]);
            }
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbItems.SelectedIndex != lbType.SelectedIndex)
            {
                lbType.SelectedIndex = lbItems.SelectedIndex;
                update_loaded_item(lbItems.SelectedIndex);
            }
        }

        private void lbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbType.SelectedIndex != lbItems.SelectedIndex)
            {
                lbItems.SelectedIndex = lbType.SelectedIndex;
                update_loaded_item(lbType.SelectedIndex);
            }
        }

        private void update_loaded_item(int index)
        {
            if (!pnlItemPreview.Visible)
            {
                pnlItemPreview.Visible = true;
            }
            loadedItem = loadedMod.get_item(index);
            lblItemName.Text = loadedItem.get_displayName();
            lblItemType.Text = loadedItem.get_type();
            btnChangeSprite.Text = loadedItem.get_name() + ".png";
            if (loadedItem.get_sprite().get_sprite_path() != null)
            {
                pbSprite.ImageLocation = loadedItem.get_sprite().get_sprite_path();
                Console.WriteLine(pbSprite.ImageLocation);
                pbSprite.Refresh();
            }
        }

        private void btnChangeSprite_Click(object sender, EventArgs e)
        {
            OpenFileDialog openSpriteDialog = new OpenFileDialog();
            openSpriteDialog.InitialDirectory = "c:\\";
            openSpriteDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            if (openSpriteDialog.ShowDialog() == DialogResult.OK)
            {
                loadedItem.get_sprite().set_sprite_path(@openSpriteDialog.FileName);
                pbSprite.ImageLocation = loadedItem.get_sprite().get_sprite_path();
                pbSprite.Refresh();
            }
        }

        private void fileSaveModAs_Click(object sender, EventArgs e)
        {

        }

        private void fileSaveMod_Click(object sender, EventArgs e)
        {
            string thePath = loadedMod.get_modPath();
            string modFile = "";
            modFile += loadedMod.get_name() + "|";
            modFile += loadedMod.get_description() + "|";
            modFile += loadedMod.get_author();
            if (!(Directory.Exists(thePath)))
            {
                Directory.CreateDirectory(thePath);
            }
            File.WriteAllText(thePath + "\\" + loadedMod.get_name() + ".txt", modFile);
        }
    }
}
