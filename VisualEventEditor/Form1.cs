using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualEventEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            img = Bitmap.FromFile("E:\\GO\\hhs+\\Schools\\NormalSchool\\Images\\People\\Student\\Casual_01\\Female_0.png");
            session = -1;
            p1.X = 0;
            p1.Y = 0;
            p2.X = 0;
            p2.Y = 0;
            //Create right click menu..
            ContextMenuStrip s = new ContextMenuStrip();

            // add one right click menu item named as hello           
            ToolStripMenuItem add = new ToolStripMenuItem();
            add.Text = "Add new item...";

            // add the clickevent of hello item
            add.Click += add_Item;

            // add the item in right click menu
            s.Items.Add(add);

            // attach the right click menu with form
            this.ContextMenuStrip = s;
        }
        private Image img;

        int session;
        bool IsClicked = false;
        int TriangleOpen = 1;
        int deltaY = 0;
        int deltaX = 0;
        int triLength = 30;
        Rectangle rectGlobal = new Rectangle(10, 10, 200, 100);
        List<RectObj> rectList = new List<RectObj>();

        private Point p1,p2;
        List<Point> p1List = new List<Point>();
        List<Point> p2List = new List<Point>();

        public class RectObj
        {
            Rectangle rect;
            bool isClicked;
            Point pointW;

            public Point PointW
            {
                get { return pointW; }
                set { pointW = value; }
            }
            Point pointB;

            public Point PointB
            {
                get { return pointB; }
                set { pointB = value; }
            }

            public bool IsClicked
            {
                get { return isClicked; }
                set { isClicked = value; }
            }

            public Rectangle Rect
            {
                get { return rect; }
                set { rect = value; }
            }
            public void rectObj_MouseDown(object sender, MouseEventArgs e, Rectangle rect, bool IsClicked)
            {
                int deltaX;
                int deltaY;
                if ((e.X < rect.X + rect.Width) && (e.X > rect.X))
                    if ((e.Y < rect.Y + rect.Height) && (e.Y > rect.Y))
                    {
                        IsClicked = true;
                        deltaX = e.X - rect.X;
                        deltaY = e.Y - rect.Y;
                    }

            }
            public void rectObj_Paint(object sender, PaintEventArgs e, Rectangle rect)
            {
                Brush brush = new SolidBrush(Color.Black);
                Pen pen = new Pen(Color.Red);
                int triLength = (int)Math.Truncate(rect.Height * 0.3);
                e.Graphics.DrawRectangle(pen, rect);
                //sdfdsf
                Point[] points = new Point[] { new Point { X = rect.X + rect.Width / 2, Y = rect.Y + rect.Height -(int) Math.Truncate(rect.Height*0.3) }, 
                new Point { X = rect.X + rect.Width / 2 -triLength, Y = rect.Y+rect.Height }, 
                new Point { X = rect.X+rect.Width/2+triLength, Y = rect.Y +rect.Height} };

                Point[] rghtPoints = new Point[] { new Point { X =rect.X + rect.Width + triLength , Y =rect.Y + rect.Height / 2  }, 
                new Point { X =rect.X+rect.Width , Y = rect.Y + rect.Height / 2 -triLength    }, 
                new Point { X =rect.X +rect.Width  , Y =     rect.Y+rect.Height/2+triLength} };

                Point[] lftPoints = new Point[] { new Point { X =rect.X - triLength , Y =rect.Y + rect.Height / 2  }, 
                new Point { X =rect.X , Y = rect.Y + rect.Height / 2 -triLength    }, 
                new Point { X =rect.X , Y =     rect.Y+rect.Height/2+triLength} };
                
                e.Graphics.DrawPolygon(pen, points);
                e.Graphics.DrawPolygon(pen, rghtPoints);
                e.Graphics.FillPolygon(brush,lftPoints);

            }
        }
      
        void add_Item(object sender, EventArgs e)
        {
            RectObj r = new RectObj();
            r.Rect = new Rectangle(100, 100, 200, 100);
            r.IsClicked = false;
            rectList.Add(r);
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int start_session=session;
            for (int i = 0; i < rectList.Count(); i++)
            {
                if ((e.X < rectList.ElementAt(i).Rect.X + rectList.ElementAt(i).Rect.Width) && (e.X > rectList.ElementAt(i).Rect.X))
                    if ((e.Y < rectList.ElementAt(i).Rect.Y + rectGlobal.Height) && (e.Y > rectList.ElementAt(i).Rect.Y))
                    {
                        rectList.ElementAt(i).IsClicked = true;
                        deltaX = e.X - rectList.ElementAt(i).Rect.X;
                        deltaY = e.Y - rectList.ElementAt(i).Rect.Y;
                    }
                //line create
                {
                    int x1 = rectList.ElementAt(i).Rect.X + rectList.ElementAt(i).Rect.Width + triLength;
                    int x2 = rectList.ElementAt(i).Rect.X + rectList.ElementAt(i).Rect.Width;
                    int x3 = rectList.ElementAt(i).Rect.X + rectList.ElementAt(i).Rect.Width;
                    int y1 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2;
                    int y2 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2 - triLength;
                    int y3 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2 + triLength;

                    if ((e.X * (y1 - y2) + (x2 - x1) * e.Y + (x1 * y2 - x2 * y1) < 0) &&
                    (e.X * (y2 - y3) + (x3 - x2) * e.Y + (x2 * y3 - x3 * y2) < 0) &&
                    (e.X * (y3 - y1) + (x1 - x3) * e.Y + (x3 * y1 - x1 * y3) < 0)&&
                        (p1.X==0))
                    {
                        p1.X = e.X;
                        p1.Y = e.Y;
                        session = session * (-1) ;
                    }
                } 
              }
            for (int i = 0; i < rectList.Count(); i++)
            {
                if (start_session == session)
                {
                    int xx1 = rectList.ElementAt(i).Rect.X - triLength;
                    int xx2 = rectList.ElementAt(i).Rect.X;
                    int xx3 = rectList.ElementAt(i).Rect.X;
                    int yy1 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2;
                    int yy2 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2 + triLength;
                    int yy3 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2 - triLength;

                    if ((e.X * (yy1 - yy2) + (xx2 - xx1) * e.Y + (xx1 * yy2 - xx2 * yy1) < 0) &&
                      (e.X * (yy2 - yy3) + (xx3 - xx2) * e.Y + (xx2 * yy3 - xx3 * yy2) < 0) &&
                      (e.X * (yy3 - yy1) + (xx1 - xx3) * e.Y + (xx3 * yy1 - xx1 * yy3) < 0) &&
                       !(p1.X == 0))
                    {
                        p2.X = e.X;
                        p2.Y = e.Y;
                        p1List.Add(p1);
                        p2List.Add(p2);
                        Invalidate();
                    }
                    else
                    {
                        p1.X = 0;
                        p1.Y = 0;
                    }
                }
            }
      
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for(int i=0; i < rectList.Count();++i)
            {
                rectList.ElementAt(i).rectObj_Paint(sender, e, rectList.ElementAt(i).Rect);
            }
            using (var p = new Pen(Color.Blue, 4))
            {
                for (int x = 0; x < p1List.Count; x++)
                {
                    e.Graphics.DrawLine(p, p1List[x], p2List[x]);
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < rectList.Count(); i++)
            {
                if (rectList.ElementAt(i).IsClicked)
                {

                    rectList.ElementAt(i).Rect = new Rectangle(e.X - deltaX, e.Y - deltaY, rectList.ElementAt(i).Rect.Width, rectList.ElementAt(i).Rect.Height);
                   

                    pictureBox1.Invalidate();
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //IsClicked = false;
            for (int i = 0; i < rectList.Count(); ++i)
            {
                rectList.ElementAt(i).IsClicked = false;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //int x1 = rectGlobal.X + rectGlobal.Width / 2;
            //int x2 = rectGlobal.X + rectGlobal.Width / 2 - triLength;
            //int x3 = rectGlobal.X + rectGlobal.Width / 2 + triLength;
            //int y1 = rectGlobal.Y + rectGlobal.Height - triLength * TriangleOpen;
            //int y2 = rectGlobal.Y + rectGlobal.Height;
            //int y3 = rectGlobal.Y + rectGlobal.Height;
            //if (TriangleOpen == 1)
            //{
            //    if ((e.X * (y1 - y2) + (x2 - x1) * e.Y + (x1 * y2 - x2 * y1) < 0) &&
            //        (e.X * (y2 - y3) + (x3 - x2) * e.Y + (x2 * y3 - x3 * y2) < 0) &&
            //        (e.X * (y3 - y1) + (x1 - x3) * e.Y + (x3 * y1 - x1 * y3) < 0))
            //    {
            //        TriangleOpen = -1;
            //    }
            //}
            //else
            //{
            //    if ((e.X * (y1 - y2) + (x2 - x1) * e.Y + (x1 * y2 - x2 * y1) > 0) &&
            //        (e.X * (y2 - y3) + (x3 - x2) * e.Y + (x2 * y3 - x3 * y2) > 0) &&
            //        (e.X * (y3 - y1) + (x1 - x3) * e.Y + (x3 * y1 - x1 * y3) > 0))
            //    {
            //        TriangleOpen = 1;
            //    }
            //}

            pictureBox1.Invalidate();
        }

    }
}
