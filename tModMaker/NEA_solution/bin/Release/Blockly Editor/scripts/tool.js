let workspace = null;

function sendDataToWinForm() {
    const state = JSON.stringify(Blockly.serialization.workspaces.save(workspace));
    window.chrome.webview.postMessage(state);
}

function sendTranslatedCode() {
    const code = 'public override void SetDefaults() {' + JSON.stringify(Blockly.JavaScript.workspaceToCode(workspace)).slice(0, -1).slice(1);
    window.chrome.webview.postMessage(code);

}

function redo() {
    workspace.redo();
}

function clear() {
    workspace.clear();
}

function clear() {
    workspace.clear();
}

function loadData(theData) {
    var json = null;
    json = JSON.parse(theData);
    try {
        Blockly.serialization.workspaces.load(json, workspace);
    }
    catch { }
}

const toolbox = {
    "kind": "categoryToolbox",
    "contents": [
        {
            "kind": "category",
            "name": "Basic",
            "colour": 230,
            "contents": [
                {
                    "kind": "block",
                    "type": "define_item"
                },
                {
                    "kind": "block",
                    "type": "define_tool"
                },
                {
                    "kind": "block",
                    "type": "define_weapon_essential"
                },
                {
                    "kind": "block",
                    "type": "max_stack"
                }
            ]
        },
        {
            "kind": "category",
            "name": "Tool",
            "colour": 60,
            "contents": [
                {
                    "kind": "block",
                    "type": "tool_power"
                },
            ]
        },
        {
            "kind": "category",
            "name": "Projectile",
            "colour": 360,
            "contents": [
                {
                    "kind": "block",
                    "type": "shoot_existing_ammo"
                },
                {
                    "kind": "block",
                    "type": "use_custom_projectile"
                }
            ]
        },
        {
            "kind": "category",
            "name": "Other",
            "colour": 120,
            "contents": [
                {
                    "kind": "block",
                    "type": "use_mana"
                },
                {
                    "kind": "block",
                    "type": "is_consumable"
                },
                {
                    "kind": "block",
                    "type": "no_melee"
                },
                {
                    "kind": "block",
                    "type": "hit_effect"
                }
            ]
        },
        {
            "kind": "category",
            "name": "Buffs",
            "colour": 330,
            "contents": [
                {
                    "kind": "block",
                    "type": "grant_ability"
                },
                {
                    "kind": "block",
                    "type": "change_class_stat"
                },
                {
                    "kind": "block",
                    "type": "set_class_stat"
                },
                {
                    "kind": "block",
                    "type": "change_player_stat"
                },
                {
                    "kind": "block",
                    "type": "set_player_stat"
                },
                {
                    "kind": "block",
                    "type": "create_wings"
                },
                {
                    "kind": "block",
                    "type": "wing_hover"
                },
                {
                    "kind": "block",
                    "type": "grant_effect"
                }
            ]
        },
        {
            "kind": "category",
            "name": "Clothes",
            "colour": 165,
            "contents": [
                {
                    "kind": "block",
                    "type": "equip_slot"
                }
            ]
        },
        {
            "kind": "category",
            "name": "Blocks",
            "colour": 360,
            "contents": [
                {
                    "kind": "block",
                    "type": "create_tile"
                }
            ]
        },
        {
            "kind": "category",
            "name": "Summoning",
            "colour": 80,
            "contents": [
                {
                    "kind": "block",
                    "type": "spawn_enemy"
                }
            ]
        }
    ]
};

