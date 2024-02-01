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
            "type": "set_all_player_bools"
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
  "type": "is_consumable",
  "message0": "Consume on use",
  "previousStatement": null,
  "nextStatement": null,
  "colour": 120,
  "tooltip": "Defines if an item is consumed on use",
  "helpUrl": ""
},
{
        "type": "set_all_player_bools",
        "message0": "Set property %1 to true",
        "args0": [
            {
                "type": "field_dropdown",
                "name": "property",
                "options": [
                    [
                        "abigailMinion",
                        "abigailMinion",
                    ],
                    [
                        "accCalendar",
                        "accCalendar",
                    ],
                    [
                        "accCritterGuide",
                        "accCritterGuide",
                    ],
                    [
                        "accDivingHelm",
                        "accDivingHelm",
                    ],
                    [
                        "accDreamCatcher",
                        "accDreamCatcher",
                    ],
                    [
                        "accFishFinder",
                        "accFishFinder",
                    ],
                    [
                        "accFishingBobber",
                        "accFishingBobber",
                    ],
                    [
                        "accFishingLine",
                        "accFishingLine",
                    ],
                    [
                        "accJarOfSouls",
                        "accJarOfSouls",
                    ],
                    [
                        "accLavaFishing",
                        "accLavaFishing",
                    ],
                    [
                        "accMerman",
                        "accMerman",
                    ],
                    [
                        "accOreFinder",
                        "accOreFinder",
                    ],
                    [
                        "accStopwatch",
                        "accStopwatch",
                    ],
                    [
                        "accTackleBox",
                        "accTackleBox",
                    ],
                    [
                        "accThirdEye",
                        "accThirdEye",
                    ],
                    [
                        "accWeatherRadio",
                        "accWeatherRadio",
                    ],
                    [
                        "ActuationRodLock",
                        "ActuationRodLock",
                    ],
                    [
                        "ActuationRodLockSetting",
                        "ActuationRodLockSetting",
                    ],
                    [
                        "adjHoney",
                        "adjHoney",
                    ],
                    [
                        "adjLava",
                        "adjLava",
                    ],
                    [
                        "adjShimmer",
                        "adjShimmer",
                    ],
                    [
                        "adjWater",
                        "adjWater",
                    ],
                    [
                        "alchemyTable",
                        "alchemyTable",
                    ],
                    [
                        "ammoBox",
                        "ammoBox",
                    ],
                    [
                        "ammoCost75",
                        "ammoCost75",
                    ],
                    [
                        "ammoCost80",
                        "ammoCost80",
                    ],
                    [
                        "ammoPotion",
                        "ammoPotion",
                    ],
                    [
                        "anglerSetSpawnReduction",
                        "anglerSetSpawnReduction",
                    ],
                    [
                        "archery",
                        "archery",
                    ],
                    [
                        "arcticDivingGear",
                        "arcticDivingGear",
                    ],
                    [
                        "armorEffectDrawOutlines",
                        "armorEffectDrawOutlines",
                    ],
                    [
                        "armorEffectDrawOutlinesForbidden",
                        "armorEffectDrawOutlinesForbidden",
                    ],
                    [
                        "armorEffectDrawShadow",
                        "armorEffectDrawShadow",
                    ],
                    [
                        "armorEffectDrawShadowBasilisk",
                        "armorEffectDrawShadowBasilisk",
                    ],
                    [
                        "armorEffectDrawShadowEOCShield",
                        "armorEffectDrawShadowEOCShield",
                    ],
                    [
                        "armorEffectDrawShadowLokis",
                        "armorEffectDrawShadowLokis",
                    ],
                    [
                        "armorEffectDrawShadowSubtle",
                        "armorEffectDrawShadowSubtle",
                    ],
                    [
                        "ashWoodBonus",
                        "ashWoodBonus",
                    ],
                    [
                        "ateArtisanBread",
                        "ateArtisanBread",
                    ],
                    [
                        "autoActuator",
                        "autoActuator",
                    ],
                    [
                        "autoJump",
                        "autoJump",
                    ],
                    [
                        "autoPaint",
                        "autoPaint",
                    ],
                    [
                        "autoReuseAllWeapons",
                        "autoReuseAllWeapons",
                    ],
                    [
                        "autoReuseGlove",
                        "autoReuseGlove",
                    ],
                    [
                        "babyBird",
                        "babyBird",
                    ],
                    [
                        "babyFaceMonster",
                        "babyFaceMonster",
                    ],
                    [
                        "ballistaPanic",
                        "ballistaPanic",
                    ],
                    [
                        "batsOfLight",
                        "batsOfLight",
                    ],
                    [
                        "beetleBuff",
                        "beetleBuff",
                    ],
                    [
                        "beetleDefense",
                        "beetleDefense",
                    ],
                    [
                        "beetleOffense",
                        "beetleOffense",
                    ],
                    [
                        "behindBackWall",
                        "behindBackWall",
                    ],
                    [
                        "biomeSight",
                        "biomeSight",
                    ],
                    [
                        "blackBelt",
                        "blackBelt",
                    ],
                    [
                        "blackCat",
                        "blackCat",
                    ],
                    [
                        "blackout",
                        "blackout",
                    ],
                    [
                        "bleed",
                        "bleed",
                    ],
                    [
                        "blind",
                        "blind",
                    ],
                    [
                        "blockExtraJumps",
                        "blockExtraJumps",
                    ],
                    [
                        "bloodMoonMonolithShader",
                        "bloodMoonMonolithShader",
                    ],
                    [
                        "blueFairy",
                        "blueFairy",
                    ],
                    [
                        "boneArmor",
                        "boneArmor",
                    ],
                    [
                        "brokenArmor",
                        "brokenArmor",
                    ],
                    [
                        "bunny",
                        "bunny",
                    ],
                    [
                        "burned",
                        "burned",
                    ],
                    [
                        "cactusThorns",
                        "cactusThorns",
                    ],
                    [
                        "calmed",
                        "calmed",
                    ],
                    [
                        "canCarpet",
                        "canCarpet",
                    ],
                    [
                        "canFloatInWater",
                        "canFloatInWater",
                    ],
                    [
                        "canRocket",
                        "canRocket",
                    ],
                    [
                        "CanSeeInvisibleBlocks",
                        "CanSeeInvisibleBlocks",
                    ],
                    [
                        "carpet",
                        "carpet",
                    ],
                    [
                        "cartFlip",
                        "cartFlip",
                    ],
                    [
                        "channel",
                        "channel",
                    ],
                    [
                        "chaosState",
                        "chaosState",
                    ],
                    [
                        "chilled",
                        "chilled",
                    ],
                    [
                        "chiselSpeed",
                        "chiselSpeed",
                    ],
                    [
                        "chloroAmmoCost80",
                        "chloroAmmoCost80",
                    ],
                    [
                        "coldDash",
                        "coldDash",
                    ],
                    [
                        "companionCube",
                        "companionCube",
                    ],
                    [
                        "confused",
                        "confused",
                    ],
                    [
                        "controlCreativeMenu",
                        "controlCreativeMenu",
                    ],
                    [
                        "controlDown",
                        "controlDown",
                    ],
                    [
                        "controlDownHold",
                        "controlDownHold",
                    ],
                    [
                        "controlHook",
                        "controlHook",
                    ],
                    [
                        "controlInv",
                        "controlInv",
                    ],
                    [
                        "controlJump",
                        "controlJump",
                    ],
                    [
                        "controlLeft",
                        "controlLeft",
                    ],
                    [
                        "controlMap",
                        "controlMap",
                    ],
                    [
                        "controlMount",
                        "controlMount",
                    ],
                    [
                        "controlQuickHeal",
                        "controlQuickHeal",
                    ],
                    [
                        "controlQuickMana",
                        "controlQuickMana",
                    ],
                    [
                        "controlRight",
                        "controlRight",
                    ],
                    [
                        "controlSmart",
                        "controlSmart",
                    ],
                    [
                        "controlThrow",
                        "controlThrow",
                    ],
                    [
                        "controlTorch",
                        "controlTorch",
                    ],
                    [
                        "controlUp",
                        "controlUp",
                    ],
                    [
                        "controlUseItem",
                        "controlUseItem",
                    ],
                    [
                        "controlUseTile",
                        "controlUseTile",
                    ],
                    [
                        "coolWhipBuff",
                        "coolWhipBuff",
                    ],
                    [
                        "cordage",
                        "cordage",
                    ],
                    [
                        "cratePotion",
                        "cratePotion",
                    ],
                    [
                        "creativeGodMode",
                        "creativeGodMode",
                    ],
                    [
                        "creativeInterface",
                        "creativeInterface",
                    ],
                    [
                        "crimsonHeart",
                        "crimsonHeart",
                    ],
                    [
                        "crimsonRegen",
                        "crimsonRegen",
                    ],
                    [
                        "crystalLeaf",
                        "crystalLeaf",
                    ],
                    [
                        "cSapling",
                        "cSapling",
                    ],
                    [
                        "cursed",
                        "cursed",
                    ],
                    [
                        "cursorItemIconEnabled",
                        "cursorItemIconEnabled",
                    ],
                    [
                        "cursorItemIconReversed",
                        "cursorItemIconReversed",
                    ],
                    [
                        "dangerSense",
                        "dangerSense",
                    ],
                    [
                        "dazed",
                        "dazed",
                    ],
                    [
                        "dd2Accessory",
                        "dd2Accessory",
                    ],
                    [
                        "dead",
                        "dead",
                    ],
                    [
                        "DeadlySphereMinion",
                        "DeadlySphereMinion",
                    ],
                    [
                        "defendedByPaladin",
                        "defendedByPaladin",
                    ],
                    [
                        "delayUseItem",
                        "delayUseItem",
                    ],
                    [
                        "desertBoots",
                        "desertBoots",
                    ],
                    [
                        "desertDash",
                        "desertDash",
                    ],
                    [
                        "detectCreature",
                        "detectCreature",
                    ],
                    [
                        "dino",
                        "dino",
                    ],
                    [
                        "discountAvailable",
                        "discountAvailable",
                    ],
                    [
                        "discountEquipped",
                        "discountEquipped",
                    ],
                    [
                        "dontHurtCritters",
                        "dontHurtCritters",
                    ],
                    [
                        "dontHurtNature",
                        "dontHurtNature",
                    ],
                    [
                        "dontStarveShader",
                        "dontStarveShader",
                    ],
                    [
                        "downedDD2EventAnyDifficulty",
                        "downedDD2EventAnyDifficulty",
                    ],
                    [
                        "dpsStarted",
                        "dpsStarted",
                    ],
                    [
                        "drawingFootball",
                        "drawingFootball",
                    ],
                    [
                        "dripping",
                        "dripping",
                    ],
                    [
                        "drippingSlime",
                        "drippingSlime",
                    ],
                    [
                        "drippingSparkleSlime",
                        "drippingSparkleSlime",
                    ],
                    [
                        "dryadWard",
                        "dryadWard",
                    ],
                    [
                        "eater",
                        "eater",
                    ],
                    [
                        "editedChestName",
                        "editedChestName",
                    ],
                    [
                        "electrified",
                        "electrified",
                    ],
                    [
                        "empressBlade",
                        "empressBlade",
                    ],
                    [
                        "empressBrooch",
                        "empressBrooch",
                    ],
                    [
                        "enabledSuperCart=true",
                        "enabledSuperCart=true",
                    ],
                    [
                        "enemySpawns",
                        "enemySpawns",
                    ],
                    [
                        "equippedAnyTileRangeAcc",
                        "equippedAnyTileRangeAcc",
                    ],
                    [
                        "equippedAnyTileSpeedAcc",
                        "equippedAnyTileSpeedAcc",
                    ],
                    [
                        "equippedAnyWallSpeedAcc",
                        "equippedAnyWallSpeedAcc",
                    ],
                    [
                        "extraAccessory",
                        "extraAccessory",
                    ],
                    [
                        "eyebrellaCloud",
                        "eyebrellaCloud",
                    ],
                    [
                        "eyeSpring",
                        "eyeSpring",
                    ],
                    [
                        "fairyBoots",
                        "fairyBoots",
                    ],
                    [
                        "findTreasure",
                        "findTreasure",
                    ],
                    [
                        "fireWalk",
                        "fireWalk",
                    ],
                    [
                        "flapSound",
                        "flapSound",
                    ],
                    [
                        "flinxMinion",
                        "flinxMinion",
                    ],
                    [
                        "flowerBoots",
                        "flowerBoots",
                    ],
                    [
                        "forceMerman",
                        "forceMerman",
                    ],
                    [
                        "forceWerewolf",
                        "forceWerewolf",
                    ],
                    [
                        "frogLegJumpBoost",
                        "frogLegJumpBoost",
                    ],
                    [
                        "frostArmor",
                        "frostArmor",
                    ],
                    [
                        "frostBurn",
                        "frostBurn",
                    ],
                    [
                        "frozen",
                        "frozen",
                    ],
                    [
                        "ghost",
                        "ghost",
                    ],
                    [
                        "ghostHeal",
                        "ghostHeal",
                    ],
                    [
                        "ghostHurt",
                        "ghostHurt",
                    ],
                    [
                        "gills",
                        "gills",
                    ],
                    [
                        "GoingDownWithGrapple",
                        "GoingDownWithGrapple",
                    ],
                    [
                        "goldRing",
                        "goldRing",
                    ],
                    [
                        "gravControl",
                        "gravControl",
                    ],
                    [
                        "gravControl2",
                        "gravControl2",
                    ],
                    [
                        "greenFairy",
                        "greenFairy",
                    ],
                    [
                        "grinch",
                        "grinch",
                    ],
                    [
                        "gross",
                        "gross",
                    ],
                    [
                        "happyFunTorchTime",
                        "happyFunTorchTime",
                    ],
                    [
                        "hasAngelHalo",
                        "hasAngelHalo",
                    ],
                    [
                        "hasCreditsSceneMusicBox",
                        "hasCreditsSceneMusicBox",
                    ],
                    [
                        "hasFloatingTube",
                        "hasFloatingTube",
                    ],
                    [
                        "hasFootball",
                        "hasFootball",
                    ],
                    [
                        "HasGardenGnomeNearby",
                        "HasGardenGnomeNearby",
                    ],
                    [
                        "hasLuck_LuckyCoin",
                        "hasLuck_LuckyCoin",
                    ],
                    [
                        "hasLuck_LuckyHorseshoe",
                        "hasLuck_LuckyHorseshoe",
                    ],
                    [
                        "hasLuckyCoin",
                        "hasLuckyCoin",
                    ],
                    [
                        "hasLucyTheAxe",
                        "hasLucyTheAxe",
                    ],
                    [
                        "hasMagiluminescence",
                        "hasMagiluminescence",
                    ],
                    [
                        "hasMoltenQuiver",
                        "hasMoltenQuiver",
                    ],
                    [
                        "hasPaladinShield",
                        "hasPaladinShield",
                    ],
                    [
                        "hasRainbowCursor",
                        "hasRainbowCursor",
                    ],
                    [
                        "hasRaisableShield",
                        "hasRaisableShield",
                    ],
                    [
                        "hasTitaniumStormBuff",
                        "hasTitaniumStormBuff",
                    ],
                    [
                        "hasUnicornHorn",
                        "hasUnicornHorn",
                    ],
                    [
                        "hbLocked",
                        "hbLocked",
                    ],
                    [
                        "headcovered",
                        "headcovered",
                    ],
                    [
                        "heartyMeal",
                        "heartyMeal",
                    ],
                    [
                        "hellfireTreads",
                        "hellfireTreads",
                    ],
                    [
                        "hideMerman",
                        "hideMerman",
                    ],
                    [
                        "hideWolf",
                        "hideWolf",
                    ],
                    [
                        "honey",
                        "honey",
                    ],
                    [
                        "hornet",
                        "hornet",
                    ],
                    [
                        "hornetMinion",
                        "hornetMinion",
                    ],
                    [
                        "hostile",
                        "hostile",
                    ],
                    [
                        "hungry",
                        "hungry",
                    ],
                    [
                        "huntressAmmoCost90",
                        "huntressAmmoCost90",
                    ],
                    [
                        "iceBarrier",
                        "iceBarrier",
                    ],
                    [
                        "iceSkate",
                        "iceSkate",
                    ],
                    [
                        "ichor",
                        "ichor",
                    ],
                    [
                        "ignoreWater",
                        "ignoreWater",
                    ],
                    [
                        "immune",
                        "immune",
                    ],
                    [
                        "immuneNoBlink",
                        "immuneNoBlink",
                    ],
                    [
                        "impMinion",
                        "impMinion",
                    ],
                    [
                        "inferno",
                        "inferno",
                    ],
                    [
                        "InfoAccMechShowWires",
                        "InfoAccMechShowWires",
                    ],
                    [
                        "invis",
                        "invis",
                    ],
                    [
                        "isControlledByFilm",
                        "isControlledByFilm",
                    ],
                    [
                        "isDisplayDollOrInanimate",
                        "isDisplayDollOrInanimate",
                    ],
                    [
                        "isFirstFractalAfterImage",
                        "isFirstFractalAfterImage",
                    ],
                    [
                        "isFullbright",
                        "isFullbright",
                    ],
                    [
                        "isHatRackDoll",
                        "isHatRackDoll",
                    ],
                    [
                        "isOperatingAnotherEntity",
                        "isOperatingAnotherEntity",
                    ],
                    [
                        "isPerformingPogostickTricks",
                        "isPerformingPogostickTricks",
                    ],
                    [
                        "isPettingAnimal",
                        "isPettingAnimal",
                    ],
                    [
                        "isTheAnimalBeingPetSmall",
                        "isTheAnimalBeingPetSmall",
                    ],
                    [
                        "jumpBoost",
                        "jumpBoost",
                    ],
                    [
                        "JustDroppedAnItem",
                        "JustDroppedAnItem",
                    ],
                    [
                        "justJumped",
                        "justJumped",
                    ],
                    [
                        "kbBuff",
                        "kbBuff",
                    ],
                    [
                        "kbGlove",
                        "kbGlove",
                    ],
                    [
                        "killClothier",
                        "killClothier",
                    ],
                    [
                        "killGuide",
                        "killGuide",
                    ],
                    [
                        "lastMouseInterface",
                        "lastMouseInterface",
                    ],
                    [
                        "lastStoned",
                        "lastStoned",
                    ],
                    [
                        "lavaImmune",
                        "lavaImmune",
                    ],
                    [
                        "lavaRose",
                        "lavaRose",
                    ],
                    [
                        "leinforsHair",
                        "leinforsHair",
                    ],
                    [
                        "lifeForce",
                        "lifeForce",
                    ],
                    [
                        "lifeMagnet",
                        "lifeMagnet",
                    ],
                    [
                        "lightOrb",
                        "lightOrb",
                    ],
                    [
                        "lizard",
                        "lizard",
                    ],
                    [
                        "longInvince",
                        "longInvince",
                    ],
                    [
                        "loveStruck",
                        "loveStruck",
                    ],
                    [
                        "luckNeedsSync",
                        "luckNeedsSync",
                    ],
                    [
                        "magicCuffs",
                        "magicCuffs",
                    ],
                    [
                        "magicLantern",
                        "magicLantern",
                    ],
                    [
                        "magicQuiver",
                        "magicQuiver",
                    ],
                    [
                        "magmaStone",
                        "magmaStone",
                    ],
                    [
                        "manaFlower",
                        "manaFlower",
                    ],
                    [
                        "manaMagnet",
                        "manaMagnet",
                    ],
                    [
                        "manaRegenBuff",
                        "manaRegenBuff",
                    ],
                    [
                        "manaSick",
                        "manaSick",
                    ],
                    [
                        "mapAlphaDown",
                        "mapAlphaDown",
                    ],
                    [
                        "mapAlphaUp",
                        "mapAlphaUp",
                    ],
                    [
                        "mapFullScreen",
                        "mapFullScreen",
                    ],
                    [
                        "mapStyle",
                        "mapStyle",
                    ],
                    [
                        "mapZoomIn",
                        "mapZoomIn",
                    ],
                    [
                        "mapZoomOut",
                        "mapZoomOut",
                    ],
                    [
                        "meleeScaleGlove",
                        "meleeScaleGlove",
                    ],
                    [
                        "merman",
                        "merman",
                    ],
                    [
                        "minecartLeft",
                        "minecartLeft",
                    ],
                    [
                        "miniMinotaur",
                        "miniMinotaur",
                    ],
                    [
                        "moonLeech",
                        "moonLeech",
                    ],
                    [
                        "moonLordLegs",
                        "moonLordLegs",
                    ],
                    [
                        "moonLordMonolithShader",
                        "moonLordMonolithShader",
                    ],
                    [
                        "mouseInterface",
                        "mouseInterface",
                    ],
                    [
                        "nebulaMonolithShader",
                        "nebulaMonolithShader",
                    ],
                    [
                        "netLife",
                        "netLife",
                    ],
                    [
                        "netMana",
                        "netMana",
                    ],
                    [
                        "nightVision",
                        "nightVision",
                    ],
                    [
                        "noBuilding",
                        "noBuilding",
                    ],
                    [
                        "noFallDmg",
                        "noFallDmg",
                    ],
                    [
                        "noItems",
                        "noItems",
                    ],
                    [
                        "noKnockback",
                        "noKnockback",
                    ],
                    [
                        "oldAdjHoney",
                        "oldAdjHoney",
                    ],
                    [
                        "oldAdjLava",
                        "oldAdjLava",
                    ],
                    [
                        "oldAdjShimmer",
                        "oldAdjShimmer",
                    ],
                    [
                        "oldAdjWater",
                        "oldAdjWater",
                    ],
                    [
                        "onFire",
                        "onFire",
                    ],
                    [
                        "onFire2",
                        "onFire2",
                    ],
                    [
                        "onFire3",
                        "onFire3",
                    ],
                    [
                        "onFrostBurn",
                        "onFrostBurn",
                    ],
                    [
                        "onFrostBurn2",
                        "onFrostBurn2",
                    ],
                    [
                        "onHitDodge",
                        "onHitDodge",
                    ],
                    [
                        "onHitPetal",
                        "onHitPetal",
                    ],
                    [
                        "onHitRegen",
                        "onHitRegen",
                    ],
                    [
                        "onHitTitaniumStorm",
                        "onHitTitaniumStorm",
                    ],
                    [
                        "onTrack",
                        "onTrack",
                    ],
                    [
                        "onWrongGround",
                        "onWrongGround",
                    ],
                    [
                        "outOfRange",
                        "outOfRange",
                    ],
                    [
                        "palladiumRegen",
                        "palladiumRegen",
                    ],
                    [
                        "panic",
                        "panic",
                    ],
                    [
                        "parrot",
                        "parrot",
                    ],
                    [
                        "parryDamageBuff",
                        "parryDamageBuff",
                    ],
                    [
                        "penguin",
                        "penguin",
                    ],
                    [
                        "petFlagBabyImp",
                        "petFlagBabyImp",
                    ],
                    [
                        "petFlagBabyRedPanda",
                        "petFlagBabyRedPanda",
                    ],
                    [
                        "petFlagBabyShark",
                        "petFlagBabyShark",
                    ],
                    [
                        "petFlagBabyWerewolf",
                        "petFlagBabyWerewolf",
                    ],
                    [
                        "petFlagBerniePet",
                        "petFlagBerniePet",
                    ],
                    [
                        "petFlagBlueChickenPet",
                        "petFlagBlueChickenPet",
                    ],
                    [
                        "petFlagBrainOfCthulhuPet",
                        "petFlagBrainOfCthulhuPet",
                    ],
                    [
                        "petFlagCaveling",
                        "petFlagCaveling",
                    ],
                    [
                        "petFlagChesterPet",
                        "petFlagChesterPet",
                    ],
                    [
                        "petFlagDD2BetsyPet",
                        "petFlagDD2BetsyPet",
                    ],
                    [
                        "petFlagDD2Dragon",
                        "petFlagDD2Dragon",
                    ],
                    [
                        "petFlagDD2Gato",
                        "petFlagDD2Gato",
                    ],
                    [
                        "petFlagDD2Ghost",
                        "petFlagDD2Ghost",
                    ],
                    [
                        "petFlagDD2OgrePet",
                        "petFlagDD2OgrePet",
                    ],
                    [
                        "petFlagDeerclopsPet",
                        "petFlagDeerclopsPet",
                    ],
                    [
                        "petFlagDestroyerPet",
                        "petFlagDestroyerPet",
                    ],
                    [
                        "petFlagDirtiestBlock",
                        "petFlagDirtiestBlock",
                    ],
                    [
                        "petFlagDukeFishronPet",
                        "petFlagDukeFishronPet",
                    ],
                    [
                        "petFlagDynamiteKitten",
                        "petFlagDynamiteKitten",
                    ],
                    [
                        "petFlagEaterOfWorldsPet",
                        "petFlagEaterOfWorldsPet",
                    ],
                    [
                        "petFlagEverscreamPet",
                        "petFlagEverscreamPet",
                    ],
                    [
                        "petFlagEyeOfCthulhuPet",
                        "petFlagEyeOfCthulhuPet",
                    ],
                    [
                        "petFlagFairyQueenPet",
                        "petFlagFairyQueenPet",
                    ],
                    [
                        "petFlagFennecFox",
                        "petFlagFennecFox",
                    ],
                    [
                        "petFlagGlitteryButterfly",
                        "petFlagGlitteryButterfly",
                    ],
                    [
                        "petFlagGlommerPet",
                        "petFlagGlommerPet",
                    ],
                    [
                        "petFlagGolemPet",
                        "petFlagGolemPet",
                    ],
                    [
                        "petFlagIceQueenPet",
                        "petFlagIceQueenPet",
                    ],
                    [
                        "petFlagJunimoPet",
                        "petFlagJunimoPet",
                    ],
                    [
                        "petFlagKingSlimePet",
                        "petFlagKingSlimePet",
                    ],
                    [
                        "petFlagLilHarpy",
                        "petFlagLilHarpy",
                    ],
                    [
                        "petFlagLunaticCultistPet",
                        "petFlagLunaticCultistPet",
                    ],
                    [
                        "petFlagMartianPet",
                        "petFlagMartianPet",
                    ],
                    [
                        "petFlagMoonLordPet",
                        "petFlagMoonLordPet",
                    ],
                    [
                        "petFlagPigPet",
                        "petFlagPigPet",
                    ],
                    [
                        "petFlagPlanteraPet",
                        "petFlagPlanteraPet",
                    ],
                    [
                        "petFlagPlantero",
                        "petFlagPlantero",
                    ],
                    [
                        "petFlagPumpkingPet",
                        "petFlagPumpkingPet",
                    ],
                    [
                        "petFlagQueenBeePet",
                        "petFlagQueenBeePet",
                    ],
                    [
                        "petFlagQueenSlimePet",
                        "petFlagQueenSlimePet",
                    ],
                    [
                        "petFlagShadowMimic",
                        "petFlagShadowMimic",
                    ],
                    [
                        "petFlagSkeletronPet",
                        "petFlagSkeletronPet",
                    ],
                    [
                        "petFlagSkeletronPrimePet",
                        "petFlagSkeletronPrimePet",
                    ],
                    [
                        "petFlagSpiffo",
                        "petFlagSpiffo",
                    ],
                    [
                        "petFlagSugarGlider",
                        "petFlagSugarGlider",
                    ],
                    [
                        "petFlagTwinsPet",
                        "petFlagTwinsPet",
                    ],
                    [
                        "petFlagUpbeatStar",
                        "petFlagUpbeatStar",
                    ],
                    [
                        "petFlagVoltBunny",
                        "petFlagVoltBunny",
                    ],
                    [
                        "pirateMinion",
                        "pirateMinion",
                    ],
                    [
                        "poisoned",
                        "poisoned",
                    ],
                    [
                        "portalPhysicsFlag",
                        "portalPhysicsFlag",
                    ],
                    [
                        "poundRelease",
                        "poundRelease",
                    ],
                    [
                        "powerrun",
                        "powerrun",
                    ],
                    [
                        "preventAllItemPickups",
                        "preventAllItemPickups",
                    ],
                    [
                        "pStone",
                        "pStone",
                    ],
                    [
                        "pulley",
                        "pulley",
                    ],
                    [
                        "puppy",
                        "puppy",
                    ],
                    [
                        "pvpDeath",
                        "pvpDeath",
                    ],
                    [
                        "pygmy",
                        "pygmy",
                    ],
                    [
                        "rabid",
                        "rabid",
                    ],
                    [
                        "raven",
                        "raven",
                    ],
                    [
                        "redFairy",
                        "redFairy",
                    ],
                    [
                        "releaseCreativeMenu",
                        "releaseCreativeMenu",
                    ],
                    [
                        "releaseDown",
                        "releaseDown",
                    ],
                    [
                        "releaseHook",
                        "releaseHook",
                    ],
                    [
                        "releaseInventory",
                        "releaseInventory",
                    ],
                    [
                        "releaseJump",
                        "releaseJump",
                    ],
                    [
                        "releaseLeft",
                        "releaseLeft",
                    ],
                    [
                        "releaseMapFullscreen",
                        "releaseMapFullscreen",
                    ],
                    [
                        "releaseMapStyle",
                        "releaseMapStyle",
                    ],
                    [
                        "releaseMount",
                        "releaseMount",
                    ],
                    [
                        "releaseQuickHeal",
                        "releaseQuickHeal",
                    ],
                    [
                        "releaseQuickMana",
                        "releaseQuickMana",
                    ],
                    [
                        "releaseRight",
                        "releaseRight",
                    ],
                    [
                        "releaseSmart",
                        "releaseSmart",
                    ],
                    [
                        "releaseThrow",
                        "releaseThrow",
                    ],
                    [
                        "releaseUp",
                        "releaseUp",
                    ],
                    [
                        "releaseUseItem",
                        "releaseUseItem",
                    ],
                    [
                        "releaseUseTile",
                        "releaseUseTile",
                    ],
                    [
                        "remoteVisionForDrone",
                        "remoteVisionForDrone",
                    ],
                    [
                        "resistCold",
                        "resistCold",
                    ],
                    [
                        "rocketFrame",
                        "rocketFrame",
                    ],
                    [
                        "rocketRelease",
                        "rocketRelease",
                    ],
                    [
                        "rulerGrid",
                        "rulerGrid",
                    ],
                    [
                        "rulerLine",
                        "rulerLine",
                    ],
                    [
                        "runningOnSand",
                        "runningOnSand",
                    ],
                    [
                        "sailDash",
                        "sailDash",
                    ],
                    [
                        "sapling",
                        "sapling",
                    ],
                    [
                        "scope",
                        "scope",
                    ],
                    [
                        "selectItemOnNextUse",
                        "selectItemOnNextUse",
                    ],
                    [
                        "setApprenticeT2",
                        "setApprenticeT2",
                    ],
                    [
                        "setApprenticeT3",
                        "setApprenticeT3",
                    ],
                    [
                        "setForbidden",
                        "setForbidden",
                    ],
                    [
                        "setForbiddenCooldownLocked",
                        "setForbiddenCooldownLocked",
                    ],
                    [
                        "setHuntressT2",
                        "setHuntressT2",
                    ],
                    [
                        "setHuntressT3",
                        "setHuntressT3",
                    ],
                    [
                        "setMonkT2",
                        "setMonkT2",
                    ],
                    [
                        "setMonkT3",
                        "setMonkT3",
                    ],
                    [
                        "setNebula",
                        "setNebula",
                    ],
                    [
                        "setSolar",
                        "setSolar",
                    ],
                    [
                        "setSquireT2",
                        "setSquireT2",
                    ],
                    [
                        "setSquireT3",
                        "setSquireT3",
                    ],
                    [
                        "setStardust",
                        "setStardust",
                    ],
                    [
                        "setVortex",
                        "setVortex",
                    ],
                    [
                        "shadowArmor",
                        "shadowArmor",
                    ],
                    [
                        "shadowDodge",
                        "shadowDodge",
                    ],
                    [
                        "sharknadoMinion",
                        "sharknadoMinion",
                    ],
                    [
                        "shieldRaised",
                        "shieldRaised",
                    ],
                    [
                        "shimmerImmune",
                        "shimmerImmune",
                    ],
                    [
                        "shimmering",
                        "shimmering",
                    ],
                    [
                        "shimmerMonolithShader",
                        "shimmerMonolithShader",
                    ],
                    [
                        "shinyStone",
                        "shinyStone",
                    ],
                    [
                        "showLastDeath",
                        "showLastDeath",
                    ],
                    [
                        "shroomiteStealth",
                        "shroomiteStealth",
                    ],
                    [
                        "silence",
                        "silence",
                    ],
                    [
                        "skeletron",
                        "skeletron",
                    ],
                    [
                        "skipAnimatingValuesInPlayerFrame",
                        "skipAnimatingValuesInPlayerFrame",
                    ],
                    [
                        "skyStoneEffects",
                        "skyStoneEffects",
                    ],
                    [
                        "sliding",
                        "sliding",
                    ],
                    [
                        "slime",
                        "slime",
                    ],
                    [
                        "slippy",
                        "slippy",
                    ],
                    [
                        "slippy2",
                        "slippy2",
                    ],
                    [
                        "sloping",
                        "sloping",
                    ],
                    [
                        "slow",
                        "slow",
                    ],
                    [
                        "slowFall",
                        "slowFall",
                    ],
                    [
                        "slowOgreSpit",
                        "slowOgreSpit",
                    ],
                    [
                        "smolstar",
                        "smolstar",
                    ],
                    [
                        "snowman",
                        "snowman",
                    ],
                    [
                        "socialGhost",
                        "socialGhost",
                    ],
                    [
                        "socialIgnoreLight",
                        "socialIgnoreLight",
                    ],
                    [
                        "socialShadowRocketBoots",
                        "socialShadowRocketBoots",
                    ],
                    [
                        "solarDashConsumedFlare",
                        "solarDashConsumedFlare",
                    ],
                    [
                        "solarDashing",
                        "solarDashing",
                    ],
                    [
                        "solarMonolithShader",
                        "solarMonolithShader",
                    ],
                    [
                        "sonarPotion",
                        "sonarPotion",
                    ],
                    [
                        "spaceGun",
                        "spaceGun",
                    ],
                    [
                        "spawnMax",
                        "spawnMax",
                    ],
                    [
                        "spider",
                        "spider",
                    ],
                    [
                        "spiderArmor",
                        "spiderArmor",
                    ],
                    [
                        "spiderMinion",
                        "spiderMinion",
                    ],
                    [
                        "sporeSac",
                        "sporeSac",
                    ],
                    [
                        "squashling",
                        "squashling",
                    ],
                    [
                        "stairFall",
                        "stairFall",
                    ],
                    [
                        "stardustDragon",
                        "stardustDragon",
                    ],
                    [
                        "stardustGuardian",
                        "stardustGuardian",
                    ],
                    [
                        "stardustMinion",
                        "stardustMinion",
                    ],
                    [
                        "stardustMonolithShader",
                        "stardustMonolithShader",
                    ],
                    [
                        "starving",
                        "starving",
                    ],
                    [
                        "sticky",
                        "sticky",
                    ],
                    [
                        "stinky",
                        "stinky",
                    ],
                    [
                        "stoned",
                        "stoned",
                    ],
                    [
                        "stormTiger",
                        "stormTiger",
                    ],
                    [
                        "strongBees",
                        "strongBees",
                    ],
                    [
                        "suffocating",
                        "suffocating",
                    ],
                    [
                        "sunflower",
                        "sunflower",
                    ],
                    [
                        "suspiciouslookingTentacle",
                        "suspiciouslookingTentacle",
                    ],
                    [
                        "tankPetReset",
                        "tankPetReset",
                    ],
                    [
                        "teleporting",
                        "teleporting",
                    ],
                    [
                        "tiki",
                        "tiki",
                    ],
                    [
                        "tileInteractAttempted",
                        "tileInteractAttempted",
                    ],
                    [
                        "tileInteractionHappened",
                        "tileInteractionHappened",
                    ],
                    [
                        "tipsy",
                        "tipsy",
                    ],
                    [
                        "tongued",
                        "tongued",
                    ],
                    [
                        "trapDebuffSource",
                        "trapDebuffSource",
                    ],
                    [
                        "treasureMagnet",
                        "treasureMagnet",
                    ],
                    [
                        "trident",
                        "trident",
                    ],
                    [
                        "truffle",
                        "truffle",
                    ],
                    [
                        "tryKeepingHoveringDown",
                        "tryKeepingHoveringDown",
                    ],
                    [
                        "tryKeepingHoveringUp",
                        "tryKeepingHoveringUp",
                    ],
                    [
                        "turtle",
                        "turtle",
                    ],
                    [
                        "turtleArmor",
                        "turtleArmor",
                    ],
                    [
                        "turtleThorns",
                        "turtleThorns",
                    ],
                    [
                        "twinsMinion",
                        "twinsMinion",
                    ],
                    [
                        "UFOMinion",
                        "UFOMinion",
                    ],
                    [
                        "unlockedBiomeTorches",
                        "unlockedBiomeTorches",
                    ],
                    [
                        "unlockedSuperCart",
                        "unlockedSuperCart",
                    ],
                    [
                        "usedAegisCrystal",
                        "usedAegisCrystal",
                    ],
                    [
                        "usedAegisFruit",
                        "usedAegisFruit",
                    ],
                    [
                        "usedAmbrosia",
                        "usedAmbrosia",
                    ],
                    [
                        "usedArcaneCrystal",
                        "usedArcaneCrystal",
                    ],
                    [
                        "usedGalaxyPearl",
                        "usedGalaxyPearl",
                    ],
                    [
                        "usedGummyWorm",
                        "usedGummyWorm",
                    ],
                    [
                        "vampireFrog",
                        "vampireFrog",
                    ],
                    [
                        "venom",
                        "venom",
                    ],
                    [
                        "volatileGelatin",
                        "volatileGelatin",
                    ],
                    [
                        "vortexDebuff",
                        "vortexDebuff",
                    ],
                    [
                        "vortexMonolithShader",
                        "vortexMonolithShader",
                    ],
                    [
                        "vortexStealthActive",
                        "vortexStealthActive",
                    ],
                    [
                        "waterWalk",
                        "waterWalk",
                    ],
                    [
                        "waterWalk2",
                        "waterWalk2",
                    ],
                    [
                        "wearsRobe",
                        "wearsRobe",
                    ],
                    [
                        "webbed",
                        "webbed",
                    ],
                    [
                        "wellFed",
                        "wellFed",
                    ],
                    [
                        "wereWolf",
                        "wereWolf",
                    ],
                    [
                        "windPushed",
                        "windPushed",
                    ],
                    [
                        "wisp",
                        "wisp",
                    ],
                    [
                        "witheredArmor",
                        "witheredArmor",
                    ],
                    [
                        "witheredWeapon",
                        "witheredWeapon",
                    ],
                    [
                        "wolfAcc",
                        "wolfAcc",
                    ],
                    [
                        "yoraiz0rDarkness",
                        "yoraiz0rDarkness",
                    ],
                    [
                        "yoyoGlove",
                        "yoyoGlove",
                    ],
                    [
                        "yoyoString",
                        "yoyoString",
                    ],
                    [
                        "zephyrfish",
                        "zephyrfish",
                    ]
                ]
            }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": 330,
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