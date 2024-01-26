using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;

namespace NEA_solution
{
    internal class CodeGenerator
    {
        public string generate_code(string code, string modName, string itemName, string itemDisplayName)
        {
            string blockType;
            string[] blocksAsStrings;
            string setDefaults = "";

            string generatedCode = "using Terraria;" +
                "\r\nusing Terraria.ID;" +
                "\r\nusing Terraria.ModLoader;" +
                "\r\nnamespace " + modName + ".Items" +
                "\r\n{" +
                "\r\n\tpublic class " + itemName + " : ModItem" +
                "\r\n\t{";

            blocksAsStrings = findBlocksInline(code);

            for (int i = 0; i < blocksAsStrings.Length; i++)
            {
                blockType = JsonSerializer.Deserialize<GenericBlock>(blocksAsStrings[i]).type;
                MessageBox.Show(blockType);
                switch (blockType)
                {
                    case "define_weapon_essential":

                        define_weapon_essential currentBlock = JsonSerializer.Deserialize<define_weapon_essential>(blocksAsStrings[i]);

                        setDefaults += "Item.damage = " + currentBlock.damage + ";";
                        setDefaults += "\r\nItem.DamageType = DamageClass." + currentBlock.damageType + ";";
                        setDefaults += "\r\nItem.width = " + currentBlock.width + ";";
                        setDefaults += "\r\nItem.height = " + currentBlock.height + ";";
                        setDefaults += "\r\nItem.useTime = " + currentBlock.useTime + ";";
                        setDefaults += "\r\nItem.useAnimation = " + currentBlock.useAnimation + ";";
                        setDefaults += "\r\nItem.knockBack = " + currentBlock.knockback + ";";
                        setDefaults += "\r\nItem.value = " + currentBlock.value + ";";
                        setDefaults += "\r\nItem.rare = " + currentBlock.rare + ";";
                        setDefaults += "\r\nItem.UseSound = SoundID.Item" + currentBlock.UseSound + ";";
                        setDefaults += "\r\nItem.autoReuse = " + currentBlock.autoReuse + ";";
                        setDefaults += "\r\nItem.useStyle = " + currentBlock.useStyle + ";";

                        break;
                }
            }

            generatedCode += "public override void SetDefaults() {" + setDefaults + "}";
            return generatedCode;
        }

        private static string[] findBlocksInline(string contents)
        {
            List<string> blocksList = new List<string>();

            string reader = "";
            bool reading = false;
            int count = 0;

            for (int i = 0; i < contents.Length; i++)
            {
                reader += contents[i];
                if (reader.Contains("\"blocks\":[") || reader.Contains("\"block\":"))
                {
                    reader = "";
                    reading = true;
                }

                if (reader.Contains(",") && reading)
                {
                    reading = false;
                    blocksList.Add(reader);
                }
            }

            for (int i = 0; i < contents.Length; i++)
            {
                reader += contents[i];
                if (reader.Contains("\"fields\":{"))
                {
                    reader = "";
                    reading = true;
                }

                if (reader.Contains("}") && reading)
                {
                    reading = false;
                    blocksList[count] += (reader);
                    count++;
                }
            }


            string[] blocks = blocksList.ToArray();
            return blocks;
        }
    }
}
