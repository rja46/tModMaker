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
        public int useTime { get; set; }
        public int useAnimation { get; set; }
        public string useStyle { get; set; }
        public int knockback { get; set; }
        public int crit { get; set; }
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
        public int flight_time { get; set; }
        public int flight_speed { get; set; }
        public int acceleration { get; set; }
    }
}
