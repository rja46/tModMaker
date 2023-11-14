let workspace = null;

function sendDataToWinForm(){
	const code = Blockly.JavaScript.workspaceToCode(workspace);
	window.chrome.webview.postMessage(code);
}	

 const toolbox = {
  "kind": "categoryToolbox",
    "contents": [
      {
      "kind": "category",
      "name": "Basic",
	  "colour": 230,
      "contents": [
        {
          "kind": "block",
          "type": "define_weapon_essential"
        },
      ]
    },
	{
      "kind": "category",
      "name": "Tool",
	  "colour": 60,
      "contents": [
        {
          "kind": "block",
          "type": "pick_power"
        },
		{
          "kind": "block",
          "type": "axe_power"
        },
		{
          "kind": "block",
          "type": "hammer_power"
        },
		{
          "kind": "block",
          "type": "fishing_power"
        },
      ]
    },
	{
      "kind": "category",
      "name": "Projectile",
	  "colour": 360,
      "contents": [
        {
          "kind": "block",
          "type": "shoot"
        },
		{
          "kind": "block",
          "type": "is_boomerang"
        },
      ]
    },
	{
      "kind": "category",
      "name": "Other",
	  "colour": 120,
      "contents": [
        {
          "kind": "block",
          "type": "use_mana"
        },
		{
          "kind": "block",
          "type": "use_ammo"
        },
		{
          "kind": "block",
          "type": "is_consumable"
        },
      ]
    },
  ]
};

