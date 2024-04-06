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
            "name": "Projectile",
            "colour": 250,
            contents: [
                {
                    "kind": "block",
                    "type": "projectile_basic"
                },
                {
                    "kind": "block",
                    "type": "use_ai"
                },
                {
                    "kind": "block",
                    "type": "set_value"
                },
                {
                    "kind": "block",
                    "type": "declare_friendly"
                },
                {
                    "kind": "block",
                    "type": "declare_hostile"
                },
                {
                    "kind": "block",
                    "type": "hide_projectile"
                },
                {
                    "kind": "block",
                    "type": "collide_with_tiles"
                },
                {
                    "kind": "block",
                    "type": "ignore_water"
                },
                {
                    "kind": "block",
                    "type": "emit_light"
                }
            ]
        }
    ],
};




Blockly.common.defineBlocksWithJsonArray([
    {
        "type": "projectile_basic",
        "message0": "Hitbox width: %1 %2 Hitbox height: %3 %4 Time left %5",
        "args0": [
            {
                "type": "field_number",
                "name": "width",
                "value": 0,
                "min": 0
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "height",
                "value": 0,
                "min": 0
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "time_left",
                "value": 0,
                "min": 0
            }
        ],
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "use_ai",
        "message0": "Use %1 AI style",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "style",
                "options": [
                    [
                        "bullet",
                        "0"
                    ],
                    [
                        "arrow",
                        "1"
                    ],
                    [
                        "thrown",
                        "2"
                    ],
                    [
                        "boomerang",
                        "3"
                    ],
                    [
                        "progressive fading",
                        "4"
                    ],
                    [
                        "falling star",
                        "5"
                    ],
                    [
                        "powder",
                        "6"
                    ],
                    [
                        "grapple",
                        "7"
                    ],
                    [
                        "magic bounce",
                        "8"
                    ],
                    [
                        "controlled bolt",
                        "9"
                    ],
                    [
                        "falling block",
                        "10"
                    ],
                    [
                        "follow player",
                        "11"
                    ],
                    [
                        "water stream",
                        "12"
                    ],
                    [
                        "harpoon",
                        "13"
                    ],
                    [
                        "bounce",
                        "14"
                    ],
                    [
                        "flail",
                        "15"
                    ],
                    [
                        "bounce & explode",
                        "16"
                    ],
                    [
                        "stationary",
                        "17"
                    ],
                    [
                        "exponential acceleration (with sparkles)",
                        "18"
                    ],
                    [
                        "spear",
                        "19"
                    ],
                    [
                        "motorised tool",
                        "20"
                    ],
                    [
                        "no gravity",
                        "21"
                    ],
                    [
                        "blue trail",
                        "22"
                    ],
                    [
                        "fiery",
                        "23"
                    ],
                    [
                        "shard",
                        "24"
                    ],
                    [
                        "boulder",
                        "25"
                    ],
                    [
                        "fly to player",
                        "26"
                    ],
                    [
                        "demon trident",
                        "27"
                    ],
                    [
                        "ice bolt",
                        "28"
                    ],
                    [
                        "amethyst bolt",
                        "29"
                    ],
                    [
                        "mushroom",
                        "30"
                    ],
                    [
                        "solution spray",
                        "31"
                    ],
                    [
                        "beach ball",
                        "32"
                    ],
                    [
                        "flare",
                        "33"
                    ],
                    [
                        "rocket",
                        "34"
                    ],
                    [
                        "rope idk",
                        "35"
                    ],
                    [
                        "bee",
                        "36"
                    ],
                    [
                        "spear",
                        "37"
                    ],
                    [
                        "stationary flame turret",
                        "38"
                    ],
                    [
                        "mechanical pirahna",
                        "39"
                    ],
                    [
                        "leaf",
                        "40"
                    ],
                    [
                        "flower petal",
                        "41"
                    ],
                    [
                        "crystal leaf A",
                        "42"
                    ],
                    [
                        "crystal leaf B",
                        "43"
                    ],
                    [
                        "spore cloud",
                        "44"
                    ],
                    [
                        "rain cloud",
                        "45"
                    ],
                    [
                        "rain cloud",
                        "46"
                    ],
                    [
                        "magnet sphere",
                        "47"
                    ],
                    [
                        "heat ray",
                        "48"
                    ],
                    [
                        "explosive bunny",
                        "49"
                    ],
                    [
                        "inferno",
                        "50"
                    ],
                    [
                        "lost soul",
                        "51"
                    ],
                    [
                        "spirit heal",
                        "52"
                    ],
                    [
                        "frost hydra",
                        "53"
                    ],
                    [
                        "raven",
                        "54"
                    ],
                    [
                        "flaming jack",
                        "55"
                    ],
                    [
                        "flaming scythe",
                        "56"
                    ],
                    [
                        "north pole",
                        "57"
                    ],
                    [
                        "present",
                        "58"
                    ],
                    [
                        "spectre wraith",
                        "59"
                    ],
                    [
                        "water gun",
                        "60"
                    ],
                    [
                        "bobber",
                        "61"
                    ],
                    [
                        "loop around player",
                        "62"
                    ],
                    [
                        "baby spider",
                        "63"
                    ],
                    [
                        "sharknado A",
                        "64"
                    ],
                    [
                        "sharknado B",
                        "65"
                    ],
                    [
                        "big loop",
                        "66"
                    ],
                    [
                        "return to player",
                        "67"
                    ],
                    [
                        "molotov cocktail",
                        "68"
                    ],
                    [
                        "flairon",
                        "69"
                    ],
                    [
                        "flairon bubble",
                        "70"
                    ],
                    [
                        "typhoon",
                        "71"
                    ],
                    [
                        "bubble",
                        "72"
                    ],
                    [
                        "lightning orb",
                        "88"
                    ]
                    

                ]
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "set_value",
        "message0": "Set %1 to %2",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "property",
                "options": [
                    [
                        "damage",
                        "damage"
                    ],
                    [
                        "knockback",
                        "knockBack"
                    ],
                    [
                        "penetration",
                        "penetrate"
                    ],
                    [
                        "alpha",
                        "alpha"
                    ]
                ]
            },
            {
                "type": "field_number",
                "name": "value",
                "value": 0
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "declare_friendly",
        "message0": "Make projectile friendly %1",
        "args0": [
            {
            "type": "field_checkbox",
            "name": "friendly",
            "checked": true
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "declare_hostile",
        "message0": "Make projectile hostile %1",
        "args0": [
            {
                "type": "field_checkbox",
                "name": "hostile",
                "checked": true
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "hide_projectile",
        "message0": "Hide projectile %1",
        "args0": [
            {
                "type": "field_checkbox",
                "name": "hide",
                "checked": true
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "collide_with_tiles",
        "message0": "Collide with tiles %1",
        "args0": [
            {
                "type": "field_checkbox",
                "name": "collide",
                "checked": true
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "ignore_water",
        "message0": "Slow in water %1",
        "args0": [
            {
                "type": "field_checkbox",
                "name": "ignore",
                "checked": true
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "emit_light",
        "message0": "Emit %1 light while active",
        "args0": [
            {
                "type": "field_number",
                "name": "light",
                "value": 0
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    }
])

workspace = Blockly.inject('blocklyDiv', {
    toolbox: toolbox,
    scrollbars: true,
    horizontalLayout: false,
    toolboxPosition: "left",
});