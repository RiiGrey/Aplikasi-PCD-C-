using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PCD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = @"D:\";

            ofd.Title = "Pilih Gambar";

            ofd.Filter = "iamge files|*.png; *.jpg; *.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);

            int tinggi = bmp.Height;
            int lebar = bmp.Width;
            
            Console.WriteLine("Tinggi citra : " + tinggi);
            Console.WriteLine("lebar citra : " + lebar);
            Console.WriteLine();
            
            Color p;

            int r, g, b;

            for (int x = 0; x < tinggi; x++)
            {
                for (int j = 0; j < lebar; j++)
                {
                    p = bmp.GetPixel(x, j);

                    r = p.R;
                    g = p.G;
                    b = p.B;

                    Console.WriteLine("nilai Red untuk pixel(" + x + "," + j + ")" + " : " + r);
                    Console.WriteLine("nilai Green untuk pixel(" + x + "," + j + ")" + " : " + g);
                    Console.WriteLine("nilai Blue untuk pixel(" + x + "," + j + ")" + " : " + b);
                    Console.WriteLine();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color p;
            int r,g,b,i;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    p = bmp.GetPixel(x, y);

                    r = p.R;
                    g = p.G;
                    b = p.B;

                    i = Convert.ToInt32(0.2989 * r + 0.5870 * g + 0.1141 * b);

                    bmp.SetPixel(x, y, Color.FromArgb(i,i,i));
                }
            }

            pictureBox2.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox2.Image);
            Color p;
            int i;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    p = bmp.GetPixel(x, y);

                    i = p.G;

                    if (i > 100)
                    {
                        i = 255;
                    }
                    else
                    {
                        i = 0;
                    }

                    bmp.SetPixel(x, y, Color.FromArgb(i, i, i));
                }
            }
            pictureBox3.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = @"D:\";

            ofd.Title = "Pilih Gambar";

            ofd.Filter = "iamge files|*.png; *.jpg; *.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
              */
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color p;
            int i;
            int[] histogram = new int[256];

            Console.WriteLine("~~~~~~~START~~~~~~~");

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    p = bmp.GetPixel(x, y);
                    i=p.R;

                    for (int j = 0; j <= 255; j++)
                    {
                        if (i == j)
                        {
                            histogram[j] = histogram[j] + 1;
                        }
                    }
                }
            }
            int m = 0;
            for (int j = 0; j <= 255; j++)
            {
                Console.WriteLine("nilai histogram intensitas [" + j + "] :" + histogram[j]);
                
                if (histogram[j] > m)
                {
                    m = histogram[j];
                }
            }
            Console.WriteLine("~~~~~~~END~~~~~~");

            for (int j = 0; j <= 255; j++)
            {

                if (histogram[j] == m)
                {

                    Console.WriteLine("nilai tertinggi histogram adalah [" + j + "] :" + m);
                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox2.Image);
            Color p;
            int i;
            int b = 30;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    p = bmp.GetPixel(x, y);

                    i = p.G + b;

                    if (i > 255)
                    {
                        i = 255;
                    }

                    bmp.SetPixel(x, y, Color.FromArgb(i, i, i));
                }
            }
            pictureBox3.Image = bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color p;
            int r, g, b;
            int beta = 30;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    p = bmp.GetPixel(x, y);

                    r = p.R + beta;
                    g = p.G + beta;
                    b = p.B + beta;

                    if (r > 255)
                        r = 255;
                    if (g > 255)
                        g = 255;
                    if (b > 255)
                        b = 255;

                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            pictureBox2.Image = bmp;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox2.Image);
            Color p;
            int i;
            double a = 1.75;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    p = bmp.GetPixel(x, y);

                    i = p.G;

                    i = Convert.ToInt32(p.R * a);
                    if (i >= 255)
                        i = 255;

                    bmp.SetPixel(x, y, Color.FromArgb(i, i, i));
                }
            }
            pictureBox3.Image = bmp;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color p;
            int r, g, b;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    p = bmp.GetPixel(x, y);


                    r = Convert.ToInt32(1.75 * p.R);
                    g = Convert.ToInt32(1.75 * p.G);
                    b = Convert.ToInt32(1.75 * p.B);
                    if (r >= 255)
                        r = 255;
                    if (g >= 255)
                        g = 255;
                    if (b >= 255)
                        b = 255;

                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            pictureBox1.Image = bmp;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox2.Image);
            Color p;
            int i;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    p = bmp.GetPixel(x, y);

                    i = p.G;

                    i = 255 - i;
                    if (i >= 255)
                        i = 255;

                    bmp.SetPixel(x, y, Color.FromArgb(i, i, i));
                }
            }
            pictureBox3.Image = bmp;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox2.Image);
            Color p;
            int i;
            double a = 1.75;
            int b = 30;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    p = bmp.GetPixel(x, y);

                    i = p.G;

                    i = Convert.ToInt32((a * p.G) + b);
                    if (i >= 255)
                        i = 255;

                    bmp.SetPixel(x, y, Color.FromArgb(i, i, i));
                }
            }
            pictureBox3.Image = bmp;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color p;
            int r, g, b;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    p = bmp.GetPixel(x, y);


                    r = 255 - p.R;
                    g = 255 - p.G;
                    b = 255 - p.B;
                    if (r >= 255)
                        r = 255;
                    if (g >= 255)
                        g = 255;
                    if (b >= 255)
                        b = 255;

                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            pictureBox1.Image = bmp;
        }
    }
}
