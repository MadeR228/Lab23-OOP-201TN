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
            // ���������� ������ �������
            float minX = -10; // ̳������� �������� x
            float maxX = 10;  // ����������� �������� x
            float minY = -10; // ̳������� �������� y
            float maxY = 10;  // ����������� �������� y

            // ������������� ������� �� ������ PictureBox
            float scaleX = pictureBox1.Width / (maxX - minX);
            float scaleY = pictureBox1.Height / (maxY - minY);

            // �������� ������� ���������
            g.Clear(Color.White);

            // ��������� ������� ���������
            DrawAxes(g, minX, maxX, minY, maxY, scaleX, scaleY);

            // ��������� ������� �������
            DrawFunction(g, minX, maxX, scaleX, scaleY);
        }

        private void RefreshGraph()
        {
            pictureBox1.Refresh();
        }

        private void DrawAxes(Graphics g, float minX, float maxX, float minY, float maxY, float scaleX, float scaleY)
        {
            // ��� X
            g.DrawLine(Pens.Black, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);

            // ��� Y
            g.DrawLine(Pens.Black, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
        }

        private void DrawFunction(Graphics g, float minX, float maxX, float scaleX, float scaleY)
        {
            if (!float.TryParse(textBox1.Text, out float p)) // �������� �������� p � ����������
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
