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
            contents: [{
                "kind": "block",
                "type": "define_tile"
            }
            ]
        }
    ],
};




Blockly.common.defineBlocksWithJsonArray([{
    "type": "define_tile",
    "message0": "Make tile solid %1 %2 Make tile merge with dirt %3 %4 Make tile block %5 %6 Set map colour to %7",
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
    "helpUrl": ""
}
])

workspace = Blockly.inject('blocklyDiv', {
    toolbox: toolbox,
    scrollbars: true,
    horizontalLayout: false,
    toolboxPosition: "left",
});