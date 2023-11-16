using System;
using System.Collections.Generic;
using System.Drawing;
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
        private string exportedCode;
        private string type;
        private Bitmap sprite;

        public Item(string name, string type)
        {
            this.name = name.Replace('\u0020', '_');
            this.type = type;
            displayName = name;
            tooltip = "";
            code = "";
            type = "";
            sprite = null;
            exportedCode = "";
        }

        public string get_name() { return name; }
        public string get_displayName() { return displayName; }
        public string get_tooltip() { return tooltip;}
        public string get_type() { return type;}
        public string get_code() { return code;}     
        public Bitmap get_sprite() { return sprite;}
        public string get_exportedCode() {  return exportedCode;}
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
        public void set_type(string type)
        {
            this.type = type;
        }
        public void set_sprite(Bitmap sprite)
        {
            this.sprite = sprite;
        }
        public void set_exportedCode(string code)
        {
            this.exportedCode = code;
        }
    }
}
