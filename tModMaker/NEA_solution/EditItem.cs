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
                    if (!Directory.Exists(thePath + "\\Items\\Sprites"))
                    {
                        Directory.CreateDirectory(thePath + "\\Items\\Sprites");
                    }
                    pbSprite.Image = new Bitmap(@openSpriteDialog.FileName);
                    pbSprite.Refresh();
                    pbSprite.Image.Save(thePath + "\\Items\\Sprites\\" + theItem.get_name() + ".png");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // the button has to be pressed twice. i do not know why. repeating the processes inside the event does nothing
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
