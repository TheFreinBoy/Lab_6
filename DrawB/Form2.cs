using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawB
{
    //б) За допомогою графічних примітивів намалювати комп'ютер, за яким ви зараз працюєте.
    public partial class Form2 : Form
    {      
        PointF[] point = new PointF[4];
        public Form2()
        {
            InitializeComponent();         
        }        
        Graphics g;
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Black, 2);            
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            Monitor();
                       
            Body(centerX, centerY);
            
            Keyboard();
            
            TouchPad();
        }
        private void Monitor()
        {
            g.FillRectangle(Brushes.DarkGray, 280, 137, 240, 130);
            g.FillRectangle(Brushes.Black, 285, 142, 230, 120);
        }
        private void Body(int centerX, int centerY)
        {
            point[0] = new PointF((centerX - 120), (centerY - 100) + 143);
            point[1] = new PointF((centerX - 120) + 240, centerY - 100 + 143);
            point[2] = new PointF((centerX - 120) + 260, (centerY - 100) + 220);
            point[3] = new PointF((centerX - 120) - 20, (centerY - 100) + 220);
            g.FillPolygon(Brushes.LightGray, point);
        }
        private void Keyboard()
        {
            point[0].X += 25;
            point[0].Y += 5;
            point[1].X -= 25;
            point[1].Y += 5;
            point[2].X -= 37;
            point[2].Y -= 35;
            point[3].X += 37;
            point[3].Y -= 35;

            g.FillPolygon(Brushes.DarkGray, point);
        }
        private void TouchPad() 
        {
            point[0].X += 70;
            point[0].Y += 40;
            point[1].X -= 70;
            point[1].Y += 40;
            point[2].X -= 75;
            point[2].Y += 30;
            point[3].X += 75;
            point[3].Y += 30;

            g.FillPolygon(Brushes.Gray, point);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
