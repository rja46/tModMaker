using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_solution
{
    public partial class CreateModDialog : Form
    {
        public Mod theMod;
        private string thePath;
        public CreateModDialog()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnFileLocation.Text = "Save Location";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            theMod = new Mod(txtName.Text, thePath + "\\" + txtName.Text);
        }

        private void btnFileLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                thePath = folderDialog.SelectedPath;
                Console.WriteLine(thePath);
            }
        }
    }
}
