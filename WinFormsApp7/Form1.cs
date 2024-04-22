using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp7;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph(e.Graphics);
        }

        private void DrawGraph(Graphics g)
        {
            // Визначення області графіку
            float minX = -10; // Мінімальне значення x
            float maxX = 10;  // Максимальне значення x
            float minY = -10; // Мінімальне значення y
            float maxY = 10;  // Максимальне значення y

            // Масштабування графіку до розмірів PictureBox
            float scaleX = pictureBox1.Width / (maxX - minX);
            float scaleY = pictureBox1.Height / (maxY - minY);

            // Очищення поверхні малювання
            g.Clear(Color.White);

            // Малювання системи координат
            DrawAxes(g, minX, maxX, minY, maxY, scaleX, scaleY);

            // Малювання графіку функції
            DrawFunction(g, minX, maxX, scaleX, scaleY);
        }

        private void RefreshGraph()
        {
            pictureBox1.Refresh();
        }

        private void DrawAxes(Graphics g, float minX, float maxX, float minY, float maxY, float scaleX, float scaleY)
        {
            // Ось X
            g.DrawLine(Pens.Black, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);

            // Ось Y
            g.DrawLine(Pens.Black, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
        }

        private void DrawFunction(Graphics g, float minX, float maxX, float scaleX, float scaleY)
        {
            if (!float.TryParse(textBox1.Text, out float p)) // Отримати значення p з текстбоксу
            {
                return;
            }

            for (float t = minX; t <= maxX; t += 0.1f)
            {
                float x = t * scaleX + pictureBox1.Width / 2;
                float y = (float)Math.Sqrt(2 * p * t) * scaleY + pictureBox1.Height / 2;
                g.FillEllipse(Brushes.Red, x, y, 2, 2);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshGraph();
        }
    }
}
