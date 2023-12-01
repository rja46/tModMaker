using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_solution
{
    internal class Code
    {
        //define_weapon_essential
        private int damage { get; set; }
        private string damageType { get; set; }
        private int width { get; set; }
        private int height { get; set; }
        private int useTime { get; set; }
        private int useAnimation { get; set; }
        private string useStyle { get; set; }
        private int knockback { get; set; }
        private int crit { get; set; }
        private int value { get; set; }
        private string rare { get; set; }
        private int UseSound { get; set; }
        private bool autoReuse { get; set; }

        public string generate_code()
        {
            string code = "public override void SetDefaults() {";
            code = "Item.damage = " + damage + "; Item.DamageType = DamageClass." + damageType + "; Item.width = "+ width + "; Item.height = " + height + "; Item.useTime = " + useTime + "; Item.useAnimation = " + useAnimation + "; Item.knockBack = " + knockback + "; Item.value = " + value + "; Item.rare = " + rare + "; Item.UseSound = SoundID.Item" + UseSound + "; Item.autoReuse = " + autoReuse + "; Item.useStyle = " + useStyle + ";";
            return code;
        }
    }
}
