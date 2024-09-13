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
using static System.Windows.Forms.AxHost;

namespace DrawD
{
    public partial class Form4 : Form
    {
        Graphics g;
        float leftStickAngle = 0f;
        float rightStickAngle = 0f;
        float angleStep = 2f;
        Timer timerDrums;

        public Form4()
        {
            InitializeComponent();
            timerDrums = new Timer { Interval=1};
            timerDrums.Tick += new EventHandler(this.TimerTick);
            timerDrums.Start();
        }    
        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            DoubleBuffered = true;           
            int centerX = (this.Width / 2);
            int centerY = (this.Height / 2);
        
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Dram(centerX - 120, centerY - 100);
                                        
 
            Matrix leftMatrix = new Matrix();
            leftMatrix.RotateAt(leftStickAngle, new PointF(centerX - 160, centerY - 120));
            g.Transform = leftMatrix;
            Sticks(centerX - 160, centerY - 130, false);
            g.ResetTransform();


            Matrix rightMatrix = new Matrix();
            rightMatrix.RotateAt(rightStickAngle, new PointF(centerX + 160, centerY - 120));
            g.Transform = rightMatrix;
            Sticks(centerX + 150, centerY - 140, true);
            g.ResetTransform();


        }
        private void Sticks(int centerX, int centerY, bool k)
        {
            int stickWidth = 5;
            int stickHeight = 120;
            int cottonRadius = 10;
            // 1 палочка
            if (k)
            {
                g.FillRectangle(Brushes.OrangeRed, new Rectangle(centerX - stickHeight, centerY, stickHeight, stickWidth));
                g.FillEllipse(Brushes.Red, new Rectangle(centerX - stickHeight - cottonRadius, centerY - cottonRadius + stickWidth / 2, cottonRadius * 2, cottonRadius * 2));
            }
            else
            // 2 палочка
            {
                g.FillRectangle(Brushes.OrangeRed, new Rectangle(centerX, centerY, stickHeight, stickWidth));
                g.FillEllipse(Brushes.Red, new Rectangle(centerX + stickHeight - cottonRadius, centerY - cottonRadius + stickWidth / 2, cottonRadius * 2, cottonRadius * 2));
            }
        }
        private void Dram(int centerX, int centerY)
        {
            g.FillRectangle(Brushes.OrangeRed, new Rectangle(centerX, centerY + 25, 200, 120));
            g.FillEllipse(Brushes.OrangeRed, new Rectangle(centerX, centerY + 105, 200, 90));

            g.FillEllipse(Brushes.Gray, new Rectangle(centerX, centerY, 200, 50));
        }
        private void TimerTick(object sender, EventArgs e)
        {
            leftStickAngle += angleStep;
            rightStickAngle += angleStep;

            if (leftStickAngle > 30 || leftStickAngle < -30)
                angleStep = -angleStep;         
            this.Invalidate();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
