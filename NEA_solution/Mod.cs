using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string get_name() { return name; }

        public void set_name(string name) { this.name = name;}

        public string[,] get_items_for_display()
        {
            string[,] itemsDisplay = new string [items.Length, items.Length];
            int count = 0;
            foreach (var item in items)
            {
                itemsDisplay[count, 0] = item.get_name();
                itemsDisplay[count, 1] = item.get_type();
                count++;
            }
            return itemsDisplay;
        }
    }
}
