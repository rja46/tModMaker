using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Xml.Linq;
using Microsoft.Web.WebView2.Core;
using System.Threading;

namespace NEA_solution
{
    public partial class EditItem : Form
    {
        bool isChanged;
        private string code;
        public Item theItem;
        bool returned;

        public EditItem(Item loadedItem, string path)
        {
            InitializeComponent();
            InitWebview();
            wvCode.Source = new Uri("C:\\Users\\rjand\\Documents\\GitHub\\tModMaker\\Blockly Editor\\tool_editor.html");
            theItem = loadedItem;
            txtDisplayName.Text = theItem.get_displayName();
            txtTooltip.Text = theItem.get_tooltip();
            cbType.Text = theItem.get_type();
            pbSprite.Refresh();
            isChanged = false;
        }

        async void InitWebview()
        {
            Controls.Add(wvCode);
            wvCode.Enabled = true;
            await wvCode.EnsureCoreWebView2Async(null);
        }

        async void requestData()
        {
            await wvCode.ExecuteScriptAsync("sendDataToWinForm()");
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
                    pbSprite.Refresh();
                    isChanged = true;
                }
            }
        }

        public async Task save_item()
        {
            requestData();
            returned = false;
            theItem.set_display_name(txtDisplayName.Text);
            theItem.set_tooltip(txtTooltip.Text);
            theItem.set_type(cbType.Text);
            do
            {
                await Task.Delay(100);
            }
            while (returned == false);
            theItem.set_code(code);
            isChanged = false;
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            FullscreenEditor fullscreenEditor = new FullscreenEditor();
            fullscreenEditor.Show();
        }

        private void pbSprite_Paint(object sender, PaintEventArgs e)
        {
            Bitmap theImage = theItem.get_sprite();
            Graphics g = e.Graphics;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            if (theItem.get_sprite() != null)
            {
                e.Graphics.DrawImage(theImage, 0, 0, pbSprite.Width, pbSprite.Height);
            }
        }

        //private async Task EditItem_FormClosingAsync(object sender, FormClosingEventArgs e)
        //{
        //    if (isChanged)
        //    {
        //        DialogResult result = MessageBox.Show("You have unsaved changes, do you wish to save them?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (result == DialogResult.Yes)
        //        {
        //            await save_item();
        //        }
        //    }
        //}

        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void txtTooltip_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void cbType_Click(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void wvCode_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            Console.WriteLine("AAAAAAAAA");
        }

        private void wvCode_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            sendData();
        }

        private void wvCode_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            code = e.TryGetWebMessageAsString();
            returned = true;
        }

        async void sendData()
        {
            await wvCode.ExecuteScriptAsync("loadData('" + theItem.get_code() + "')");
        }
    }
}
