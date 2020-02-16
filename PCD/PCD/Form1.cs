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

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox2.Image);
            Bitmap bmp2 = new Bitmap(pictureBox2.Image);
            Color pe;
            Color t1, t2, t3, t4, t5, t6, t7, t8;
            int p0, p1, p2, p3, p4, p5, p6, p7, p8;

            int maks =0;
            int min = 0;

            int g = 0;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (x == 0)
                    {
                        x = 1;
                    }
                    if (x == 255)
                    {
                        x = 254;
                    }
                    if (y == 0)
                    {
                        y = 1;
                    }
                    if (y == 255)
                    {
                        y = 254;
                    }
                        pe = bmp.GetPixel(x, y);
                        t1 = bmp.GetPixel(x + 1, y);
                        t2 = bmp.GetPixel(x +1, y - 1);
                        t3 = bmp.GetPixel(x, y - 1);
                        t4 = bmp.GetPixel(x - 1, y-1);
                        t5 = bmp.GetPixel(x - 1, y);
                        t6 = bmp.GetPixel(x-1 , y + 1);
                        t7 = bmp.GetPixel(x, y+1);
                        t8 = bmp.GetPixel(x + 1, y + 1);

                        p0 = pe.R;
                        p1 = t1.R;
                        p2 = t2.R;
                        p3 = t3.R;
                        p4 = t4.R;
                        p5 = t5.R;
                        p6 = t6.R;
                        p7 = t7.R;
                        p8 = t8.R;
                        int[] p = new int[] { p1, p2, p3 , p4 , p5 , p6 , p7, p8  };


                        maks = p.Max();
                        min = p.Min();

                        if (p0 < min)
                        {
                            g = min;
                        }
                        else
                        {
                            if (p0 > maks)
                            {
                                g = maks;
                            }
                            else
                            {
                                g = p0;
                            }
                        }
                        bmp2.SetPixel(x, y, Color.FromArgb(g,g,g));
                }
            }
            pictureBox3.Image = bmp2;
        }
    }
}
