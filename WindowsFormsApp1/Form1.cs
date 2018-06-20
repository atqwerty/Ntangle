using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Point[] points;
        public int amountOfAngles;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            Graphics g0 = CreateGraphics();
            g0.Clear(Color.White);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g1 = CreateGraphics();
            g1.Clear(Color.White);
            amountOfAngles = int.Parse(textBox1.Text);
            int radius = 100;
            int centerY = ClientSize.Height / 2;
            int centerX = ClientSize.Width / 2;
            int x, y;
            points = new Point[amountOfAngles + 1];
            for (int i = 0; i <= amountOfAngles - 1; i++)
            {
                x = centerX + Convert.ToInt32(radius * Math.Cos(2 * i * Math.PI / amountOfAngles));
                y = centerY + Convert.ToInt32(radius * Math.Sin(2 * i * Math.PI / amountOfAngles));
                points[i] = new Point(x, y);
            }
            points[amountOfAngles] = new Point(points[0].X, points[0].Y);
            g1.DrawLines(new Pen(Color.Black, 1), points);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g2 = CreateGraphics();
            g2.Clear(Color.White);
            int centerY = ClientSize.Height / 2;
            int centerX = ClientSize.Width / 2;
            int degree = -10;
            if (radioButton2.Checked == true)
            {
                degree *= -1;
            }
            while (true)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = RotatePoint(amountOfAngles, points[i], new Point(centerX, centerY), degree);
                }
                Thread.Sleep(50);
                g2.Clear(Color.White);
                g2.DrawLines(new Pen(Color.Black, 1), points);
                g2.DrawEllipse(new Pen(Color.Black, 1), centerX - 100, centerY - 100, 200, 200);
            }
        }
        static Point RotatePoint(int amount, Point pointToRotate, Point centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point
            {
                X =

                    (int)
                    (cosTheta * (pointToRotate.X - centerPoint.X) -
                    sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y =
                (int)
                (sinTheta * (pointToRotate.X - centerPoint.X) +
                cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }
    }
}