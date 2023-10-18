using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_solution
{
    public class Sprite
    {
        private string imageLocation;
        private bool isAnimated;
        private int frameTime;
        public int sizeX;
        public int sizeY;
        public Sprite()
        {

        }

        public string get_sprite_path() { return imageLocation; }
        public void set_sprite_path(string path) { imageLocation = path; }
    }
}
