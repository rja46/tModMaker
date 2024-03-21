let workspace = null;

function sendDataToWinForm() {
    const state = JSON.stringify(Blockly.serialization.workspaces.save(workspace));
    window.chrome.webview.postMessage(state);
}

function sendTranslatedCode() {
    const code = JSON.stringify(Blockly.JavaScript.workspaceToCode(workspace))
    window.chrome.webview.postMessage(code);

}

function clear() {
    workspace.clear();
    Blockly.serialization.workspaces.load({
        "blocks": {
            "languageVersion": 0,
            "blocks": [

            ]
        },
        "variables": [
            {
                "name": "targetPositionX",
                "id": "UA9(!IdVzK({OKS9K{cG"
            },
            {
                "name": "targetPositionY",
                "id": "UA9(!IdVzK({OKS9K{cm"
            },
            {
                "name": "npcPositionX",
                "id": "xPL.?7[CsNSy`vE^`Q@e"
            },
            {
                "name": "npcPositionY",
                "id": "xPL.?7[CsNSy`vE^`Q@a"
            },
            {
                "name": "npcVelocityX",
                "id": "=qJLLnYn!MFm#ZRyL]8P"
            },
            {
                "name": "npcVelocityY",
                "id": "J@r2PhFwz4/t`[Fw9LY3"
            },
            {
                "name": "timer",
                "id": "9*WRnT-s]$;ps7c9=rz9"
            },
            {
                "name": "phase",
                "id": "z#UbUNTotP7R:a~zket6"
            }
        ]
    }, workspace);
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
            "name": "Game",
            "contents": [
                {
                    "kind": "block",
                    "type": "target_player"
                },
                {
                    "kind": "block",
                    "type": "flip_sprite"
                },
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
};

Blockly.common.defineBlocksWithJsonArray([
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
])


//blocks here


workspace = Blockly.inject('blocklyDiv', {
    toolbox: toolbox,
    scrollbars: true,
    horizontalLayout: false,
    toolboxPosition: "left",

});