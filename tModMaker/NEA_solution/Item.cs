using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_solution
{
    public class Item
    {
        private string name;
        private string displayName;
        private string tooltip;
        private string code;
        private string spritePath;
        private string type;

        public Item(string name, string type)
        {
            this.name = name;
            this.type = type;
            displayName = name;
            tooltip = "";
            code = "";
            spritePath = "";
            type = "";
        }

        public string get_name() { return name; }
        public string get_displayName() { return displayName; }
        public string get_tooltip() { return tooltip;}
        public string get_type() { return type;}
        public string get_code() { return code;}
        public string get_sprite_path() { return spritePath;}
        
        public void set_tooltip(string tooltip)
        {
            this.tooltip = tooltip;
        }
        public void set_display_name(string displayName)
        {
            this.displayName = displayName;
        }
        public void set_code(string code)
        {
            this.code = code;
        }
        public void set_sprite_path(string sprite_path)
        {
            this.spritePath = sprite_path;
        }
        public void set_name(string name)
        {
            this.name = name;
        }
        public void set_type(string type)
        {
            this.type = type;
        }
    }
}
