using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace NEA_solution
{
    internal class CodeGenerator
    {
        public string generate_code(string code, string modName, string itemName, string itemDisplayName)
        {
            string blockType;
            string[] blocks;
            GenericBlock block;

            string generatedCode = "using Terraria;" +
                "\r\nusing Terraria.ID;" +
                "\r\nusing Terraria.ModLoader;" +
                "\r\nnamespace " + modName + ".Items" +
                "\r\n{" +
                "\r\n\tpublic class " + itemName + " : ModItem" +
                "\r\n\t{";

            blocks = findBlocksInline(code);

            block = JsonSerializer.Deserialize<GenericBlock>

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
