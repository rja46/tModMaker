using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_solution
{
    internal class Mod
    {
        public Item[] items;
        private string name;
        private string description;
        private string author;
        private string modPath;

        public Mod(string name, string modPath)
        {
            this.name = name;
            this.modPath = modPath;
            items = new Item[0];
            author = string.Empty;
            description = string.Empty;
        }

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
            return items[index];
        }
        public string get_name() { return name; }
        public string get_description() { return description; }
        public string get_author() { return author;}

        public void set_name(string name) { this.name = name;}
        public void set_author (string  author) { this.author = author;}
        public void set_description(string description) {  this.description = description;}

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
