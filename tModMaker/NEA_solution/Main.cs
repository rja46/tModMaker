using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        bool hasExportPath;
        string workspace;
        Item theItem;
        bool returned;
        bool saveReturned;
        bool wvready = false;
        bool wvSaveReady = false;

        public Main()
        {
            //MessageBox.Show("Hi Sir, please do not click one item 4 times in a short space of time.");
            InitializeComponent();
            Text = "tModMaker";

            //Loads an empty mod.
            loadedMod = new Mod("", "");

            if (File.ReadAllText(Environment.CurrentDirectory + "\\userConfig.txt") != "")
            {
                hasExportPath = true;
            }
            else { hasExportPath = false; }

            initialise_editor();
            load_recents();
        }

        private void load_recents()
        {
            string[] recents = File.ReadAllLines(Environment.CurrentDirectory + "\\recents.txt");
            openRecentToolStripMenuItem.DropDownItems.Clear();
            for (int i = 0;i < recents.Length; i++)
            {
                openRecentToolStripMenuItem.DropDownItems.Add(recents[i]);
                openRecentToolStripMenuItem.DropDownItems[i].Click += recent_click;
            }
        }

        private void recent_click(object sender, EventArgs e)
        {
            open_mod(sender.ToString());
        }

        private void initialise_editor()
        {
            //sets up the webview component running the editor
            InitWebview();
            wvCode.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\start.html");
            //wvCode.Source = new Uri("C:\\Users\\rjand\\Documents\\GitHub\\tModMaker\\Blockly Editor\\start.html");
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //Loads the dialog to get the details for the new item.
            CreateItemDialog createItemDialog = new CreateItemDialog();
            DialogResult result = createItemDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Gets the new item from CreateItem form.
                loadedMod.add_item(createItemDialog.newItem);

                //Updates the list of items in the mod.
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

        private async void update_loaded_item(int index)
        {
            //loads the item specified by the index from the list of items in the mod
            if (loadedItem != null)
            {
                requestData();
                returned = false;
                do
                {
                    await Task.Delay(100);

                }
                while (returned == false);
                loadedItem.set_code(workspace);
            }
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
                add_recent_path(loadedMod.get_modPath());
                save_mod();
            }
        }

        //this procedure is asynchronous as it waits to recieve the data from the web component
        private async void save_mod()
        {
            pbSave.Step = 1;
            pbSave.Minimum = 1;
            if (loadedMod.get_item_number() > 0)
            {
                pbSave.Maximum = loadedMod.get_item_number() * 2;
            }
            else
            {
                pbSave.Maximum = 1;
            }
            pbSave.Value = 1;
            //if an item is loaded, it is saved
            if (txtDisplayName.Text != "")
            {
                theItem.set_display_name(txtDisplayName.Text);
            }
            if (txtTooltip.Text != "")
            {
                theItem.set_tooltip(txtTooltip.Text);
            }
            if (loadedItem != null)
            {
                requestData();
                returned = false;
                do
                {
                    await Task.Delay(100);

                }
                while (returned == false);
                loadedItem.set_code(workspace);
            }
            for (int i = 0; i < loadedMod.get_item_number(); i++)
            {
                await Console.Out.WriteLineAsync(i.ToString());
                string prevSource = wvSave.Source.ToString();

                switch (loadedMod.get_item(i).get_type())
                {
                    case "Item":
                        wvSave.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\tool_editor.html");
                        break;

                    case "Projectile":
                        wvSave.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\projectile_editor.html");
                        break;

                    case "NPC":
                        wvSave.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\npc_editor.html");
                        break;
                }
                
                await Console.Out.WriteLineAsync("type found");

                if (prevSource != wvSave.Source.ToString())
                {
                    await Console.Out.WriteLineAsync(prevSource);
                    await Console.Out.WriteLineAsync(wvSave.Source.ToString());
                    wvSaveReady = false;
                    do
                    {
                        await Task.Delay(100);

                        await Console.Out.WriteLineAsync("waiting for uri");
                    }
                    while (wvSaveReady == false);
                }


                await Console.Out.WriteLineAsync("blockly loaded");
                
                await wvSave.ExecuteScriptAsync("loadData('" + loadedMod.get_item(i).get_code() + "')");
                
                await Console.Out.WriteLineAsync("data sent");
                
                requestSaveData();

                await Console.Out.WriteLineAsync("data request sent");
                
                saveReturned = false;
                do
                {
                    await Task.Delay(100);

                    await Console.Out.WriteLineAsync("waiting for data");
                }
                while (saveReturned == false);

                await Console.Out.WriteLineAsync("data recieved");

                loadedMod.get_item(i).set_code(workspace);

                await Console.Out.WriteLineAsync("code set");
                await Console.Out.WriteLineAsync(loadedMod.get_item(i).get_code());
                pbSave.PerformStep();
            }


            string thePath = loadedMod.get_modPath();
            string modFile = "";
            string tempItem;
            string recipeItems;
            
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
            


            /*
            if the mod is missing a path i.e. the placeholder is loaded, the save_mod_as(),
            then returns nothing for this procedure
            */
            if (thePath == "")
            {
                save_mod_as();
                return;
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
                if (!Directory.Exists(thePath + "\\Items\\Recipes"))
                {
                    Directory.CreateDirectory(thePath + "\\Items\\Recipes");
                }

                //this loops through and saves each item
                for (int i = 0; i < loadedMod.get_item_number(); i++)
                {
                    //the details of the item and put into a string, then saved
                    tempItem = "";
                    tempItem += loadedMod.get_item(i).get_name() + "\r\n";
                    tempItem += loadedMod.get_item(i).get_displayName() + "\r\n";
                    tempItem += loadedMod.get_item(i).get_tooltip() + "\r\n";
                    tempItem += loadedMod.get_item(i).get_type();
                    File.WriteAllText(thePath + "\\Items\\" + loadedMod.get_item(i).get_name() + ".item", tempItem);
                    
                    //the code is written to a seperate file
                    File.WriteAllText(thePath + "\\Items\\Code\\" + loadedMod.get_item(i).get_name() + "_code.code", loadedMod.get_item(i).get_code());

                    recipeItems = "";
                    for (int j = 0; j < loadedMod.get_item(i).get_ingredients().Length; j++)
                    {
                        recipeItems += loadedMod.get_item(i).get_ingredients()[j].itemName + "|" + loadedMod.get_item(i).get_ingredients()[j].quantity + "\r\n";
                    }
                    File.WriteAllText(thePath + "\\Items\\Recipes\\" + loadedMod.get_item(i).get_name() + "_recipe.recipe", recipeItems);
                    
                    Bitmap bmp = loadedMod.get_item(i).get_sprite();
                    //File.Delete(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + ".png");
                    //if a sprite exists for the item, it is saved as a .png
                    if (bmp != null)
                    {
                        bmp.Save(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + ".png", ImageFormat.Png);
                    }

                    bmp = loadedMod.get_item(i).get_wingSprite();
                    File.Delete(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + "_Wings.png");
                    if (bmp != null)
                    {
                        bmp.Save(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + "_Wings.png", ImageFormat.Png);
                    }

                    string itemType = GetTypeOfItem(loadedMod.get_item(i));

                    bmp = loadedMod.get_item(i).get_headSprite();
                    File.Delete(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + "_Head.png");
                    if (bmp != null && itemType == "head")
                    {
                        bmp.Save(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + "_Head.png", ImageFormat.Png);
                    }

                    bmp = loadedMod.get_item(i).get_bodySprite();
                    File.Delete(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + "_Body.png");
                    if (bmp != null && itemType == "body")
                    {
                        bmp.Save(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + "_Body.png", ImageFormat.Png);
                    }

                    bmp = loadedMod.get_item(i).get_legsSprite();
                    File.Delete(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + "_Legs.png");
                    if (bmp != null && itemType == "legs")
                    {
                        bmp.Save(thePath + "\\Items\\Sprites\\" + loadedMod.get_item(i).get_name() + "_Legs.png", ImageFormat.Png);
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
            string[] existingRecipes;
            string[] recipeItems;
            List<RecipeItem> tmpRecipe;
            Item currentItem;
            string[] tmpProperties;
            {
                //this ensures the correct structure exists in the specified directory
                if (Directory.Exists(loadedMod.get_modPath() + "\\Items") 
                    && Directory.Exists(loadedMod.get_modPath() + "\\Items\\Code") 
                    && Directory.Exists(loadedMod.get_modPath() + "\\Items\\Sprites")
                    && Directory.Exists(loadedMod.get_modPath() + "\\Items\\Recipes"))
                {
                    //if it does, arrays of paths are created for each item, sprite, and code
                    existingItems = Directory.GetFiles(loadedMod.get_modPath() + "\\Items");
                    existingCode = Directory.GetFiles(loadedMod.get_modPath() + "\\Items\\Code");
                    existingSprites = Directory.GetFiles(loadedMod.get_modPath() + "\\Items\\Sprites");
                    existingRecipes = Directory.GetFiles(loadedMod.get_modPath() + "\\Items\\Recipes");
                    
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

                            //The details are split by the dividing symbol.
                            tmpProperties = File.ReadAllLines(existingItems[i]);
                            
                            //The properties in the array created are used to assemble the item.
                            currentItem = new Item(tmpProperties[0], tmpProperties[3]);
                            currentItem.set_display_name(tmpProperties[1]);
                            currentItem.set_tooltip(tmpProperties[2]);
                            currentItem.set_code(File.ReadAllText(existingCode[i]));

                            /*
                             * Sprites are assigned to their item by sharing a file name,
                             * so this checks if a sprite corresponds to the item that has been loaded.
                             */
                            for (int j = 0; j < existingSprites.Length; j++)
                            {
                                if (loadedMod.get_modPath() + "\\Items\\Sprites\\" + currentItem.get_name() + ".png" == existingSprites[j])
                                {
                                    FileStream fileHandler = File.Open(existingSprites[j], FileMode.Open);
                                    currentItem.set_sprite(new Bitmap(fileHandler));
                                    fileHandler.Close();
                                }
                                else if (loadedMod.get_modPath() + "\\Items\\Sprites\\" + currentItem.get_name() + "_Wings.png" == existingSprites[j])
                                {
                                    FileStream fileHandler = File.Open(existingSprites[j], FileMode.Open);
                                    currentItem.set_wingSprite(new Bitmap(fileHandler));
                                    fileHandler.Close();
                                    Console.WriteLine(currentItem.get_name());
                                }
                                else if (loadedMod.get_modPath() + "\\Items\\Sprites\\" + currentItem.get_name() + "_Head.png" == existingSprites[j])
                                {
                                    FileStream fileHandler = File.Open(existingSprites[j], FileMode.Open);
                                    currentItem.set_headSprite(new Bitmap(fileHandler));
                                    fileHandler.Close();
                                    Console.WriteLine(currentItem.get_name());
                                }
                                else if (loadedMod.get_modPath() + "\\Items\\Sprites\\" + currentItem.get_name() + "_Body.png" == existingSprites[j])
                                {
                                    FileStream fileHandler = File.Open(existingSprites[j], FileMode.Open);
                                    currentItem.set_bodySprite(new Bitmap(fileHandler));
                                    fileHandler.Close();
                                    Console.WriteLine(currentItem.get_name());
                                }
                                else if (loadedMod.get_modPath() + "\\Items\\Sprites\\" + currentItem.get_name() + "_Legs.png" == existingSprites[j])
                                {
                                    FileStream fileHandler = File.Open(existingSprites[j], FileMode.Open);
                                    currentItem.set_legsSprite(new Bitmap(fileHandler));
                                    fileHandler.Close();
                                    Console.WriteLine(currentItem.get_name());
                                }
                            }

                            for (int j = 0; j < existingRecipes.Length; j++)
                            {
                                if (loadedMod.get_modPath() + "\\Items\\Recipes\\" + currentItem.get_name() + "_recipe.recipe" == existingRecipes[j])
                                {
                                    tmpRecipe = new List<RecipeItem>();
                                    recipeItems = File.ReadAllLines(existingRecipes[j]);
                                    for (int k = 0; k < recipeItems.Length; k++)
                                    {
                                        tmpRecipe.Add(new RecipeItem(recipeItems[k].Split('|')[0],Convert.ToInt32(recipeItems[k].Split('|')[1])));
                                    }
                                    currentItem.set_ingredients(tmpRecipe.ToArray());
                                }
                            }
                            //The item is added to the list, then the displayed list is updated.
                            loadedMod.add_item(currentItem);
                            update_item_list();
                        }
                    }
                }
                //This is reached if the directory does not have the right structure.
                else
                {
                    MessageBox.Show("Please select a valid folder");
                }
            }
        }

        private void modDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This opens a dialog where the user can edit the details of the mod.
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
            //A confirmation dialog will appear.
            DialogResult result = MessageBox.Show("Are you sure?", "Confirm action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //This ensures they have selected a valid item to delete.
                if (lbItems.SelectedIndex != -1)
                {
                    /*
                     * A list one shorter than the current one is created,
                     * and every item except the deleted one is written to it.
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
                    //The files for the item are deleted, and the list of items is overwritten.
                    File.Delete(loadedMod.get_modPath() + "\\Items\\" + loadedItem.get_name() + ".item");
                    File.Delete(loadedMod.get_modPath() + "\\Items\\Code\\" + loadedItem.get_name() + "_code.code");
                    loadedMod.set_items(tmpItems);
                    displayItem(new Item("", ""));
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
            //A confirmation dialog will appear.
            DialogResult result = MessageBox.Show("Are you sure? Unsaved work will be lost.", "Confirm action", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                //A blank mod is created.
                loadedMod = new Mod("", "");
                displayItem(new Item("", ""));
                clearBlockly();
                lock_controls();
                
                //The ui is reset.
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

                 //This ensures the directory is the correct structure.
                 if (existingFiles.Length != 1)
                 {
                     MessageBox.Show("Please select a valid folder");
                     return;
                 }
                 else
                 {
                     //The details of the mod are loaded for the files.
                     modDetails = File.ReadAllText(existingFiles[0]);
                     modDetailsSplit = modDetails.Split('|');
                     theMod = new Mod(modDetailsSplit[0], folderDialog.SelectedPath);
                     theMod.set_description(modDetailsSplit[1]);
                     theMod.set_author(modDetailsSplit[2]);
                     loadedMod = theMod;
                     Text = "tModMaker - " + loadedMod.get_name();
                     displayItem(new Item("", ""));
                     clearBlockly();
                     lock_controls();
                 }
                 //The procedure to load the items is called.
                 load_items_for_mod();
                 add_recent_path(folderDialog.SelectedPath);
            }
        }

        private void open_mod(string path)
        {
            Mod theMod;
            string modDetails;
            string[] modDetailsSplit;
            string[] existingFiles;
            try
            {
                existingFiles = Directory.GetFiles(path);
            
            
                //This ensures the directory is the correct structure.
                if (existingFiles.Length != 1)
                {
                    MessageBox.Show("Please select a valid folder");
                    return;
                }
                else
                {
                    //The details of the mod are loaded for the files.
                    modDetails = File.ReadAllText(existingFiles[0]);
                    modDetailsSplit = modDetails.Split('|');
                    theMod = new Mod(modDetailsSplit[0], path);
                    theMod.set_description(modDetailsSplit[1]);
                    theMod.set_author(modDetailsSplit[2]);
                    loadedMod = theMod;
                    Text = "tModMaker - " + loadedMod.get_name();
                    displayItem(new Item("", ""));
                    clearBlockly();
                    lock_controls();
                }
                //The procedure to load the items is called.
                load_items_for_mod();
                add_recent_path(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void add_recent_path(string path)
        {
            string[] recents = File.ReadAllLines(Environment.CurrentDirectory + "\\recents.txt");
            string pathsToWrite = path;

            int count = 0;
            int checkPaths = 0;
            Console.WriteLine(recents.Length);
            while (count < 5 && checkPaths < recents.Length)
            {
                if (recents[checkPaths] != path)
                {
                    pathsToWrite += "\r\n" + recents[count];
                    Console.WriteLine("wrote " + recents[count]);

                    checkPaths++;
                }
                else
                {
                    Console.WriteLine("did not write " + recents[count]);
                }
                count++;
                Console.WriteLine(count);
            }
            File.WriteAllText(Environment.CurrentDirectory + "\\recents.txt", pathsToWrite);
            load_recents();
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            save_mod();
        }

        private void lbItems_DoubleClick(object sender, EventArgs e)
        {
            if (loadedItem != null)
            {

                displayItem(loadedItem);
                update_item_list();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeGenerator codeGenerator = new CodeGenerator();
            string path;
            string tmpCode;
            bool canExport = true;
            List<string> incompleteItems = new List<string>();
            string localizationString = "";

            if (File.ReadAllText(Environment.CurrentDirectory + "\\userConfig.txt") != "")
            {
                hasExportPath = true;
            }
            else { hasExportPath = false; }
            //This checks for the export directory being set. If not, the user is prompted to set one.
            //validate if the mod is going to overwrite the editable files: do they have the same name.
            if (hasExportPath)
            {
                path = File.ReadAllText(Environment.CurrentDirectory + "\\userConfig.txt") + "\\" + loadedMod.get_name();

                //An array is created containing all the items to export.
                Item[] itemsToExport = new Item[loadedMod.get_item_number()];
                for (int i = 0; i < itemsToExport.Length; i++)
                {
                    itemsToExport[i] = loadedMod.get_item(i);
                }

                //The necessary directories are created.
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + "\\Items");
                Directory.CreateDirectory(path + "\\Localization");
                Directory.CreateDirectory(path + "\\Properties");
                Directory.CreateDirectory(path + "\\Projectiles");
                Directory.CreateDirectory(path + "\\NPCs");

                File.WriteAllText(path + "\\description.txt", loadedMod.get_description());
                //add functionality to enter a version number
                File.WriteAllText(path + "\\build.txt", "displayName = " + loadedMod.get_name() + "\nauthor = " + loadedMod.get_author() + "\nversion = 0.1");
                
                File.WriteAllText(path + "\\" + loadedMod.get_name() + ".cs", "using Terraria.ModLoader;\r\n\r\nnamespace " + loadedMod.get_name() + "\r\n{\r\n\tpublic class " + loadedMod.get_name() + " : Mod\r\n\t{\r\n\t}\r\n}");

                File.WriteAllText(path + "\\" + loadedMod.get_name() + ".csproj", File.ReadAllText(@"projectConfig.txt"));

                localizationString += "Mods: {\r\n" + loadedMod.get_name() + ": {\r\nItems: {\r\n";
                for (int i = 0; i < itemsToExport.Length; i++)
                {
                    if (itemsToExport[i].get_type() == "Item")
                    {
                        localizationString += itemsToExport[i].get_name() + ": {\r\nTooltip: "+ itemsToExport[i].get_tooltip() +"\r\nDisplayName: " + itemsToExport[i].get_displayName() + "\r\n}\r\n";
                    }
                }
                localizationString += "}\r\n";
                for (int i = 0; i < itemsToExport.Length; i++)
                {
                    if (itemsToExport[i].get_type() == "Projectile")
                    {
                        localizationString += "Projectiles." + itemsToExport[i].get_name() + ".DisplayName: " + itemsToExport[i].get_displayName() + "\r\n";
                    }
                }
                localizationString += "NPCs: {\r\n";
                for (int i = 0; i < itemsToExport.Length; i++)
                {
                    if (itemsToExport[i].get_type() == "NPC")
                    {
                        localizationString += "\r\n" + itemsToExport[i].get_name() + ": {\r\nDisplayName: " + itemsToExport[i].get_displayName() + "\r\n}";
                    }
                }
                localizationString += "\r\n}";
                localizationString += "\r\n}\r\n}";
                File.WriteAllText(path + "\\Localization\\en-US.hjson", localizationString);

                /*
                 * The code is generated by the code generator, then the correctly named code and sprite
                 * are saved to the export directory.
                 */
                Bitmap bmp;
                for (int i = 0; i < itemsToExport.Length; i++)
                {
                    tmpCode = codeGenerator.generate_code(itemsToExport[i], loadedMod.get_name());
                    
                    if (itemsToExport[i].get_type() == "Item")
                    {
                        File.WriteAllText(path + "\\Items\\" + itemsToExport[i].get_name() + ".cs", tmpCode);
                    }
                    else if (itemsToExport[i].get_type() == "Projectile")
                    {
                        File.WriteAllText(path + "\\Projectiles\\" + itemsToExport[i].get_name() + ".cs", tmpCode);
                    }
                    else if (itemsToExport[i].get_type() == "NPC")
                    {
                        File.WriteAllText(path + "\\NPCs\\" + itemsToExport[i].get_name() + ".cs", tmpCode);
                    }
                    bmp = itemsToExport[i].get_sprite();
                    if (bmp == null)
                    {
                        incompleteItems.Add(itemsToExport[i].get_name());
                        canExport = false;
                    }
                    else
                    {
                        if (itemsToExport[i].get_type() == "Item")
                        {
                            bmp.Save(path + "\\Items\\" + itemsToExport[i].get_name() + ".png", ImageFormat.Png);
                        }
                        else if (itemsToExport[i].get_type() == "Projectile")
                        {
                            bmp.Save(path + "\\Projectiles\\" + itemsToExport[i].get_name() + ".png", ImageFormat.Png);
                        }
                        else if (itemsToExport[i].get_type() == "NPC")
                        {
                            bmp.Save(path + "\\NPCs\\" + itemsToExport[i].get_name() + ".png", ImageFormat.Png);
                        }
                    }
                    bmp = itemsToExport[i].get_wingSprite();
                    if (bmp != null)
                    {
                        if (itemsToExport[i].get_type() == "Item")
                        {
                            bmp.Save(path + "\\Items\\" + itemsToExport[i].get_name() + "_Wings.png", ImageFormat.Png);
                        }
                    }
                    bmp = itemsToExport[i].get_headSprite();
                    if (bmp != null)
                    {
                        if (itemsToExport[i].get_type() == "Item")
                        {
                            bmp.Save(path + "\\Items\\" + itemsToExport[i].get_name() + "_Head.png", ImageFormat.Png);
                        }
                    }
                    bmp = itemsToExport[i].get_bodySprite();
                    if (bmp != null)
                    {
                        if (itemsToExport[i].get_type() == "Item")
                        {
                            bmp.Save(path + "\\Items\\" + itemsToExport[i].get_name() + "_Body.png", ImageFormat.Png);
                        }
                    }
                    bmp = itemsToExport[i].get_legsSprite();
                    if (bmp != null)
                    {
                        if (itemsToExport[i].get_type() == "Item")
                        {
                            bmp.Save(path + "\\Items\\" + itemsToExport[i].get_name() + "_Legs.png", ImageFormat.Png);
                        }
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
                else
                {
                    MessageBox.Show("Export complete");
                }

            }
            else
            {
                MessageBox.Show("Please set an export directory in Edit>Settings");
            }

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        public async void displayItem(Item loadedItem)
        {
            string prevSource = wvCode.Source.ToString();
            //these paths need to be made relative to the programs location
            if (loadedItem.get_type() == "Item")
            {
                wvCode.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\tool_editor.html");
                txtTooltip.Enabled = true;
                btnRecipe.Enabled = true;
            }
            else if (loadedItem.get_type() == "Projectile")
            {
                wvCode.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\projectile_editor.html");
                txtTooltip.Enabled = false;
                btnRecipe.Enabled = false;
            }
            else if (loadedItem.get_type() == "NPC")
            {
                wvCode.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\npc_editor.html");
                txtTooltip.Enabled = false;
                btnRecipe.Enabled = false;
            }
            else
            {
                Console.WriteLine("please update type");
            }
            /* Tidy this up. The constant delay works, but isn't a good way of doing it. Make it wait
             * on a value being true.
             */

            //loads the details of the item onto the screen

            string type = GetTypeOfItem(loadedItem);

            if (type == "body")
            {
                btnAdditionalSprites.Enabled = true;
            }
            else if (type == "head")
            {
                btnAdditionalSprites.Enabled = true;
            }
            else if (type == "legs")
            {
                btnAdditionalSprites.Enabled = true;
            }
            else if (type == "wings")
            {
                btnAdditionalSprites.Enabled = true;
            }
            else
            {
                btnAdditionalSprites.Enabled = false;
            }


            if (prevSource != wvCode.Source.ToString())
            {
                wvready = false;

            }

            while (!wvready)
            {
                await Task.Delay(100);
            }
            
            clearBlockly();
            theItem = loadedItem;
            txtDisplayName.Text = theItem.get_displayName();
            txtTooltip.Text = theItem.get_tooltip();
            pbSprite.Refresh();
            sendData();

            unlock_controls();
        }

        async void InitWebview()
        {
            await wvCode.EnsureCoreWebView2Async(null);
            await wvCode.EnsureCoreWebView2Async(null);
        }

        async void requestData()
        {
            await wvCode.ExecuteScriptAsync("sendDataToWinForm()");
        }

        async void requestSaveData()
        {
            await wvSave.ExecuteScriptAsync("sendDataToWinForm()");
        }

        async void sendData()
        {
            await wvCode.ExecuteScriptAsync("loadData('" + theItem.get_code() + "')");
        }

        public async void clearBlockly()
        {
            await wvCode.ExecuteScriptAsync("clear()");
        }

        //these need to lock the controls at certain points where access to the buttons would cause issues
        public void lock_controls()
        {
            btnChangeSprite.Enabled = false;
            txtDisplayName.Enabled = false;
            txtTooltip.Enabled = false;
            wvCode.Enabled = false;
        }

        public void unlock_controls()
        {
            btnChangeSprite.Enabled = true;
            txtDisplayName.Enabled = true;
            wvCode.Enabled = true;
        }

        private void pbSprite_Paint(object sender, PaintEventArgs e)
        {
            if (theItem != null)
            {
                Bitmap theImage = theItem.get_sprite();
                Graphics g = e.Graphics;
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                if (theItem.get_sprite() != null)
                {
                    double picBoxWidth = pbSprite.Width;
                    double picBoxHeight = pbSprite.Height;
                    double height = theItem.get_sprite().Height;
                    double width = theItem.get_sprite().Width;
                    if (height > width)
                    {
                        e.Graphics.DrawImage(theImage, (int)(picBoxWidth - (picBoxHeight / height * width)) / 2, 0, (int)(picBoxHeight / height * width), (int)(picBoxHeight));
                    }
                    else if (height < width)
                    {
                        e.Graphics.DrawImage(theImage, 0, (int)(picBoxHeight - (picBoxWidth / width * height)) / 2, (int)picBoxWidth, (int)(picBoxWidth / width * height));
                    }
                    else
                    {
                        e.Graphics.DrawImage(theImage, 0, 0, pbSprite.Width, pbSprite.Height);
                    }
                }
            }
        }

        private void btnAdditionalSprites_Click(object sender, EventArgs e)
        {
            if (theItem != null)
            {
                OtherSprites otherSprites = new OtherSprites(theItem, GetTypeOfItem(theItem));
                otherSprites.Show();
                theItem = otherSprites.theItem;
            }
        }

        private void wvCode_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            workspace = e.TryGetWebMessageAsString();
            returned = true;
        }

        private void wvCode_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            wvready = true;
            if (wvready == false)
            {
                displayItem(new Item("", ""));
                lock_controls();
            }
        }

        private void btnChangeSprite_Click(object sender, EventArgs e)
        {
            //this opens a file dialog to let the user select a new sprite, then refreshes the pic box
            if (theItem != null)
            {
                OpenFileDialog openSpriteDialog = new OpenFileDialog();
                openSpriteDialog.InitialDirectory = "c:\\";
                openSpriteDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                if (openSpriteDialog.ShowDialog() == DialogResult.OK)
                {
                    theItem.set_sprite(new Bitmap(@openSpriteDialog.FileName));
                    pbSprite.Refresh();
                }
            }
        }

        private string GetTypeOfItem(Item item)
        {
            //If the below strings were entered as a value, problems would occur.

            if (item.get_code().Contains("{\"slot\":\"Body\"}"))
            {
                return "body";
            }
            else if (item.get_code().Contains("\"slot\":\"Head\""))
            {
                return "head";
            }
            else if (item.get_code().Contains("\"slot\":\"Legs\""))
            {
                return "legs";
            }
            else if (item.get_code().Contains("\"type\":\"create_wings\""))
            {
                return "wings";
            }

            return "null";
        }

        private void openExportDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = File.ReadAllText(Environment.CurrentDirectory + "\\userConfig.txt") + "\\" + loadedMod.get_name();
            Process.Start("explorer.exe", @path);
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {
            RecipeEditor recipeEditor = new RecipeEditor(loadedItem);
            recipeEditor.ShowDialog();
            loadedItem.set_ingredients(recipeEditor.outputArray);
        }

        private void wvSave_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            workspace = e.TryGetWebMessageAsString();
            saveReturned = true;
        }

        private void wvSave_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            wvSaveReady = true;
        }
    }
}
