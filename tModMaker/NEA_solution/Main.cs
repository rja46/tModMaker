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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Specialized;
using System.Net;
using System.Security.Policy;

//This program is confirmed working for 1.4.4.9
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
        string LoggedInUser = "";

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
            open_mod_and_items(sender.ToString());
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
            displayItem(loadedItem);
            update_item_list();

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
                loadedMod.set_modPath(dialog.SelectedPath);
                
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
        private async Task save_mod()
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
                pbSave.PerformStep();
                pbSave.PerformStep();
            }

            string thePath = loadedMod.get_modPath();

            /*
             * If the mod is missing a path i.e. the placeholder is loaded, the save_mod_as(),
             * then returns nothing for this procedure.
             */
            if (thePath == "")
            {
                save_mod_as();
                return;
            }

            File.WriteAllText(loadedMod.get_modPath() + "\\" + loadedMod.get_name() + ".json", generateJson());


            if (loadedMod.get_item_number() != 0)
            {
                
                //This delay is purely visual, but I found the user experience was much better as a result.
                await Task.Delay(500);
                pbSave.Value = 1;
                tbSave.Enabled = true;
                fileSaveMod.Enabled = true;
                wvCode.Enabled = true;
                unlock_controls();
            }
        }

        private void fileOpenMod_Click(object sender, EventArgs e)
        {
            open_mod_and_items("");
        }

        private void modDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This opens a dialog where the user can edit the details of the mod.
            EditDetailsDialog editDetailsDialog = new EditDetailsDialog(loadedMod.get_name(), loadedMod.get_author(), loadedMod.get_description(), loadedMod.get_version(), loadedMod.get_icon());
            editDetailsDialog.ShowDialog();
            loadedMod.set_name(editDetailsDialog.name);
            loadedMod.set_author(editDetailsDialog.author);
            loadedMod.set_description(editDetailsDialog.description);
            loadedMod.set_version(editDetailsDialog.version);
            loadedMod.set_icon(editDetailsDialog.icon);
            Text = loadedMod.get_name();
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

        private void open_mod_and_items(string path)
        {
            string thePath = "";
            dynamic JsonObj = "";

            if (path == "")
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                DialogResult result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    JsonObj = JsonConvert.DeserializeObject(File.ReadAllText(fileDialog.FileName));
                    thePath = fileDialog.FileName;
                }
            }
            else
            {
                JsonObj = JsonConvert.DeserializeObject(File.ReadAllText(path));
                thePath = path;

            }

            loadedMod = new Mod(Convert.ToString(JsonObj["name"]), Convert.ToString(JsonObj["modPath"]));
            loadedMod.set_author(Convert.ToString(JsonObj["author"]));
            loadedMod.set_description(Convert.ToString(JsonObj["description"]));
            loadedMod.set_version(Convert.ToDouble(JsonObj["version"]));
            if (JsonObj["icon"] != null)
            {
                loadedMod.set_icon(Base64StringToImage(Convert.ToString(JsonObj["icon"])));
            }

            List<Item> items = new List<Item>();
            List<RecipeItem> recipe;

            Item tmpItem;

            foreach (dynamic item in JsonObj["items"])
            {
                tmpItem = new Item(Convert.ToString(item["name"]), Convert.ToString(item["type"]));
                tmpItem.displayName = Convert.ToString(item["displayName"]);
                tmpItem.tooltip = Convert.ToString(item["tooltip"]);
                tmpItem.code = Convert.ToString(item["code"]);
                tmpItem.displayName = Convert.ToString(item["displayName"]);
                if (item["sprite"] != null)
                {
                    tmpItem.sprite = Base64StringToImage(Convert.ToString(item["sprite"]));
                }
                if (item["headSprite"] != null)
                {
                    tmpItem.headSprite = Base64StringToImage(Convert.ToString(item["headSprite"]));
                }
                if (item["bodySprite"] != null)
                {
                    tmpItem.bodySprite = Base64StringToImage(Convert.ToString(item["bodySprite"]));
                }
                if (item["legsSprite"] != null)
                {
                    tmpItem.legsSprite = Base64StringToImage(Convert.ToString(item["legsSprite"]));
                }
                if (item["mapHead"] != null)
                {
                    tmpItem.mapHead = Base64StringToImage(Convert.ToString(item["mapHead"]));
                }

                recipe = new List<RecipeItem>();

                foreach (dynamic recipeItem in item["ingredients"])
                {
                    recipe.Add(new RecipeItem(Convert.ToString(recipeItem["itemName"]), Convert.ToInt32(recipeItem["quantity"])));
                }

                tmpItem.set_ingredients(recipe.ToArray());

                items.Add(tmpItem);
            }
            displayItem(new Item("", ""));
            clearBlockly();
            loadedMod.set_items(items.ToArray());
            update_item_list();
            loadedItem = loadedMod.get_item(0);
            displayItem(loadedItem);
            add_recent_path(thePath);
        }

        private void tbOpen_Click(object sender, EventArgs e)
        {
            open_mod_and_items("");
        }


        private void add_recent_path(string path)
        {
            string[] recents = File.ReadAllLines(Environment.CurrentDirectory + "\\recents.txt");
            string pathsToWrite = path;

            //This loop ensures there are at maximum 5 unique paths listed.
            int checkPaths = 0;
            while (checkPaths < recents.Length && checkPaths < 4)
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
            if (lbItems.SelectedIndex != -1)
            {
                update_loaded_item(lbItems.SelectedIndex);
            }
        }

        private async void exportToolStripMenuItem_Click(object sender, EventArgs e)
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
                    DialogResult result = MessageBox.Show("Save before exporting?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await save_mod();
                    }
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
                            incompleteItems.Add(itemsToExport[i].get_name() + " - no sprite");
                            canExport = false;
                        }
                        if (slot == "Head" && itemsToExport[i].get_headSprite() == null)
                        {
                            incompleteItems.Add(itemsToExport[i].get_name() + " - no head sprite");
                            canExport = false;
                        }
                        if (slot == "Body" && itemsToExport[i].get_bodySprite() == null)
                        {
                            incompleteItems.Add(itemsToExport[i].get_name() + " - no body sprite");
                            canExport = false;
                        }
                        if (slot == "Legs" && itemsToExport[i].get_legsSprite() == null)
                        {
                            incompleteItems.Add(itemsToExport[i].get_name() + " - no legs sprite");
                            canExport = false;
                        }
                        if (GetTypeOfItem(itemsToExport[i]) == "boss" && itemsToExport[i].get_mapHead() == null)
                        {
                            incompleteItems.Add(itemsToExport[i].get_name() + " - no map sprite");
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

                    Bitmap icon = loadedMod.get_icon();
                    if (icon != null)
                    {
                        Bitmap exportIcon = new Bitmap(80, 80);
                        Graphics g = Graphics.FromImage(exportIcon);
                        g.DrawRectangle(new Pen(Color.Transparent), 0, 0, 80, 80);
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        double picBoxWidth = 80;
                        double picBoxHeight = 80;
                        double height = icon.Height;
                        double width = icon.Width;
                        if (height > width)
                        {
                            g.DrawImage(icon, (int)(picBoxWidth - (picBoxHeight / height * width)) / 2, 0, (int)(picBoxHeight / height * width), (int)(picBoxHeight));
                        }
                        else if (height < width)
                        {
                            g.DrawImage(icon, 0, (int)(picBoxHeight - (picBoxWidth / width * height)) / 2, (int)picBoxWidth, (int)(picBoxWidth / width * height));
                        }
                        else
                        {
                            g.DrawImage(icon, 0, 0, 80, 80);

                        }
                        exportIcon.Save(path + "\\icon.png", ImageFormat.Png);
                    }

                    File.WriteAllText(path + "\\description.txt", loadedMod.get_description());
                    DialogResult messageResult = MessageBox.Show("Increment version number?", "Increment version",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            localizationString += itemsToExport[i].get_name() + ": {";
                            if (itemsToExport[i].get_tooltip() != "")
                            {
                                localizationString += "\r\nTooltip: " + itemsToExport[i].get_tooltip();
                            }
                            if (itemsToExport[i].get_displayName() != "")
                            {
                                localizationString += "\r\nDisplayName: " + itemsToExport[i].get_displayName();
                            }
                            localizationString += "\r\n}\r\n";
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
                            else if (itemsToExport[i].get_type() == "Tile")
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

                        bmp = itemsToExport[i].get_mapHead();
                        if (bmp != null)
                        {
                            if (GetTypeOfItem(itemsToExport[i]) == "boss")
                            {
                                bmp.Save(path + "\\NPCs\\" + itemsToExport[i].get_name() + "_Head_Boss.png", ImageFormat.Png);
                            }
                        }
                    }

                    MessageBox.Show("Export complete: the mod will be available in the develop mods section of tModLoader");
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
            lock_controls();
            //If the Blockly editor needs to be changed, it is. The correct buttons are enabled or disabled.
            if (loadedItem != null)
            {
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
            }
            if (loadedItem == null)
            {
                wvCode.Source = new Uri(Environment.CurrentDirectory + "\\Blockly Editor\\start.html");
            }
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
            toolStrip1.Enabled = false;
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;
            exportToolStripMenuItem.Enabled = false;
        }

        public void unlock_controls()
        {
            wvCode.Enabled = true;
            lbItems.Enabled = true;
            tbSave.Enabled = true;
            fileSaveMod.Enabled = true;
            wvCode.Enabled = true;
            toolStrip1.Enabled = true;
            btnUndo.Enabled = true;
            btnRedo.Enabled = true;
            exportToolStripMenuItem.Enabled = true;

            //This has to check whether or not the additional sprite button should be enabled.
            CodeGenerator codeGenerator = new CodeGenerator();
            if (loadedItem != null)
            {
                btnChangeSprite.Enabled = true;
                txtDisplayName.Enabled = true;
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
                if (GetTypeOfItem(loadedItem) == "boss")
                {
                    btnAdditionalSprites.Enabled = true;
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
            else if (item.get_code().Contains("\"boss\":true"))
            {
                return "boss";
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
            loadedItem.set_craftingStationID(recipeEditor.station);
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S | Keys.Shift))
            {
                save_mod_as();
            }
            if (keyData == (Keys.Control | Keys.S))
            {
                save_mod();
            }
            if (keyData == (Keys.Control | Keys.O))
            {
                open_mod_and_items("");
            }
            if (keyData == (Keys.Control | Keys.Z))
            {
                undo();
            }
            if (keyData == (Keys.Control | Keys.Y))
            {
                redo();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        async Task undo()
        {
            await wvCode.ExecuteScriptAsync("undo()");
        }

        async Task redo()
        {
            await wvCode.ExecuteScriptAsync("redo()");
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            redo();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpDialog helpDialog = new HelpDialog();
            helpDialog.ShowDialog();
        }

        private string generateJson()
        {
            string theJson = JsonConvert.SerializeObject(loadedMod);

            dynamic JsonObj = JsonConvert.DeserializeObject(theJson);

            Item[] theItems = loadedMod.get_items();

            if (loadedMod.get_icon() != null)
            {
                JsonObj["icon"] = ImageToBase64String(loadedMod.get_icon());
            }

            for (int i = 0; i < loadedMod.get_item_number(); i++)
            {
                //JsonObj["items"][i]
                if (theItems[i].get_sprite() != null)
                {
                    JsonObj["items"][i]["sprite"] = ImageToBase64String(theItems[i].get_sprite());
                }
                if (theItems[i].get_headSprite() != null)
                {
                    JsonObj["items"][i]["headSprite"] = ImageToBase64String(theItems[i].get_headSprite());
                }
                if (theItems[i].get_bodySprite() != null)
                {
                    JsonObj["items"][i]["bodySprite"] = ImageToBase64String(theItems[i].get_bodySprite());
                }
                if (theItems[i].get_legsSprite() != null)
                {
                    JsonObj["items"][i]["legsSprite"] = ImageToBase64String(theItems[i].get_legsSprite());
                }
                if (theItems[i].get_mapHead() != null)
                {
                    JsonObj["items"][i]["mapHead"] = ImageToBase64String(theItems[i].get_mapHead());
                }
            }

            theJson = JsonConvert.SerializeObject(JsonObj, Formatting.Indented);

            return theJson;
        }

        private string ImageToBase64String(Bitmap bitmap)
        {

            MemoryStream ms = new MemoryStream();

            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            byte[] arr = new byte[ms.Length];

            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();

            string strBase64 = Convert.ToBase64String(arr);

            return strBase64;
        }

        private Bitmap Base64StringToImage(string base64)
        {
            byte[] arr = Convert.FromBase64String(base64);
            MemoryStream ms = new MemoryStream(arr);
            ms.Position = 0;
            Bitmap bitmap = null;

            bitmap = (Bitmap)(Bitmap.FromStream(ms));

            return bitmap;
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateJson();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            Account account = new Account(LoggedInUser);

            account.ShowDialog();
        }
    }
}
