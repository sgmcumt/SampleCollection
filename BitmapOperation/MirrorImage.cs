using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BitmapOperation
{
    public class MirrorImage
    {
        public  Bitmap HorizontalMirror(Bitmap curBitmap)
        {
            if (curBitmap != null)
            {
                Bitmap image2 = (Bitmap)curBitmap.Clone();
                //水平镜像
                image2.RotateFlip(RotateFlipType.RotateNoneFlipX);
                return image2;
            }
            return null;
        }
        public Bitmap VerticalMirror(Bitmap curBitmap)
        {
            if (curBitmap != null)
            {
                Bitmap image2 = (Bitmap)curBitmap.Clone();
                //垂直镜像                
                image2.RotateFlip(RotateFlipType.Rotate180FlipX);
                return image2;
            }
            return curBitmap;
        }

    }
}
