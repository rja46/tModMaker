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
        private string type;
        private Bitmap sprite;
        private Bitmap wingSprite;
        private Bitmap headSprite;
        private Bitmap bodySprite;
        private Bitmap legsSprite;
        private RecipeItem[] ingredients;

        public Item(string name, string type)
        {
            //The spaces in the name must be replaced with underscores to make it a valid class name.
            this.name = name.Replace('\u0020', '_');
            this.type = type;
            displayName = name;
            tooltip = "";
            code = "";
            type = "";
            sprite = null;
        }

        public string get_name() { return name; }
        public string get_displayName() { return displayName; }
        public string get_tooltip() { return tooltip;}
        public string get_type() { return type;}
        public string get_code() { return code;}     
        public Bitmap get_sprite() { return sprite;}
        public RecipeItem[] get_ingredients() { return ingredients; }
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
        public Bitmap get_wingSprite()
        {
            return wingSprite;
        }
        public void set_wingSprite(Bitmap wingSprite)
        {
            this.wingSprite = wingSprite;
        }
        public Bitmap get_headSprite()
        {
            return headSprite;
        }
        public void set_headSprite(Bitmap headSprite)
        {
            this.headSprite = headSprite;
        }
        public Bitmap get_bodySprite()
        {
            return bodySprite;
        }
        public void set_bodySprite(Bitmap bodySprite)
        {
            this.bodySprite = bodySprite;
        }
        public Bitmap get_legsSprite()
        {
            return legsSprite;
        }
        public void set_legsSprite(Bitmap legsSprite)
        {
            this.legsSprite = legsSprite;
        }

        public void set_ingredients(RecipeItem[] ingredients)
        {
            this.ingredients = ingredients;
        }
    }
}
