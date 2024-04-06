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
using System.Net.Http.Headers;
using System.Reflection;
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
            InitializeComponent();
            Text = "tModMaker";

            loadedMod = new Mod("", "");

            //This checks to seem if the user has set a path to export to.
            if (File.ReadAllText(Environment.CurrentDirectory + "\\userConfig.txt") != "")
            {
                hasExportPath = true;
            }
            else { hasExportPath = false; }

            initialise_editor();
            load_recents();
            lock_controls();
        }

        private void load_recents()
        {
            string[] recents = File.ReadAllLines(Environment.CurrentDirectory + "\\recents.txt");
            openRecentToolStripMenuItem.DropDownItems.Clear();
            //Each recent project is added to the dropdown.
            for (int i = 0;i < recents.Length; i++)
            {
                openRecentToolStripMenuItem.DropDownItems.Add(recents[i]);
                openRecentToolStripMenuItem.DropDownItems[i].Click += recent_click;
            }
        }

        private void recent_click(object sender, EventArgs e)
        {
            //The name of the sender is the path of the mod, so it can be opened like this.
            open_mod(sender.ToString());
        }

        private void initialise_editor()
        {
            //The webView component containing the editor is set up.
            InitWebview();
            wvCode.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\start.html");
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //A dialog for the users to enter the details of the mod is opened.
            CreateItemDialog createItemDialog = new CreateItemDialog();
            DialogResult result = createItemDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadedMod.add_item(createItemDialog.newItem);

                //The list of items is updated to contain the new item.
                update_item_list();
                loadedItem = loadedMod.get_item(loadedMod.get_item_number() - 1);
                displayItem(loadedItem);
            }
        }

        private void update_item_list()
        {
            //Each name is added to the list box.
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

        private async void update_loaded_item(int index)
        {
            if (loadedItem != null)
            {
                /*
                 * The save data of the load item is requested before it is changed.
                 * This means that when the save button is pressed, all items have 
                 * their updated code written to file.
                 */
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
            NameDialog nameDialog = new NameDialog();
            DialogResult result = nameDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadedMod.set_name(nameDialog.name);
            }
            else
            {
                //When save mod is called, the controls are locked, so they must be unlocked here if the mod is not going to be saved.
                unlock_controls();
                
                return;
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                loadedMod.set_modPath(dialog.SelectedPath + "\\" + loadedMod.get_name());
                
                //Once the path and name are specified, it is saved as normal.
                add_recent_path(loadedMod.get_modPath());
                save_mod();
            }
            else
            {
                unlock_controls();
                
                return;
            }
            unlock_controls();
            Text = "tModMaker - " + loadedMod.get_name();
        }

        //This procedure is asynchronous as it waits to recieve the data from the web component.
        private async void save_mod()
        {
            lock_controls();
            //The properties of the progress bar are set up.
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
            //If an item is loaded, it is saved.
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
                //The program must wait here to recieve the code.
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
                string prevSource = wvSave.Source.ToString();

                /* The correct editor is loaded into the hidden webView component where the 
                 * saving takes place.
                 */
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

                    case "Tile":
                        wvSave.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\tile_editor.html");
                        break;
                }
                
                //If the correct editor is not loaded, it will be loaded here.
                if (prevSource != wvSave.Source.ToString())
                {
                    wvSaveReady = false;
                    do
                    {
                        await Task.Delay(100);
                    }
                    while (wvSaveReady == false);
                }
                
                await wvSave.ExecuteScriptAsync("loadData('" + loadedMod.get_item(i).get_code() + "')");                
                requestSaveData();
                
                saveReturned = false;
                do
                {
                    await Task.Delay(100);
                }
                while (saveReturned == false);

                loadedMod.get_item(i).set_code(workspace);

                pbSave.PerformStep();
            }


            string thePath = loadedMod.get_modPath();
            string modFile = "";
            string tempItem;
            string recipeItems;
            
            /*
             * The details of the mod are compiled into one string, seperated with pipes,
             * as it is a fairly uncommon character, and is unlikely to appear in the mod's
             * details.
             * Validation is needed here, because terrible things will happen if someone enters
             * a pipe in any of these fields.
             */
            modFile += loadedMod.get_name() + "|";
            modFile += loadedMod.get_description() + "|";
            modFile += loadedMod.get_author() + "|";
            modFile += loadedMod.get_version();

            /*
             * The progress bar is set up to make a step for each item in the mod.
             * It is worth noting that the progress bar doesnt appear to work on 
             * windows 11 - this issue is inconsistent, and seems to be happening
             * less
             */
            


            /*
             * If the mod is missing a path i.e. the placeholder is loaded, the save_mod_as(),
             * then returns nothing for this procedure.
             */
            if (thePath == "")
            {
                save_mod_as();
                return;
            }

            Directory.CreateDirectory(thePath);

            //The details of the mod are written to a file here.
            File.WriteAllText(thePath + "\\" + loadedMod.get_name() + ".mod", modFile);

            //This checks for and creates other directories that need to exist.
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

            if (loadedMod.get_item_number() != 0)
            {
                //This loops through and saves each item.
                for (int i = 0; i < loadedMod.get_item_number(); i++)
                {
                    //The details of the item and put into a string, then saved.
                    tempItem = "";
                    tempItem += loadedMod.get_item(i).get_name() + "\r\n";
                    tempItem += loadedMod.get_item(i).get_displayName() + "\r\n";
                    tempItem += loadedMod.get_item(i).get_tooltip() + "\r\n";
                    tempItem += loadedMod.get_item(i).get_type();
                    File.WriteAllText(thePath + "\\Items\\" + loadedMod.get_item(i).get_name() + ".item", tempItem);
                    
                    //The code is written to a seperate file.
                    File.WriteAllText(thePath + "\\Items\\Code\\" + loadedMod.get_item(i).get_name() + "_code.code", loadedMod.get_item(i).get_code());

                    recipeItems = "";
                    for (int j = 0; j < loadedMod.get_item(i).get_ingredients().Length; j++)
                    {
                        recipeItems += loadedMod.get_item(i).get_ingredients()[j].itemName + "|" + loadedMod.get_item(i).get_ingredients()[j].quantity + "\r\n";
                    }
                    File.WriteAllText(thePath + "\\Items\\Recipes\\" + loadedMod.get_item(i).get_name() + "_recipe.recipe", recipeItems);
                    
                    Bitmap bmp = loadedMod.get_item(i).get_sprite();
                    
                    //If a sprite exists for the item, it is saved as a .png.
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

                    //The step for the progress bar is performed.
                    pbSave.PerformStep();
                }
                //This delay is purely visual, but I found the user experience was much better as a result.
                finishSaving(1000);
            }
        }

        private async void finishSaving(int delay)
        {
            await Task.Delay(delay);
            pbSave.Value = 1;
            tbSave.Enabled = true;
            fileSaveMod.Enabled = true;
            wvCode.Enabled = true;
            unlock_controls();
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
                /*
                 * This ensures the correct structure exists in the specified directory.
                 * 
                 * This isn't foolproof, but it is unlikely someone would try to open another folder which
                 * just happened to have the same structure, without doing it on purpose.
                 */
                if (Directory.Exists(loadedMod.get_modPath() + "\\Items") 
                    && Directory.Exists(loadedMod.get_modPath() + "\\Items\\Code") 
                    && Directory.Exists(loadedMod.get_modPath() + "\\Items\\Sprites")
                    && Directory.Exists(loadedMod.get_modPath() + "\\Items\\Recipes"))
                {
                    //If it does, arrays of paths are created for each item, sprite, and code.
                    existingItems = Directory.GetFiles(loadedMod.get_modPath() + "\\Items");
                    existingCode = Directory.GetFiles(loadedMod.get_modPath() + "\\Items\\Code");
                    existingSprites = Directory.GetFiles(loadedMod.get_modPath() + "\\Items\\Sprites");
                    existingRecipes = Directory.GetFiles(loadedMod.get_modPath() + "\\Items\\Recipes");
                    
                    //If there are no items in the mod, an empty workspace is loaded.
                    if (existingItems.Length == 0)
                    {
                        wvCode.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\start.html");
                        lbItems.Items.Clear();
                        return;
                    }
                    else
                    {
                        lbItems.Items.Clear();
                        for (int i = 0; i < existingItems.Length; i++)
                        {

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
                                }
                                else if (loadedMod.get_modPath() + "\\Items\\Sprites\\" + currentItem.get_name() + "_Head.png" == existingSprites[j])
                                {
                                    FileStream fileHandler = File.Open(existingSprites[j], FileMode.Open);
                                    currentItem.set_headSprite(new Bitmap(fileHandler));
                                    fileHandler.Close();
                                }
                                else if (loadedMod.get_modPath() + "\\Items\\Sprites\\" + currentItem.get_name() + "_Body.png" == existingSprites[j])
                                {
                                    FileStream fileHandler = File.Open(existingSprites[j], FileMode.Open);
                                    currentItem.set_bodySprite(new Bitmap(fileHandler));
                                    fileHandler.Close();
                                }
                                else if (loadedMod.get_modPath() + "\\Items\\Sprites\\" + currentItem.get_name() + "_Legs.png" == existingSprites[j])
                                {
                                    FileStream fileHandler = File.Open(existingSprites[j], FileMode.Open);
                                    currentItem.set_legsSprite(new Bitmap(fileHandler));
                                    fileHandler.Close();
                                }
                            }

                            //If the item has a recipe, it is assigned here.
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
                            loadedItem = loadedMod.get_item(0);
                            displayItem(loadedItem);
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
            EditDetailsDialog editDetailsDialog = new EditDetailsDialog(loadedMod.get_name(), loadedMod.get_author(), loadedMod.get_description(),loadedMod.get_version());
            DialogResult result = editDetailsDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadedMod.set_name(editDetailsDialog.name);
                loadedMod.set_author(editDetailsDialog.author);
                loadedMod.set_description(editDetailsDialog.description);
                loadedMod.set_version(editDetailsDialog.version);
                this.Text = loadedMod.get_name();
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lbItems.SelectedIndex != -1)
            {
                //A confirmation dialog will appear.
                DialogResult result = MessageBox.Show("Are you sure?", "Confirm action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //This ensures they have selected a valid item to delete.
                    
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
                    if (File.Exists(loadedMod.get_modPath() + "\\Items\\" + loadedMod.get_item(indexToDelete).get_name() + ".item"))
                    {
                        File.Delete(loadedMod.get_modPath() + "\\Items\\" + loadedMod.get_item(indexToDelete).get_name() + ".item");
                    }
                    if (File.Exists(loadedMod.get_modPath() + "\\Items\\Code\\" + loadedMod.get_item(indexToDelete).get_name() + "_code.code"))
                    {
                        File.Delete(loadedMod.get_modPath() + "\\Items\\Code\\" + loadedMod.get_item(indexToDelete).get_name() + "_code.code");
                    }
                    loadedMod.set_items(tmpItems);
                    loadedItem = null;
                    displayItem(new Item("", ""));
                    wvCode.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\start.html");
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
                     theMod.set_version(Convert.ToDouble(modDetailsSplit[3]));
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
                    theMod.set_version(Convert.ToDouble(modDetailsSplit[3]));
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
                //This should tell the user that the path does not exist, as this is the error this is designed to catch.
                MessageBox.Show(e.Message);
            }
        }

        private void add_recent_path(string path)
        {
            string[] recents = File.ReadAllLines(Environment.CurrentDirectory + "\\recents.txt");
            string pathsToWrite = path;

            //This loop ensures there are at maximum 5 unique paths listed.
            int checkPaths = 0;
            while (checkPaths < recents.Length && checkPaths < 5)
            {
                if (recents[checkPaths] != path)
                {
                    pathsToWrite += "\r\n" + recents[checkPaths];
                }
                checkPaths++;
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
            string slot;

            if (File.ReadAllText(Environment.CurrentDirectory + "\\userConfig.txt") != "")
            {
                hasExportPath = true;
            }
            else { hasExportPath = false; }
            //This checks for the export directory being set. If not, the user is prompted to set one.
            
            if (loadedMod.get_name() != "")
            {
                if (hasExportPath)
                {
                    path = File.ReadAllText(Environment.CurrentDirectory + "\\userConfig.txt") + "\\" + loadedMod.get_name();
                    Bitmap bmp;

                    //An array is created containing all the items to export.
                    Item[] itemsToExport = new Item[loadedMod.get_item_number()];
                    for (int i = 0; i < itemsToExport.Length; i++)
                    {
                        itemsToExport[i] = loadedMod.get_item(i);
                    }

                    for (int i = 0;i < itemsToExport.Length; i++)
                    {
                        //This ensures each item has all the sprites they require.
                        slot = codeGenerator.get_slot(itemsToExport[i]);
                        bmp = itemsToExport[i].get_sprite();
                        if (bmp == null)
                        {
                            incompleteItems.Add(itemsToExport[i].get_name());
                            canExport = false;
                        }
                        if (slot == "Head" && itemsToExport[i].get_headSprite() == null)
                        {
                            incompleteItems.Add(itemsToExport[i].get_name());
                            canExport = false;
                        }
                        if (slot == "Body" && itemsToExport[i].get_bodySprite() == null)
                        {
                            incompleteItems.Add(itemsToExport[i].get_name());
                            canExport = false;
                        }
                        if (slot == "Legs" && itemsToExport[i].get_legsSprite() == null)
                        {
                            incompleteItems.Add(itemsToExport[i].get_name());
                            canExport = false;
                        }
                    }

                    //At this point, all the checks to ensure the mod is valid have been run, so it will return if it is invalid.
                    if (!canExport)
                    {
                        string tmpString = "The following items cannot be exported:\n";
                        for (int i = 0; i < incompleteItems.Count; i++)
                        {
                            tmpString += "\u2022 " + incompleteItems[i] + "\n";
                        }
                        tmpString += "Please ensure all items have sprites, details, and code.";
                        
                        //The user is told which item is the problem.
                        MessageBox.Show(tmpString);
                        return;
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
                    Directory.CreateDirectory(path + "\\Tiles");

                    File.WriteAllText(path + "\\description.txt", loadedMod.get_description());
                    DialogResult messageResult = MessageBox.Show("Increment version number?", "Increment version",MessageBoxButtons.YesNo);
                    if (messageResult == DialogResult.Yes)
                    {
                        //It the version number is incremented, the change is saved here.
                        loadedMod.set_version(loadedMod.get_version() + 0.1);
                        string modFile = "";
                        modFile += loadedMod.get_name() + "|";
                        modFile += loadedMod.get_description() + "|";
                        modFile += loadedMod.get_author() + "|";
                        modFile += loadedMod.get_version();

                        File.WriteAllText(loadedMod.get_modPath() + "\\" + loadedMod.get_name() + ".mod", modFile);

                    }

                    File.WriteAllText(path + "\\build.txt", "displayName = " + loadedMod.get_name() + "\nauthor = " + loadedMod.get_author() + "\nversion = " + loadedMod.get_version());

                    File.WriteAllText(path + "\\" + loadedMod.get_name() + ".cs", "using Terraria.ModLoader;\r\n\r\nnamespace " + loadedMod.get_name() + "\r\n{\r\n\tpublic class " + loadedMod.get_name() + " : Mod\r\n\t{\r\n\t}\r\n}");

                    File.WriteAllText(path + "\\" + loadedMod.get_name() + ".csproj", File.ReadAllText(@"projectConfig.txt"));

                    /*
                     * The localisation string contains user facing data, mainly display names.
                     * While it would be nice to add functionality to support multiple languages,
                     * this is a fairly unlikely scenario for my target users, so I have not implemented it.
                     */
                    localizationString += "Mods: {\r\n" + loadedMod.get_name() + ": {\r\nItems: {\r\n";
                    for (int i = 0; i < itemsToExport.Length; i++)
                    {
                        if (itemsToExport[i].get_type() == "Item")
                        {
                            localizationString += itemsToExport[i].get_name() + ": {\r\nTooltip: " + itemsToExport[i].get_tooltip() + "\r\nDisplayName: " + itemsToExport[i].get_displayName() + "\r\n}\r\n";
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
                        else if (itemsToExport[i].get_type() == "Tile")
                        {
                            File.WriteAllText(path + "\\Tiles\\" + itemsToExport[i].get_name() + ".cs", tmpCode);
                        }
                        
                        /*
                         * The sprites are written to files here. Each item has a main sprite, then
                         * other sprites are checked for and saved.
                         */
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
                            else if (itemsToExport[i].get_type() == "Tiles")
                            {
                                bmp.Save(path + "\\Tiles\\" + itemsToExport[i].get_name() + ".png", ImageFormat.Png);
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

                    MessageBox.Show("Export complete: the mod will be available in tModLoader");
                }
                else
                {
                    MessageBox.Show("Please set an export directory in Edit>Settings");
                }
            }
            else
            {
                MessageBox.Show("Please save the mod before exporting");
            }

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        public async void displayItem(Item loadedItem)
        {
            //If the Blockly editor needs to be changed, it is. The correct buttons are enabled or disabled.
            string prevSource = wvCode.Source.ToString();
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
            else if (loadedItem.get_type() == "Tile")
            {
                wvCode.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\tile_editor.html");
                txtTooltip.Enabled = false;
                btnRecipe.Enabled = false;
            }

            //Here, it checks to see if the item has an additional sprite, and enables the button to change it.
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


            //This waits for the webView componenent to be ready before displaying the item.
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

        /*
         * These are needed to lock the controls at certain points where access
         * to the buttons would cause issues, predominantly during saving.
         */
        public void lock_controls()
        {
            btnChangeSprite.Enabled = false;
            txtDisplayName.Enabled = false;
            txtTooltip.Enabled = false;
            wvCode.Enabled = false;
            btnRecipe.Enabled = false;
            btnAdditionalSprites.Enabled = false;
            lbItems.Enabled = false;
            tbSave.Enabled = false;
            fileSaveMod.Enabled = false;
            wvCode.Enabled = false;
        }

        public void unlock_controls()
        {
            btnChangeSprite.Enabled = true;
            txtDisplayName.Enabled = true;
            wvCode.Enabled = true;
            lbItems.Enabled = true;
            tbSave.Enabled = true;
            fileSaveMod.Enabled = true;
            wvCode.Enabled = true;
            
            //This has to check whether or not the additional sprite button should be enabled.
            CodeGenerator codeGenerator = new CodeGenerator();
            if (loadedItem != null)
            {
                if (loadedItem.get_type() == "Item")
                {
                    txtTooltip.Enabled = true;
                    btnRecipe.Enabled = true;
                    if (codeGenerator.get_slot(loadedItem) != string.Empty)
                    {
                        btnAdditionalSprites.Enabled = true;
                    }
                }
                if (loadedItem.get_type() == "Item")
                {
                    btnRecipe.Enabled = true;
                    txtTooltip.Enabled = true;
                }
            }
        }

        private void pbSprite_Paint(object sender, PaintEventArgs e)
        {
            if (theItem != null)
            {
                Bitmap theImage = theItem.get_sprite();
                Graphics g = e.Graphics;
                
                //As this will be using mostly pixel art, this prevents bluring instead of sharp edges.
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
                otherSprites.ShowDialog();
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
            //This opens a file dialog to let the user select a new sprite, then refreshes the picture box.
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
