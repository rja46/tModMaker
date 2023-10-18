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

function clearWSpace() {
    if (workspace!=null)
    {
        if(workspace.getAllBlocks().length>0)
        {
            var c = confirm("You have blocks in the editor.\n\nPress OK to clear the blocks.\nPress CANCEL to keep your current program.");
            if (c)
            {
                workspace.clear();
                clearCode();
            }
        }
    }
}
function saveFile() {
    if (workspace!=null)
    {
        if(workspace.getAllBlocks().length>0)
        {
            const state = JSON.stringify(Blockly.serialization.workspaces.save(workspace), null, 2);
            var blob = new Blob([state], {
            type: "text/plain;charset=utf-8;",
            });
            saveAs(blob);
        }
    }    
}

function openFile(txt) {
    if (workspace!=null)
    {
        if(workspace.getAllBlocks().length>0)
        {
            var c = confirm("You have blocks in the editor.\n\nPress OK to clear the blocks and load the new file.\nPress CANCEL to keep your current program.");
            if (c)
            {
                loadBlocks(txt);
            }
        }
        else
        {
            loadBlocks(txt);
        }
    }
}

function loadBlocks(j) {
    workspace.clear();
    // try to parse the JSON and load
    var json = null;
    try {
        json = JSON.parse(j);
    } catch (e) {
        alert("There was an error trying to load this file.");
        return;
    }
    if (json) {
        Blockly.serialization.workspaces.load(json, workspace);
        fInput.value = null;
    }   
}

function initApi(interpreter, globalObject) {
      // Add an API function for the alert() block, generated for "text_print" blocks.
      const wrapperAlert = function alert(text) {
        text = arguments.length ? text : '';
        outputArea.innerHTML += '\n' + text;
      };
      interpreter.setProperty(globalObject, 'alert',
          interpreter.createNativeFunction(wrapperAlert));
        
      // Add an API function for the prompt() block.
      const wrapperPrompt = function prompt(text) {
        return window.prompt(text);
      };
      interpreter.setProperty(globalObject, 'prompt',
          interpreter.createNativeFunction(wrapperPrompt));
}
function resetStepUi(clearOutput) {
      clearTimeout(runnerPid);
      workspace.highlightBlock(null);
      runButton.disabled = '';
      runTurboB.disabled = '';
      runTurboS.disabled = '';
      if (clearOutput) {
      outputArea.innerHTML = '';
      }
      myInterpreter = null;
}

function runCode() {
      if (!myInterpreter) {
        // First statement of this code.
        // Clear the program output.
        resetStepUi(true);
        const latestCode = Blockly.JavaScript.workspaceToCode(workspace);
        runButton.disabled = 'disabled';
        runTurboB.disabled = 'disabled';
        runTurboS.disabled = 'disabled';

        // And then show generated code in an alert.
        // In a timeout to allow the outputArea.value to reset first.
        setTimeout(function() {
        alert('Ready to execute JavaScript code\n' +
              '======================\n');

          // Begin execution
          myInterpreter = new Interpreter(latestCode, initApi);
          outputArea.innerHTML = 'Program output:\n=================\n\n';
        function nextStep() {
        if (!myInterpreter.step()) {
          outputArea.innerHTML += '\n\n<< Program complete >>';
            resetStepUi(false);   
          }
          else
          {
          setTimeout(nextStep, 1);                   
          }
        }
        nextStep();
        }, 1);
        return;
      }
}

function runTurbo() {
      if (!myInterpreter) {
        // First statement of this code.
        // Clear the program output.
        resetStepUi(true);
        const latestCode = Blockly.JavaScript.workspaceToCode(workspace);
        runButton.disabled = 'disabled';
        runTurboB.disabled = 'disabled';
        runTurboS.disabled = 'disabled';

        // And then show generated code in an alert.
        // In a timeout to allow the outputArea.value to reset first.
        setTimeout(function() {
        alert('Ready to execute JavaScript code\n' +
              '======================\n');

          // Begin execution
          myInterpreter = new Interpreter(latestCode, initApi);
          outputArea.innerHTML = 'Program output:\n=================\n\n';
        function nextStep() {
        if (!myInterpreter.step()) {
          outputArea.innerHTML += '\n\n<< Program complete >>';
            resetStepUi(false);   
          }
          else
          {
          //setTimeout(nextStep, 0);                   
          nextStep();
          }
        }
        nextStep();
        }, 1);
        return;
      }
}

