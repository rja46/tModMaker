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
    public partial class loadCreateModDialog : Form
    {
        public Mod theMod;
        public loadCreateModDialog()
        {
            InitializeComponent();
        }

        private void btnLoadMod_Click(object sender, EventArgs e)
        {
            //open file browser
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
