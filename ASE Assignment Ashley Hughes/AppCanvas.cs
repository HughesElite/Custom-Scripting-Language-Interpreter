using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    class AppCanvas : ICanvas
    {
        private int xPos, yPos; //pen position when drawing
        int XCanvasSize, YCanvasSize;
        private Color penColour;
        private Pen Pen;


        const int XSIZE = 400;
        const int YSIZE = 365;
        Bitmap bm = new Bitmap(XSIZE, YSIZE); // Width and height of the bitmap
        Graphics g;
        private int penSize = 5;


        public AppCanvas()
        {
            Set(XSIZE, YSIZE);
        }

        public int Xpos
        {
            get
            {
                return xPos;
            }
            set
            {
                xPos = value;
            }

        }
        public int Ypos
        {
            get
            {
                return yPos;
            }
            set
            {
                yPos = value;
            }

        }

        public Object PenColour
        {
            get
            {
                return penColour;
            }
            set
            {
                penColour = (Color)value;
            }
        }

        public void Circle(int radius, bool filled)
        {
            if (radius < 0)
                throw new CanvasException("Invalid circle radius " + radius);
            if (g != null)
                if (!filled)
                    g.DrawEllipse(Pen, xPos - radius, yPos - radius, radius * 2, radius * 2);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void DrawTo(int toX, int toY)
        {
            if (toX < 0 || toX > XCanvasSize || toY < 0 || toY > YCanvasSize)
                throw new CanvasException("Invalid screen position Draw To " + toX + "," + toY);
            if (g != null)
                g.DrawLine(Pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;
        }

        public object getBitmap()
        {
            return bm;
        }

        public void MoveTo(int x, int y)
        {
            if (x < 0 || x > XCanvasSize || y < 0 || y > YCanvasSize)
                throw new CanvasException("Invalid screen position Move To" + x + "," + y);
            xPos = x;
            yPos = y;
        }

        public void Rect(int width, int height, bool filled)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Set(int xsize, int ysize)
        {
            XCanvasSize = xsize;
            YCanvasSize = ysize;
            xPos = yPos = 0;
            XCanvasSize = xsize;
            g = Graphics.FromImage(bm);
        }

        public void SetColour(int red, int green, int blue)
        {
            if (red > 255 || green > 255 || blue > 255)
                throw new CanvasException("Invalid colour " + red + "," + green + "," + blue);
            penColour = Color.FromArgb(255, red, green, blue);
            Pen = new Pen(penColour, penSize);

        }

        public void Tri(int width, int height)
        {
            throw new NotImplementedException();
        }

        public void WriteText(string text)
        {
            throw new NotImplementedException();
        }
    }
}
