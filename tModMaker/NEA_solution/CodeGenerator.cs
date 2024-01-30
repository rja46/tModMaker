using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;
using System.Numerics;

namespace NEA_solution
{
    internal class CodeGenerator
    {
        public string generate_code(string code, string modName, string itemName, string itemDisplayName, string toolTip)
        {
            string blockType;
            string[] blocksAsStrings;
            string setDefaults = "Item.SetNameOverride(\"" + itemDisplayName + "\");";
            string UpdateAccessory = "";
            bool isEquipable = false;

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
                    case "define_item":
                        define_item define_Item = JsonSerializer.Deserialize<define_item>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.width = " + define_Item.width + ";";
                        setDefaults += "\r\nItem.height = " + define_Item.height + ";";
                        setDefaults += "\r\nItem.value = " + define_Item.value + ";";
                        setDefaults += "\r\nItem.rare = " + define_Item.rare + ";";
                        break;

                    case "define_weapon_essential":
                        define_weapon_essential define_Weapon_Essential = JsonSerializer.Deserialize<define_weapon_essential>(blocksAsStrings[i]);

                        setDefaults += "\r\nItem.damage = " + define_Weapon_Essential.damage + ";";
                        setDefaults += "\r\nItem.DamageType = DamageClass." + define_Weapon_Essential.damageType + ";";
                        setDefaults += "\r\nItem.useTime = " + define_Weapon_Essential.useTime + ";";
                        setDefaults += "\r\nItem.useAnimation = " + define_Weapon_Essential.useAnimation + ";";
                        setDefaults += "\r\nItem.knockBack = " + define_Weapon_Essential.knockback + ";";
                        setDefaults += "\r\nItem.UseSound = SoundID.Item" + define_Weapon_Essential.UseSound + ";";
                        setDefaults += "\r\nItem.autoReuse = " + define_Weapon_Essential.autoReuse.ToString().ToLower() + ";";
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
                        is_consumable is_Consumable = JsonSerializer.Deserialize<is_consumable>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.consumable = " + is_Consumable.isConsumable.ToString().ToLower() + ";";
                        break;

                    case "no_melee":
                        no_melee_block no_Melee_Block = JsonSerializer.Deserialize<no_melee_block>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.noMelee = " + no_Melee_Block.no_melee.ToString().ToLower() + ";";
                        break;

                    case "shoot_existing_ammo":
                        shoot_existing_ammo shoot_Existing_Ammo = JsonSerializer.Deserialize<shoot_existing_ammo>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.shoot = 10;" + "\r\nItem.shootSpeed = " + shoot_Existing_Ammo.shoot_speed + ";" + "\r\nItem.useAmmo = AmmoID." + shoot_Existing_Ammo.ammo_type + ";";
                        //this may need a tider implementation to allow the user to choose the rocket fired
                        if (shoot_Existing_Ammo.ammo_type == "Rocket")
                        {
                            setDefaults += "\r\nItem.shoot = ProjectileID.RocketI;";
                        }
                        break;

                    case "change_class_stat":
                        change_class_stat change_Class_Stat = JsonSerializer.Deserialize<change_class_stat>(blocksAsStrings[i]);
                        UpdateAccessory += "player." + change_Class_Stat.stat + "(DamageClass." + change_Class_Stat.class_name + ") += " + change_Class_Stat.value + ";";
                        isEquipable = true;
                        break;

                    case "use_mana":
                        use_mana use_Mana = JsonSerializer.Deserialize<use_mana>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.mana = " + use_Mana.useMana + ";";
                        break;

                    case "increase_life":
                        increase_life increase_Life = JsonSerializer.Deserialize<increase_life>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\nplayer.statLifeMax2 += " + increase_Life.life + ";";
                        isEquipable = true;
                        break;

                    case "increase_move_speed":
                        increase_move_speed increase_Move_Speed = JsonSerializer.Deserialize<increase_move_speed>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\nplayer.moveSpeed += " + increase_Move_Speed.value + "f;";
                        isEquipable = true;
                        break;

                    case "grant_ability":
                        grant_ability grant_Ability = JsonSerializer.Deserialize<grant_ability>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\nplayer." + grant_Ability.ability + " = true;";
                        isEquipable = true;
                        break;
                }
            }

            if (isEquipable)
            {
                setDefaults += "\r\nItem.accessory = true;";
            }

            generatedCode += "\r\npublic override void SetDefaults()\r\n{\r\n" + setDefaults + "\r\n}" + "\r\npublic override void UpdateAccessory(Player player, bool hideVisual)\r\n{\r\n" + UpdateAccessory + "\r\n}\r\n}\r\n}";
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
