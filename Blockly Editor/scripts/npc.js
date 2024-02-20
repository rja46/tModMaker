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
    }
]);


//blocks here
workspace = Blockly.inject('blocklyDiv', {
    toolbox: toolbox,
    scrollbars: true,
    horizontalLayout: false,
    toolboxPosition: "left",
});