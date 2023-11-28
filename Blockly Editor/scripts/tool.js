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
  ]
};

Blockly.common.defineBlocksWithJsonArray([
{
  "type": "define_weapon_essential",
  "message0": "Damage: %1 %2 Damage Type %3 %4 Width: %5 Height: %6 %7 Use Time: %8 %9 Animation Time: %10 %11 Use Style: %12 %13 Knockback: %14 %15 Crit Chance: %16 %17 Value: %18 %19 Rarity: %20 %21 Sound ID: %22 %23 Auto Reuse: %24",
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
      "name": "crit",
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
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "field_number",
      "name": "UseSound",
      "value": 1,
      "min": 1,
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

javascript.javascriptGenerator.forBlock['define_weapon_essential'] = function(block, generator) {
  var number_damage = block.getFieldValue('damage');
  var dropdown_damagetype = block.getFieldValue('damageType');
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
  var number_crit = block.getFieldValue('crit');
  // TODO: Assemble javascript into code variable.
  var code = 'Item.damage = ' + number_damage + '; Item.DamageType = DamageClass.' + dropdown_damagetype + '; Item.width = '+ number_width + '; Item.height = ' +  number_height + '; Item.useTime = ' + number_usetime + '; Item.useAnimation = ' + number_useanimation + '; Item.knockBack = ' + number_knockback + '; Item.value = ' + number_value + '; Item.rare = ' + dropdown_rare + '; Item.UseSound = SoundID.Item' + number_usesound + '; Item.autoReuse = ' + checkbox_autoreuse + '; Item.useStyle = ' + dropdown_usestyle + ';';
  return code;
};

javascript.javascriptGenerator.forBlock['pick_power'] = function(block, generator) {
  var number_pick = block.getFieldValue('pick');
  // TODO: Assemble javascript into code variable.
  var code = 'Item.pick = ' + number_pick + ';';
  return code;
};

javascript.javascriptGenerator.forBlock['axe_power'] = function(block, generator) {
  var number_axe = block.getFieldValue('axe');
  // TODO: Assemble javascript into code variable.
  var code = 'Item.axe = ' + number_axe + ';';
  return code;
};

javascript.javascriptGenerator.forBlock['hammer_power'] = function(block, generator) {
  var number_hammer = block.getFieldValue('hammer');
  // TODO: Assemble javascript into code variable.
  var code = 'Item.hammer = ' + number_hammer + ';';
  return code;
};

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

javascript.javascriptGenerator.forBlock['use_ammo'] = function(block, generator) {
  var text_ammoname = block.getFieldValue('ammoName');
  // TODO: Assemble javascript into code variable.
  var code = 'use_ammo';
  return code;
};

javascript.javascriptGenerator.forBlock['is_consumable'] = function(block, generator) {
  var checkbox_consumable = block.getFieldValue('isConsumable') === 'TRUE';
  // TODO: Assemble javascript into code variable.
  var code = 'Item.consumable = ' + checkbox_consumable + ';';
  return code;
};

javascript.javascriptGenerator.forBlock['no_melee'] = function(block, generator) {
  var checkbox_noMelee = block.getFieldValue('no_melee') === 'TRUE';
  // TODO: Assemble javascript into code variable.
  var code = 'Item.noMelee = ' + checkbox_noMelee + ';';
  return code;
};

javascript.javascriptGenerator.forBlock['shoot_existing_ammo'] = function(block, generator) {
  var dropdown_ammo_type = block.getFieldValue('ammo_type');
  var number_shoot_speed = block.getFieldValue('shoot_speed');
  // TODO: Assemble javascript into code variable.
  var code = 'Item.shoot = 10;' + 'Item.shootSpeed = ' + number_shoot_speed + ';' + 'Item.useAmmo = AmmoID.' + dropdown_ammo_type + ';';
  return code;
};