function runSuper() {
      if (!myInterpreter) {
        var c = confirm("WARNING! This option can cause the program to crash.\n\nMake sure that you have saved any code before you try this. You may need to close the browser if this script locks up.\n\nPress OK to run the program.Press CANCEL to change your mind.");
        if (c)
            {// First statement of this code.
            // Clear the program output.
            resetStepUi(true);
            const latestCode = Blockly.JavaScript.workspaceToCode(workspace);
            runButton.disabled = 'disabled';
            runTurboB.disabled = 'disabled';
            runTurboS.disabled = 'disabled';

            // And then show generated code in an alert.
            // In a timeout to allow the outputArea.value to reset first.
            setTimeout(function() {
              // Begin execution
              myInterpreter = new Interpreter(latestCode, initApi);
              outputArea.innerHTML = 'Program output:\n=================\n\n';
              myInterpreter.run();
              outputArea.innerHTML += '\n\n<< Program complete >>';
              resetStepUi(false);
            }, 1);
            return;
        }
      }
}
function showCodeJS() {
    // Generate JavaScript code and display it.
    const code = Blockly.JavaScript.workspaceToCode(workspace);
    const codeHolder = document.getElementById('codeHolder');
    codeHolder.innerHTML = '';  // Delete old code.
    codeHolder.classList.remove('prettyprinted');
    codeHolder.appendChild(document.createTextNode(code));
    if (typeof PR === 'object') {
    PR.prettyPrint();
  }
}

function clearCode()
{
    const codeHolder = document.getElementById('codeHolder');
    codeHolder.innerHTML = '';  // Delete old code.
    codeHolder.classList.remove('prettyprinted');
}

