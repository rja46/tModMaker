using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_solution
{
    internal class GenericBlock
    {
        public string type { get; set; }
    }

    internal class define_weapon_essential : GenericBlock 
    {
        public int damage { get; set; }
        public string damageType { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int useTime { get; set; }
        public int useAnimation { get; set; }
        public string useStyle { get; set; }
        public int knockback { get; set; }
        public int crit { get; set; }
        public int value { get; set; }
        public string rare { get; set; }
        public int UseSound { get; set; }
        public bool autoReuse { get; set; }
    }

    internal class pick_power : GenericBlock
    {
        public int pick { get; set; }
    }

    internal class axe_power : GenericBlock
    {
        public int axe { get; set;}
    }

    internal class hammer_power : GenericBlock
    { 
        public int hammer { get; set;}
    }

    internal class is_consumable : GenericBlock
    {
        public bool consumable { get; set; }
    }
}
