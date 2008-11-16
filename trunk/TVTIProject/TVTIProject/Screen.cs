using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary.Graphics;

namespace TVTIProject
{
    public class Screen
    {

        public Image Background
        {
            get;
            set;
        }


        public Screen(Image bckgrnd) {
            this.Background = bckgrnd;
        }


    }
}