var toolbox = {
  "kind": "categoryToolbox",
  "contents": [
    {
      "kind": "category",
      "name": "Selection",
      "categorystyle": "logic_category",
      "contents": [
        {
            "kind":"block",
            "type":"controls_if"
        },
        {
            "kind":"block",
            "type":"controls_if",
            "extraState":{
            "hasElse":"true"
        }
        },
        {
            "kind":"block",
            "type":"controls_if",
            "extraState":{
            "hasElse":"true",
            "elseIfCount":1
        }
        }, 
        {
            "kind": "block",
            "type": "logic_ternary"
        },       
        {
            "kind": "block",
            "type": "logic_compare"
        },
        {
            "kind": "block",
            "type": "logic_operation"
        },
        {
            "kind": "block",
            "type": "logic_boolean"
        }
      ]
    },
    {
      "kind": "category",
      "name": "Iteration",
      "categorystyle": "loop_category",
      "contents": [
              {
                "kind":"block",
                "type":"controls_repeat_ext",
                "inputs":{
                  "TIMES":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                        "NUM":10
                      }
                    }
                  }
                }
              },
              {
                "kind":"block",
                "type":"controls_whileUntil"
              },
              {
                "kind":"block",
                "type":"controls_for",
                "fields":{
                  "VAR":"i"
                },
                "inputs":{
                  "FROM":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                        "NUM":1
                      }
                    }
                  },
                  "TO":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                        "NUM":10
                      }
                    }
                  },
                  "BY":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                        "NUM":1
                      }
                    }
                  }
                }
              },            
              {
                "kind":"block",
                "type":"controls_forEach"
              },
              {
                "kind":"block",
                "type":"controls_flow_statements"
              }      
      ]
    },
    {
      "kind": "category",
      "name": "Maths",
      "categorystyle": "math_category",
      "contents": [
              {
                "kind":"block",
                "type":"math_number",
                "fields":{
                  "NUM":123
                }
              },
              {
                "kind":"block",
                "type":"math_arithmetic",
                "fields":{
                  "OP":"ADD"
                }
              },
              {
                "kind":"block",
                "type":"math_single",
                "fields":{
                  "OP":"ROOT"
                }
              },
              {
                "kind":"block",
                "type":"math_trig",
                "fields":{
                  "OP":"SIN"
                }
              },
              {
                "kind":"block",
                "type":"math_constant",
                "fields":{
                  "CONSTANT":"PI"
                }
              },
              {
                "kind":"block",
                "type":"math_round",
                "fields":{
                  "OP":"ROUND"
                }
              },
              {
                "kind":"block",
                "type":"math_on_list",
                "extraState":"<mutation op=\"SUM\"></mutation>",
                "fields":{
                  "OP":"SUM"
                }
              },
              {
                "kind":"block",
                "type":"math_modulo"
              },
              {
                "kind":"block",
                "type":"math_constrain",
                "inputs":{
                  "LOW":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                        "NUM":1
                      }
                    }
                  },
                  "HIGH":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                        "NUM":100
                      }
                    }
                  }
                }
              },
              {
                "kind":"block",
                "type":"math_random_int",
                "inputs":{
                  "FROM":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                        "NUM":1
                      }
                    }
                  },
                  "TO":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                        "NUM":100
                      }
                    }
                  }
                }
              },
              {
                "kind":"block",
                "type":"math_random_float"
              }      
      ]
    },
              {
      "kind": "category",
      "name": "Bitwise",
      "categorystyle": "math_category",
      "contents": [
              {
                "kind":"block",
                "type":"bw_binary",
                "inputs":{
                  "n":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                  }
                }
              },
              {
                "kind":"block",
                "type":"bw_not",
                "inputs":{
                  "n":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                  }
                }
              },              
              {
                "kind":"block",
                "type":"bw_and",
                "inputs":{
                "a":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                    },
                "b":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                    },                    
                }
              },              
              {
                "kind":"block",
                "type":"bw_or",
                "inputs":{
                "a":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                    },
                "b":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                    },                    
                }
              },
              {
                "kind":"block",
                "type":"bw_xor",
                "inputs":{
                "a":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                    },
                "b":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                    },                    
                }
              },  
              {
                "kind":"block",
                "type":"bw_left_shift",
                "inputs":{
                "a":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                    },
                "b":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                    },                    
                }
              },
              {
                "kind":"block",
                "type":"bw_right_shift",
                "inputs":{
                "a":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                    },
                "b":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                      "NUM":0
                      }
                    }
                    },                    
                }
              },              
      ]
    },    
    {
      "kind": "category",
      "name": "Text",
      "categorystyle": "text_category",
      "contents": [
              {
                "kind":"block",
                "type":"text"
              },
              {
                "kind":"block",
                "type":"text_multiline"
              },
              {
                "kind":"block",
                "type":"text_join"
              },
              {
                "kind":"block",
                "type":"text_append",
                "inputs": {
                "TEXT": {
                "shadow": {
                "type": "text",
                "fields": {
                  "TEXT": "abc"
                }                
                }
                }
                }                
              },
              {
                "kind":"block",
                "type":"text_length",
                
              },
              {
                "kind":"block",
                "type":"text_isEmpty"
              },
              {
                "kind":"block",
                "type":"text_indexOf"
              },
              {
                "kind":"block",
                "type":"text_charAt"
              },
              {
                "kind":"block",
                "type":"text_getSubstring"
              },
              {
                "kind":"block",
                "type":"text_changeCase",
                "inputs": {
                "TEXT": {
                "shadow": {
                "type": "text",
                "fields": {
                  "TEXT": "abc"
                }                
                }
                }
                }                 
              },
              {
                "kind":"block",
                "type":"text_trim",
                "inputs": {
                "TEXT": {
                "shadow": {
                "type": "text",
                "fields": {
                  "TEXT": "abc"
                }                
                }
                }
                }                 
              },
              {
                "kind":"block",
                "type":"text_count"
              },
              {
                "kind":"block",
                "type":"text_replace"
              },
              {
                "kind":"block",
                "type":"text_reverse"
              },
                {
                  "kind": "label",
                  "text": "Input / Output",
                  "web-class": "inlineLabel"
                },            
              {
                "kind":"block",
                "type":"text_print",
                "inputs": {
                "TEXT": {
                "shadow": {
                "type": "text",
                "fields": {
                  "TEXT": "abc"
                }                
                }
                }
                }  
              }, 
              {
                "kind":"block",
                "type":"text_prompt_ext"
              },

      ]
    },
    {
      "kind": "category",
      "name": "Lists",
      "categorystyle": "list_category",
      "contents": [
              {
                "kind":"block",
                "type":"lists_create_empty"
              },
              {
                "kind":"block",
                "type":"lists_create_with",
                "extraState":{
                  "itemCount":3
                }
              },
              {
                "kind":"block",
                "type":"lists_repeat",
                "inputs":{
                  "NUM":{
                    "block":{
                      "type":"math_number",
                      "fields":{
                        "NUM":5
                      }
                    }
                  }
                }
              },
              {
                "kind":"block",
                "type":"lists_length"
              },
              {
                "kind":"block",
                "type":"lists_isEmpty"
              },
              {
                "kind":"block",
                "type":"lists_indexOf",
                "fields":{
                  "END":"FIRST"
                }
              },
              {
                "kind":"block",
                "type":"lists_getIndex",
                "fields":{
                  "MODE":"GET",
                  "WHERE":"FROM_START"
                }
              },
              {
                "kind":"block",
                "type":"lists_setIndex",
                "fields":{
                  "MODE":"SET",
                  "WHERE":"FROM_START"
                }
              }      
            ]
            },
            {
            "kind": "sep",
            "cssConfig": {
            "container": "sepClass"
            }    
            },
          {
            "kind":"category",
            "name":"Variables",
            "categorystyle":"variable_category",
            "custom":"VARIABLE"
          },
          {
            "kind":"category",
            "name":"Subroutines",
            "categorystyle":"procedure_category",
            "custom":"PROCEDURE"
          },   
  ]
}


