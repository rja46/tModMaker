using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace NEA_solution
{
    public partial class OtherSprites : Form
    {
        public Item theItem;
        string type;
        public OtherSprites(Item item, string type)
        {
            InitializeComponent();
            theItem = item;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.type = type;
            if (type == "body")
            {
                btnChangeSprite.Text = "Change Body Sprite";
            }
            else if (type == "head")
            {
                btnChangeSprite.Text = "Change Head Sprite";
            }
            else if (type == "legs")
            {
                btnChangeSprite.Text = "Change Legs Sprite";
            }
            else if (type == "wings")
            {
                btnChangeSprite.Text = "Change Wings Sprite";
            }
            else if (type == "boss")
            {
                btnChangeSprite.Text = "Change Map Head Sprite";
            }
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
                    if (type == "body")
                    {
                        theItem.set_bodySprite(new Bitmap(@openSpriteDialog.FileName));
                    }
                    else if (type == "head")
                    {
                        theItem.set_headSprite(new Bitmap(@openSpriteDialog.FileName));
                    }
                    else if (type == "legs")
                    {
                        theItem.set_legsSprite(new Bitmap(@openSpriteDialog.FileName));
                    }
                    else if (type == "wings")
                    {
                        theItem.set_wingSprite(new Bitmap(@openSpriteDialog.FileName));
                    }
                    else if (type == "boss")
                    {
                        theItem.set_mapHead(new Bitmap(@openSpriteDialog.FileName));
                    }

                    pbSprite.Refresh();
                }
            }
        }

        private void pbSprite_Paint(object sender, PaintEventArgs e)
        {
            if (theItem != null)
            {
                Bitmap theImage = null;
                if (type == "body")
                {
                    theImage = theItem.get_bodySprite();
                }
                else if (type == "head")
                {
                    theImage = theItem.get_headSprite();
                }
                else if (type == "legs")
                {
                    theImage = theItem.get_legsSprite();
                }
                else if (type == "wings")
                {
                    theImage = theItem.get_wingSprite();
                }
                else if (type == "boss")
                {
                    theImage = theItem.get_mapHead();
                }
                else
                {
                    this.Close();
                }

                //This ensures the sprite's aspect ratio is maintained.
                Graphics g = e.Graphics;
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                if (theImage != null)
                {
                    double picBoxWidth = pbSprite.Width;
                    double picBoxHeight = pbSprite.Height;
                    double height = theImage.Height;
                    double width = theImage.Width;
                    if (height > width)
                    {
                        e.Graphics.DrawImage(theImage, (int)(picBoxWidth - (picBoxHeight / height * width)) / 2, 0, (int)(picBoxHeight / height * width), (int)(picBoxHeight));
                    }
                    else if (height < width)
                    {
                        e.Graphics.DrawImage(theImage, 0, (int)(picBoxHeight - (picBoxWidth / width * height)) / 2, (int)picBoxWidth, (int)(picBoxWidth / width * height));
                    }
                    else
                    {
                        e.Graphics.DrawImage(theImage, 0, 0, pbSprite.Width, pbSprite.Height);
                    }
                }
            }
        }
    }
}
