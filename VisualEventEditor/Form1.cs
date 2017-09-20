using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Data.SQLite;
using System.Diagnostics;

namespace VisualEventEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            img = Bitmap.FromFile("E:\\GO\\hhs+\\Schools\\NormalSchool\\Images\\People\\Student\\Casual_01\\Female_0.png");
            p1.X = 0;
            p1.Y = 0;
            p2.X = 0;
            p2.Y = 0;
            //Create right click menu..
            ContextMenuStrip s = new ContextMenuStrip();

            // add one right click menu item named as hello           
            ToolStripMenuItem add = new ToolStripMenuItem();
            ToolStripMenuItem add_label = new ToolStripMenuItem();
            add.Text = "Add new item...";
            add_label.Text = "Add label";
            // add the clickevent of hello item
            add.Click += add_Item;
            add_label.Click += add_Label;

            // add the item in right click menu
            s.Items.Add(add);
            s.Items.Add(add_label);
            // attach the right click menu with form
            this.ContextMenuStrip = s;
        }

        private Image img;

        private LocEditForm locEditForm;

        int deltaY = 0;
        int deltaX = 0;
        int triLength = 30;
       
        List<RectObj> rectList = new List<RectObj>();


        Label ShtLocDescription = new Label();

        private Point p1,p2;
        Point rectPoint;
        List<Point> p1List = new List<Point>();
        List<Point> p2List = new List<Point>();
        List<Point> rectPointList = new List<Point>();

        public class RectObj
        {

            Rectangle rect;
            bool isClicked;
            
           
           
            string locName;

            public string LocName
            {
                get { return locName; }
                set { locName = value; }
            }

            string shtLocDescription;

            public string ShtLocDescription
            {
                get { return shtLocDescription; }
                set { shtLocDescription = value; }
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
            public void rectObj_Paint(object sender, PaintEventArgs e, Rectangle rect,string description,string locName)
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
                e.Graphics.DrawString(description, new Font("Arial", 10), Brushes.Green, new Point(rect.X+10, rect.Y+10));
                e.Graphics.DrawString(locName, new Font("Arial", 14), Brushes.DarkBlue, new Point(rect.X, rect.Y - 30));

            }
        }
      
        void add_Item(object sender, EventArgs e)
        {            
            RectObj r = new RectObj();
            r.Rect = new Rectangle(100, 100, 200, 100);
            r.IsClicked = false;
            r.ShtLocDescription =  " rect" + rectList.Count().ToString();
            r.LocName = "";

            
            rectList.Add(r);
            pictureBox1.Invalidate();
        }
        void add_Label(object sender, EventArgs e)
        {

            ShtLocDescription.Text = "asdsadad";//1
            ShtLocDescription.Location = new Point(300, 300);//2
            ShtLocDescription.Size = new Size(200, 200);//3
            ShtLocDescription.Font = new Font("Microsoft Sans Serif", 30, FontStyle.Regular);//4
            ShtLocDescription.ForeColor = Color.Red;//5

            this.Controls.Add(ShtLocDescription);//6
            {
                ShtLocDescription.BringToFront();
            }

            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            locEditForm = new LocEditForm();
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < rectList.Count(); i++)
            {
                if ((e.X < rectList.ElementAt(i).Rect.X + rectList.ElementAt(i).Rect.Width) && (e.X > rectList.ElementAt(i).Rect.X))
                    if ((e.Y < rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height) && (e.Y > rectList.ElementAt(i).Rect.Y))
                    {
                        rectList.ElementAt(i).IsClicked = true;
                        deltaX = e.X - rectList.ElementAt(i).Rect.X;
                        deltaY = e.Y - rectList.ElementAt(i).Rect.Y;
                    }
              }      
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for(int i=0; i < rectList.Count();++i)
            {
                rectList.ElementAt(i).rectObj_Paint(sender, e, rectList.ElementAt(i).Rect, rectList.ElementAt(i).ShtLocDescription, rectList.ElementAt(i).LocName);
                
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
                    //change position on move
                    rectList.ElementAt(i).Rect = new Rectangle(e.X - deltaX, e.Y - deltaY, rectList.ElementAt(i).Rect.Width, rectList.ElementAt(i).Rect.Height);
                    //rectList.ElementAt(i).ShtLocDescription.Location = new Point(rectList.ElementAt(i).Rect.X + 10, rectList.ElementAt(i).Rect.Y + 10);
                    for (int j = 0; j < p1List.Count; ++j)
                    {
                        if (rectPointList.ElementAt(j).X == i)
                        {
                            Point newPoint = new Point { X = rectList.ElementAt(i).Rect.X + rectList.ElementAt(i).Rect.Width + triLength, Y = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2 };
                            p1List.RemoveAt(j);
                            p1List.Insert(j,newPoint);
                                                        
                        }
                    }
                    for (int j = 0; j < p1List.Count; ++j)
                    {
                        if (rectPointList.ElementAt(j).Y == i)
                        {
                            Point newPoint =new Point { X =rectList.ElementAt(i).Rect.X - triLength , Y =rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2  };
                            p2List.RemoveAt(j);
                            p2List.Insert(j,newPoint);
                                                        
                        }
                    }

                    pictureBox1.Invalidate();
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < rectList.Count(); ++i)
            {
                rectList.ElementAt(i).IsClicked = false;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            //block for p2
            if (p1.X+p1.Y!=0)
            {
                for (int i = 0; i < rectList.Count(); i++)
                {
                
                    int xx1 = rectList.ElementAt(i).Rect.X - triLength;
                    int xx2 = rectList.ElementAt(i).Rect.X;
                    int xx3 = rectList.ElementAt(i).Rect.X;
                    int yy1 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2;
                    int yy2 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2 + triLength;
                    int yy3 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2 - triLength;

                    if ((e.X * (yy1 - yy2) + (xx2 - xx1) * e.Y + (xx1 * yy2 - xx2 * yy1) < 0) &&
                      (e.X * (yy2 - yy3) + (xx3 - xx2) * e.Y + (xx2 * yy3 - xx3 * yy2) < 0) &&
                      (e.X * (yy3 - yy1) + (xx1 - xx3) * e.Y + (xx3 * yy1 - xx1 * yy3) < 0))
                    {
                        p2.X = rectList.ElementAt(i).Rect.X - triLength;
                        p2.Y = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2;
                        rectPoint.Y = i;
                        p1List.Add(p1);
                        p2List.Add(p2);


                        rectPointList.Add(rectPoint);
                        p1.X = p2.X = p1.Y = p2.Y = 0;
                        rectPoint.X = 0;
                        rectPoint.Y = 0;
                        Invalidate();
                    }
                    else
                    {
                    }
                  }
            }
            //block for p1
            else
            {
                for (int i = 0; i < rectList.Count(); i++)
                {
                    int x1 = rectList.ElementAt(i).Rect.X + rectList.ElementAt(i).Rect.Width + triLength;
                    int x2 = rectList.ElementAt(i).Rect.X + rectList.ElementAt(i).Rect.Width;
                    int x3 = rectList.ElementAt(i).Rect.X + rectList.ElementAt(i).Rect.Width;
                    int y1 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2;
                    int y2 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2 - triLength;
                    int y3 = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2 + triLength;

                    if ((e.X * (y1 - y2) + (x2 - x1) * e.Y + (x1 * y2 - x2 * y1) < 0) &&
                    (e.X * (y2 - y3) + (x3 - x2) * e.Y + (x2 * y3 - x3 * y2) < 0) &&
                    (e.X * (y3 - y1) + (x1 - x3) * e.Y + (x3 * y1 - x1 * y3) < 0))
                    {
                       
                        p1.X = rectList.ElementAt(i).Rect.X + rectList.ElementAt(i).Rect.Width + triLength;
                        p1.Y = rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height / 2;
                        rectPoint.X = i;

                    }
                } 

            }
          pictureBox1.Invalidate();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
         
            for (int i = 0; i < rectList.Count(); i++)
            {
                if ((Cursor.Position.X < rectList.ElementAt(i).Rect.X + rectList.ElementAt(i).Rect.Width) && (Cursor.Position.X > rectList.ElementAt(i).Rect.X))
                    if ((Cursor.Position.Y < rectList.ElementAt(i).Rect.Y + rectList.ElementAt(i).Rect.Height) && (Cursor.Position.Y > rectList.ElementAt(i).Rect.Y))
                    {
                        locEditForm.txtLocContent.Text = "";
                        if (locEditForm.ShowDialog() == DialogResult.OK)
                        {
                           
                            rectList.ElementAt(i).LocName = locEditForm.txtLocName.Text;
                            rectList.ElementAt(i).ShtLocDescription = locEditForm.txtShtLocDescription.Text;
                            //Create/update file locName.txt                    
                            //string lines = "# " + rectList.ElementAt(i).LocName + "\r\n" + @"!' " +@rectList.ElementAt(i).ShtLocDescription +@" '"+ "\r\n" + "--- " + rectList.ElementAt(i).LocName + " ---------------------------------";

                            // Write the string to a file.
                            //string fileName = @"E:\\dev\\Location\\" + rectList.ElementAt(i).LocName.Trim() + ".txt";
                            //System.IO.StreamWriter file = new System.IO.StreamWriter("E:\\dev\\Location\\" + rectList.ElementAt(i).LocName.Trim() + ".txt");
                            //file.WriteLine(lines);
                            //file.Close();
                            //end txt

                            ////txt2gam convert
                            //{
                            //    Process cmd = new Process();
                            //    cmd.StartInfo.FileName = "cmd.exe";
                            //    cmd.StartInfo.RedirectStandardInput = true;
                            //    cmd.StartInfo.UseShellExecute = false;
                            //    cmd.Start();
                            //    cmd.StandardInput.WriteLine(@"e:");
                            //    cmd.StandardInput.WriteLine(@"cd E:\dev\GameConventor");
                            //    cmd.StandardInput.WriteLine(@".\txt2gam.exe "+fileName+" game.gam");
                            //    cmd.Kill();                          
                            //}
                            ////end convert

                            
                            pictureBox1.Invalidate();
                        }
                    }
            }  
            
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void сохраранитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
           using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"E:\dev\save.txt"))
            {
                file.WriteLine(rectList.Count());
                for(int i=0;i<rectList.Count();i++)
                {
                    
                        file.WriteLine(rectList.ElementAt(i).Rect.X.ToString()+" "
                            + rectList.ElementAt(i).Rect.Y.ToString()+" "
                            + rectList.ElementAt(i).Rect.Width.ToString() + " "
                             + rectList.ElementAt(i).Rect.Height.ToString());
                        //List<Point> p1List = new List<Point>();
                        //List<Point> p2List = new List<Point>();
                        //List<Point> rectPointList = new List<Point>();
                }
                file.WriteLine(p1List.Count());
                for (int i = 0; i < p1List.Count(); i++)
                {
                    file.WriteLine(p1List.ElementAt(i).X.ToString() + " "
                            + p1List.ElementAt(i).Y.ToString() + " "
                            + p2List.ElementAt(i).X.ToString() + " "
                            + p2List.ElementAt(i).Y.ToString() + " "
                            + rectPointList.ElementAt(i).X.ToString()+ " "
                            + rectPointList.ElementAt(i).Y.ToString());
                }
            }
        }

        private void загрузитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"E:\dev\save.txt");
            for (int i = 1; i < Int32.Parse(lines[0])+1; ++i)
            {
                string [] split = lines[i].Split(new Char [] {' ', ',', '.', ':', '\t' });
                RectObj r = new RectObj();
                r.Rect = new Rectangle(Int32.Parse(split.ElementAt(0)), Int32.Parse(split.ElementAt(1)), Int32.Parse(split.ElementAt(2)), Int32.Parse(split.ElementAt(3)));
                r.IsClicked = false;
                rectList.Add(r);
               
            }
            for (int i = Int32.Parse(lines[0]) + 2; i < Int32.Parse(lines[0]) + Int32.Parse(lines[Int32.Parse(lines[0]) + 1]) + 1; ++i)
            {
                string[] split = lines[i].Split(new Char[] { ' ', ',', '.', ':', '\t' });

                Point p1 = new Point(Int32.Parse(split[0]), Int32.Parse(split[1]));
                Point p2 = new Point(Int32.Parse(split[2]), Int32.Parse(split[3]));
                Point p3 = new Point(Int32.Parse(split[4]), Int32.Parse(split[5]));

                p1List.Add(p1);
                p2List.Add(p2);
                rectPointList.Add(p3);
            }
            pictureBox1.Invalidate();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rectList.Clear();
            p1List.Clear();
            p2List.Clear();
            rectPointList.Clear();
            pictureBox1.Invalidate();
        }

        private void загрузитьJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string json = System.IO.File.ReadAllText(@"E:\json.txt"); ;
            List<RectObj> rectJson = JsonConvert.DeserializeObject<List<RectObj>>(json);
            rectList = rectJson;
            pictureBox1.Invalidate();
        }

        private void gENERATECODEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gameGamPath = @"E:\dev\game.gam";
            string mainGameFilePath = @"E:\dev\game.txt";
            System.IO.StreamWriter fileGame = new System.IO.StreamWriter(mainGameFilePath);
            for (int i = 0; i < rectList.Count(); i++)
            {
                string startLoc= "# " + rectList.ElementAt(i).LocName + "\r\n";
                string contentLoc = File.ReadAllText("E:\\dev\\Location\\" + rectList.ElementAt(i).LocName + ".txt");
                string endLoc= "--- " + rectList.ElementAt(i).LocName + " ---------------------------------"+"\r\n";
                fileGame.Write(startLoc+contentLoc+endLoc);
            }
            


            //for (int i = 0; i < rectList.Count(); i++)
            //{
            //    string lines = "# " + rectList.ElementAt(i).LocName + "\r\n" + @"!' " + @rectList.ElementAt(i).ShtLocDescription + @" '" + "\r\n" + "--- " + rectList.ElementAt(i).LocName + " ---------------------------------";

            //    // Write the string to a file.
            //    string fileName = @"E:\\dev\\Location\\" + rectList.ElementAt(i).LocName.Trim() + ".txt";
            //    System.IO.StreamWriter file = new System.IO.StreamWriter("E:\\dev\\Location\\" + rectList.ElementAt(i).LocName.Trim() + ".txt");
            //    file.WriteLine(lines);
            //    file.Close();
            //}

            fileGame.Close();

            //txt2gam convert
            
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine(@"e:");
            cmd.StandardInput.WriteLine(@"cd E:\dev\GameConventor");
            cmd.StandardInput.WriteLine(@".\txt2gam.exe E:\dev\game.txt E:\dev\game.gam");
            cmd.WaitForExit(500);             
            cmd.Kill();

            //end convert



            //SQLiteConnection conn = new SQLiteConnection("Data Source=filename.db; Version=3;");
            //try
            //{
            //    conn.Open();
            //}
            //catch (SQLiteException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //if (conn.State == ConnectionState.Open)
            //{
            //    // ******
            //}

            ////conn.Dispose();


            //SQLiteCommand cmd = conn.CreateCommand();
            //string sql_command = "DROP TABLE IF EXISTS location;"
            //  + "CREATE TABLE location("
            //  + "id INTEGER PRIMARY KEY AUTOINCREMENT, "
            //  + "locationName TEXT, "
            //  + "last_name TEXT, "
            //  + "sex INTEGER, "
            //  + "birth_date INTEGER);"
            //  + "INSERT INTO person(first_name, last_name, sex, birth_date) "
            //  + "VALUES ('John', 'Doe', 0, strftime('%s', '1979-12-10'));"
            //  + "INSERT INTO person(first_name, last_name, sex, birth_date) "
            //  + "VALUES ('Vanessa', 'Maison', 1, strftime('%s', '1977-12-10'));"
            //  + "INSERT INTO person(first_name, last_name, sex, birth_date) "
            //  + "VALUES ('Ivan', 'Vasiliev', 0, strftime('%s', '1987-01-06'));"
            //  + "INSERT INTO person(first_name, last_name, sex, birth_date) "
            //  + "VALUES ('Kevin', 'Drago', 0, strftime('%s', '1991-06-11'));"
            //  + "INSERT INTO person(first_name, last_name, sex, birth_date) "
            //  + "VALUES ('Angel', 'Vasco', 1, strftime('%s', '1987-10-09'));";
            //cmd.CommandText = sql_command;
            //try
            //{
            //    cmd.ExecuteNonQuery();
            //}
            //catch (SQLiteException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}



            ////GEBERATE
            //gtxt.Clear();
            //for (int i = 1; i <= b.GetListDataFromTable().Count(); ++i)
            //{

            //    if (i % 2 == 0)
            //    {
            //        gtxt.SelectionColor = Color.Blue;
            //    }
            //    else
            //    {
            //        gtxt.SelectionColor = Color.Red;
            //    }
            //    gtxt.AppendText(File.ReadAllText("E:\\dev\\Location\\" + b.GetListDataFromTable().ElementAt(i - 1).FirstName + ".txt"));
            //}
            ////GENERATE END

            ////Save txt
            //string path = "E:\\game.txt";
            //File.Delete(path);
            //var newFile = File.Create(path);
            //newFile.Close();
            //String[] s = gtxt.Text.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //for (int i = s.Count() - 1; i >= 0; --i)
            //{
            //    var allLines = File.ReadAllLines("E:\\dev\\game.txt").ToList();
            //    allLines.Insert(0, s.ElementAt(i));
            //    File.WriteAllLines("E:\\dev\\game.txt", allLines.ToArray());
            //}
            ////END Save
        }

        private void создатьJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<RectObj> _data = rectList;

            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(@"E:\json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, _data);
            }
            
            
            
        }

    }
}
