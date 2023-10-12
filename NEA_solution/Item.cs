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
        private Code code;
        private Sprite sprite;
        private string type;

        public Item(string name, string type)
        {
            this.name = name;
            this.type = type;
            displayName = name;
            tooltip = "";
            code = new Code();
            sprite = new Sprite();
            type = "";
        }

        public string get_name() { return name; }
        public string get_displayName() { return displayName; }
        public string get_tooltip() { return tooltip;}
        public string get_type() { return type;}
    }
}
