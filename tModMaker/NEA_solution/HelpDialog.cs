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
    public partial class HelpDialog : Form
    {
        public HelpDialog()
        {
            InitializeComponent();
            webView21.Source = new Uri(Environment.CurrentDirectory + "\\Help Pages\\AddItemHelp.html");
        }

        //When the item is double clicked, the corresponding page is loaded.
        private void lbMenu_DoubleClick(object sender, EventArgs e)
        {
            if (lbMenu.SelectedIndex == 0)
            {
                webView21.Source = new Uri(Environment.CurrentDirectory + "\\Help Pages\\AddItemHelp.html");
            }
            else if (lbMenu.SelectedIndex == 1)
            {
                webView21.Source = new Uri(Environment.CurrentDirectory + "\\Help Pages\\EditItemHelp.html");
            }
            else if (lbMenu.SelectedIndex == 2)
            {
                webView21.Source = new Uri(Environment.CurrentDirectory + "\\Help Pages\\EditModHelp.html");
            }
            else if (lbMenu.SelectedIndex == 3)
            {
                webView21.Source = new Uri(Environment.CurrentDirectory + "\\Help Pages\\ExportModHelp.html");
            }
        }
    }
}
