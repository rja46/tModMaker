﻿using System;
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
        private string workspace;
        public Item theItem;
        bool returned;
        public bool wvready = false;

        public EditItem(Item loadedItem)
        {
            InitializeComponent();
            
            //sets up the webview component running the editor
            InitWebview();
            wvCode.Source = new Uri("C:\\Users\\rjand\\Documents\\GitHub\\tModMaker\\Blockly Editor\\tool_editor.html");
        }

        public void displayItem(Item loadedItem)
        {
            if (wvready)
            {
                //loads the details of the item onto the screen
                clearBlockly();
                theItem = loadedItem;
                txtDisplayName.Text = theItem.get_displayName();
                txtTooltip.Text = theItem.get_tooltip();
                cbType.Text = theItem.get_type();
                pbSprite.Refresh();
                sendData();

                unlock_controls();
            }
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
            //this opens a file dialog to let the user select a new sprite, then refreshes the pic box
            if (theItem != null)
            {
                OpenFileDialog openSpriteDialog = new OpenFileDialog();
                openSpriteDialog.InitialDirectory = "c:\\";
                openSpriteDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                if (openSpriteDialog.ShowDialog() == DialogResult.OK)
                {
                    theItem.set_sprite(new Bitmap(@openSpriteDialog.FileName));
                    pbSprite.Refresh();
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
            theItem.set_code(workspace);
        }

        private void pbSprite_Paint(object sender, PaintEventArgs e)
        {
            if (theItem != null)
            {
                Bitmap theImage = theItem.get_sprite();
                Graphics g = e.Graphics;
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                if (theItem.get_sprite() != null)
                {
                    int height = theItem.get_sprite().Height;
                    int width = theItem.get_sprite().Width;
                    if (height > width)
                    {
                        e.Graphics.DrawImage(theImage, 0, 0, pbSprite.Height / height * width, pbSprite.Height);
                    }
                    else if (height < width)
                    {
                        e.Graphics.DrawImage(theImage, 0, pbSprite.Height/2 - height, pbSprite.Width, pbSprite.Width / width * height);
                    }
                    else
                    {
                        e.Graphics.DrawImage(theImage, 0, 0, pbSprite.Width, pbSprite.Height);
                    }
                }
            }
        }

        private void wvCode_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            wvready = true;
            displayItem(new Item("", ""));
            lock_controls();
        }

        private void wvCode_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            workspace = e.TryGetWebMessageAsString();
            returned = true;
        }

        async void sendData()
        {
            await wvCode.ExecuteScriptAsync("loadData('" + theItem.get_code() + "')");
        }

        public async void clearBlockly()
        {
            await wvCode.ExecuteScriptAsync("clear()");
        }

        //these need to lock the controls at certain points where access to the buttons would cause issues
        public void lock_controls()
        {
            btnChangeSprite.Enabled = false;
            txtDisplayName.Enabled = false;
            cbType.Enabled = false;
            txtTooltip.Enabled = false;
            wvCode.Enabled = false;
        }

        public void unlock_controls()
        {
            btnChangeSprite.Enabled = true;
            txtDisplayName.Enabled = true;
            cbType.Enabled = true;
            txtTooltip.Enabled = true;
            wvCode.Enabled = true;
        }
    }
}
