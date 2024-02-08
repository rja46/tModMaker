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
                }
            ]
        },
        {
            "kind": "category",
            "name": "NPC",
            "colour": 170,
            contents: [

            ]
        }
    ],
};




Blockly.common.defineBlocksWithJsonArray([
    {
        "type": "projectile_basic",
        "message0": "Width: %1 %2 Height: %3 %4 Collide with tiles: %5 %6 Display scale: %7 %8 Time left %9",
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
                "type": "field_checkbox",
                "name": "collide",
                "checked": true
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_number",
                "name": "scale",
                "value": 0
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
                        "sound delay",
                        "soundDelay"
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
    }
])

workspace = Blockly.inject('blocklyDiv', {
    toolbox: toolbox,
    scrollbars: false,
    horizontalLayout: false,
    toolboxPosition: "left",
});