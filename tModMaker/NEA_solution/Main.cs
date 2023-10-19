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
    public partial class Main : Form
    {
        //load this value from path
        Mod loadedMod;
        Item loadedItem;
        public Main()
        {
            InitializeComponent();

            loadCreateModDialog loadCreateModDialog = new loadCreateModDialog();
            loadCreateModDialog.ShowDialog();
            loadedMod = loadCreateModDialog.theMod;

            txtModName.Text = loadedMod.get_name();
            load_items_for_mod();
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
            loadedItem = loadedMod.get_item(index);
            txtItemName.Text = loadedItem.get_displayName();
            txtItemType.Text = loadedItem.get_type();
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
            if (loadedItem != null)
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
        }

        private void fileSaveModAs_Click(object sender, EventArgs e)
        {

        }

        private void fileSaveMod_Click(object sender, EventArgs e)
        {
            string thePath = loadedMod.get_modPath();
            string modFile = "";
            string tempItem;
            modFile += loadedMod.get_name() + "|";
            modFile += loadedMod.get_description() + "|";
            modFile += loadedMod.get_author();
            if (!(Directory.Exists(thePath)))
            {
                Directory.CreateDirectory(thePath);
            }
            File.WriteAllText(thePath + "\\" + loadedMod.get_name() + ".mod", modFile);
            if (loadedMod.get_item_number() != 0)
            {
                if (!Directory.Exists(thePath + "\\Items"))
                {
                    Directory.CreateDirectory(thePath + "\\Items");
                }
                if (!Directory.Exists(thePath + "\\Items\\Code"))
                {
                    Directory.CreateDirectory(thePath + "\\Items\\Code");
                }
                for (int i = 0; i < loadedMod.get_item_number(); i++)
                {
                    tempItem = "";
                    tempItem += loadedMod.get_item(i).get_name() + "|";
                    tempItem += loadedMod.get_item(i).get_displayName() + "|";
                    tempItem += loadedMod.get_item(i).get_tooltip() + "|";
                    tempItem += loadedMod.get_item(i).get_type();
                    File.WriteAllText(thePath + "\\Items\\" + loadedMod.get_item(i).get_name() + ".item", tempItem);
                    File.WriteAllText(thePath + "\\Items\\Code\\" + loadedMod.get_item(i).get_name() + "_code.code", loadedMod.get_item(i).get_code());

                }
            }
        }

        private void fileOpenMod_Click(object sender, EventArgs e)
        {
            //maybe make this a subroutine
            Mod theMod;
            string modDetails;
            string[] modDetailsSplit;
            string[] existingFiles;
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    existingFiles = Directory.GetFiles(folderDialog.SelectedPath);
                    if (existingFiles.Length != 1)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        modDetails = File.ReadAllText(existingFiles[0]);
                        modDetailsSplit = modDetails.Split('|');
                        theMod = new Mod(modDetailsSplit[0], folderDialog.SelectedPath);
                        theMod.set_description(modDetailsSplit[1]);
                        theMod.set_author(modDetailsSplit[2]);
                        loadedMod = theMod;
                    }
                }
                catch
                {
                    MessageBox.Show("Please select a valid folder");
                }
            }
            load_items_for_mod();
        }
        private void load_items_for_mod()
        {
            string[] existingItems;
            string[] existingCode;
            Item currentItem;
            string[] tmpProperties;
            string tmpFile;
            try
            {
                existingItems = Directory.GetFiles(loadedMod.get_modPath() + "\\Items");
                existingCode = Directory.GetFiles(loadedMod.get_modPath() + "\\Items\\Code");
                Console.WriteLine(loadedMod.get_modPath() + "\\Items");
                if (existingItems.Length == 0)
                {
                    throw new Exception();
                }
                else
                {
                    for (int i = 0; i < existingItems.Length; i++)
                    {
                        tmpFile = File.ReadAllText(existingItems[i]);
                        tmpProperties = tmpFile.Split('|');
                        currentItem = new Item(tmpProperties[0], tmpProperties[3]);
                        currentItem.set_display_name(tmpProperties[1]);
                        currentItem.set_tooltip(tmpProperties[2]);
                        currentItem.set_code(File.ReadAllText(existingCode[i]));
                        loadedMod.add_item(currentItem);
                        update_item_list();
                    }
                }
            }
            catch { }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (loadedItem != null)
            {
                EditItem editItem = new EditItem(loadedItem);
                DialogResult result = editItem.ShowDialog();
                if (result == DialogResult.OK)
                {
                    loadedItem = editItem.theItem;
                }
                editItem.ShowDialog();
            }
        }
    }
}
