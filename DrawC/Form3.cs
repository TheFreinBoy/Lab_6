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

namespace DrawC
{
    public partial class Form3 : Form
    {
        //в) Намалювати рівнобедрений трикутник, який обертається навколо вертикальної прямої, що проходить через один з його кутів.    
         PointF[] trianglePoints; 
         float angle = 0; // Початковий
        
        public Form3()
        {
            DoubleBuffered = true;
            InitializeComponent();
            
            TrianglePoints();           
         
            Timer timer = new Timer();
            timer.Interval = 60; // Інтервал в мілісекундах
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            angle += 15; // Кут обертання
            Invalidate(); 
        }
        private void TrianglePoints()
        {
            trianglePoints = new PointF[3];
            trianglePoints[0] = new PointF(500, 250); // Вершина A
            trianglePoints[1] = new PointF(400, 450); // Вершина B
            trianglePoints[2] = new PointF(600, 450); // Вершина C
        }
        protected override void OnPaint(PaintEventArgs e)
        {          
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            // Обертаємо трикутник навколо вершини A
            Matrix rotationMatrix = new Matrix();
            rotationMatrix.RotateAt(angle, trianglePoints[0]);
            g.Transform = rotationMatrix;

            g.FillPolygon(Brushes.LightGreen, trianglePoints);
            g.DrawPolygon(Pens.Black, trianglePoints);

        }
        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
