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
            "name": "Tile",
            "colour": 250,
            contents: [
                {
                    "kind": "block",
                    "type": "tile_default"
                },
                {
                    "kind": "block",
                    "type": "toughness"
                }
            ]
        }
    ]
};




Blockly.common.defineBlocksWithJsonArray([
    {
        "type": "toughness",
        "message0": "Require %1 pickaxe power to mine",
        "args0": [
            {
                "type": "field_number",
                "name": "power",
                "value": 0,
                "min": 0,
                "precision": 1
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "",
        "helpUrl": ""
    },
    {
        "type": "tile_default",
        "message0": "Solid block %1 %2 Merge with dirt %3 %4 Block light %5 %6 Dust type %7",
        "args0": [
            {
                "type": "field_checkbox",
                "name": "solid",
                "checked": true
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_checkbox",
                "name": "merge",
                "checked": true
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_checkbox",
                "name": "block_light",
                "checked": true
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_dropdown",
                "name": "dust_type",
                "options": [
                    [
                        "option",
                        "OPTIONNAME"
                    ],
                    [
                        "option",
                        "OPTIONNAME"
                    ],
                    [
                        "option",
                        "OPTIONNAME"
                    ]
                ]
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