using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PictureReda4er
{
    public interface savee
    {
        void save1(Bitmap imgg1);

        Bitmap save2();
    }

    public class save : savee
    {
        public Bitmap imgg;
        public void save1(Bitmap imgg1)
        {
            imgg = new Bitmap(imgg1);
        }

        public Bitmap save2()
        {
            return imgg;
        }
    }
        
        

    
}
