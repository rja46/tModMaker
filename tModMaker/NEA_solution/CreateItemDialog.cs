using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_solution
{
    public partial class CreateItemDialog : Form
    {
        public Item newItem;
        public CreateItemDialog()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length != 0 && cbType.SelectedIndex != -1)
            {
                newItem = new Item(txtName.Text, cbType.Text);
                newItem.set_display_name(txtDisplayName.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please enter all values");
            }
        }
    }
}
