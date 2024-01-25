using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_solution
{
    internal class define_weapon_essential
    {
        public string type { get; set; }
        public int damage { get; set; }
        public string damageType { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int useTime {  get; set; }
        public int useAnimation {  get; set; }
        public string useStyle { get; set; }
        public int knockback { get; set; }
        public int crit {  get; set; }
        public int value { get; set; }
        public string rare { get; set; }
        public int UseSound { get; set; }
        public bool autoReuse {  get; set; }
    }
}
