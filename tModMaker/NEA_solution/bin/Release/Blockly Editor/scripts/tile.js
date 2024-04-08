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
            ]
        }
    ],
};




Blockly.common.defineBlocksWithJsonArray([
])

workspace = Blockly.inject('blocklyDiv', {
    toolbox: toolbox,
    scrollbars: true,
    horizontalLayout: false,
    toolboxPosition: "left",
});