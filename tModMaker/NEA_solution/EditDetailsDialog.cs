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
    public partial class EditDetailsDialog : Form
    {
        public string name;
        public string description;
        public string author;
        public double version;
        public Bitmap icon;
        public EditDetailsDialog(string name, string author, string description, double version, Bitmap icon)
        {
            InitializeComponent();
            txtAuthor.Text = author;
            txtDescription.Text = description;
            txtName.Text = name;
            numVersion.Value = (decimal)version;
            this.icon = icon;
            pictureBox1.Refresh();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap theImage = icon;
            Graphics g = e.Graphics;

            //As this will be using mostly pixel art, this prevents bluring instead of sharp edges.
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

            if (icon != null)
            {
                double picBoxWidth = pictureBox1.Width;
                double picBoxHeight = pictureBox1.Height;
                double height = icon.Height;
                double width = icon.Width;
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
                    e.Graphics.DrawImage(theImage, 0, 0, pictureBox1.Width, pictureBox1.Height);
                }
            }
        }

        private void btnChangeIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openSpriteDialog = new OpenFileDialog();
            openSpriteDialog.InitialDirectory = "c:\\";
            openSpriteDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            if (openSpriteDialog.ShowDialog() == DialogResult.OK)
            {
                icon = new Bitmap(@openSpriteDialog.FileName);
                pictureBox1.Refresh();
            }
        }

        private void EditDetailsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            name = txtName.Text;
            description = txtDescription.Text;
            author = txtAuthor.Text;
            version = (double)numVersion.Value;
        }
    }
}
