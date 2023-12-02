using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_solution
{
    internal class CodeGenerator
    {
        private string name;
        
        //these following properties are added to define_weapon_essential
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
        //additional blocks
        private int? pick { get; set; }
        private int? axe { get; set; }
        private int? hammer { get; set; }



        string[] codeSnippetsDefineWeaponEssential = {
            "Item.pick = ",
            "Item.axe = ",
            "Item.hammer = "
        };

        public string generate_code(string name)
        {
            Object[] parameterValuesDefineWeaponEssential = { pick, axe, hammer };
            this.name = name;
            string code = "\r\n\t\tpublic override void SetDefaults()\r\n\t\t{";
            code += "\r\n\t\t\tItem.SetNameOverride(\"" + name + "\");\r\n\t\t\t" + "Item.damage = " + damage + ";\r\n\t\t\tItem.DamageType = DamageClass." + damageType + ";\r\n\t\t\tItem.width = " + width + ";\r\n\t\t\tItem.height = " + height + ";\r\n\t\t\tItem.useTime = " + useTime + ";\r\n\t\t\tItem.useAnimation = " + useAnimation + ";\r\n\t\t\tItem.knockBack = " + knockback + ";\r\n\t\t\tItem.value = " + value + ";\r\n\t\t\tItem.rare = " + rare + ";\r\n\t\t\tItem.UseSound = SoundID.Item" + UseSound + ";\r\n\t\t\tItem.autoReuse = " + autoReuse + ";\r\n\t\t\tItem.useStyle = " + useStyle + ";";
            
            for (int i = 0; i < codeSnippetsDefineWeaponEssential.Length; i++)
            {
                if (parameterValuesDefineWeaponEssential[i] != null)
                {
                    code += "\r\n\t\t\t" + codeSnippetsDefineWeaponEssential[i] + parameterValuesDefineWeaponEssential[i] + ";";
                }
            }

            code += "\r\n\t\t}";
            return code;
        }

        
        /*
        turn this into a json dictionary
        iterate through each item. if not null, find corresponding point in dict,
        grab code snippet and add the value.
        */

    }
}
