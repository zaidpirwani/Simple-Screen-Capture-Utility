using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cs_test
{
    public partial class Form1 : Form
    {
        Point p1 = new Point();
        Point p2 = new Point();
        Boolean capture_mode = new Boolean();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (capture_mode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p1 = p2;
                    p2 = MousePosition;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    // Ideal POINTS X1<X2 and Y1<Y2
                    // testing for points and correcting
                    if (p1.Equals(p2)) p1 = Point.Empty;
                    if (p1.X == p2.X) p1.X--;
                    if (p1.Y == p2.Y) p1.Y--;
                    if (p1.X > p2.X)
                    {

                        int temp = 0;
                        temp = p1.X;
                        p1.X = p2.X;
                        p2.X = temp;
                    }
                    if (p1.Y > p2.Y)
                    {
                        int temp = 0;
                        temp = p1.Y;
                        p1.Y = p2.Y;
                        p2.Y = temp;
                    }

                    this.Visible = false;

                    Point capt_size = new Point();
                    capt_size.X = Math.Abs(p2.X - p1.X);
                    capt_size.Y = Math.Abs(p2.Y - p1.Y);
                    
                    Bitmap capture = new Bitmap(capt_size.X, capt_size.Y);
                    Graphics scr = Graphics.FromImage(capture);
                    using (Graphics gr = Graphics.FromImage(capture))
                    { gr.CopyFromScreen(new Point(p1.X, p1.Y), Point.Empty, new System.Drawing.Size(capt_size.X, capt_size.Y)); }

                    Form_2 frm_prev = new Form_2();
                    frm_prev.prev_image = capture;
                    frm_prev.Width = capt_size.X;
                    frm_prev.Height = capt_size.Y;
                    frm_prev.ShowDialog();

                    Clipboard.SetImage(capture);

                    this.Opacity = 1.0D;
                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                    
                    /*
                    pictureBox2.Image = capture;
                    pictureBox2.Top = 0;
                    pictureBox2.Left = 0;
                    if (capt_size.X > 100) pictureBox2.Width = capt_size.X;
                    else pictureBox2.Width = 100;
                    if (capt_size.Y > 100) pictureBox2.Height = capt_size.Y;
                    else pictureBox2.Height = 100;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Visible = true;
                    */

                    button1.Visible = true;
                    button3.Visible = true;

                    p1 = Point.Empty;
                    p2 = p1;
                    capture_mode = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 0.25D;
            button1.Visible = false;
            button3.Visible = false;
            capture_mode = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, not yet implemented\nThe image will be put on CLIPBOARD though to paste in WORD/Paint/etc");
        }
    }
}
