using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawA
{
    /* 11.а) Намалювати в різних місцях екрана сектор кола, куб, зафарбований еліпс і зафарбований семикутник.
        б) За допомогою графічних примітивів намалювати комп'ютер, за яким ви зараз працюєте.
        в) Намалювати рівнобедрений трикутник, який обертається навколо вертикальної прямої, що проходить через один з його кутів.
        г) Намалювати барабан з паличками.*/
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawCube();
            DrawSevenAngles();

            g.FillEllipse(Brushes.Blue,5, 5, 200, 100);
 
            g.DrawPie(Pens.Orange, new Rectangle(700, 0, 200, 200), 0, -60);                               
        }
        private void DrawSevenAngles() 
        {
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;
            int radius = 100;


            Point[] points = new Point[7];
            for (int i = 0; i < 7; i++)
            {
                double angle = i * 2 * Math.PI / 7 - Math.PI / 2; // Починаємо з 90 градусів
                points[i] = new Point(
                    centerX + (int)(radius * Math.Cos(angle)),//Вершина Х
                    centerY + (int)(radius * Math.Sin(angle)) //Вершина У
                                     );
            }
            g.FillPolygon(Brushes.Green, points);
        }
        private void DrawCube ()
        {
            Point frontTopLeft = new Point(5, 500);
            Point frontTopRight = new Point(105, 500);
            Point frontBottomLeft = new Point(5, 600);
            Point frontBottomRight = new Point(105, 600);

            Point backTopLeft = new Point(55, 550);
            Point backTopRight = new Point(155, 550);
            Point backBottomLeft = new Point(55, 650);
            Point backBottomRight = new Point(155, 650);

            Pen pen = Pens.Black;

            //Передня частина куба
            g.DrawLine(pen, frontTopLeft, frontTopRight);
            g.DrawLine(pen, frontTopRight, frontBottomRight);
            g.DrawLine(pen, frontBottomRight, frontBottomLeft);
            g.DrawLine(pen, frontBottomLeft, frontTopLeft);

            //Задня частина куба
            g.DrawLine(pen, backTopLeft, backTopRight);
            g.DrawLine(pen, backTopRight, backBottomRight);
            g.DrawLine(pen, backBottomRight, backBottomLeft);
            g.DrawLine(pen, backBottomLeft, backTopLeft);

            //З'єднувальні лінії між передньою та задньою частинами куба
            g.DrawLine(pen, frontTopLeft, backTopLeft);
            g.DrawLine(pen, frontTopRight, backTopRight);
            g.DrawLine(pen, frontBottomLeft, backBottomLeft);
            g.DrawLine(pen, frontBottomRight, backBottomRight);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
