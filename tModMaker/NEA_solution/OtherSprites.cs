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
        public OtherSprites(Item item)
        {
            InitializeComponent();
            theItem = item;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnChangeWingSprite_Click(object sender, EventArgs e)
        {
            if (theItem != null)
            {
                OpenFileDialog openSpriteDialog = new OpenFileDialog();
                openSpriteDialog.InitialDirectory = "c:\\";
                openSpriteDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                if (openSpriteDialog.ShowDialog() == DialogResult.OK)
                {
                    theItem.set_wingSprite(new Bitmap(@openSpriteDialog.FileName));
                    pbWingSprite.Refresh();
                }
            }
        }

        private void pbWingSprite_Paint(object sender, PaintEventArgs e)
        {
            if (theItem != null)
            {
                Bitmap theImage = theItem.get_wingSprite();
                Graphics g = e.Graphics;
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                if (theItem.get_wingSprite() != null)
                {
                    double picBoxWidth = pbWingSprite.Width;
                    double picBoxHeight = pbWingSprite.Height;
                    double height = theItem.get_wingSprite().Height;
                    double width = theItem.get_wingSprite().Width;
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
                        e.Graphics.DrawImage(theImage, 0, 0, pbWingSprite.Width, pbWingSprite.Height);
                    }
                }
            }
        }
    }
}
