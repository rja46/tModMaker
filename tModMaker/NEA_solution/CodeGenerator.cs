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
        public string generate_code(string code, string modName, string itemName, string itemDisplayName, string toolTip, string type)
        {
            string blockType;
            string[] blocksAsStrings;
            string setDefaults = "Item.SetNameOverride(\"" + itemDisplayName + "\");";
            string UpdateAccessory = "";
            bool isEquipable = false;
            bool isWing = false;
            string SetStaticDefaults = "";
            string verticalWingsSpeeds;
            float[] wingStats = new float[5];
            bool canHover = false;


            /*
             * Sets the string to be retuned to the namespace setup, with the correct names in place.
             * 
             * Everything is on a new line to aid readability for test and the end user.
             */
            string generatedCode = "using Terraria;" +
                "\r\nusing System.Linq;" +
                "\r\nusing Terraria;" +
                "\r\nusing Terraria.DataStructures;" +
                "\r\nusing Terraria.ID;" +
                "\r\nusing Terraria.ModLoader;" +
                "\r\nusing Terraria.ID;" +
                "\r\nusing Terraria.ModLoader;";
            if (type == "Item")
            {
                generatedCode += "\r\nnamespace " + modName + ".Items";
            }
            else if (type == "NPC/Projectile")
            {
                generatedCode += "\r\nnamespace " + modName + ".Projectiles";
            }
            generatedCode += "\r\n{";
                

            //Each block is found in the code, and put in an array of strings.
            blocksAsStrings = findBlocksInline(code);

            for (int i = 0; i < blocksAsStrings.Length; i++)
            {
                /*
                 * Each block is a small json array, which is deserialised into a class with only type
                 * as a field.
                 * 
                 * This allows the type of block to be identified and handled accordingly.
                 */
                blockType = JsonSerializer.Deserialize<GenericBlock>(blocksAsStrings[i]).type;
                /*
                 * The switch case takes the type of block, and deserialises the block into the correct
                 * child class of GenericBlock.
                 * 
                 * The values and code are then added to the code for the correct method
                 * 
                 * the value isEquipable may be set to true. This means it must be made into an accessory
                 * to have these properties function.
                 */
                switch (blockType)
                {
                    //Item class blocks
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

                    case "tool_power":
                        tool_power tool_Power = JsonSerializer.Deserialize<tool_power>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem." + tool_Power.tool_type + " = " + tool_Power.power + ";";
                        break;

                    case "is_consumable":
                        setDefaults += "\r\nItem.consumable = true;";
                        break;

                    case "no_melee":
                        setDefaults += "\r\nItem.noMelee = true;";
                        break;

                    case "shoot_existing_ammo":
                        shoot_existing_ammo shoot_Existing_Ammo = JsonSerializer.Deserialize<shoot_existing_ammo>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.shoot = 10;" + "\r\nItem.shootSpeed = " + shoot_Existing_Ammo.shoot_speed + ";" + "\r\nItem.useAmmo = AmmoID." + shoot_Existing_Ammo.ammo_type + ";";
                        //this may need a tidier implementation to allow the user to choose the rocket fired
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

                    case "grant_ability":
                        grant_ability grant_Ability = JsonSerializer.Deserialize<grant_ability>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\nplayer." + grant_Ability.ability + " = true;";
                        isEquipable = true;
                        break;

                    case "change_player_stat":
                        change_player_stat change_Player_Stat = JsonSerializer.Deserialize<change_player_stat>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\nplayer." + change_Player_Stat.stat + " += " + change_Player_Stat.value + ";";
                        isEquipable = true;
                        break;

                    case "set_player_stat":
                        //defence doesnt work
                        set_player_stat set_Player_Stat = JsonSerializer.Deserialize<set_player_stat>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\nplayer." + set_Player_Stat.stat + " = " + set_Player_Stat.value + ";";
                        isEquipable = true;
                        break;

                    case "set_class_stat":
                        set_class_stat set_Class_Stat = JsonSerializer.Deserialize<set_class_stat>(blocksAsStrings[i]);
                        UpdateAccessory += "player." + set_Class_Stat.stat + "(DamageClass." + set_Class_Stat.class_name + ") = " + set_Class_Stat.value + ";";
                        isEquipable = true;
                        break;

                    case "set_all_player_bools":
                        set_all_player_bools set_All_Player_Bools = JsonSerializer.Deserialize<set_all_player_bools>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\nplayer." + set_All_Player_Bools.property + " = true;";
                        isEquipable = true;
                        break;

                    case "create_wings":
                        create_wings create_Wings = JsonSerializer.Deserialize<create_wings>(blocksAsStrings[i]); ;
                        wingStats[0] = create_Wings.flight_time;
                        wingStats[1] = create_Wings.flight_speed;
                        wingStats[2] = create_Wings.acceleration;
                        isWing = true;
                        break;

                    case "wing_hover":
                        wing_hover wing_Hover = JsonSerializer.Deserialize<wing_hover>(blocksAsStrings[i]);
                        wingStats[3] = wing_Hover.hover_speed;
                        wingStats[4] = wing_Hover.acceleration;
                        canHover = true;
                        break;

                    case "use_custom_projectile":
                        use_custom_projectile use_Custom_Projectile = JsonSerializer.Deserialize<use_custom_projectile>(blocksAsStrings[i]);
                        setDefaults += "Item.shoot = ModContent.ProjectileType<Projectiles." + use_Custom_Projectile.projectile + ">();";
                        break;




                    //NPC/Projectile class blocks
                    case "projectile_basic":
                        projectile_basic projectile_Basic = JsonSerializer.Deserialize<projectile_basic>(blocksAsStrings[i]);
                        setDefaults += "\r\nProjectile.width = " + projectile_Basic.width + ";";
                        setDefaults += "\r\nProjectile.height = " + projectile_Basic.height + ";";
                        setDefaults += "\r\nProjectile.tileCollide = " + projectile_Basic.collide.ToString().ToLower() + ";";
                        setDefaults += "\r\nProjectile.scale = " + projectile_Basic.scale + "f;";
                        setDefaults += "\r\nProjectile.timeLeft = " + projectile_Basic.time_left + ";";
                        setDefaults += "\r\nProjectile.name = \"" + projectile_Basic.name + "\";";
                        break;
                }
            }

            if (isWing)
            {
                generatedCode += "\r\n[AutoloadEquip(EquipType.Wings)]";
            }

            generatedCode +=
                "\r\npublic class " + itemName + " : ModItem" +
                "\r\n{";

            if (isEquipable)
            {
                setDefaults += "\r\nItem.accessory = true;";
            }

            if (isWing)
            {
                if (canHover)
                {
                    SetStaticDefaults = "\r\nArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(" + (int)wingStats[0] + ", " + wingStats[1] + "f, " + wingStats[2] + "f, true, "+ wingStats[3] +"f, " + wingStats[4] +"f);";
                }
                else
                {
                    SetStaticDefaults = "\r\nArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(" + (int)wingStats[0] + "," + wingStats[1] + "f," + wingStats[2] + "f);";
                }
                generatedCode += "\r\npublic override void SetStaticDefaults()\r\n{\r\n" + SetStaticDefaults + "\r\n}\r\n";
            }

            //I need to make it possible to add the second sprite for wings.
            verticalWingsSpeeds = "public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising," +
                "\r\nref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)" +
                "\r\n{" +
                "\r\nascentWhenFalling = 0.85f;" +
                "\r\nascentWhenRising = 0.15f;" +
                "\r\nmaxCanAscendMultiplier = 1f;" +
                "\r\nmaxAscentMultiplier = 3f;" +
                "\r\nconstantAscend = 0.135f;" +
                "\r\n}";

            if (isWing)
            {
                generatedCode += verticalWingsSpeeds;
            }
            //The generated methods are compiled into one string here.
            generatedCode += "\r\npublic override void SetDefaults()\r\n{\r\n" + setDefaults + "\r\n}" + "\r\npublic override void UpdateAccessory(Player player, bool hideVisual)\r\n{\r\n" + UpdateAccessory + "\r\n}\r\n}\r\n}";
            return generatedCode;
        }

        private static string[] findBlocksInline(string contents)
        {
            List<string> blocksList = new List<string>();

            string reader = "";
            bool reading = false;
            int count = 0;

            //This first loop checks for the type of each block and add them to an array.
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

            /*
             * This loop finds the other properties of each block, and adds them to the
             * item in the array.
             */
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
                    blocksList[count] += reader;
                    count++;
                }
            }

            string[] blocks = blocksList.ToArray();
            return blocks;
        }
    }
}
