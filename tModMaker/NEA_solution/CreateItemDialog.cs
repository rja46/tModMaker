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
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //This ensures the needed values are entered before creating a new item using them.
            if (txtName.Text.Length != 0 && cbType.SelectedIndex != -1)
            {
                newItem = new Item(txtName.Text, cbType.Text);
                newItem.set_display_name(txtDisplayName.Text);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please enter all values");
            }
        }
    }
}