// Custom Block Definitions

Blockly.defineBlocksWithJsonArray([
{
  "type": "bw_binary",
  "message0": "convert %1 to binary string",
  "args0": [
    {
      "type": "input_value",
      "name": "n",
      "check": "Number"
    }
  ],
  "output": "String",
  "colour": 230,
  "tooltip": "Converts a number to binary. Negative numbers are shown in two's complement form. Decimal places are ignored.",
  "helpUrl": ""
  },
{
  "type": "bw_not",
  "message0": "NOT %1 ",
  "args0": [
    {
      "type": "input_value",
      "name": "n",
      "check": "Number"
    }
  ],
  "output": "Number",
  "colour": 230,
  "tooltip": "Performs bitwise NOT operation on the input",
  "helpUrl": ""
  },  
  {
  "type": "bw_and",
  "message0": "%1 AND %2 %3",
  "args0": [
    {
      "type": "input_value",
      "name": "a",
      "check": "Number"
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "input_value",
      "name": "b",
      "check": "Number"
    }
  ],
  "output": "Number",
  "colour": 230,
  "tooltip": "Performs bitwise AND operation on the inputs",
  "helpUrl": ""
  },
  {
  "type": "bw_or",
  "message0": "%1 OR %2 %3",
  "args0": [
    {
      "type": "input_value",
      "name": "a",
      "check": "Number"
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "input_value",
      "name": "b",
      "check": "Number"
    }
  ],
  "output": "Number",
  "colour": 230,
  "tooltip": "Performs bitwise OR operation on the inputs",
  "helpUrl": ""
  },
  {
  "type": "bw_xor",
  "message0": "%1 XOR %2 %3",
  "args0": [
    {
      "type": "input_value",
      "name": "a",
      "check": "Number"
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "input_value",
      "name": "b",
      "check": "Number"
    }
  ],
  "output": "Number",
  "colour": 230,
  "tooltip": "Performs bitwise XOR operation on the inputs",
  "helpUrl": ""
  },  
  {
  "type": "bw_left_shift",
  "message0": "%1 << %2 %3",
  "args0": [
    {
      "type": "input_value",
      "name": "a",
      "check": "Number"
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "input_value",
      "name": "b",
      "check": "Number"
    }
  ],
  "output": "Number",
  "colour": 230,
  "tooltip": "Performs bitwise left shift",
  "helpUrl": ""
  },   
  {
  "type": "bw_right_shift",
  "message0": "%1 >> %2 %3",
  "args0": [
    {
      "type": "input_value",
      "name": "a",
      "check": "Number"
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "input_value",
      "name": "b",
      "check": "Number"
    }
  ],
  "output": "Number",
  "colour": 230,
  "tooltip": "Performs bitwise right shift",
  "helpUrl": ""
  },
]);


