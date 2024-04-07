let workspace = null;

function sendDataToWinForm() {
    const state = JSON.stringify(Blockly.serialization.workspaces.save(workspace));
    window.chrome.webview.postMessage(state);
}

function sendTranslatedCode() {
    const code = 'public override void SetDefaults() {' + JSON.stringify(Blockly.JavaScript.workspaceToCode(workspace)).slice(0, -1).slice(1);
    window.chrome.webview.postMessage(code);

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
    kind: 'categoryToolbox',
    contents: [
        {
            "kind": "category",
            "name": "Basic",
            "colour": 300,
            "contents": [
                {
                    "kind": "block",
                    "type": "npc_basic"
                },
                {
                    "kind": "block",
                    "type": "use_npc_ai"
                },
                {
                    "kind": "block",
                    "type": "set_spawn_rate"
                },
                {
                    "kind": "block",
                    "type": "set_spawn_condition"
                },
                {
                    "kind": "block",
                    "type": "spawn_rate_multiplier"
                },
                {
                    "kind": "block",
                    "type": "add_loot_drop"
                },
                {
                    "kind": "block",
                    "type": "set_npc_property"
                }
            ]
        },
        {
            "kind": "category",
            "name": "Friendly",
            "colour": 250,
            "contents": [
                {
                    "kind": "block",
                    "type": "chat_option"
                },
                {
                    "kind": "block",
                    "type": "npc_friendly"
                },
                {
                    "kind": "block",
                    "type": "add_shop_item"
                }
            ]
        },
        {
            "kind": "category",
            "name": "Enemy",
            "colour": 170,
            "contents": [
                {
                    "kind": "block",
                    "type": "is_boss"
                },
                {
                    "kind": "block",
                    "type": "set_boss_value"
                }
            ]
        }
    ]
}

