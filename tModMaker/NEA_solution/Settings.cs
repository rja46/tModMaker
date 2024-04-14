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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Xml.Linq;
using System.Reflection;

namespace NEA_solution
{
    public partial class Settings : Form
    {
        string path;
        string filePath = Environment.CurrentDirectory + "\\userConfig.txt";
        public Settings()
        {
            InitializeComponent();
            txtPath.Text = File.ReadAllText(filePath);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnApply.Enabled = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Console.WriteLine(filePath);
            File.WriteAllText(filePath, txtPath.Text);
            //Disabling the button makes it clear to the user that the changes have been applied.
            btnApply.Enabled = false;
        }

        private void btnFolderDialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderDialog.SelectedPath;
                txtPath.Text = path;
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }
    }
}
