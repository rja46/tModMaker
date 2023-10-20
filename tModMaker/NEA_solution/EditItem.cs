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
    public partial class EditItem : Form
    {
        private string code;
        public Item theItem;

        public EditItem(Item loadedItem)
        {
            theItem = loadedItem;
            InitializeComponent();
            InitWebview();
            txtDisplayName.Text = theItem.get_displayName();
            txtTooltip.Text = theItem.get_tooltip();
            cbType.Text = theItem.get_type();
        }

        async void InitWebview()
        {
            await webViewCode.EnsureCoreWebView2Async();
        }

        public async void requestData()
        {
            await webViewCode.ExecuteScriptAsync("sendDataToWinForm()");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            requestData();
            theItem.set_code(code);
            theItem.set_display_name(txtDisplayName.Text);
            theItem.set_tooltip(txtTooltip.Text);
            theItem.set_type(cbType.Text);
        }

        private void webViewCode_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            code = e.TryGetWebMessageAsString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeSprite_Click(object sender, EventArgs e)
        {
            if (theItem != null)
            {
                OpenFileDialog openSpriteDialog = new OpenFileDialog();
                openSpriteDialog.InitialDirectory = "c:\\";
                openSpriteDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                if (openSpriteDialog.ShowDialog() == DialogResult.OK)
                {
                    theItem.set_sprite_path(@openSpriteDialog.FileName);
                    pbSprite.ImageLocation = theItem.get_sprite_path();
                    pbSprite.Refresh();
                }
            }
        }
    }
}
