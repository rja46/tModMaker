using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_solution
{
    public partial class loadCreateModDialog : Form
    {
        public Mod theMod;
        public loadCreateModDialog()
        {
            InitializeComponent();
        }

        private void btnLoadMod_Click(object sender, EventArgs e)
        {
            string modDetails;
            string[] modDetailsSplit;
            string[] existingFiles;
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    existingFiles = Directory.GetFiles(folderDialog.SelectedPath);
                    if (existingFiles.Length != 1)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        modDetails = File.ReadAllText(existingFiles[0]);
                        modDetailsSplit = modDetails.Split('|');
                        theMod = new Mod(modDetailsSplit[0], folderDialog.SelectedPath);
                        theMod.set_description(modDetailsSplit[1]);
                        theMod.set_author(modDetailsSplit[2]);
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Please select a valid folder");
                }
            }
        }

        private void btnCreateMod_Click(object sender, EventArgs e)
        {
            CreateModDialog createModDialog = new CreateModDialog();
            DialogResult result = createModDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                theMod = createModDialog.theMod;
                this.Close();
            }
        }
    }
}
