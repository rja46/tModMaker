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
        public string name;
        public string displayName;
        public string tooltip;
        public string code;
        public string type;
        public Bitmap sprite;
        public Bitmap wingSprite;
        public Bitmap headSprite;
        public Bitmap bodySprite;
        public Bitmap legsSprite;
        public RecipeItem[] ingredients = new RecipeItem[1];
        public Bitmap mapHead;
        public int craftingStationID = -1;


        public Item(string name, string type)
        {
            //The spaces in the name must be replaced with underscores to make it a valid class name.
            ingredients[0] = new RecipeItem("DirtBlock", 10);
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
        public Bitmap get_mapHead() { return mapHead;}
        public int get_craftingStationID() { return craftingStationID; }
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
        public void set_mapHead(Bitmap mapHead)
        {
            this.mapHead = mapHead;
        }
        public void set_craftingStationID (int craftingStationID)
        {
            this.craftingStationID = craftingStationID;
        }
    }
}
