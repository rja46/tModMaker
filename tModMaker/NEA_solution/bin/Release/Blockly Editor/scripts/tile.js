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
            "colour": 15,
            contents: [
                {
                    "kind": "block",
                    "type": "define_tile"
                },
                {
                    "kind": "block",
                    "type": "min_pickaxe"
                },
                {
                    "kind": "block",
                    "type": "mine_resist"
                }
            ]
        }
    ],
};




Blockly.common.defineBlocksWithJsonArray([{
    "type": "define_tile",
    "message0": "Make tile solid %1 %2 Make tile merge with dirt %3 %4 Make tile block light %5 %6 Set map colour to %7",
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
                "name": "mergeDirt",
                "checked": true
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_checkbox",
                "name": "blockLight",
                "checked": true
            },
            {
                "type": "input_dummy"
            },
            {
                "type": "field_colour",
                "name": "colour",
                "colour": "#ff0000"
            }
        ],
        "colour": 15,
        "tooltip": "Sets the basic properties of a block",
        "helpUrl": "",
        "nextStatement": null
    },
    {
        "type": "min_pickaxe",
        "message0": "Set minimum pickaxe power to mine to %1",
        "args0": [
            {
                "type": "field_number",
                "name": "power",
                "value": 0,
                "min": 0,
                "max": 2147483646,
                "precision": 1
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 15,
        "tooltip": "Makes the tile only breakable with certain pickaxes",
        "helpUrl": ""
    },
    {
        "type": "mine_resist",
        "message0": "Set block mining time to %1  times the default",
        "args0": [
            {
                "type": "field_number",
                "name": "resist",
                "value": 0,
                "min": 0,
                "max": 2147483646
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 15,
        "tooltip": "Sets the amount of time it takes to mine the tile",
        "helpUrl": ""
    }
])

workspace = Blockly.inject('blocklyDiv', {
    toolbox: toolbox,
    scrollbars: true,
    horizontalLayout: false,
    toolboxPosition: "left",
});