﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_solution
{
    //These are definitions of blocks that can have data deserialised into them.
    internal class GenericBlock
    {
        public string type { get; set; }
    }

    internal class define_item : GenericBlock
    {
        public int width { get; set; }
        public int height { get; set; }
        public int value { get; set; }
        public string rare { get; set; }
    }

    internal class define_weapon_essential : GenericBlock 
    {
        public int damage { get; set; }
        public string damageType { get; set; }
        public int knockback { get; set; }
        public int crit { get; set; }
    }

    internal class define_tool : GenericBlock
    {
        public int useTime { get; set; }
        public string useStyle { get; set; }
        public int UseSound { get; set; }
        public bool autoReuse { get; set; }
    }

    internal class tool_power : GenericBlock
    {
        public string tool_type { get; set; }
        public int power { get; set; }
    }

    internal class shoot_existing_ammo : GenericBlock
    {
        public string ammo_type { get; set; }
        public int shoot_speed { get; set; }
    }

    internal class change_class_stat : GenericBlock
    {
        public string stat { get; set; }
        public string class_name { get; set; }
        public int value { get; set; }
    }

    internal class use_mana : GenericBlock
    {
        public int useMana { get; set; }
    }

    internal class increase_life : GenericBlock
    {
        public int life { get; set; }
    }

    internal class increase_move_speed : GenericBlock
    {
        public float value { get; set; }
    }

    internal class grant_ability : GenericBlock
    {
        public string ability { get; set; }
    }

    internal class change_player_stat : GenericBlock
    {
        public string stat { get; set; }
        public int value { get; set; }
    }

    internal class set_player_stat : GenericBlock
    {
        public string stat { get; set; }
        public int value { get; set; }
    }

    internal class set_class_stat : GenericBlock
    {
        public string stat { get; set; }
        public string class_name { get; set; }
        public int value { get; set; }
    }

    internal class set_all_player_bools : GenericBlock
    {
        public string property { get; set; }
    }

    internal class create_wings : GenericBlock
    {
        public float flight_time { get; set; }
        public float flight_speed { get; set; }
        public float acceleration { get; set; }
    }

    internal class wing_hover : GenericBlock
    {
        public float hover_speed { get; set; }
        public float acceleration { get; set;}
    }

    internal class use_custom_projectile : GenericBlock
    {
        public string projectile { get; set; }
        public int shoot_speed { get; set; }

    }

    internal class projectile_basic : GenericBlock
    {
        public int width { get; set; }
        public int height { get; set; }
        public int time_left { get; set; }
    }

    internal class use_ai : GenericBlock
    {
        public string style { get; set; }
    }

    internal class Set_value : GenericBlock
    {
        public string property { get; set; }
        public int value { get; set; }
    }

    internal class declare_friendly : GenericBlock
    {
        public bool friendly { get; set; }
    }

    internal class declare_hostile : GenericBlock
    {
        public bool hostile { get; set; }
    }

    internal class no_melee : GenericBlock
    {
        public bool melee { get; set; }
    }

    internal class is_consumable : GenericBlock
    {
        public bool consumable { get; set; }
    }

    internal class hide_projectile : GenericBlock
    {
        public bool hide { get; set; }
    }

    internal class collide_with_tiles : GenericBlock
    {
        public bool collide { get; set; }
    }

    internal class ignore_water : GenericBlock
    {
        public bool ignore { get; set; }
    }

    internal class emit_light : GenericBlock
    {
        public int light { get; set; }
    }

    internal class equip_slot : GenericBlock
    {
        public string slot { get; set;}
    }

    internal class npc_basic : GenericBlock
    {
        public int width { get; set; }
        public int height { get; set; }
        public int damage { get; set; }
        public int defense { get; set;}
        public int life { get; set; }
        public float knockResist { get; set; }
    }
    
    internal class chat_options : GenericBlock
    {
        public string chat { get; set; }
    }

    internal class name_options : GenericBlock
    {
        public string name { get; set; }
    }

    internal class add_buttons : GenericBlock
    {
        public string button1 { get; set; }
        public string button2 { get; set; }
    }

    internal class use_custom_ai : GenericBlock
    {
        public string aiName { get; set; }
    }
    
    //AI Blocks
    internal class chase_player_X : GenericBlock
    {
        public int xVelocity { get; set; }
        public float xAcceleration { get; set; }
    }

    internal class chase_player_Y : GenericBlock
    {
        public int yVelocity { get; set; }
        public float yAcceleration { get; set; }
        public int distance { get; set; }
    }

    internal class set_spawn_rate: GenericBlock
    {
        public float rate { get; set; }
    }

    internal class set_spawn_condition : GenericBlock
    {
        public string condition { get; set; }
        public float multiplier { get; set; }

    }

    internal class create_tile : GenericBlock
    {
        public string tileName { get; set; }
    }

    internal class tile_default : GenericBlock
    {
        public bool solid { get; set; }
        public bool merge { get; set; }
        public bool block_light { get; set; }
        public string dust_type { get; set; }
    }

    internal class npc_friendly : GenericBlock
    {
        public bool friendly { get; set; }
    }

    internal class add_shop_item : GenericBlock
    {
        public string item { get; set; }
        public int value { get; set; }
    }

    internal class grant_effect : GenericBlock
    {
        public string effect { get; set; }
        public int time { get; set; }
    }

    internal class add_loot_drop : GenericBlock
    {
        public int min { get; set; }
        public int max { get; set; }
        public string item { get; set; }
        public string amount { get; set; }
        public int numerator { get; set; }
        public int denominator { get; set; }
    }

    internal class hit_effect : GenericBlock
    {
        public string effect { get; set; }
        public int time { get; set; }
    }

    internal class spawn_enemy : GenericBlock
    {
        public string enemy_name { get; set; }
    }

    internal class is_boss : GenericBlock
    {
        public bool boss { get; set; }
    }

    internal class max_stack : GenericBlock
    {
        public int max { get; set; }
    }

    internal class set_boss_value : GenericBlock
    {
        public int value { get; set; }
    }

    internal class set_npc_property : GenericBlock
    {
        public string property { get; set; }
    }

    internal class define_tile : GenericBlock
    {
        public bool solid { get; set; }
        public bool mergeDirt { get; set; }
        public bool blockLight { get; set; }
        public string colour { get; set; }
    }

    internal class min_pickaxe : GenericBlock
    {
        public int power { get; set; }
    }

    internal class mine_resist : GenericBlock
    {
        public int resist { get; set; }
    }

    internal class set_flavour_text : GenericBlock
    {
        public string text { get; set; }
    }
    internal class drop_potion : GenericBlock
    {
        public string potion { get; set; }
    }

    internal class have_solid_top : GenericBlock
    {
        public bool solid { get; set; }
    }

    internal class frame_important : GenericBlock
    {
        public bool connect { get; set; }
    }
}