Blockly.common.defineBlocksWithJsonArray([
    {
        "type": "define_weapon_essential",
        "message0": "Deal %1 damage %2 Deal %3 damage %4 Deal %5 knockback %6 Have a %7 % chance of a critical hit",
        "args0": [
            {
                "type": "field_number",
                "name": "damage",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_dropdown",
                "name": "damageType",
                "options": [
                    [
                        "melee",
                        "Melee"
                    ],
                    [
                        "ranged",
                        "Ranged"
                    ],
                    [
                        "magic",
                        "Magic"
                    ],
                    [
                        "summon",
                        "Summon"
                    ],
                    [
                        "generic",
                        "Generic"
                    ]
                ]
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "knockback",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "crit",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "Defines a basic weapon",
        "helpUrl": ""
    },
    {
        "type": "define_tool",
        "message0": "Take %1 ticks to use %2 Use %3 animation when used %4 Use sound ID %5 %6 Automatically reuse %7",
        "args0": [
            {
                "type": "field_number",
                "name": "useTime",
                "value": 1,
                "precision": 1,
                "min": 1,
                "max": 2147483646
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_dropdown",
                "name": "useStyle",
                "options": [
                    [
                        "null (item is unusable)",
                        "0"
                    ],
                    [
                        "swinging",
                        "1"
                    ],
                    [
                        "drinking",
                        "2"
                    ],
                    [
                        "thrusting",
                        "3"
                    ],
                    [
                        "holding up",
                        "4"
                    ],
                    [
                        "shooting",
                        "5"
                    ],
                    [
                        "long drinking",
                        "6"
                    ],
                    [
                        "eating",
                        "7"
                    ],
                    [
                        "golf swinging",
                        "8"
                    ],
                    [
                        "drinking liquid",
                        "9"
                    ],
                    [
                        "hidden",
                        "10"
                    ],
                    [
                        "mowing the lawn",
                        "11"
                    ],
                    [
                        "guitar",
                        "12"
                    ],
                    [
                        "stabbing",
                        "13"
                    ],
                    [
                        "raising",
                        "14"
                    ]
                ]
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "UseSound",
                "value": 1,
                "min": 1,
                "max": 172,
                "precision": 1
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_checkbox",
                "name": "autoReuse",
                "checked": true
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "Defines how a weapon is used",
        "helpUrl": "https://terraria.fandom.com/wiki/Sound_IDs"
    },
    {
        "type": "define_item",
        "message0": "Set value to %1 copper %2 Have %3 rarity",
        "args0": [
            {
                "type": "field_number",
                "name": "value",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_dropdown",
                "name": "rare",
                "options": [
                    [
                        "Grey",
                        "-1"
                    ],
                    [
                        "White",
                        "0"
                    ],
                    [
                        "Blue",
                        "1"
                    ],
                    [
                        "Green",
                        "2"
                    ],
                    [
                        "Orange",
                        "3"
                    ],
                    [
                        "Light Red",
                        "4"
                    ],
                    [
                        "Pink",
                        "5"
                    ],
                    [
                        "Light Purple",
                        "6"
                    ],
                    [
                        "Lime",
                        "7"
                    ],
                    [
                        "Yellow",
                        "8"
                    ],
                    [
                        "Cyan",
                        "9"
                    ],
                    [
                        "Red",
                        "10"
                    ],
                    [
                        "Purple",
                        "11"
                    ],
                    [
                        "Rainbow",
                        "-12"
                    ],
                    [
                        "Fiery Red",
                        "-13"
                    ],
                    [
                        "Amber",
                        "-11"
                    ]
                ]
            }
        ],
        "nextStatement": null,
        "colour": 230,
        "tooltip": "Defines a basic item",
        "helpUrl": "no"
    },
    {
        "type": "tool_power",
        "message0": "Set %2 power to %1",
        "args0": [
            {
                "type": "field_number",
                "name": "power",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            },
            {
                "type": "field_dropdown",
                "name": "tool_type",
                "options": [
                    [
                        "pickaxe",
                        "pick"
                    ],
                    [
                        "axe",
                        "axe"
                    ],
                    [
                        "hammer",
                        "hammer"
                    ],
                    [
                        "fishing",
                        "fishing"
                    ],
                ]
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 60,
        "tooltip": "Defines the item's power as a tool",
        "helpUrl": ""
    },
    {
        "type": "use_mana",
        "message0": "Consume %1 mana per use",
        "args0": [
            {
                "type": "field_number",
                "name": "useMana",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 120,
        "tooltip": "Defines if an item uses mana",
        "helpUrl": ""
    },
    {
        "type": "no_melee",
        "message0": "Deal contact damage %1",
        "args0": [
            {
                "type": "field_checkbox",
                "name": "melee",
                "checked": true
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 120,
        "tooltip": "Defines if an item deals melee damage",
        "helpUrl": ""
    },
    {
        "type": "shoot_existing_ammo",
        "message0": "Fire %1 with %2 velocity",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "ammo_type",
                "options": [
                    [
                        "bullets",
                        "Bullet"
                    ],
                    [
                        "arrows",
                        "Arrow"
                    ],
                    [
                        "rockets",
                        "Rocket"
                    ],
                    [
                        "darts",
                        "Dart"
                    ]
                ]
            },
            {
                "type": "field_number",
                "name": "shoot_speed",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 0,
        "tooltip": "Allows the item to fire an existing ammo type",
        "helpUrl": ""
    },
    {
        "type": "change_class_stat",
        "message0": "Increase %1 for %2 by %3",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "stat",
                "options": [
                    [
                        "Crit Chance",
                        "GetCritChance"
                    ],
                    [
                        "Damage",
                        "GetDamage"
                    ],
                    [
                        "Attack Speed",
                        "GetAttackSpeed"
                    ],
                    [
                        "Armor Penetration",
                        "GetArmorPenetration"
                    ],
                    [
                        "Knockback",
                        "GetKnockback"
                    ]
                ]
            },
            {
                "type": "field_dropdown",
                "name": "class_name",
                "options": [
                    [
                        "Melee",
                        "Melee"
                    ],
                    [
                        "Ranged",
                        "Ranged"
                    ],
                    [
                        "Magic",
                        "Magic"
                    ],
                    [
                        "Summon",
                        "Summon"
                    ],
                    [
                        "Generic",
                        "Generic"
                    ]
                ]
            },
            {
                "type": "field_number",
                "name": "value",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 330,
        "tooltip": "Increases a specific class' stat by the given value",
        "helpUrl": ""
    },
    {
        "type": "set_class_stat",
        "message0": "Set %1 for %2 to %3",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "stat",
                "options": [
                    [
                        "Crit Chance",
                        "GetCritChance"
                    ],
                    [
                        "Damage",
                        "GetDamage"
                    ],
                    [
                        "Attack Speed",
                        "GetAttackSpeed"
                    ],
                    [
                        "Armor Penetration",
                        "GetArmorPenetration"
                    ],
                    [
                        "Knockback",
                        "GetKnockback"
                    ]
                ]
            },
            {
                "type": "field_dropdown",
                "name": "class_name",
                "options": [
                    [
                        "Melee",
                        "Melee"
                    ],
                    [
                        "Ranged",
                        "Ranged"
                    ],
                    [
                        "Magic",
                        "Magic"
                    ],
                    [
                        "Summon",
                        "Summon"
                    ],
                    [
                        "Generic",
                        "Generic"
                    ]
                ]
            },
            {
                "type": "field_number",
                "name": "value",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 330,
        "tooltip": "Sets a specific class' stat to the given value",
        "helpUrl": ""
    },
    {
        "type": "grant_ability",
        "message0": "Grant player %1",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "ability",
                "options": [
                    [
                        "damage immunity",
                        "immune"
                    ],
                    [
                        "gravity control",
                        "gravControl"
                    ],
                    [
                        "fire block immunity",
                        "fireWalk"
                    ],
                    [
                        "fall damage immunity",
                        "noFallDmg"
                    ],
                    [
                        "jump boost",
                        "jumpBoost"
                    ],
                    [
                        "knockback immunity",
                        "noKnockback"
                    ],
                    [
                        "water walking",
                        "waterWalk"
                    ],
                    [
                        "thorns",
                        "thorns"
                    ],
                    [
                        "lava immunity",
                        "lavaImmune"
                    ],
                    [
                        "invisibility",
                        "invis"
                    ],
                    [
                        "reduced potion sickness",
                        "pStone"
                    ],
                    [
                        "increased invincibility duration",
                        "longInvince"
                    ]
                ]
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 330,
        "tooltip": "Grant the player various abilities",
        "helpUrl": ""
    },
    {
        "type": "change_player_stat",
        "message0": "Increase %1 by %2",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "stat",
                "options": [
                    [
                        "defence",
                        "statDefense"
                    ],
                    [
                        "maximum life",
                        "statLifeMax2"
                    ],
                    [
                        "movement speed",
                        "moveSpeed"
                    ],
                    [
                        "mana costs",
                        "manaCost"
                    ],
                    [
                        "maximum mana",
                        "statManaMax2"
                    ],
                    [
                        "mining time",
                        "pickSpeed"
                    ],
                    [
                        "rocket boot flight time",
                        "rocketTime"
                    ],
                    [
                        "wing flight time",
                        "wingTime"
                    ],
                    [
                        "immunity time",
                        "immuneTime"
                    ]
                ]
            },
            {
                "type": "field_number",
                "name": "value",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 330,
        "tooltip": "Change various stats for the player",
        "helpUrl": ""
    },
    {
        "type": "set_player_stat",
        "message0": "Set %1 to %2",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "stat",
                "options": [
                    [
                        "maximum life",
                        "statLifeMax2"
                    ],
                    [
                        "movement speed",
                        "moveSpeed"
                    ],
                    [
                        "mana costs",
                        "manaCost"
                    ],
                    [
                        "maximum mana",
                        "statManaMax2"
                    ],
                    [
                        "mining time",
                        "pickSpeed"
                    ],
                    [
                        "rocket boot flight time",
                        "rocketTime"
                    ],
                    [
                        "wing flight time",
                        "wingTime"
                    ],
                    [
                        "immunity time",
                        "immuneTime"
                    ]
                ]
            },
            {
                "type": "field_number",
                "name": "value",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 330,
        "tooltip": "Sets various stats for the player",
        "helpUrl": ""
    },
    {
        "type": "is_consumable",
        "message0": "Consume on use %1",
        "args0": [
            {
                "type": "field_checkbox",
                "name": "consumable",
                "checked": true
            }],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 120,
        "tooltip": "Defines if an item is consumed on use",
        "helpUrl": ""
    },
    {
        "type": "create_wings",
        "message0": "Create wings with flight time %1 %2 flight speed %3 , %4 and acceleration %5",
        "args0": [
            {
                "type": "field_number",
                "name": "flight_time",
                "value": 180,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "flight_speed",
                "value": 9,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "acceleration",
                "value": 2.5,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 330,
        "tooltip": "Sets the flight properties of the item when equipped",
        "helpUrl": ""
    },
    {
        "type": "wing_hover",
        "message0": "Allow player to hover with hover speed %1 %2 and hover acceleration %3",
        "args0": [
            {
                "type": "field_number",
                "name": "hover_speed",
                "value": 9,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "acceleration",
                "value": 2.5,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 330,
        "tooltip": "Allows the player to hover",
        "helpUrl": ""
    },
    {
        "type": "use_custom_projectile",
        "message0": "Fire custom projectile called %1 with %2 velocity",
        "args0": [
            {
                "type": "field_input",
                "name": "projectile",
                "text": "projectile name"
            },
            {
                "type": "field_number",
                "name": "shoot_speed",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 0,
        "tooltip": "Uses a custom projectile created by the user",
        "helpUrl": ""
    },
    {
        "type": "equip_slot",
        "message0": "Equip to %1",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "slot",
                "options": [
                    [
                        "head",
                        "Head"
                    ],
                    [
                        "body",
                        "Body"
                    ],
                    [
                        "legs",
                        "Legs"
                    ]
                ]
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 165,
        "tooltip": "Makes the item display on the corresponding slot on the body",
        "helpUrl": ""
    },
    {
        "type": "create_tile",
        "message0": "Create tile called %1",
        "args0": [
            {
                "type": "field_input",
                "name": "tileName",
                "text": "tile name"
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 360,
        "tooltip": "Places an existing tile",
        "helpUrl": "https://terraria.wiki.gg/wiki/Tile_IDs/Part1"
    },
    {
        "type": "grant_effect",
        "message0": "Grant player %1 effect for %2 seconds",
        "args0": [
            {
                "type": "field_input",
                "name": "effect",
                "text": "buff"
            },
            {
                "type": "field_number",
                "name": "time",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 330,
        "tooltip": "Grants the player a status effect",
        "helpUrl": "https://terraria.wiki.gg/wiki/Buff_IDs"
    },
    {
        "type": "hit_effect",
        "message0": "Inflict %1 effect on hit for %2 seconds",
        "args0": [
            {
                "type": "field_input",
                "name": "effect",
                "text": "buff"
            },
            {
                "type": "field_number",
                "name": "time",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 120,
        "tooltip": "Inflicts a buff or debuff on hit",
        "helpUrl": "https://terraria.wiki.gg/wiki/Buff_IDs"
    },
    {
        "type": "spawn_enemy",
        "message0": "Spawn %1 on player",
        "args0": [
            {
                "type": "field_input",
                "name": "enemy_name",
                "text": "enemy name"
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 80,
        "tooltip": "Spawns an enemy when used",
        "helpUrl": "https://terraria.wiki.gg/wiki/Data_IDs"
    },
    {
        "type": "max_stack",
        "message0": "Set maximum stack size to %1",
        "args0": [
            {
                "type": "field_number",
                "name": "max",
                "value": 0,
                "precision": 1,
                "min": 1,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "Sets the number of items that will fit in one inventory slot",
        "helpUrl": ""
    }
]);

workspace = Blockly.inject('blocklyDiv', {
    toolbox: toolbox,
    scrollbars: true,
    horizontalLayout: false,
    toolboxPosition: "left",
});