Blockly.common.defineBlocksWithJsonArray([{
  "type": "define_weapon_essential",
  "message0": "Damage: %1 %2 Melee: %3 %4 Width: %5 Height: %6 %7 Use Time: %8 %9 Animation Time: %10 %11 Use Style: %12 %13 Knockback: %14 %15 Value %16 %17 Rarity %18 %19 Sound ID %20 %21 Auto Reuse %22",
  "args0": [
    {
      "type": "field_number",
      "name": "damage",
      "value": 0,
      "min": 0
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_checkbox",
      "name": "melee",
      "checked": true
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_number",
      "name": "width",
      "value": 0,
      "min": 0
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
      "name": "useTime",
      "value": 0
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_number",
      "name": "useAnimation",
      "value": 0
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_dropdown",
      "name": "useStyle",
      "options": [
        [
          "None",
          "0"
        ],
        [
          "Swing",
          "1"
        ],
        [
          "DrinkOld",
          "2"
        ],
        [
          "Thrust",
          "3"
        ],
        [
          "HoldUp",
          "4"
        ],
        [
          "Shoot",
          "5"
        ],
        [
          "DrinkLong",
          "6"
        ],
        [
          "EatFood",
          "7"
        ],
        [
          "GolfPlay",
          "8"
        ],
        [
          "DrinkLiquid",
          "9"
        ],
        [
          "HiddenAnimation",
          "10"
        ],
        [
          "MowTheLaw",
          "11"
        ],
        [
          "Guitar",
          "12"
        ],
        [
          "Rapier",
          "13"
        ],
        [
          "RaiseLamp",
          "14"
        ]
      ]
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_number",
      "name": "knockback",
      "value": 0
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_number",
      "name": "value",
      "value": 0
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_dropdown",
      "name": "rare",
      "options": [
        [
          "Grey",
          "-1"
        ],
        [
          "White",
          "0"
        ],
        [
          "Blue",
          "1"
        ],
        [
          "Green",
          "2"
        ],
        [
          "Orange",
          "3"
        ],
        [
          "Light Red",
          "4"
        ],
        [
          "Pink",
          "5"
        ],
        [
          "Light Purple",
          "6"
        ],
        [
          "Lime",
          "7"
        ],
        [
          "Yellow",
          "8"
        ],
        [
          "Cyan",
          "9"
        ],
        [
          "Red",
          "10"
        ],
        [
          "Purple",
          "11"
        ],
        [
          "Rainbow",
          "-12"
        ],
        [
          "Fiery Red",
          "-13"
        ],
        [
          "Amber",
          "-11"
        ]
      ]
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_number",
      "name": "UseSound",
      "value": 0,
      "min": 0,
      "max": 172
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_checkbox",
      "name": "autoReuse",
      "checked": true
    }
  ],
  "nextStatement": null,
  "colour": 230,
  "tooltip": "Define a basic weapon",
  "helpUrl": "no"
},
{
  "type": "pick_power",
  "message0": "Pickaxe power:  %1",
  "args0": [
    {
      "type": "field_number",
      "name": "pick",
      "value": 0,
      "min": 0
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 60,
  "tooltip": "Defines the item's power as a pickaxe",
  "helpUrl": ""
},
{
  "type": "axe_power",
  "message0": "Axe power:  %1",
  "args0": [
    {
      "type": "field_number",
      "name": "axe",
      "value": 0,
      "min": 0
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 60,
  "tooltip": "Defines the item's power as an axe",
  "helpUrl": ""
},
{
  "type": "hammer_power",
  "message0": "Hammer power:  %1",
  "args0": [
    {
      "type": "field_number",
      "name": "hammer",
      "value": 0,
      "min": 0
    }
  ],
  "colour": 60,
  "tooltip": "Defines the item's power as a hammer",
  "helpUrl": ""
},
{
  "type": "fishing_power",
  "message0": "Fishing power:  %1",
  "args0": [
    {
      "type": "field_number",
      "name": "NAME",
      "value": 0,
      "min": 0
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 60,
  "tooltip": "Defines the item's power as a fishing rod",
  "helpUrl": ""
},
{
  "type": "shoot",
  "message0": "Projectile:  %1 %2 Projectile velocity: %3",
  "args0": [
    {
      "type": "field_input",
      "name": "projectileName",
      "text": "null"
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_number",
      "name": "NAME",
      "value": 0
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 0,
  "tooltip": "Defines the projectile fired by an item",
  "helpUrl": ""
},
{
  "type": "is_boomerang",
  "message0": "Return to player:  %1",
  "args0": [
    {
      "type": "field_checkbox",
      "name": "isBoomerang",
      "checked": true
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 0,
  "tooltip": "Defines whether an item returns when throw",
  "helpUrl": ""
},
{
  "type": "use_mana",
  "message0": "Use mana:  %1",
  "args0": [
    {
      "type": "field_checkbox",
      "name": "useMana",
      "checked": true
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 120,
  "tooltip": "Defines if an item uses mana",
  "helpUrl": ""
},
{
  "type": "use_ammo",
  "message0": "Use ammo:  %1",
  "args0": [
    {
      "type": "field_input",
      "name": "ammoName",
      "text": "null"
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 120,
  "tooltip": "Defines what ammo an item uses",
  "helpUrl": ""
},
{
  "type": "is_consumable",
  "message0": "Is consumable:  %1",
  "args0": [
    {
      "type": "field_checkbox",
      "name": "NAME",
      "checked": true
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 120,
  "tooltip": "Defines if an item is consumed on use",
  "helpUrl": ""
}]);

 workspace = Blockly.inject('blocklyDiv', {
  toolbox: toolbox,
  scrollbars: false,
  horizontalLayout: false,
  toolboxPosition: "left",
});

javascript.javascriptGenerator.forBlock['define_weapon_essential'] = function(block, generator) {
  var number_damage = block.getFieldValue('damage');
  var checkbox_melee = block.getFieldValue('melee') === 'TRUE';
  var number_width = block.getFieldValue('width');
  var number_height = block.getFieldValue('height');
  var number_usetime = block.getFieldValue('useTime');
  var number_useanimation = block.getFieldValue('useAnimation');
  var dropdown_usestyle = block.getFieldValue('useStyle');
  var number_knockback = block.getFieldValue('knockback');
  var number_value = block.getFieldValue('value');
  var dropdown_rare = block.getFieldValue('rare');
  var number_usesound = block.getFieldValue('UseSound');
  var checkbox_autoreuse = block.getFieldValue('autoReuse') === 'TRUE';
  // TODO: Assemble javascript into code variable.
  var code = 'public override void SetDefaults() {Item.width = ' + number_width + '; Item.height = ' + number_height + '; Item.useStyle = ' + 'dropdown_usestyle' + ';';
  return code;
};

javascript.javascriptGenerator.forBlock['pick_power'] = function(block, generator) {
  var number_pick = block.getFieldValue('pick');
  // TODO: Assemble javascript into code variable.
  var code = '...\n';
  return code;
};

javascript.javascriptGenerator.forBlock['axe_power'] = function(block, generator) {
  var number_axe = block.getFieldValue('axe');
  // TODO: Assemble javascript into code variable.
  var code = '...\n';
  return code;
};

javascript.javascriptGenerator.forBlock['hammer_power'] = function(block, generator) {
  var number_hammer = block.getFieldValue('hammer');
  // TODO: Assemble javascript into code variable.
  var code = '...\n';
  return code;
};

javascript.javascriptGenerator.forBlock['fishing_power'] = function(block, generator) {
  var number_name = block.getFieldValue('NAME');
  // TODO: Assemble javascript into code variable.
  var code = '...\n';
  return code;
};

javascript.javascriptGenerator.forBlock['shoot'] = function(block, generator) {
  var text_projectilename = block.getFieldValue('projectileName');
  var number_name = block.getFieldValue('NAME');
  // TODO: Assemble javascript into code variable.
  var code = '...\n';
  return code;
};

javascript.javascriptGenerator.forBlock['is_boomerang'] = function(block, generator) {
  var checkbox_isboomerang = block.getFieldValue('isBoomerang') === 'TRUE';
  // TODO: Assemble javascript into code variable.
  var code = '...\n';
  return code;
};

javascript.javascriptGenerator.forBlock['use_mana'] = function(block, generator) {
  var checkbox_usemana = block.getFieldValue('useMana') === 'TRUE';
  // TODO: Assemble javascript into code variable.
  var code = '...\n';
  return code;
};

javascript.javascriptGenerator.forBlock['use_ammo'] = function(block, generator) {
  var text_ammoname = block.getFieldValue('ammoName');
  // TODO: Assemble javascript into code variable.
  var code = '...\n';
  return code;
};

javascript.javascriptGenerator.forBlock['is_consumable'] = function(block, generator) {
  var checkbox_name = block.getFieldValue('NAME') === 'TRUE';
  // TODO: Assemble javascript into code variable.
  var code = '...\n';
  return code;
};