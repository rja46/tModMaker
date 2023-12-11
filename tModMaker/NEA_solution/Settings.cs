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
        public Settings()
        {
            InitializeComponent();
            txtPath.Text = File.ReadAllText(@"userConfig.txt");
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"userConfig.txt");
            File.WriteAllText(filePath, txtPath.Text);
        }

        private void btnFolderDialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderDialog.SelectedPath;
            }

            txtPath.Text = path;
        }
    }
}
