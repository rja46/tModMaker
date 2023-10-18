'use strict';

let workspace = null;
let outputArea = null;
let runButton = null;
let runTurboB = null;
let runTurboS = null;
let fOpen = null;
let myInterpreter = null;
let fInput = null;
let runnerPid = 0;

var options = { 
    toolbox : toolbox, 
};

function start() {
    workspace = Blockly.inject('blocklyDiv', 
    {
    toolbox: toolbox,
    comments : true,
    sounds : true, 
    trashcan : true, 
    scrollbars : true, 
    grid : {
        spacing : 20, 
        length : 1, 
        colour : '#888', 
        snap : true
    },
    zoom : {
        controls : true, 
        wheel : false, 
        startScale : 1, 
        maxScale : 3, 
        minScale : 0.3, 
        scaleSpeed : 1.2
    }    
    });
    outputArea = document.getElementById('codeHolder');
    runButton = document.getElementById('runButton');
    runTurboB = document.getElementById('runTurboB');
    runTurboS = document.getElementById('runTurboS');
    fOpen = document.getElementById('fileOpen');
    fInput = document.getElementById('fileInput');
    fOpen.onclick = () => {
        fInput.click();
    }
    workspace.addChangeListener(function(event) {
      if (!event.isUiEvent) {
        // Something changed.  Interpreter needs to be reloaded.
        resetStepUi(true);
      }
    });

    fInput.addEventListener('change', function(e) {
    let file = fInput.files[0];
      (async () => {
        const fileContent = await file.text();
        openFile(fileContent);
      })();
    });    
}