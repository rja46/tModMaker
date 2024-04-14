using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_solution
{
    public class Mod
    {
        public Item[] items;
        private string name;
        private string description;
        private string author;
        private string modPath;
        private double version;
        private Bitmap icon;

        public Mod(string name, string modPath)
        {
            this.name = name;
            this.modPath = modPath;
            items = new Item[0];
            author = string.Empty;
            description = string.Empty;
            version = 0;
        }

        //This creates a new array one item larger to add the new item to.
        public void add_item(Item item)
        {
            Item[] tempItems = new Item[items.Length + 1];
            for (int i = 0; i < items.Length; i++)
            {
                tempItems[i] = items[i];
            }
            tempItems[items.Length] = item;
            items = tempItems;
        }

        public Item get_item(int index)
        {
            try
            {
                return items[index];
            }
            catch
            {
                { return null; }
            }
        }

        public string get_name() { return name; }
        public string get_description() { return description; }
        public string get_author() { return author;}
        public string get_modPath() {  return modPath;}
        public int get_item_number() { return items.Length; }
        public double get_version() { return version;}
        public Bitmap get_icon() { return icon;}
        public void set_name(string name) { this.name = name.Replace('\u0020', '_');}
        public void set_author (string  author) { this.author = author;}
        public void set_description(string description) {  this.description = description;}
        public void set_modPath(string modPath) { this.modPath = modPath;}
        public void set_items(Item[] items) { this.items = items;}
        public void set_version(double version) {  this.version = version;}
        public void set_icon(Bitmap icon) {  this.icon = icon;}

        public string[,] get_items_for_display()
        {
            string[,] itemsDisplay = new string[items.Length, items.Length+1];
            for (int i = 0; i < items.Length; i++)
            {
                itemsDisplay[i, 0] = items[i].get_name();
                itemsDisplay[i, 1] = items[i].get_type();
            }
            return itemsDisplay;
        }
    }
}
