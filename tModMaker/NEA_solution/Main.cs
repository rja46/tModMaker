using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace NEA_solution
{
    public partial class Main : Form
    {
        Mod loadedMod;
        Item loadedItem;
        EditItem editItem;
        bool returned;
        string tmpCodeFromBlockly;

        public Main()
        {
            //MessageBox.Show("Hi Sir, please do not click one item 4 times in a short space of time.");
            InitializeComponent();
            this.Text = "tModMaker";

            //creates a blank mod
            loadedMod = new Mod("", "");

            InitWebview();
            wvCodeGetter.Source = new Uri("C:\\Users\\rjand\\Documents\\GitHub\\tModMaker\\Blockly Editor\\tool_editor.html");

            initialise_editor();
        }

        private void initialise_editor()
        {
            pnlItem.Controls.Clear();
            editItem = new EditItem(loadedItem);
            editItem.TopLevel = false;
            pnlItem.Controls.Add(editItem);
            editItem.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            editItem.Dock = DockStyle.Fill;
            editItem.Size = new Size(pnlItem.Size.Width, pnlItem.Size.Height);
            editItem.Show();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //loads dialog to get the details for the new item
            CreateItemDialog createItemDialog = new CreateItemDialog();
            DialogResult result = createItemDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //get new item from CreateItem form
                loadedMod.add_item(createItemDialog.newItem);

                //updates the list of items in the mod
                update_item_list();
            }
        }

        private void update_item_list()
        {
            //loops through items and add their names to the list box
            lbItems.Items.Clear();
            string[,] displayText = loadedMod.get_items_for_display();
            for (int i = 0; i < displayText.GetLength(0); i++)
            {
                lbItems.Items.Add(displayText[i, 0]);
            }
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //changes the item loaded by the mod when a different one is select
            update_loaded_item(lbItems.SelectedIndex);
        }

        private void update_loaded_item(int index)
        {
            //loads the item specified by the index from the list of items in the mod
            loadedItem = loadedMod.get_item(index);
        }


        private void fileSaveModAs_Click(object sender, EventArgs e)
        {
            save_mod_as();
        }

        private void fileSaveMod_Click(object sender, EventArgs e)
        {
             save_mod();
        }

        private void save_mod_as()
        {
            if (loadedMod.get_name() == "")
            {
                //loads the dialog to ensure the mod has a name
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
            //opens a folder browser so the user can choose where the mod is saved
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                loadedMod.set_modPath(dialog.SelectedPath + "\\" + loadedMod.get_name());
                //once the necessary details exist, the regular save_mod() procedure is called
                save_mod();
            }
        }

        //this procedure is asynchronous as it waits to recieve the data from the web component
        private async void save_mod()
        {
            //if an item is loaded, it is saved
            if (editItem != null)
            {
               await editItem.save_item();
            }

            string thePath = loadedMod.get_modPath();
            string modFile = "";
            string tempItem;
            
            /*
            the details of the mod are compiled into one string, seperated with pipes,
            as it is a fairly uncommon character, and is unlikely to appear in the mod's
            details
            validation is needed here, because terrible things will happen if someone enters
            a pipe in any of these fields
            */
            modFile += loadedMod.get_name() + "|";
            modFile += loadedMod.get_description() + "|";
            modFile += loadedMod.get_author();

            /*
            the progress bar is set up to make a step for each item in the mod
            it is worth noting that the progress bar doesnt appear to work on 
            windows 11
            */
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

            //this creates the directory for the mod if it doesnt already exist
            if (!(Directory.Exists(thePath)))
            {
                //save_mod_as();
                //return;
            }

            Directory.CreateDirectory(thePath);

            //the details of the mod are written to a file here
            File.WriteAllText(thePath + "\\" + loadedMod.get_name() + ".mod", modFile);

            if (loadedMod.get_item_number() != 0)
            {
                //this checks for and creates other directories that need to exist
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

                //this loops through and saves each item
                for (int i = 0; i < loadedMod.get_item_number(); i++)
                {
                    //the details of the item and put into a string, then saved
                    tempItem = "";
                    tempItem += loadedMod.get_item(i).get_name() + "|";
                    tempItem += loadedMod.get_item(i).get_displayName() + "|";
                    tempItem += loadedMod.get_item(i).get_tooltip() + "|";
                    tempItem += loadedMod.get_item(i).get_type();
                    File.WriteAllText(thePath + "\\Items\\" + loadedMod.get_item(i).get_name() + ".item", tempItem);
                    
                    //the code is written to a seperate file
                    File.WriteAllText(thePath + "\\Items\\Code\\" + loadedMod.get_item(i).get_name() + "_code.code", loadedMod.get_item(i).get_code());
                    
                    Bitmap bmp = loadedMod.get_item(i).get_sprite();
                    File.Delete(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + ".png");
                    //if a sprite exists for the item, it is saved as a .png
                    if (bmp != null)
                    {
                        bmp.Save(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + ".png", ImageFormat.Png);
                    }

                    //the step for the progress bar is performed
                    pbSave.PerformStep();
                }
                finishPb(1000);
            }
        }

        //this doesnt work with any value <1000
        private async void finishPb(int delay)
        {
            await Task.Delay(delay);
            await Console.Out.WriteLineAsync("clearing");
            pbSave.Value = 1;
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
                //this ensures the correct structure exists in the specified directory
                if (Directory.Exists(loadedMod.get_modPath() + "\\Items") 
                    && Directory.Exists(loadedMod.get_modPath() + "\\Items\\Code") 
                    && Directory.Exists(loadedMod.get_modPath() + "\\Items\\Sprites"))
                {
                    //if it does, arrays of paths are created for each item, sprite, and code
                    existingItems = Directory.GetFiles(loadedMod.get_modPath() + "\\Items");
                    existingCode = Directory.GetFiles(loadedMod.get_modPath() + "\\Items\\Code");
                    existingSprites = Directory.GetFiles(loadedMod.get_modPath() + "\\Items\\Sprites");
                    
                    //this stops and item with no items from loading - it needs to be removed
                    if (existingItems.Length == 0)
                    {
                        return;
                    }
                    else
                    {
                        lbItems.Items.Clear();
                        for (int i = 0; i < existingItems.Length; i++)
                        {
                            //the contents of each path in the array are read
                            tmpFile = File.ReadAllText(existingItems[i]);

                            //the details are split by the dividing symbol
                            tmpProperties = tmpFile.Split('|');
                            
                            //the properties in the array created are used to assemble the item
                            currentItem = new Item(tmpProperties[0], tmpProperties[3]);
                            currentItem.set_display_name(tmpProperties[1]);
                            currentItem.set_tooltip(tmpProperties[2]);
                            currentItem.set_code(File.ReadAllText(existingCode[i]));

                            /*
                            sprites are assigned to their item by sharing a file name,
                            so this checks if a sprite corresponds to the item that has been loaded
                            */
                            for (int j = 0; j < existingSprites.Length; j++)
                            {
                                if (loadedMod.get_modPath() + "\\Items\\Sprites\\" + currentItem.get_name() + ".png" == existingSprites[j])
                                {
                                    FileStream fileHandler = File.Open(existingSprites[j], FileMode.Open);
                                    currentItem.set_sprite(new Bitmap(fileHandler));
                                    fileHandler.Close();
                                }
                            }
                            //the item is added to the list, then the displayed list is updated
                            loadedMod.add_item(currentItem);
                            update_item_list();
                        }
                    }
                }
                //this is triggered if the directory does not have the right structure
                else
                {
                    MessageBox.Show("Please select a valid folder");
                }
            }
        }

        private void modDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this opens a dialog where the user can edit the details of the mod
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
            //a confirmation dialog will appear
            DialogResult result = MessageBox.Show("Are you sure?", "Confirm action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //this ensures they have selected a valid item to delete
                if (lbItems.SelectedIndex != -1)
                {
                    /*
                    a list one shorter than the current one is created,
                     and every item except the deleted one is written to it
                    */
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
                    //the files for the item are deleted, and the list of items is overwritten
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
            //a confirmation dialog will appear
            DialogResult result = MessageBox.Show("Are you sure? Unsaved work will be lost.", "Confirm action", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                //a blank mod is created
                loadedMod = new Mod("", "");
                editItem.displayItem(new Item("", ""));
                editItem.clearBlockly();
                editItem.lock_controls();
                
                //the ui is reset
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
            
            //this opens a folder browser for the user to select the folder
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                existingFiles = Directory.GetFiles(folderDialog.SelectedPath);

                //ensures that the is only one directory (\\Items) in the directory selected
                if (existingFiles.Length != 1)
                {
                    MessageBox.Show("Please select a valid folder");
                    return;
                }   
                else
                {
                    //loads the details for the mod from the folder
                    //pnlItem.Controls.Clear();
                    modDetails = File.ReadAllText(existingFiles[0]);
                    modDetailsSplit = modDetails.Split('|');
                    theMod = new Mod(modDetailsSplit[0], folderDialog.SelectedPath);
                    theMod.set_description(modDetailsSplit[1]);
                    theMod.set_author(modDetailsSplit[2]);
                    loadedMod = theMod;
                    Text = "tModMaker - " + loadedMod.get_name();
                    editItem.displayItem(new Item("", ""));
                    editItem.clearBlockly();
                    editItem.lock_controls();
                }
                //calls the procedure to load the items
                load_items_for_mod();
            }
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            save_mod();
        }

        private void lbItems_DoubleClick(object sender, EventArgs e)
        {
            if (loadedItem != null)
            {
                editItem.displayItem(loadedItem);
                update_item_list();
            }
        }

        async void InitWebview()
        {
            await wvCodeGetter.EnsureCoreWebView2Async();
        }

        private async void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;
            string tmpCode;
            bool canExport = true;
            List<string> incompleteItems = new List<string>();
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
                
                File.WriteAllText(path + "\\" + loadedMod.get_name() + ".cs", "using Terraria.ModLoader;\r\n\r\nnamespace " + loadedMod.get_name() + "\r\n{\r\n\tpublic class " + loadedMod.get_name() + " : Mod\r\n\t{\r\n\t}\r\n}");

                File.WriteAllText(path + "\\" + loadedMod.get_name() + ".csproj", File.ReadAllText(@"projectConfig.txt"));

                //save code and sprite for each item
                Bitmap bmp;
                for (int i = 0; i < itemsToExport.Length; i++)
                {
                    returned = false;
                    //load code from web component
                    tmpCodeFromBlockly = "";
                    await wvCodeGetter.ExecuteScriptAsync("loadData('" + itemsToExport[i].get_code() + "')");

                    await wvCodeGetter.ExecuteScriptAsync("sendTranslatedCode()");
                    do
                    {
                        await Task.Delay(100);
                    }
                    while (returned == false);

                    //this works, but i need to prevent the user from using spaces in names.
                    tmpCode = "using Terraria;\r\nusing Terraria.ID;\r\nusing Terraria.ModLoader;\r\nnamespace " + loadedMod.get_name() + ".Items\r\n{\r\n\tpublic class " + itemsToExport[i].get_name() + " : ModItem\r\n\t{";
                    tmpCode += tmpCodeFromBlockly;
                    //this line MUST add a curly bracket to close set defaults.
                    tmpCode += "Item.SetNameOverride(\"" + itemsToExport[i].get_displayName() + "\");}";
                    tmpCode += "\r\n}\r\n}";
                    File.WriteAllText(path + "\\Items\\" + itemsToExport[i].get_name() + ".cs", tmpCode);
                    bmp = itemsToExport[i].get_sprite();
                    if (bmp == null)
                    {
                        incompleteItems.Add(itemsToExport[i].get_name());
                        canExport = false;
                    }
                    else
                    {
                        bmp.Save(path + "\\Items\\" + itemsToExport[i].get_name() + ".png", ImageFormat.Png);
                    }
                }

                //make this the last thing that runs
                if (!canExport)
                {
                    Directory.Delete(path, true);

                    string tmpString = "The following items cannot be exported:\n";
                    for (int i = 0;i < incompleteItems.Count; i++)
                    {
                        tmpString += "\u2022 " + incompleteItems[i] + "\n";
                    }
                    tmpString += "Please ensure all items have sprites, details, and code.";
                    MessageBox.Show(tmpString);
                }

                await Console.Out.WriteLineAsync("done exporting");
            }

        }

        private void wvCodeGetter_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            tmpCodeFromBlockly = e.TryGetWebMessageAsString();
            returned = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            DialogResult result = settings.ShowDialog();
            if (result == DialogResult.OK)
            {

            }
        }
    }
}
