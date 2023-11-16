using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
        Mod loadedMod;
        Item loadedItem;
        EditItem editItem;
        public Main()
        {
            //MessageBox.Show("Hi Sir, please do not click one item 4 times in a short space of time.");
            InitializeComponent();
            this.Text = "tModMaker";
            loadedMod = new Mod("", "");
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
            lbItems.Items.Clear();
            string[,] displayText = loadedMod.get_items_for_display();
            for (int i = 0; i < displayText.GetLength(0); i++)
            {
                lbItems.Items.Add(displayText[i, 0]);
            }
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
                update_loaded_item(lbItems.SelectedIndex);
        }

        private void update_loaded_item(int index)
        {
            loadedItem = loadedMod.get_item(index);
        }


        private void fileSaveModAs_Click(object sender, EventArgs e)
        {
            save_mod_as();
        }

        private void fileSaveMod_Click(object sender, EventArgs e)
        {
            try
            {
                save_mod();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Path cannot be the empty string or all whitespace.")
                {
                    save_mod_as();
                }
            }
        }
        private void save_mod_as()
        {
            if (loadedMod.get_name() == "")
            {
                NameDialog nameDialog = new NameDialog();
                DialogResult result = nameDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    loadedMod.set_name(nameDialog.name);
                }
                else
                {
                    return;
                }
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                loadedMod.set_modPath(dialog.SelectedPath + "\\" + loadedMod.get_name());
                save_mod();
            }
        }

        private async void save_mod()
        {
            if (editItem != null)
            {
               await editItem.save_item();
            }
            string thePath = loadedMod.get_modPath();
            string modFile = "";
            string tempItem;
            modFile += loadedMod.get_name() + "|";
            modFile += loadedMod.get_description() + "|";
            modFile += loadedMod.get_author();
            pbSave.Step = 1;
            pbSave.Minimum = 1;
            if (loadedMod.get_item_number() > 0)
            {
                pbSave.Maximum = loadedMod.get_item_number();
            }
            else
            {
                pbSave.Maximum = 1;
            }
            pbSave.Value = 1;
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
                if (!Directory.Exists(thePath + "\\Items\\Sprites"))
                {
                    Directory.CreateDirectory(thePath + "\\Items\\Sprites");
                }
                for (int i = 0; i < loadedMod.get_item_number(); i++)
                {
                    tempItem = "";
                    tempItem += loadedMod.get_item(i).get_name() + "|";
                    tempItem += loadedMod.get_item(i).get_displayName() + "|";
                    tempItem += loadedMod.get_item(i).get_tooltip() + "|";
                    tempItem += loadedMod.get_item(i).get_type();
                    File.WriteAllText(thePath + "\\Items\\" + loadedMod.get_item(i).get_name() + ".item", tempItem);
                    Console.WriteLine("new loop");
                    Console.WriteLine(loadedMod.get_item(i).get_code());
                    File.WriteAllText(thePath + "\\Items\\Code\\" + loadedMod.get_item(i).get_name() + "_code.code", loadedMod.get_item(i).get_code());
                    Bitmap bmp = loadedMod.get_item(i).get_sprite();
                    File.Delete(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + ".png");
                    if (bmp != null)
                    {
                        bmp.Save(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + ".png", ImageFormat.Png);
                    }
                    pbSave.PerformStep();
                }
            }
        }
        private void fileOpenMod_Click(object sender, EventArgs e)
        {
            open_mod();
        }
        private void load_items_for_mod()
        {
            string[] existingItems;
            string[] existingCode;
            string[] existingSprites;
            Item currentItem;
            string[] tmpProperties;
            string tmpFile;
            {
                if (Directory.Exists(loadedMod.get_modPath() + "\\Items") 
                    && Directory.Exists(loadedMod.get_modPath() + "\\Items\\Code") 
                    && Directory.Exists(loadedMod.get_modPath() + "\\Items\\Sprites"))
                {
                    existingItems = Directory.GetFiles(loadedMod.get_modPath() + "\\Items");
                    existingCode = Directory.GetFiles(loadedMod.get_modPath() + "\\Items\\Code");
                    existingSprites = Directory.GetFiles(loadedMod.get_modPath() + "\\Items\\Sprites");
                    if (existingItems.Length == 0)
                    {
                        return;
                    }
                    else
                    {
                        lbItems.Items.Clear();
                        for (int i = 0; i < existingItems.Length; i++)
                        {
                            tmpFile = File.ReadAllText(existingItems[i]);
                            tmpProperties = tmpFile.Split('|');
                            currentItem = new Item(tmpProperties[0], tmpProperties[3]);
                            currentItem.set_display_name(tmpProperties[1]);
                            currentItem.set_tooltip(tmpProperties[2]);
                            currentItem.set_code(File.ReadAllText(existingCode[i]));
                            for (int j = 0; j < existingSprites.Length; j++)
                            {
                                if (loadedMod.get_modPath() + "\\Items\\Sprites\\" + currentItem.get_name() + ".png" == existingSprites[j])
                                {
                                    FileStream fileHandler = File.Open(existingSprites[j], FileMode.Open);
                                    currentItem.set_sprite(new Bitmap(fileHandler));
                                    fileHandler.Close();
                                }
                            }
                            loadedMod.add_item(currentItem);
                            update_item_list();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid folder");
                }
            }
        }

        private void modDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditDetailsDialog editDetailsDialog = new EditDetailsDialog(loadedMod.get_name(), loadedMod.get_author(), loadedMod.get_description());
            DialogResult result = editDetailsDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadedMod.set_name(editDetailsDialog.name);
                loadedMod.set_author(editDetailsDialog.author);
                loadedMod.set_description(editDetailsDialog.description);
                this.Text = loadedMod.get_name();
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Confirm action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (lbItems.SelectedIndex != -1)
                {
                    Item[] tmpItems = new Item[loadedMod.get_item_number() - 1];
                    int indexToDelete = lbItems.SelectedIndex;
                    int count = 0;
                    for (int i = 0; i < loadedMod.get_item_number(); i++)
                    {
                        if (i != indexToDelete)
                        {
                            tmpItems[count] = loadedMod.get_item(i);
                            count++;
                        }
                    }
                    File.Delete(loadedMod.get_modPath() + "\\Items\\" + loadedItem.get_name() + ".item");
                    File.Delete(loadedMod.get_modPath() + "\\Items\\Code\\" + loadedItem.get_name() + "_code.code");
                    loadedMod.set_items(tmpItems);
                    update_item_list();
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_project();
        }

        private void tbNew_Click(object sender, EventArgs e)
        {
            new_project();
        }

        private void new_project()
        {
            DialogResult result = MessageBox.Show("Are you sure? Unsaved work will be lost.", "Confirm action", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                loadedMod = new Mod("", "");
                update_item_list();
                update_loaded_item(-1);
            }
        }

        private void tbOpen_Click(object sender, EventArgs e)
        {
            open_mod();
        }

        private void open_mod()
        {
            Mod theMod;
            string modDetails;
            string[] modDetailsSplit;
            string[] existingFiles;
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                existingFiles = Directory.GetFiles(folderDialog.SelectedPath);
                if (existingFiles.Length != 1)
                {
                    MessageBox.Show("Please select a valid folder");
                    return;
                }   
                else
                {
                    pnlItem.Controls.Clear();
                    modDetails = File.ReadAllText(existingFiles[0]);
                    modDetailsSplit = modDetails.Split('|');
                    theMod = new Mod(modDetailsSplit[0], folderDialog.SelectedPath);
                    theMod.set_description(modDetailsSplit[1]);
                    theMod.set_author(modDetailsSplit[2]);
                    loadedMod = theMod;
                    Text = "tModLoader - " + loadedMod.get_name();
             
                }
                load_items_for_mod();
            }
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            try
            {
                save_mod();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Path cannot be the empty string or all whitespace.")
                {
                    save_mod_as();
                }
            }
        }

        private void lbItems_DoubleClick(object sender, EventArgs e)
        {
            if (loadedItem != null)
            {
                if (editItem != null)
                {
                    editItem.Close();
                }
                pnlItem.Controls.Clear();
                editItem = new EditItem(loadedItem, loadedMod.get_modPath());
                editItem.TopLevel = false;
                pnlItem.Controls.Add(editItem);
                editItem.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                editItem.Dock = DockStyle.Fill;
                editItem.Size = new Size(pnlItem.Size.Width, pnlItem.Size.Height);
                editItem.Show();
                loadedItem = editItem.theItem;
                update_item_list();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;
            string tmpCode;
            //get path for output
            //validate if the mod is going to overwrite the editable files: do they have the same name.
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult dialogResult = fd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                path = fd.SelectedPath + "\\" + loadedMod.get_name();
                
                //create an array of the items
                Item[] itemsToExport = new Item[loadedMod.get_item_number()];
                for (int i = 0; i < itemsToExport.Length; i++)
                {
                    itemsToExport[i] = loadedMod.get_item(i);
                }

                //create the necessary directories
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + "\\Items");
                //need to get the files for these 2
                Directory.CreateDirectory(path + "\\Localization");
                Directory.CreateDirectory(path + "\\Properties");

                File.WriteAllText(path + "\\description.txt", loadedMod.get_description());
                //add functionality to enter a version number
                File.WriteAllText(path + "\\build.txt", "displayName = " + loadedMod.get_name() + "\nauthor = " + loadedMod.get_author() + "\nversion = 0.1");

                //save code and sprite for each item
                Bitmap bmp;
                for (int i = 0; i < itemsToExport.Length; i++)
                {
                    //this works, but i need to prevent the user from using spaces in names.
                    tmpCode = "using Terraria;\r\nusing Terraria.ID;\r\nusing Terraria.ModLoader;\r\nnamespace " + loadedMod.get_name() + ".Items\r\n{\r\n\tpublic class " + itemsToExport[i].get_name() + " : ModItem\r\n\t{";
                    tmpCode += itemsToExport[i].get_exportedCode();
                    tmpCode += "\t}\r\n}";
                    File.WriteAllText(path + "\\Items\\" + itemsToExport[i].get_name() + ".cs", tmpCode);
                    bmp = itemsToExport[i].get_sprite();
                    bmp.Save(path + "\\Items\\" + itemsToExport[i].get_name() + ".png", ImageFormat.Png);
                }
            }

        }
    }
}