Blockly.JavaScript['bw_binary'] = function(block) {
  var value_n = Blockly.JavaScript.valueToCode(block, 'n', Blockly.JavaScript.ORDER_ATOMIC);
  // Assemble JavaScript into code variable.  
  
  var code = '('+ value_n + ' >>> 0).toString(2)';
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['bw_and'] = function(block) {
  var value_a = Blockly.JavaScript.valueToCode(block, 'a', Blockly.JavaScript.ORDER_ATOMIC);
  var value_b = Blockly.JavaScript.valueToCode(block, 'b', Blockly.JavaScript.ORDER_ATOMIC);
  // TODO: Assemble JavaScript into code variable.
  var code = value_a + ' & ' + value_b;
  return [code, Blockly.JavaScript.ORDER_BITWISE_AND];
};

Blockly.JavaScript['bw_or'] = function(block) {
  var value_a = Blockly.JavaScript.valueToCode(block, 'a', Blockly.JavaScript.ORDER_ATOMIC);
  var value_b = Blockly.JavaScript.valueToCode(block, 'b', Blockly.JavaScript.ORDER_ATOMIC);
  // TODO: Assemble JavaScript into code variable.
  var code = value_a + ' | ' + value_b;
  return [code, Blockly.JavaScript.ORDER_BITWISE_OR];
};

Blockly.JavaScript['bw_xor'] = function(block) {
  var value_a = Blockly.JavaScript.valueToCode(block, 'a', Blockly.JavaScript.ORDER_ATOMIC);
  var value_b = Blockly.JavaScript.valueToCode(block, 'b', Blockly.JavaScript.ORDER_ATOMIC);
  // TODO: Assemble JavaScript into code variable.
  var code = value_a + ' ^ ' + value_b;
  return [code, Blockly.JavaScript.ORDER_BITWISE_XOR];
};

Blockly.JavaScript['bw_left_shift'] = function(block) {
  var value_a = Blockly.JavaScript.valueToCode(block, 'a', Blockly.JavaScript.ORDER_ATOMIC);
  var value_b = Blockly.JavaScript.valueToCode(block, 'b', Blockly.JavaScript.ORDER_ATOMIC);
  // TODO: Assemble JavaScript into code variable.
  var code = value_a + ' << ' + value_b;
  return [code, Blockly.JavaScript.ORDER_BITWISE_SHIFT];
};

Blockly.JavaScript['bw_right_shift'] = function(block) {
  var value_a = Blockly.JavaScript.valueToCode(block, 'a', Blockly.JavaScript.ORDER_ATOMIC);
  var value_b = Blockly.JavaScript.valueToCode(block, 'b', Blockly.JavaScript.ORDER_ATOMIC);
  // TODO: Assemble JavaScript into code variable.
  var code = value_a + ' >> ' + value_b;
  return [code, Blockly.JavaScript.ORDER_BITWISE_SHIFT];
};

Blockly.JavaScript['bw_not'] = function(block) {
  var value_n = Blockly.JavaScript.valueToCode(block, 'n', Blockly.JavaScript.ORDER_ATOMIC);
  // Assemble JavaScript into code variable.  
  var code = '~ ' + value_n ;
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_BITWISE_NOT];
};