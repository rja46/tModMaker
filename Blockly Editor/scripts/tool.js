let workspace = null;

function sendDataToWinForm(){
	const state = JSON.stringify(Blockly.serialization.workspaces.save(workspace));
	window.chrome.webview.postMessage(state);
}

function sendTranslatedCode(){
const code = 'public override void SetDefaults() {' + JSON.stringify(Blockly.JavaScript.workspaceToCode(workspace)).slice(0,-1).slice(1);
	window.chrome.webview.postMessage(code);

}

function clear(){
	workspace.clear();
}

function loadData(theData){
	var json = null;
	json = JSON.parse(theData);
	try{
	Blockly.serialization.workspaces.load(json, workspace);
	}
	catch{}
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
		  "type": "define_item"
		},
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
          "type": "shoot_existing_ammo"
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
          "type": "is_consumable"
        },
				{
          "kind": "block",
          "type": "no_melee"
        },
      ]
    },
	{
		"kind": "category",
		"name": "Buffs",
		"colour": 330,
		"contents": [
		{
			"kind": "block",
			"type": "change_class_stat"
		}
		]
	},
  ]
};

Blockly.common.defineBlocksWithJsonArray([
{
  "type": "define_weapon_essential",
  "message0": "Damage: %1 %2 Damage Type %3 %4 Use Time: %5 %6 Animation Time: %7 %8 Use Style: %9 %10 Knockback: %11 %12 Crit Chance %13 %14 Sound ID %15 %16 Auto Reuse %17",
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
      "type": "field_dropdown",
      "name": "damageType",
      "options": [
        [
          "Melee",
          "Melee"
        ],
        [
          "Ranged",
          "Ranged"
        ],
        [
          "Magic",
          "Magic"
        ],
        [
          "Summon",
          "Summon"
        ],
        [
          "Generic",
          "Generic"
        ]
      ]
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
      "name": "crit",
      "value": 0,
      "min": 0
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
  "previousStatement": null,
  "nextStatement": null,
  "colour": 230,
  "tooltip": "Define a basic weapon",
  "helpUrl": "no"
},
{
  "type": "define_item",
  "message0": "Width: %1 Height: %2 %3 Value %4 %5 Rarity %6",
  "args0": [
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
  "previousStatement": null,
  "nextStatement": null,
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
  "type": "no_melee",
  "message0": "No melee:  %1",
  "args0": [
    {
      "type": "field_checkbox",
      "name": "no_melee",
      "checked": true
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 120,
  "tooltip": "Defines if an item deals melee damage",
  "helpUrl": ""
},
{
  "type": "shoot_existing_ammo",
  "message0": "Ammo Type:  %1 %2 Shoot Speed:  %3",
  "args0": [
    {
      "type": "field_dropdown",
      "name": "ammo_type",
      "options": [
        [
          "Bullet",
          "Bullet"
        ],
        [
          "Arrow",
          "Arrow"
        ],
        [
          "Rocket",
          "Rocket"
        ],
        [
          "Dart",
          "Dart"
        ]
      ]
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_number",
      "name": "shoot_speed",
      "value": 0,
      "min": 0
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 0,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "change_class_stat",
  "message0": "Increase %1 for %2 by %3",
  "args0": [
    {
      "type": "field_dropdown",
      "name": "stat",
      "options": [
        [
          "Crit Chance",
          "GetCritChance"
        ],
        [
          "Damage",
          "GetDamage"
        ],
        [
          "Attack Speed",
          "GetAttackSpeed"
        ],
        [
          "Armor Penetration",
          "GetArmorPenetration"
        ],
        [
          "Knockback",
          "GetKnockback"
        ]
      ]
    },
    {
      "type": "field_dropdown",
      "name": "class_name",
      "options": [
        [
          "Melee",
          "Melee"
        ],
        [
          "Ranged",
          "Ranged"
        ],
        [
          "Magic",
          "Magic"
        ],
        [
          "Summon",
          "Summon"
        ],
        [
          "Generic",
          "Generic"
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
  "type": "is_consumable",
  "message0": "Is consumable:  %1",
  "args0": [
    {
      "type": "field_checkbox",
      "name": "isConsumable",
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

javascript.javascriptGenerator.forBlock['fishing_power'] = function(block, generator) {
  var number_name = block.getFieldValue('NAME');
  // TODO: Assemble javascript into code variable.
  var code = 'fishing_power';
  return code;
};

javascript.javascriptGenerator.forBlock['is_boomerang'] = function(block, generator) {
  var checkbox_isboomerang = block.getFieldValue('isBoomerang') === 'TRUE';
  // TODO: Assemble javascript into code variable.
  var code = 'is_boomerang';
  return code;
};

javascript.javascriptGenerator.forBlock['use_mana'] = function(block, generator) {
  var checkbox_usemana = block.getFieldValue('useMana') === 'TRUE';
  // TODO: Assemble javascript into code variable.
  var code = 'use_mana';
  return code;
};
