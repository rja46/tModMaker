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
    public partial class EditDetailsDialog : Form
    {
        public string name;
        public string description;
        public string author;
        public double version;
        public EditDetailsDialog(string name, string author, string description, double version)
        {
            InitializeComponent();
            txtAuthor.Text = author;
            txtDescription.Text = description;
            txtName.Text = name;
            numVersion.Value = (decimal)version;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            name = txtName.Text;
            description = txtDescription.Text;
            author = txtAuthor.Text;
            version = (double)numVersion.Value;
        }
    }
}
