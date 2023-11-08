﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        bool isChanged;
        private string code;
        public Item theItem;
        private string thePath;

        public EditItem(Item loadedItem, string path)
        {
            InitializeComponent();
            theItem = loadedItem;
            thePath = path;
            txtDisplayName.Text = theItem.get_displayName();
            txtTooltip.Text = theItem.get_tooltip();
            cbType.Text = theItem.get_type();
            pbSprite.Refresh();
            isChanged = false;
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

        public void save_item()
        {
            //requestData();
            theItem.set_code(code);
            theItem.set_display_name(txtDisplayName.Text);
            theItem.set_tooltip(txtTooltip.Text);
            theItem.set_type(cbType.Text);
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

        private void EditItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes, do you wish to save them?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    save_item();
                }
            }
        }

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

        private void EditItem_Load(object sender, EventArgs e)
        {
            InitWebview();
            requestData();
            //sendData();

        }
    }
}
