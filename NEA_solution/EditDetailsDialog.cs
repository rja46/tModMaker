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
        public EditDetailsDialog(string name, string author, string description)
        {
            InitializeComponent();
            txtAuthor.Text = author;
            txtDescription.Text = description;
            txtName.Text = name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            name = txtName.Text;
            description = txtDescription.Text;
            author = txtAuthor.Text;
        }
    }
}
