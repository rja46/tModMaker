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
                    "type": "add_buttons"
                },
                {
                    "kind": "block",
                    "type": "name_option"
                },
                {
                    "kind": "block",
                    "type": "set_mood_text"
                }
            ]
        },
        {
            "kind": "category",
            "name": "AI",
            "colour": 170,
            "contents": [
                {
                    "kind": "block",
                    "type": "fire_projectile"
                },
                {
                    "kind": "block",
                    "type": "chase_player_x"
                },
                {
                    "kind": "block",
                    "type": "chase_player_y"
                }
            ]
        }
    ]
}

Blockly.common.defineBlocksWithJsonArray([
    {
        "type": "npc_basic",
        "message0": "Hitbox width: %1 %2 Hitbox height: %3 %4 Damage: %5 %6 Defense: %7 %8 Maximum life: %9 %10 Knockback resistance: %11",
        "args0": [
            {
                "type": "field_number",
                "name": "width",
                "value": 0,
                "precision": 1
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "height",
                "value": 0,
                "precision": 1
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "damage",
                "value": 0,
                "precision": 1
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "defense",
                "value": 0,
                "precision": 1
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "life",
                "value": 0,
                "precision": 1
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "knockResist",
                "value": 0,
                "precision": 1
            }
        ],
        "nextStatement": null,
        "colour": 300,
        "tooltip": "",
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
        "tooltip": "",
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
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "name_option",
        "message0": "Add name option: %1",
        "args0": [
            {
                "type": "field_input",
                "name": "name",
                "text": "Dave, the Former Ethereal"
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 250,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "add_buttons",
        "implicitAlign0": "RIGHT",
        "message0": "Add buttons: %1 %2 %3 %4",
        "args0": [
            {
                "type": "input_dummy"
            },
            {
                "type": "field_input",
                "name": "button1",
                "text": "button1"
            },
            {
                "type": "input_dummy",
                "align": "RIGHT"
            },
            {
                "type": "field_input",
                "name": "button2",
                "text": "button2"
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 250,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "set_mood_text",
        "message0": "When content say: %1 %2 When homeless say: %3 %4 When far from home say: %5 %6 When not crowded say: %7 %8 When crowded say: %9 %10 When too crowded say: %11",
        "args0": [
            {
                "type": "field_input",
                "name": "content",
                "text": "I am content."
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_input",
                "name": "noHome",
                "text": "I hate not having a home."
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_input",
                "name": "FarFromHome",
                "text": "I am too far from home."
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_input",
                "name": "LoveSpace",
                "text": "I love having so much space."
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_input",
                "name": "DislikeCrowded",
                "text": "I dislike how crowded I am."
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_input",
                "name": "HateCrowded",
                "text": "I hate how crowded I am."
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
        {
        "type": "customAI",
        "message0": "Use custom AI called %1",
        "args0": [
            {
                "type": "field_input",
                "name": "aiName",
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
        "type": "use_custom_ai",
        "message0": "Use custom AI called %1",
        "args0": [
            {
                "type": "field_input",
                "name": "aiName",
                "text": "default"
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 170,
        "tooltip": "",
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
        "type": "chase_player_x",
        "message0": "Chase player horizontally with %1 velocity and %2 acceleration",
        "args0": [
            {
                "type": "field_number",
                "name": "xVelocity",
                "value": 0,
                "precision": 1
            },
            {
                "type": "field_number",
                "name": "xAcceleration",
                "value": 0,
                "precision": 0
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "chase_player_y",
        "message0": "Chase player vertically with %1 velocity and %2 acceleration if player is within %3 blocks",
        "args0": [
            {
                "type": "field_number",
                "name": "yVelocity",
                "value": 0,
                "precision": 1
            },
            {
                "type": "field_number",
                "name": "yAcceleration",
                "value": 0,
                "precision": 0
            },
            {
                "type": "field_number",
                "name": "distance",
                "value": 0,
                "precision": 1
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
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