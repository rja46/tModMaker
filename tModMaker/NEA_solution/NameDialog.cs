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
    public partial class NameDialog : Form
    {
        public string name;
        public NameDialog()
        {
            InitializeComponent();
        }

        private void NameDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtName.Text != "")
            {
                name = txtName.Text;
            }
            else
            {
                MessageBox.Show("Please enter a valid name");
                e.Cancel = true;
            }
        }
    }
}
