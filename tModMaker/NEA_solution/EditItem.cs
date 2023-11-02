using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_solution
{
    public partial class EditItem : Form
    {
        private string code;
        public Item theItem;
        private string thePath;

        public EditItem(Item loadedItem, string path)
        {
            theItem = loadedItem;
            thePath = path;
            InitializeComponent();
            InitWebview();
            txtDisplayName.Text = theItem.get_displayName();
            txtTooltip.Text = theItem.get_tooltip();
            cbType.Text = theItem.get_type();
            pbSprite.Image = theItem.get_sprite();
            pbSprite.Refresh();
            //need to adjust the scaling mode on the picture box to avoid the existing blurryness.
            //sendData();

        }
        async void InitWebview()
        {
            await webViewCode.EnsureCoreWebView2Async();
        }

        async void sendData()
        {
            await webViewCode.ExecuteScriptAsync("loadData(" + theItem.get_code() + ")");
        }

        public async void requestData()
        {
            await webViewCode.ExecuteScriptAsync("sendDataToWinForm()");
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
                    theItem.set_sprite(new Bitmap(@openSpriteDialog.FileName));
                    pbSprite.Image = theItem.get_sprite();
                    pbSprite.Refresh();
                }
            }
        }

        public void save_item()
        {
            requestData();
            theItem.set_code(code);
            theItem.set_display_name(txtDisplayName.Text);
            theItem.set_tooltip(txtTooltip.Text);
            theItem.set_type(cbType.Text);
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            FullscreenEditor fullscreenEditor = new FullscreenEditor();
            fullscreenEditor.Show();
        }
    }
}
