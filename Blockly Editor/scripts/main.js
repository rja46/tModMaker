  const toolbox = {
  "kind": "flyoutToolbox",
    "contents": [
      {
        "kind": "block",
        "type": "controls_if"
      },
      {
        "kind": "block",
        "type": "define_weapon_essential"
      }

  ]
};

Blockly.common.defineBlocksWithJsonArray([
{
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
}
]);

Blockly.inject('blocklyDiv', {
  toolbox: toolbox,
  scrollbars: false,
  horizontalLayout: true,
  toolboxPosition: "left",
});