using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_solution
{
    public class RecipeItem
    {
        public string itemName { get; set; }
        public int quantity { get; set; }
        public RecipeItem(string name, int number)
        {
            itemName = name;
            quantity = number;
        }
    }
}
