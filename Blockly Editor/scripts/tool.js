let workspace = null;

function sendDataToWinForm(){
	const state = JSON.stringify(Blockly.serialization.workspaces.save(workspace));
	window.chrome.webview.postMessage(state);
}

function sendTranslatedCode(){
const code = 'public override void SetDefaults() {' + JSON.stringify(Blockly.JavaScript.workspaceToCode(workspace)).slice(0,-1).slice(1);
	window.chrome.webview.postMessage(code);

}

function changeThemeDefault() {
    workspace.dispose();
    workspace = Blockly.inject('blocklyDiv', {
        toolbox: toolbox,
        scrollbars: false,
        horizontalLayout: false,
        toolboxPosition: "left",
    });
}

function changeThemeDark() {
    workspace.dispose();
    workspace = Blockly.inject('blocklyDiv', {
        toolbox: toolbox,
        scrollbars: false,
        horizontalLayout: false,
        toolboxPosition: "left",
        theme: dark,
    });
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
          "type": "tool_power"
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
          "type": "use_custom_projectile"
        }
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
            "type": "grant_ability"
        },
		{
			"kind": "block",
			"type": "change_class_stat"
		},
        {
            "kind": "block",
            "type": "set_class_stat"
        },
        {
            "kind": "block",
            "type": "change_player_stat"
        },
        {
            "kind": "block",
            "type": "set_player_stat"
        },
        {
            "kind": "block",
            "type": "create_wings"
        },
        {
            "kind": "block",
            "type": "wing_hover"
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
  "type": "tool_power",
  "message0": "Set %2 power to %1",
  "args0": [
      {
          "type": "field_number",
          "name": "power",
          "value": 0,
          "min": 0
      },
      {
          "type": "field_dropdown",
          "name": "tool_type",
          "options": [
              [
                  "pickaxe",
                  "pick"
              ],
              [
                  "axe",
                  "axe"
              ],
              [
                  "hammer",
                  "hammer"
              ],
              [
                  "fishing",
                  "fishing"
              ],
          ]
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 60,
  "tooltip": "Defines the item's power as a tool",
  "helpUrl": ""
},
{
  "type": "use_mana",
  "message0": "Consume %1 mana per use",
  "args0": [
    {
      "type": "field_number",
      "name": "useMana",
      "value": 0
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
  "message0": "Nullify contact damage",
  "previousStatement": null,
  "nextStatement": null,
  "colour": 120,
  "tooltip": "Defines if an item deals melee damage",
  "helpUrl": ""
},
{
  "type": "shoot_existing_ammo",
  "message0": "Fire %1 with %2 additional velocity",
  "args0": [
    {
      "type": "field_dropdown",
      "name": "ammo_type",
      "options": [
        [
          "bullets",
          "Bullet"
        ],
        [
          "arrows",
          "Arrow"
        ],
        [
          "rockets",
          "Rocket"
        ],
        [
          "darts",
          "Dart"
        ]
      ]
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
  "colour": 330,
  "tooltip": "",
  "helpUrl": ""
},
{
    "type": "set_class_stat",
    "message0": "Set %1 for %2 to %3",
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
    "colour": 330,
    "tooltip": "",
    "helpUrl": ""
},
{
    "type": "grant_ability",
    "message0": "Grant player %1",
    "args0": [
        {
            "type": "field_dropdown",
            "name": "ability",
            "options": [
                [
                    "damage immunity",
                    "immune"
                ],
                [
                    "gravity control",
                    "gravControl"
                ],
                [
                    "fire block immunity",
                    "fireWalk"
                ],
                [
                    "fall damage immunity",
                    "noFallDmg"
                ],
                [
                    "jump boost",
                    "jumpBoost"
                ],
                [
                    "knockback immunity",
                    "noKnockback"
                ],
                [
                    "water walking",
                    "waterWalk"
                ],
                [
                    "thorns",
                    "thorns"
                ],
                [
                    "lava immunity",
                    "lavaImmune"
                ],
                [
                    "invisibility",
                    "invis"
                ],
                [
                    "reduced potion sickness",
                    "pStone"
                ],
                [
                    "increased invincibility duration",
                    "longInvince"
                ]
            ]
        }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 330,
    "tooltip": "Grant the player various abilities.",
    "helpUrl": ""
},
{
    "type": "change_player_stat",
    "message0": "Increase %1 by %2",
    "args0": [
        {
            "type": "field_dropdown",
            "name": "stat",
            "options": [
                [
                    "defence",
                    "statDefense"
                ],
                [
                    "maximum life",
                    "statLifeMax2"
                ],
                [
                    "movement speed",
                    "moveSpeed"
                ],
                [
                    "mana costs",
                    "manaCost"
                ],
                [
                    "maximum mana",
                    "statManaMax2"
                ],
                [
                    "mining time",
                    "pickSpeed"
                ],
                [
                    "rocket boot flight time",
                    "rocketTime"
                ],
                [
                    "wing flight time",
                    "wingTime"
                ],
                [
                    "immunity time",
                    "immuneTime"
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
    "colour": 330,
    "tooltip": "Change various stats for the player",
    "helpUrl": ""
},
{
    "type": "set_player_stat",
    "message0": "Set %1 to %2",
    "args0": [
        {
            "type": "field_dropdown",
            "name": "stat",
            "options": [
                [
                    "maximum life",
                    "statLifeMax2"
                ],
                [
                    "movement speed",
                    "moveSpeed"
                ],
                [
                    "mana costs",
                    "manaCost"
                ],
                [
                    "maximum mana",
                    "statManaMax2"
                ],
                [
                    "mining time",
                    "pickSpeed"
                ],
                [
                    "rocket boot flight time",
                    "rocketTime"
                ],
                [
                    "wing flight time",
                    "wingTime"
                ],
                [
                    "immunity time",
                    "immuneTime"
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
    "colour": 330,
    "tooltip": "Change various stats for the player",
    "helpUrl": ""
},
{
  "type": "is_consumable",
  "message0": "Consume on use",
  "previousStatement": null,
  "nextStatement": null,
  "colour": 120,
  "tooltip": "Defines if an item is consumed on use",
  "helpUrl": ""
},
{
    "type": "create_wings",
    "message0": "Create wings with flight time %1 %2 flight speed %3 , %4 and acceleration %5",
    "args0": [
        {
            "type": "field_number",
            "name": "flight_time",
            "value": 180,
            "min": 0
        },
        {
            "type": "input_dummy"
        },
        {
            "type": "field_number",
            "name": "flight_speed",
            "value": 9,
            "min": 0
        },
        {
            "type": "input_dummy"
        },
        {
            "type": "field_number",
            "name": "acceleration",
            "value": 2.5,
            "min": 0
        }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 330,
    "tooltip": "",
    "helpUrl": ""
},
{
    "type": "wing_hover",
    "message0": "Allow player to hover with hover speed %1 %2 and hover acceleration %3",
    "args0": [
        {
            "type": "field_number",
            "name": "hover_speed",
            "value": 9,
            "min": 0
        },
        {
            "type": "input_dummy"
        },
        {
            "type": "field_number",
            "name": "acceleration",
            "value": 2.5,
            "min": 0
        }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 330,
    "tooltip": "",
    "helpUrl": ""
},
{
  "type": "use_custom_projectile",
  "message0": "Fire custom projectile called %1",
  "args0": [
    {
      "type": "field_input",
      "name": "projectile",
      "text": "projectile"
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 0,
  "tooltip": "",
  "helpUrl": ""
}
]);

var dark = Blockly.Theme.defineTheme('dark', {

    base: Blockly.Themes.Classic,

    componentStyles: {
        workspaceBackgroundColour: '#1e1e1e',
        toolboxBackgroundColour: 'blackBackground',
        toolboxForegroundColour: '#fff',
        flyoutBackgroundColour: '#252526',
        flyoutForegroundColour: '#ccc',
        flyoutOpacity: 1,
        scrollbarColour: '#797979',
        insertionMarkerColour: '#fff',
        insertionMarkerOpacity: 0.3,
        scrollbarOpacity: 0.4,
        cursorColour: '#d0d0d0',
        blackBackground: '#333',
    },
});

workspace = Blockly.inject('blocklyDiv', {
    toolbox: toolbox,
    scrollbars: false,
    horizontalLayout: false,
    toolboxPosition: "left",
});