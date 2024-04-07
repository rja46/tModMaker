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
        //This algorithm will only return the final slot that is assigned in code.
        public string get_slot(Item item)
        {
            string slot = string.Empty;
            string blockType;

            string[] blocksAsStrings = findBlocksInline(item.get_code());

            for (int i = 0; i < blocksAsStrings.Length; i++)
            {
                blockType = JsonSerializer.Deserialize<GenericBlock>(blocksAsStrings[i]).type;

                if (blockType == "equip_slot")
                {
                    slot = JsonSerializer.Deserialize<equip_slot>(blocksAsStrings[i]).slot;
                }
            }

            return slot;

        }
        public string generate_code(Item item, string modName)
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
            List<string> nameOptions = new List<string>();
            List<string> shopItems = new List<string>();
            List<int> shopValues = new List<int>();
            bool hasShop = false;
            string AI = "";
            bool chasePlayer = false;
            string spawnrate = "";
            string NPCloot = "";
            string onHit = "";
            string useItem = "";
            bool isBoss = false;
            string useItemReturn = "\r\n\t\t\treturn true;";
            string[] vanillaItems = File.ReadAllLines(Environment.CurrentDirectory + "\\itemIDs.txt");
            string[] vanillaMobs = File.ReadAllLines(Environment.CurrentDirectory + "\\npcIDs.txt");


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
                "\r\nusing System;" +
                "\r\nusing System.Collections.Generic;" +
                "\r\nusing Terraria.ModLoader.Utilities;" +
                "\r\nusing Terraria.GameContent.ItemDropRules;";

            string itemType = item.get_type();
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
            blocksAsStrings = findBlocksInline(item.get_code());

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
                        setDefaults += "\r\n\t\t\tItem.value = " + define_Item.value + ";";
                        setDefaults += "\r\n\t\t\tItem.rare = " + define_Item.rare + ";";
                        break;

                    case "define_weapon_essential":
                        define_weapon_essential define_Weapon_Essential = JsonSerializer.Deserialize<define_weapon_essential>(blocksAsStrings[i]);

                        setDefaults += "\r\n\t\t\tItem.damage = " + define_Weapon_Essential.damage + ";";
                        setDefaults += "\r\n\t\t\tItem.DamageType = DamageClass." + define_Weapon_Essential.damageType + ";";
                        setDefaults += "\r\n\t\t\tItem.knockBack = " + define_Weapon_Essential.knockback + ";";
                        setDefaults += "\r\n\t\t\tItem.crit = " + define_Weapon_Essential.crit + ";";
                        break;

                    case "define_tool":
                        define_tool define_Tool = JsonSerializer.Deserialize<define_tool>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tItem.useTime = " + define_Tool.useTime + ";";
                        setDefaults += "\r\n\t\t\tItem.useAnimation = " + define_Tool.useTime + ";";
                        setDefaults += "\r\n\t\t\tItem.UseSound = SoundID.Item" + define_Tool.UseSound + ";";
                        setDefaults += "\r\n\t\t\tItem.autoReuse = " + define_Tool.autoReuse.ToString().ToLower() + ";";
                        setDefaults += "\r\n\t\t\tItem.useStyle = " + define_Tool.useStyle + ";";
                        break;

                    case "tool_power":
                        tool_power tool_Power = JsonSerializer.Deserialize<tool_power>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tItem." + tool_Power.tool_type + " = " + tool_Power.power + ";";
                        break;

                    case "is_consumable":
                        is_consumable is_Consumable = JsonSerializer.Deserialize<is_consumable>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tItem.consumable = " + is_Consumable.consumable.ToString().ToLower() + ";";
                        break;

                    case "no_melee":
                        no_melee no_Melee = JsonSerializer.Deserialize<no_melee>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tItem.noMelee = " + (!no_Melee.melee).ToString().ToLower() + ";";
                        break;

                    case "shoot_existing_ammo":
                        shoot_existing_ammo shoot_Existing_Ammo = JsonSerializer.Deserialize<shoot_existing_ammo>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tItem.shoot = 10;"
                            + "\r\n\t\t\tItem.shootSpeed = " + shoot_Existing_Ammo.shoot_speed + ";"
                            + "\r\n\t\t\tItem.useAmmo = AmmoID." + shoot_Existing_Ammo.ammo_type + ";";
                        //this may need a tidier implementation to allow the user to choose the rocket fired
                        if (shoot_Existing_Ammo.ammo_type == "Rocket")
                        {
                            setDefaults += "\r\n\t\t\tItem.shoot = ProjectileID.RocketI;";
                        }
                        break;

                    case "change_class_stat":
                        change_class_stat change_Class_Stat = JsonSerializer.Deserialize<change_class_stat>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\n\t\t\tplayer." + change_Class_Stat.stat + "(DamageClass." + change_Class_Stat.class_name + ") += " + change_Class_Stat.value + ";";
                        isEquipable = true;
                        break;

                    case "use_mana":
                        use_mana use_Mana = JsonSerializer.Deserialize<use_mana>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tItem.mana = " + use_Mana.useMana + ";";
                        break;

                    case "grant_ability":
                        grant_ability grant_Ability = JsonSerializer.Deserialize<grant_ability>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\n\t\t\tplayer." + grant_Ability.ability + " = true;";
                        isEquipable = true;
                        break;

                    case "change_player_stat":
                        change_player_stat change_Player_Stat = JsonSerializer.Deserialize<change_player_stat>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\n\t\t\tplayer." + change_Player_Stat.stat + " += " + change_Player_Stat.value + ";";
                        isEquipable = true;
                        break;

                    case "set_player_stat":
                        set_player_stat set_Player_Stat = JsonSerializer.Deserialize<set_player_stat>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\n\t\t\tplayer." + set_Player_Stat.stat + " = " + set_Player_Stat.value + ";";
                        isEquipable = true;
                        break;

                    case "set_class_stat":
                        set_class_stat set_Class_Stat = JsonSerializer.Deserialize<set_class_stat>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\n\t\t\tplayer." + set_Class_Stat.stat + "(DamageClass." + set_Class_Stat.class_name + ") = " + set_Class_Stat.value + ";";
                        isEquipable = true;
                        break;

                    case "set_all_player_bools":
                        set_all_player_bools set_All_Player_Bools = JsonSerializer.Deserialize<set_all_player_bools>(blocksAsStrings[i]);
                        UpdateAccessory += "\r\n\t\t\tplayer." + set_All_Player_Bools.property + " = true;";
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
                        setDefaults += "\r\n\t\t\tItem.shoot = 10;" + "\r\nItem.shootSpeed = " + use_Custom_Projectile.shoot_speed + ";" + "\r\nItem.shoot = ModContent.ProjectileType<Projectiles." + use_Custom_Projectile.projectile + ">();";
                        break;

                    case "equip_slot":
                        equip_slot equip_Slot = JsonSerializer.Deserialize<equip_slot>(blocksAsStrings[i]);
                        slot = equip_Slot.slot;
                        break;

                    case "create_tile":
                        create_tile create_Tile = JsonSerializer.Deserialize<create_tile>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tItem.createTile = TileID." + create_Tile.tileName + ";";
                        break;

                    case "grant_effect":
                        grant_effect grant_Effect = JsonSerializer.Deserialize<grant_effect>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tItem.buffType = BuffID." + grant_Effect.effect + ";";
                        setDefaults += "\r\n\t\t\tItem.buffTime =" + grant_Effect.time * 60 + ";";
                        break;

                    case "hit_effect":
                        hit_effect hit_Effect = JsonSerializer.Deserialize<hit_effect>(blocksAsStrings[i]);
                        onHit += "\r\n\t\t\ttarget.AddBuff(BuffID." + hit_Effect.effect + ", " + hit_Effect.time * 60 + ");";
                        break;

                    case "spawn_enemy":
                        spawn_enemy spawn_Enemy = JsonSerializer.Deserialize<spawn_enemy>(blocksAsStrings[i]);
                        if (vanillaMobs.Contains(spawn_Enemy.enemy_name))
                        {
                            useItem += "\r\n\t\t\tNPC.SpawnOnPlayer(player.whoAmI, NPCID." + spawn_Enemy.enemy_name + ");";
                        }
                        else
                        {
                            useItem += "\r\n\t\t\tNPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs." + spawn_Enemy.enemy_name + ">());";
                        }
                        break;

                    case "max_stack":
                        max_stack max_Stack = JsonSerializer.Deserialize<max_stack>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tItem.maxStack = " + max_Stack.max + ";";
                        break;


                    //Projectile class blocks
                    case "projectile_basic":
                        projectile_basic projectile_Basic = JsonSerializer.Deserialize<projectile_basic>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tProjectile.timeLeft = " + projectile_Basic.time_left * 60 + ";";
                        break;

                    case "use_ai":
                        use_ai use_Ai = JsonSerializer.Deserialize<use_ai>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tProjectile.aiStyle = " + use_Ai.style + ";";
                        break;

                    case "set_value":
                        Set_value set_Value = JsonSerializer.Deserialize<Set_value>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tProjectile." + set_Value.property + " = " + set_Value.value + ";";
                        break;

                    case "declare_friendly":
                        declare_friendly declare_Friendly = JsonSerializer.Deserialize<declare_friendly>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tProjectile.friendly = " + declare_Friendly.friendly.ToString().ToLower() + ";";
                        break;

                    case "declare_hostile":
                        declare_hostile declare_Hostile = JsonSerializer.Deserialize<declare_hostile>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tProjectile.hostile = " + declare_Hostile.hostile.ToString().ToLower() + ";";
                        break;

                    case "hide_projectile":
                        hide_projectile hide_Projectile = JsonSerializer.Deserialize<hide_projectile>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tProjectile.hide = " + hide_Projectile.hide.ToString().ToLower() + ";";
                        break;

                    case "collide_with_tiles":
                        collide_with_tiles collide_With_Tiles = JsonSerializer.Deserialize<collide_with_tiles>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tProjectile.tileCollide = " + collide_With_Tiles.collide.ToString().ToLower() + ";";
                        break;

                    case "emit_light":
                        emit_light emit_Light = JsonSerializer.Deserialize<emit_light>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tProjectile.light = " + emit_Light.light + "f;";
                        break;



                    //NPC Class Blocks
                    case "npc_basic":
                        npc_basic npc_Basic = JsonSerializer.Deserialize<npc_basic>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tNPC.damage = " + npc_Basic.damage + ";";
                        setDefaults += "\r\n\t\t\tNPC.defense = " + npc_Basic.defense + ";";
                        setDefaults += "\r\n\t\t\tNPC.lifeMax = " + npc_Basic.life + ";";
                        setDefaults += "\r\n\t\t\tNPC.knockBackResist = " + npc_Basic.knockResist + ";";
                        break;

                    case "use_npc_ai":
                        use_ai use_Npc_Ai = JsonSerializer.Deserialize<use_ai>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tNPC.aiStyle = " + use_Npc_Ai.style + ";";
                        break;

                    case "chat_option":
                        chat_options chat_Options = JsonSerializer.Deserialize<chat_options>(blocksAsStrings[i]);
                        chatOptions.Add(chat_Options.chat);
                        break;


                    case "name_option":
                        name_options name_Options = JsonSerializer.Deserialize<name_options>(blocksAsStrings[i]);
                        nameOptions.Add(name_Options.name);
                        break;

                    case "set_spawn_rate":
                        set_spawn_rate set_Spawn_Rate = JsonSerializer.Deserialize<set_spawn_rate>(blocksAsStrings[i]);
                        spawnrate += "\r\n\t\t\tspawnChance = " + set_Spawn_Rate.rate + "f;";
                        break;

                    case "set_spawn_condition":
                        set_spawn_condition set_Spawn_Condition = JsonSerializer.Deserialize<set_spawn_condition>(blocksAsStrings[i]);
                        spawnrate += "\r\n\t\t\tspawnChance = SpawnCondition." + set_Spawn_Condition.condition + ".Chance;";
                        break;

                    case "spawn_rate_multiplier":
                        spawn_rate_multiplayer spawn_Rate_Multiplayer = JsonSerializer.Deserialize<spawn_rate_multiplayer>(blocksAsStrings[i]);
                        spawnrate += "\r\n\t\t\tspawnChance *= " + spawn_Rate_Multiplayer.multiplier + "f;";
                        break;

                    case "npc_friendly":
                        npc_friendly npc_Friendly = JsonSerializer.Deserialize<npc_friendly>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tNPC.friendly = " + npc_Friendly.friendly.ToString().ToLower() + ";";
                        break;

                    case "add_shop_item":
                        add_shop_item add_Shop_Item = JsonSerializer.Deserialize<add_shop_item>(blocksAsStrings[i]);
                        shopItems.Add(add_Shop_Item.item);
                        shopValues.Add(add_Shop_Item.value);
                        hasShop = true;
                        break;

                    case "add_loot_drop":
                        add_loot_drop add_Loot_Drop = JsonSerializer.Deserialize<add_loot_drop>(blocksAsStrings[i]);
                        if (vanillaItems.Contains(add_Loot_Drop.item))
                        {
                            NPCloot += "\r\n\t\t\tnpcLoot.Add(new CommonDrop(ItemID." + add_Loot_Drop.item + "," + add_Loot_Drop.numerator + "," + add_Loot_Drop.min + "," + add_Loot_Drop.max + "," + add_Loot_Drop.denominator + "));";
                        }
                        else
                        {
                            //This currently doesn't work - I'm not sure about the referencing.
                            NPCloot += "\r\n\t\t\tnpcLoot.Add(new CommonDrop(ModContent.ItemType<Items." + add_Loot_Drop.item + ">()," + add_Loot_Drop.numerator + "," + add_Loot_Drop.min + "," + add_Loot_Drop.max + "," + add_Loot_Drop.denominator + "));";
                        }
                        break;

                    case "is_boss":
                        is_boss is_Boss = JsonSerializer.Deserialize<is_boss>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tNPC.boss = " + is_Boss.boss.ToString().ToLower() + ";";
                        if (is_Boss.boss)
                        {
                            isBoss = true;
                        }
                        else
                        {
                            isBoss = false;
                        }
                        break;

                    case "set_boss_value":
                        set_boss_value set_Boss_Value = JsonSerializer.Deserialize<set_boss_value>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tNPC.value = " + set_Boss_Value.value + ";";
                        break;

                    case "set_npc_property":
                        set_npc_property set_Npc_Property = JsonSerializer.Deserialize<set_npc_property>(blocksAsStrings[i]);
                        setDefaults += "\r\n\t\t\tNPC." + set_Npc_Property.property + " = true;";
                        break;
                }
            }

            //All these if statements ensure the formatting is correct.
            if (item.get_type() == "Item")
            {
                setDefaults += "\r\n\t\t\tItem.width = " + item.get_sprite().Width + ";";
                setDefaults += "\r\n\t\t\tItem.height = " + item.get_sprite().Height + ";";
            }
            if (item.get_type() == "NPC")
            {
                setDefaults += "\r\n\t\t\tNPC.width = " + item.get_sprite().Width + ";";
                setDefaults += "\r\n\t\t\tNPC.height = " + item.get_sprite().Height + ";";
            }
            if (item.get_type() == "Projectile")
            {
                setDefaults += "\r\n\t\t\tProjectile.width = " + item.get_sprite().Width + ";";
                setDefaults += "\r\n\t\t\tProjectile.height = " + item.get_sprite().Height + ";";
            }

            if (isBoss)
            {
                generatedCode += "\r\n\t[AutoloadBossHead]";
            }

            if (slot != null)
            {
                generatedCode += "\r\n\t[AutoloadEquip(EquipType." + slot + ")]";
            }

            if (itemType == "Item")
            {
                generatedCode +=
                    "\r\n\tpublic class " + item.get_name() + " : ModItem" +
                    "\r\n\t{";
            }
            else if (itemType == "Projectile")
            {
                generatedCode +=
                    "\r\n\tpublic class " + item.get_name() + " : ModProjectile" +
                    "\r\n\t{";
            }
            else if (itemType == "NPC")
            {
                generatedCode +=
                    "\r\n\tpublic class " + item.get_name() + " : ModNPC" +
                    "\r\n\t{";
            }
            else if (itemType == "Tile")
            {
                generatedCode +=
                    "\r\n\tpublic class " + item.get_name() + " : ModTile" +
                    "\r\n\t{";
            }

            if (isEquipable)
            {
                setDefaults += "\r\n\t\t\tItem.accessory = true;";
            }

            if (isWing)
            {
                if (canHover)
                {
                    SetStaticDefaults = "\r\n\t\t\tArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(" + (int)wingStats[0] + ", " + wingStats[1] + "f, " + wingStats[2] + "f, true, " + wingStats[3] + "f, " + wingStats[4] + "f);";
                }
                else
                {
                    SetStaticDefaults = "\r\n\t\t\tArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(" + (int)wingStats[0] + "," + wingStats[1] + "f," + wingStats[2] + "f);";
                }
                generatedCode += "\r\n\t\tpublic override void SetStaticDefaults()\r\n\t\t{\r\n" + SetStaticDefaults + "\r\n\t\t}";
            }

            verticalWingsSpeeds = "\r\n\t\tpublic override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising," +
                "\r\n\t\tref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)" +
                "\r\n\t\t{" +
                "\r\n\t\tascentWhenFalling = 0.85f;" +
                "\r\n\t\tascentWhenRising = 0.15f;" +
                "\r\n\t\tmaxCanAscendMultiplier = 1f;" +
                "\r\n\t\tmaxAscentMultiplier = 3f;" +
                "\r\n\t\tconstantAscend = 0.135f;" +
                "\r\n\t\t}";

            if (isWing)
            {
                generatedCode += verticalWingsSpeeds;
            }

            if (chatOptions.Count > 0)
            {
                generatedCode += "\r\n\t\tpublic override string GetChat() {";
                generatedCode += "\r\n\t\t\tRandom rand = new Random();";
                generatedCode += "\r\n\t\t\tint result = rand.Next(" + chatOptions.Count + ");";
                for (int i = 0; i < chatOptions.Count; i++)
                {
                    generatedCode += "\r\n\t\t\tif (result == " + i + ") { return \"" + chatOptions[i] + "\"; }";
                }
                generatedCode += "\r\n\t\t\telse { return \"oh no\"; }";
                generatedCode += "\r\n\t\t}";
                setDefaults += "\r\n\t\t\tNPC.townNPC = true;";
            }

            if (hasShop)
            {
                generatedCode += "\r\n\t\tpublic override void SetChatButtons(ref string button, ref string button2) {";
                generatedCode += "\r\n\t\t\tbutton = \"Shop\";";
                generatedCode += "\r\n\t\t}";
                setDefaults += "\r\n\t\t\tNPC.townNPC = true;";
            }

            if (spawnrate != "")
            {
                generatedCode += "\r\n\t\tpublic override float SpawnChance(NPCSpawnInfo spawnInfo)";
                generatedCode += "\r\n\t\t{\r\n\t\t\tfloat spawnChance;";
                generatedCode += spawnrate;
                generatedCode += "\r\n\t\t\treturn spawnChance;\r\n\t\t}";
            }

            //The generated methods are compiled into one string here.
            generatedCode += "\r\n\t\tpublic override void SetDefaults()\r\n\t\t{\r\n" + setDefaults + "\r\n\t\t}";
            if (isEquipable)
            {
                generatedCode += "\r\n\t\tpublic override void UpdateAccessory(Player player, bool hideVisual)\r\n\t\t{\r\n" + UpdateAccessory + "\r\n\t\t}";
            }

            string[] stations = File.ReadAllLines(Environment.CurrentDirectory + "\\tileIDs.txt");
            //The recipes are added here.
            if (itemType == "Item")
            {
                generatedCode += "\r\n\t\tpublic override void AddRecipes() \r\n\t\t{" +
                    "\r\n\t\t\tRecipe recipe = CreateRecipe();";
                for (int i = 0; i < item.get_ingredients().Length; i++)
                {
                    generatedCode += "\r\n\t\t\trecipe.AddIngredient(ItemID." + item.get_ingredients()[i].itemName + "," + item.get_ingredients()[i].quantity + ");";
                }
                if (item.get_craftingStationID() != 0)
                {
                    generatedCode += "\r\n\t\t\trecipe.AddTile(TileID." + stations[item.get_craftingStationID()] + ");";

                }
                generatedCode += "\r\n\t\t\trecipe.Register();";
                generatedCode += "\r\n\t\t}";
            }

            if (AI != "")
            {
                generatedCode += "public void AI\r\n{";

                if (chasePlayer)
                {
                    generatedCode += "\r\nnpc.TargetClosest(true);";
                    generatedCode += "\r\nVector2 targetPosition = Main.player[npc.target].position;";
                }

                generatedCode += AI;

                generatedCode += "\r\n}";
            }

            if (shopItems.Count > 0)
            {
                generatedCode += "\r\n\t\tpublic override void OnChatButtonClicked(bool firstButton, ref string shop)";
                generatedCode += "\r\n\t\t{";
                generatedCode += "\r\n\t\t\tif (firstButton) { shop = \"Shop\"; }";
                generatedCode += "\r\n\t\t}";

                generatedCode += "\r\n";

                generatedCode += "\r\n\t\tpublic override void AddShops()";
                generatedCode += "\r\n\t\t{";

                generatedCode += "\r\n\t\t\tNPCShop Shop = new NPCShop(Type);";

                for (int i = 0;i < shopItems.Count; i++)
                {
                    if (vanillaItems.Contains(shopItems[i]))
                    {
                        generatedCode += "\r\n\t\t\tShop.Add(ItemID." + shopItems[i] + ");";
                    }
                    else
                    {
                        generatedCode += "\r\n\t\t\tShop.Add(ModContent.ItemType<Items." + shopItems[i] + ">());";
                    }
                }

                generatedCode += "\r\n\t\t\tShop.Register();";

                generatedCode += "\r\n\t\t}";
            }

            if (NPCloot != "")
            {
                generatedCode += "\r\n\t\tpublic override void ModifyNPCLoot(NPCLoot npcLoot)";
                generatedCode += "\r\n\t\t{";
                generatedCode += NPCloot;
                generatedCode += "\r\n\t\t}";
            }

            if (onHit != "")
            {
                generatedCode += "\r\n\t\tpublic override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)";
                generatedCode += "\r\n\t\t{";
                generatedCode += onHit;
                generatedCode += "\r\n\t\t}";
            }

            if (useItem != "")
            {
                generatedCode += "\r\n\t\tpublic override bool? UseItem(Player player)";
                generatedCode += "\r\n\t\t{";
                generatedCode += useItem;
                generatedCode += useItemReturn;
                generatedCode += "\r\n\t\t}";
            }

            generatedCode += "\r\n\t}\r\n}";
            
            return generatedCode;
        }

        private static string[] findBlocksInline(string contents)
        {
            List<string> blocksList = new List<string>();

            string reader = "";
            bool reading = false;
            int count = 0;

            //An ID can contain '}', which causes the program to misidentify blocks, so they must be removed.
            while (contents.Contains("\"id\""))
            {
                contents = contents.Remove(contents.IndexOf("\"id\""), 28);
            }

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

                //still doesnt work
                if (reader.Contains("}") && reading)
                { 
                    blocksList[count] += reader;
                    reading = false;
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
                }
            }

            string[] blocks = blocksList.ToArray();

            return blocks;
        }
    }
}