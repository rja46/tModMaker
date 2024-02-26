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
        public string generate_code(string code, string modName, string itemName, string itemDisplayName, string toolTip, string itemType)
        {
            string setDefaults = "";
            string blockType;
            string[] blocksAsStrings;
            string UpdateAccessory = "";
            bool isEquipable = false;
            bool isWing = false;
            string SetStaticDefaults = "";
            string verticalWingsSpeeds;
            float[] wingStats = new float[5];
            bool canHover = false;
            string slot = null;
            List<string> chatOptions = new List<string>();

            if (itemType == "Item")
            {
                setDefaults = "Item.SetNameOverride(\"" + itemDisplayName + "\");";
            }



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
                "\r\nusing Terraria.ModLoader;" +
                "\r\nusing System;";
            Console.WriteLine(itemType);
            if (itemType == "Item")
            {
                generatedCode += "\r\nnamespace " + modName + ".Items";
            }
            else if (itemType == "Projectile")
            {
                generatedCode += "\r\nnamespace " + modName + ".Projectiles";
            }
            else if (itemType == "NPC")
            {
                generatedCode += "\r\nnamespace " + modName + ".NPCs";
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
                        is_consumable is_Consumable = JsonSerializer.Deserialize<is_consumable>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.consumable = " + is_Consumable.consumable + ";";
                        break;

                    case "no_melee":
                        no_melee no_Melee = JsonSerializer.Deserialize<no_melee>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.noMelee = " + (!no_Melee.melee).ToString().ToLower() + ";";
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
                        isEquipable = true;
                        isWing = true;
                        slot = "Wings";
                        break;

                    case "wing_hover":
                        wing_hover wing_Hover = JsonSerializer.Deserialize<wing_hover>(blocksAsStrings[i]);
                        wingStats[3] = wing_Hover.hover_speed;
                        wingStats[4] = wing_Hover.acceleration;
                        canHover = true;
                        break;

                    case "use_custom_projectile":
                        use_custom_projectile use_Custom_Projectile = JsonSerializer.Deserialize<use_custom_projectile>(blocksAsStrings[i]);
                        setDefaults += "\r\nItem.shoot = 10;" + "\r\nItem.shootSpeed = " + use_Custom_Projectile.shoot_speed + ";" + "\r\nItem.shoot = ModContent.ProjectileType<Projectiles." + use_Custom_Projectile.projectile + ">();";
                        break;

                    case "equip_slot":
                        equip_slot equip_Slot = JsonSerializer.Deserialize<equip_slot>(blocksAsStrings[i]);
                        slot = equip_Slot.slot;
                        break;




                    //Projectile class blocks
                    case "projectile_basic":
                        projectile_basic projectile_Basic = JsonSerializer.Deserialize<projectile_basic>(blocksAsStrings[i]);
                        setDefaults += "\r\nProjectile.width = " + projectile_Basic.width + ";";
                        setDefaults += "\r\nProjectile.height = " + projectile_Basic.height + ";";
                        setDefaults += "\r\nProjectile.timeLeft = " + projectile_Basic.time_left + ";";
                        break;

                    case "use_ai":
                        use_ai use_Ai = JsonSerializer.Deserialize<use_ai>(blocksAsStrings[i]);
                        setDefaults += "\r\nProjectile.aiStyle = " + use_Ai.style + ";";
                        break;

                    case "set_value":
                        Set_value set_Value = JsonSerializer.Deserialize<Set_value>(blocksAsStrings[i]);
                        setDefaults += "\r\nProjectile." + set_Value.property + " = " + set_Value.value + ";";
                        break;

                    case "declare_friendly":
                        declare_friendly declare_Friendly = JsonSerializer.Deserialize<declare_friendly>(blocksAsStrings[i]);
                        setDefaults += "\r\nProjectile.friendly = " + declare_Friendly.friendly.ToString().ToLower() + ";";
                        break;

                    case "declare_hostile":
                        declare_hostile declare_Hostile = JsonSerializer.Deserialize<declare_hostile>(blocksAsStrings[i]);
                        setDefaults += "\r\nProjectile.hostile = " + declare_Hostile.hostile.ToString().ToLower() + ";";
                        break;

                    case "hide_projectile":
                        hide_projectile hide_Projectile = JsonSerializer.Deserialize<hide_projectile>(blocksAsStrings[i]);
                        setDefaults += "\r\nProjectile.hide = " + hide_Projectile.hide.ToString().ToLower() + ";";
                        break;

                    case "collide_with_tiles":
                        collide_with_tiles collide_With_Tiles = JsonSerializer.Deserialize<collide_with_tiles>(blocksAsStrings[i]);
                        setDefaults += "\r\nProjectile.tileCollide = " + collide_With_Tiles.collide.ToString().ToLower() + ";";
                        break;

                    case "ignore_water":
                        ignore_water ignore_Water = JsonSerializer.Deserialize<ignore_water>(blocksAsStrings[i]);
                        setDefaults += "\r\nProjectile.ignoreWater = " + (!ignore_Water.ignore).ToString().ToLower() + ";";
                        break;

                    case "emit_light":
                        emit_light emit_Light = JsonSerializer.Deserialize<emit_light>(blocksAsStrings[i]);
                        setDefaults += "\r\nProjectile.light = " + emit_Light.light + "f;";
                        break;



                    //NPC Class Blocks
                    case "npc_basic":
                        npc_basic npc_Basic = JsonSerializer.Deserialize<npc_basic>(blocksAsStrings[i]);
                        setDefaults += "\r\nNPC.width = " + npc_Basic.width + ";";
                        setDefaults += "\r\nNPC.height = " + npc_Basic.height + ";";
                        setDefaults += "\r\nNPC.height = " + npc_Basic.height + ";";
                        setDefaults += "\r\nNPC.damage = " + npc_Basic.damage + ";";
                        setDefaults += "\r\nNPC.defense = " + npc_Basic.defense + ";";
                        setDefaults += "\r\nNPC.lifeMax = " + npc_Basic.life + ";";
                        setDefaults += "\r\nNPC.knockBackResist = " + npc_Basic.knockResist + ";";
                        break;

                    case "use_npc_ai":
                        use_ai use_Npc_Ai = JsonSerializer.Deserialize<use_ai>(blocksAsStrings[i]);
                        setDefaults += "\r\nNPC.aiStyle = " + use_Npc_Ai.style + ";";
                        break;

                    case "chat_option":
                        chat_options chat_Options = JsonSerializer.Deserialize<chat_options>(blocksAsStrings[i]);
                        chatOptions.Add(chat_Options.chat);
                        break;

                }
            }

            if (slot != null)
            {
                generatedCode += "\r\n[AutoloadEquip(EquipType." + slot + ")]";
            }

            if (itemType == "Item")
            {
                generatedCode +=
                    "\r\npublic class " + itemName + " : ModItem" +
                    "\r\n{";
            }
            else if (itemType == "Projectile")
            {
                generatedCode +=
                    "\r\npublic class " + itemName + " : ModProjectile" +
                    "\r\n{";
            }
            else if (itemType == "NPC")
            {
                generatedCode +=
                    "\r\npublic class " + itemName + " : ModNPC" +
                    "\r\n{";
            }
            else
            {
                MessageBox.Show("Fatal error: item type invalid. Exported code will not run.");
            }

            if (isEquipable)
            {
                setDefaults += "\r\nItem.accessory = true;";
            }

            if (isWing)
            {
                if (canHover)
                {
                    SetStaticDefaults = "\r\nArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(" + (int)wingStats[0] + ", " + wingStats[1] + "f, " + wingStats[2] + "f, true, " + wingStats[3] + "f, " + wingStats[4] + "f);";
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

            if (chatOptions.Count > 0)
            {
                generatedCode += "\r\npublic override string GetChat() {";
                generatedCode += "\r\nRandom rand = new Random();";
                generatedCode += "\r\nint result = rand.Next(" + chatOptions.Count + ");";
                for (int i = 0; i < chatOptions.Count; i++)
                {
                    generatedCode += "\r\nif (result == " + i + ") { return \"" + chatOptions[i] + "\"; }";
                }
                generatedCode += "\r\nelse { return \"oh no\"; }";
                generatedCode += "\r\n}";
                setDefaults += "\r\nNPC.townNPC = true;";
            }

            //The generated methods are compiled into one string here.
            generatedCode += "\r\npublic override void SetDefaults()\r\n{\r\n" + setDefaults + "\r\n}";
            if (isEquipable)
            {
                generatedCode += "\r\npublic override void UpdateAccessory(Player player, bool hideVisual)\r\n{\r\n" + UpdateAccessory + "\r\n}";
            }

            

            generatedCode += "\r\n}\r\n}";
            
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

            for (int i = 0; i < blocksList.Count; i++)
            {
                blocksList[i].Trim();
                if (blocksList[i][blocksList[i].Length - 1] != '}')
                {
                    blocksList[i] = blocksList[i].Trim(',');
                    blocksList[i] += '}';
                    Console.WriteLine(blocksList[i]);
                }
            }

            string[] blocks = blocksList.ToArray();
            foreach (string block in blocks)
            {
                Console.WriteLine(block);
            }
            return blocks;
        }
    }
}
