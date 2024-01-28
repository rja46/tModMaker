using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;

namespace NEA_solution
{
    internal class CodeGenerator
    {
        public string generate_code(string code, string modName, string itemName, string itemDisplayName)
        {
            string blockType;
            string[] blocksAsStrings;
            string setDefaults = "Item.SetNameOverride(\"" + itemDisplayName + "\");";

            string generatedCode = "using Terraria;" +
                "\r\nusing Terraria.ID;" +
                "\r\nusing Terraria.ModLoader;" +
                "\r\nnamespace " + modName + ".Items" +
                "\r\n{" +
                "\r\npublic class " + itemName + " : ModItem" +
                "\r\n{";

            blocksAsStrings = findBlocksInline(code);

            for (int i = 0; i < blocksAsStrings.Length; i++)
            {
                blockType = JsonSerializer.Deserialize<GenericBlock>(blocksAsStrings[i]).type;
                switch (blockType)
                {
                    case "define_weapon_essential":

                        define_weapon_essential define_Weapon_Essential = JsonSerializer.Deserialize<define_weapon_essential>(blocksAsStrings[i]);

                        setDefaults += "\r\nItem.damage = " + define_Weapon_Essential.damage + ";";
                        setDefaults += "\r\nItem.DamageType = DamageClass." + define_Weapon_Essential.damageType + ";";
                        setDefaults += "\r\nItem.width = " + define_Weapon_Essential.width + ";";
                        setDefaults += "\r\nItem.height = " + define_Weapon_Essential.height + ";";
                        setDefaults += "\r\nItem.useTime = " + define_Weapon_Essential.useTime + ";";
                        setDefaults += "\r\nItem.useAnimation = " + define_Weapon_Essential.useAnimation + ";";
                        setDefaults += "\r\nItem.knockBack = " + define_Weapon_Essential.knockback + ";";
                        setDefaults += "\r\nItem.value = " + define_Weapon_Essential.value + ";";
                        setDefaults += "\r\nItem.rare = " + define_Weapon_Essential.rare + ";";
                        setDefaults += "\r\nItem.UseSound = SoundID.Item" + define_Weapon_Essential.UseSound + ";";
                        setDefaults += "\r\nItem.autoReuse = " + define_Weapon_Essential.autoReuse + ";";
                        setDefaults += "\r\nItem.useStyle = " + define_Weapon_Essential.useStyle + ";";

                        break;

                    case "pick_power":
                        pick_power pick_Power = JsonSerializer.Deserialize<pick_power>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.pick = " + pick_Power.pick + ";";
                        break;

                    case "axe_power":
                        axe_power axe_Power = JsonSerializer.Deserialize<axe_power>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.axe = " + axe_Power.axe + ";";
                        break;

                    case "hammer_power":
                        hammer_power hammer_Power = JsonSerializer.Deserialize<hammer_power>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.hammer = " + hammer_Power.hammer + ";";
                        break;

                    case "fishing_power":
                        //this needs a class implementation
                        break;

                    case "is_consumable":
                        //doesnt work
                        is_consumable is_Consumable = JsonSerializer.Deserialize<is_consumable>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.consumable = " + is_Consumable.consumable + ";";
                        break;
                }
            }

            generatedCode += "\r\npublic override void SetDefaults()\r\n{\r\n" + setDefaults + "\r\n}";
            return generatedCode;
        }

        private static string[] findBlocksInline(string contents)
        {
            List<string> blocksList = new List<string>();

            string reader = "";
            bool reading = false;
            int count = 0;

            for (int i = 0; i < contents.Length; i++)
            {
                reader += contents[i];
                if (reader.Contains("\"blocks\":[") || reader.Contains("\"block\":"))
                {
                    reader = "";
                    reading = true;
                }

                if (reader.Contains(",") && reading)
                {
                    reading = false;
                    blocksList.Add(reader);
                }
            }

            for (int i = 0; i < contents.Length; i++)
            {
                reader += contents[i];
                if (reader.Contains("\"fields\":{"))
                {
                    reader = "";
                    reading = true;
                }

                if (reader.Contains("}") && reading)
                {
                    reading = false;
                    blocksList[count] += (reader);
                    count++;
                }
            }


            string[] blocks = blocksList.ToArray();
            return blocks;
        }
    }
}