Blockly.common.defineBlocksWithJsonArray([
    {
        "type": "npc_basic",
        "message0": "Deal %1 damage on hit %2 Set defence to %3 %4 Set maximum life to %5 %6 Take %7 knockback",
        "args0": [
            {
                "type": "field_number",
                "name": "damage",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483647
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "defense",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483647
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "life",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483647
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "knockResist",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483647
            }
        ],
        "nextStatement": null,
        "colour": 300,
        "tooltip": "Sets the basic properties of an NPC",
        "helpUrl": ""
    },
    {
        "type": "use_npc_ai",
        "message0": "Use %1 AI style",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "style",
                "options": [
                    [
                        "Null",
                        "0"
                    ],
                    [
                        "Slime",
                        "1"
                    ],
                    [
                        "Simple Flier",
                        "2"
                    ],
                    [
                        "Simple Fighter",
                        "3"
                    ],
                    [
                        "Eye of Cthulhu",
                        "4"
                    ],
                    [
                        "Aggressive Flier",
                        "5"
                    ],
                    [
                        "Burrower",
                        "6"
                    ],
                    [
                        "Friendly NPC",
                        "7"
                    ],
                    [
                        "Teleporting Spellcaster",
                        "8"
                    ],
                    [
                        "Magical Projectiles",
                        "9"
                    ],
                    [
                        "Hesitant Flier",
                        "10"
                    ],
                    [
                        "Flying Skull",
                        "11"
                    ],
                    [
                        "Flying Arms",
                        "12"
                    ],
                    [
                        "Carnivorous Plant",
                        "13"
                    ],
                    [
                        "General Flier",
                        "14"
                    ],
                    [
                        "King Slime",
                        "15"
                    ],
                    [
                        "Fish",
                        "16"
                    ],
                    [
                        "Vulture",
                        "17"
                    ],
                    [
                        "Jellyfish",
                        "18"
                    ],
                    [
                        "Antlion",
                        "19"
                    ],
                    [
                        "Spike Ball",
                        "20"
                    ],
                    [
                        "Blazing Wheel",
                        "21"
                    ],
                    [
                        "Hovering Fliers",
                        "22"
                    ],
                    [
                        "Animated Weapons",
                        "23"
                    ],
                    [
                        "Birds",
                        "24"
                    ],
                    [
                        "Mimic",
                        "25"
                    ],
                    [
                        "Unicorn",
                        "26"
                    ],
                    [
                        "Wall of Flesh (Mouth)",
                        "27"
                    ],
                    [
                        "Wall of Flesh (Eye)",
                        "28"
                    ],
                    [
                        "The Hungry",
                        "29"
                    ],
                    [
                        "Retinazer",
                        "30"
                    ],
                    [
                        "Spazmatism",
                        "31"
                    ],
                    [
                        "Skeletron Prime (Head)",
                        "32"
                    ],
                    [
                        "Skeletron Prime (Saw)",
                        "33"
                    ],
                    [
                        "Skeletron Prime (Vice)",
                        "34"
                    ],
                    [
                        "Skeletron Prime (Cannon)",
                        "35"
                    ],
                    [
                        "Skeletron Prime (Laser)",
                        "36"
                    ],
                    [
                        "Destroyer",
                        "37"
                    ],
                    [
                        "Snowman",
                        "38"
                    ],

                ]
            }
        ],
        "nextStatement": null,
        "previousStatement": null,
        "colour": 300,
        "tooltip": "Defines the way in which the NPC moves",
        "helpUrl": ""
    },
    {
        "type": "chat_option",
        "message0": "Add chat option: %1",
        "args0": [
            {
                "type": "field_input",
                "name": "chat",
                "text": "Hello World!"
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 250,
        "tooltip": "Adds a phrase to the list of things the NPC can say",
        "helpUrl": ""
    },
    {
        "type": "fire_projectile",
        "message0": "Fire projectile called %1",
        "args0": [
            {
                "type": "field_input",
                "name": "projectile",
                "text": "default"
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "set_spawn_rate",
        "message0": "Set spawn rate to %1",
        "args0": [
            {
                "type": "field_number",
                "name": "rate",
                "value": 0,
                "min": 0,
                "max": 2147483647
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 300,
        "tooltip": "Sets a flat rate at which the NPC will spawn",
        "helpUrl": ""
    },
    {
        "type": "spawn_rate_multiplier",
        "message0": "Multiply spawn rate by %1",
        "args0": [
            {
                "type": "field_number",
                "name": "multiplier",
                "value": 0,
                "min": 0,
                "max": 2147483647
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 300,
        "tooltip": "Sets a multiplier for the spawn rate",
        "helpUrl": ""
    },
    {
        "type": "set_spawn_condition",
        "message0": "Use %1 spawn condition",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "condition",
                "options": [
                    [
                        "BoundCaveNPC",
                        "BoundCaveNPC"
                    ],
                    [
                        "Cavern",
                        "Cavern"
                    ],
                    [
                        "Corruption",
                        "Corruption"
                    ],
                    [
                        "Crimson",
                        "Crimson"
                    ],
                    [
                        "Default Water Critter",
                        "DefaultWaterCritter"
                    ],
                    [
                        "Desert Cave",
                        "DesertCave"
                    ],
                    [
                        "Dungeon",
                        "Dungeon"
                    ],
                    [
                        "Jungle Temple",
                        "JungleTemple"
                    ],
                    [
                        "Ocean",
                        "Ocean"
                    ],
                    [
                        "Overworld",
                        "Overworld"
                    ],
                    [
                        "Overworld Day",
                        "OverworldDay"
                    ],
                    [
                        "Overworld Hallow",
                        "OverworldHallow"
                    ],
                    [
                        "Overworld Night",
                        "OverworldNight"
                    ],
                    [
                        "Overworld Night Monster",
                        "OverworldNightMonster"
                    ],
                    [
                        "Sky",
                        "Sky"
                    ],
                    [
                        "Solar Eclipse",
                        "SolarEclipse"
                    ],
                    [
                        "Underground",
                        "Underground"
                    ],
                    [
                        "Underworld",
                        "Underworld"
                    ]
                ]
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 300,
        "tooltip": "Sets the spawn rate to a given condition",
        "helpUrl": ""
    },
    {
        "type": "npc_friendly",
        "message0": "Make NPC friendly %1",
        "args0": [
            {
                "type": "field_checkbox",
                "name": "friendly",
                "checked": true
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 250,
        "tooltip": "Stops the NPC from damaging the player",
        "helpUrl": ""
    },
    {
        "type": "add_shop_item",
        "message0": "Add %1 to shop",
        "args0": [
            {
                "type": "field_input",
                "name": "item",
                "text": "item name"
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 250,
        "tooltip": "Adds an item to the NPC's shop",
        "helpUrl": "https://terraria.fandom.com/wiki/Item_IDs"
    },
    {
        "type": "add_loot_drop",
        "message0": "Drop %1 to %2 %3 with a %4 in %5 chance",
        "args0": [
            {
                "type": "field_number",
                "name": "min",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483647
            },
            {
                "type": "field_number",
                "name": "max",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483647
            },
            {
                "type": "field_input",
                "name": "item",
                "text": "item"
            },
            {
                "type": "field_number",
                "name": "numerator",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483647
            },
            {
                "type": "field_number",
                "name": "denominator",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483647
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 300,
        "tooltip": "Gives the NPC a chance to drop an item on death",
        "helpUrl": ""
    },
    {
        "type": "is_boss",
        "message0": "Is boss %1",
        "args0": [
            {
                "type": "field_checkbox",
                "name": "boss",
                "checked": true
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 170,
        "tooltip": "Makes the NPC a boss",
        "helpUrl": "https://terraria.fandom.com/wiki/Item_IDs"
    },
    {
        "type": "set_boss_value",
        "message0": "Drop %1 copper on death",
        "args0": [
            {
                "type": "field_number",
                "name": "value",
                "value": 0,
                "precision": 1,
                "min": 0,
                "max": 2147483647
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 170,
        "tooltip": "Sets the amount of money the NPC will drop on death",
        "helpUrl": ""
    },
    {
        "type": "set_npc_property",
        "message0": "Make NPC %1",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "property",
                "options": [
                    [
                        "immune to lava",
                        "lavaImmune"
                    ],
                    [
                        "pass through tiles",
                        "noTileCollide"
                    ],
                    [
                        "unaffected by gravity",
                        "noGravity"
                    ]
                ]
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 300,
        "tooltip": "Sets a property of the NPC",
        "helpUrl": ""
    }
]);


//blocks here
workspace = Blockly.inject('blocklyDiv', {
    toolbox: toolbox,
    scrollbars: true,
    horizontalLayout: false,
    toolboxPosition: "left",
});